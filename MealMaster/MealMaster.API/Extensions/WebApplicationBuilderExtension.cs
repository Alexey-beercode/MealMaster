using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using MealMaster.BLL.Facades;
using MealMaster.BLL.Infrastructure.Mapping;
using MealMaster.BLL.Infrastructure.Validators.Auth;
using MealMaster.BLL.Infrastructure.Validators.CuisineType;
using MealMaster.BLL.Infrastructure.Validators.DietaryRestriction;
using MealMaster.BLL.Infrastructure.Validators.Menu;
using MealMaster.BLL.Infrastructure.Validators.MenuItem;
using MealMaster.BLL.Infrastructure.Validators.Product;
using MealMaster.BLL.Infrastructure.Validators.Recipe;
using MealMaster.BLL.Interfaces.Facades;
using MealMaster.BLL.Interfaces.Services;
using MealMaster.BLL.Services;
using MealMaster.DAL.Infrastructure;
using MealMaster.DAL.Infrastructure.Database;
using MealMaster.DAL.Interfaces;
using MealMaster.DAL.Interfaces.Repositories;
using MealMaster.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace MealMaster.Extensions;

public static class WebApplicationBuilderExtension
{
    public static void AddSwaggerDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition(
                "Bearer",
                new OpenApiSecurityScheme
                {
                    Description = @"Enter JWT Token please.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                }
            );
            options.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                        },
                        new List<string>()
                    }
                }
            );
        });
    }

    public static void AddMapping(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(
            typeof(UserProfile).Assembly,
            typeof(AuthProfile).Assembly,
            typeof(CuisineTypeProfile).Assembly,
            typeof(DietaryRestrictionProfile).Assembly,
            typeof(MenuHistoryProfile).Assembly,
            typeof(MenuProfile).Assembly,
            typeof(RecipeProfile).Assembly
        );
    }

    public static void AddDatabase(this WebApplicationBuilder builder)
    {
        string? connectionString = builder.Configuration.GetConnectionString("ConnectionString");
        builder.Services.AddDbContext<ApplicationDbContext>(options => { options.UseNpgsql(connectionString); });
        builder.Services.AddScoped<ApplicationDbContext>();
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IRecipeFacade, RecipeFacade>();
        builder.Services.AddScoped<IMenuFacade, MenuFacade>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ICuisineTypeRepository, CuisineTypeRepository>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IDietaryRestrictionRepository, DietaryRestrictionRepository>();
        builder.Services.AddScoped<IMenuHistoryRepository, MenuHistoryRepository>();
        builder.Services.AddScoped<IMenuRepository, MenuRepository>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAuthService,AuthService>();
        builder.Services.AddScoped<ICuisineTypeService,CuisineTypeService>();
        builder.Services.AddScoped<IDietaryRestrictionService,DietaryRestrictionService>();
        builder.Services.AddScoped<IMenuHistoryService,MenuHistoryService>();
        builder.Services.AddScoped<IMenuService,MenuService>();
        builder.Services.AddScoped<IRecipeService,RecipeService>();
        builder.Services.AddControllers();
    }

    public static void AddValidation(this WebApplicationBuilder builder)
    {
        builder
            .Services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
        builder.Services.AddValidatorsFromAssemblyContaining<LoginDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<RegisterDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<UpdateUserDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<CreateCuisineTypeDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<CreateDietaryRestrictionDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<CreateMenuDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<DeleteMenuDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<GenerateMenuDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<SetMenuToUserDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<MenuItemDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<ProductDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<CreateRecipeDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<DeleteRecipeDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<ProductToRecipeOperationDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<RecipeFilterDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<UpdateRecipeDtoValidator>();
    }

    public static void AddIdentity(this WebApplicationBuilder builder)
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt");

        var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);
        var issuer = jwtSettings["Issuer"];
        var audience = jwtSettings["Audience"];

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                LogValidationExceptions = true
            };
        });

        builder.Services.AddAuthorization(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
        });
    }

}
