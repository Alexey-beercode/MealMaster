import {AuthBaseComponent} from "../base/auth-base.component";
import {Component, OnInit} from "@angular/core";
import {RecipeResponseDto} from "../../models/recipe-response.dto";
import {RecipeFilterDto} from "../../models/recipe-filter.dto";
import {CommonModule} from "@angular/common";
import {FormsModule} from "@angular/forms";
import {DietaryRestrictionResponseDto} from "../../models/dietary-restriction-response.dto";
import {CuisineTypeResponseDto} from "../../models/cuisine-type-response.dto";
import {MenuItemDto} from "../../models/menu-item.dto";
import {AuthService} from "../../services/auth.service";
import {TokenService} from "../../services/token.service";
import {Router} from "@angular/router";
import {RecipeService} from "../../services/recipe.service";
import {CuisineTypeService} from "../../services/cuisine-type.service";
import {DietaryRestrictionService} from "../../services/dietary-restriction.service";
import {MenuService} from "../../services/menu.service";
import {firstValueFrom} from "rxjs";
import {CreateMenuDto} from "../../models/create-menu.dto";

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class RecipesComponent extends AuthBaseComponent implements OnInit {
  recipes: RecipeResponseDto[] = [];
  filter: RecipeFilterDto = {
    userId: '',
    searchTerm: '',
    cuisineTypeId: '',
    restrictionId: ''
  };
  cuisineTypes: CuisineTypeResponseDto[] = [];
  dietaryRestrictions: DietaryRestrictionResponseDto[] = [];
  selectedRecipes: string[] = [];
  showPortionSizeModal = false;
  showRecipeModal = false;
  selectedRecipe: RecipeResponseDto | null = null;
  menuItems: MenuItemDto[] = [];

  protected override error: string = '';
  protected override loading: boolean = false;
  constructor(
    protected override authService: AuthService,
    protected override tokenService: TokenService,
    protected override router: Router,
    private recipeService: RecipeService,
    private cuisineTypeService: CuisineTypeService,
    private dietaryRestrictionService: DietaryRestrictionService,
    private menuService: MenuService,
  ) {
    super(authService, tokenService, router);
  }

  ngOnInit(): void {
    this.tokenService.checkTokenStatus().subscribe({
      next: (isValid) => {
        if (isValid) {
          this.loadInitialData();
        } else {
          this.router.navigate(['/login']);
        }
      },
      error: () => this.router.navigate(['/login'])
    });
  }

  private loadInitialData(): void {
    const userId = this.tokenService.getUserId();
    if (!userId) {
      this.router.navigate(['/login']);
      return;
    }

    this.filter.userId = userId;
    this.loading = true;

    Promise.all([
      this.loadRecipes(),
      this.loadCuisineTypes(),
      this.loadDietaryRestrictions()
    ]).finally(() => this.loading = false);
  }

  private async loadRecipes(): Promise<void> {
    try {
      const userId = this.tokenService.getUserId();
      if (!userId) throw new Error('User ID not found');

      this.recipes = await firstValueFrom(this.recipeService.getByUserPreferences(userId));
    } catch (error) {
      this.handleError(error);
    }
  }

  private async loadCuisineTypes(): Promise<void> {
    try {
      this.cuisineTypes = await firstValueFrom(this.cuisineTypeService.getAll());
    } catch (error) {
      this.handleError(error);
    }
  }

  private async loadDietaryRestrictions(): Promise<void> {
    try {
      this.dietaryRestrictions = await firstValueFrom(this.dietaryRestrictionService.getAll());
    } catch (error) {
      this.handleError(error);
    }
  }

  applyFilter(): void {
    this.loading = true;
    this.error = '';

    const userId = this.tokenService.getUserId();
    if (!userId) {
      this.router.navigate(['/login']);
      return;
    }

    // Create a clean filter object with proper type conversions
    const filterData: RecipeFilterDto = {
      userId: userId,
      searchTerm: this.filter.searchTerm || '',
      minCalories: this.filter.minCalories ? Number(this.filter.minCalories) : undefined,
      maxCalories: this.filter.maxCalories ? Number(this.filter.maxCalories) : undefined,
      minPreparationTime: this.filter.minPreparationTime ? Number(this.filter.minPreparationTime) : undefined,
      maxPreparationTime: this.filter.maxPreparationTime ? Number(this.filter.maxPreparationTime) : undefined,
      cuisineTypeId: this.filter.cuisineTypeId || undefined,
      restrictionId: this.filter.restrictionId || undefined
    };

    // Add logging to debug the request
    console.log('Sending filter data:', filterData);

    this.recipeService.getByFilter(filterData).subscribe({
      next: (data) => {
        this.recipes = data;
        if (data.length === 0) {
          this.error = 'Рецепты не найдены';
        }
      },
      error: (error) => {
        console.error('Filter error details:', error);
        this.handleError(error);
      },
      complete: () => {
        this.loading = false;
      }
    });
  }

  protected override handleError(error: any): void {
    console.error('Error:', error);
    this.error = error.message || 'Произошла ошибка';
    this.loading = false;
  }

  createMenu(): void {
    if (this.selectedRecipes.length === 0) {
      this.error = 'Please select at least one recipe';
      return;
    }

    this.menuItems = this.selectedRecipes.map(recipeId => ({
      recipeId,
      portionSize: 0
    }));
    this.showPortionSizeModal = true;
  }

  submitMenu(): void {
    const userId = this.tokenService.getUserId();
    if (!userId) {
      this.router.navigate(['/login']);
      return;
    }

    const createMenuDto: CreateMenuDto = {
      menuItems: this.menuItems,
      userId: userId,
      totalCalories: this.calculateTotalCalories()
    };

    this.loading = true;
    this.menuService.createMenu(createMenuDto).subscribe({
      next: () => {
        this.selectedRecipes = [];
        this.showPortionSizeModal = false;
        this.loading = false;
      },
      error: (error) => this.handleError(error)
    });
  }

  private calculateTotalCalories(): number {
    return this.menuItems.reduce((total, item) => {
      const recipe = this.recipes.find(r => r.id === item.recipeId);
      return total + (recipe ? recipe.calories * (item.portionSize / 100) : 0);
    }, 0);
  }

  toggleRecipeSelection(recipeId: string): void {
    const index = this.selectedRecipes.indexOf(recipeId);
    if (index > -1) {
      this.selectedRecipes.splice(index, 1);
    } else {
      this.selectedRecipes.push(recipeId);
    }
  }

  closeModal(): void {
    this.showPortionSizeModal = false;
  }

  getRecipeName(recipeId: string): string {
    return this.recipes.find(r => r.id === recipeId)?.name || '';
  }

  goToProfile() {
    this.router.navigate(['/profile']);
  }
  openRecipe(recipe: RecipeResponseDto): void {
    this.selectedRecipe = recipe;
    this.showRecipeModal = true;
  }

  closeRecipeModal(): void {
    this.showRecipeModal = false;
    this.selectedRecipe = null;
  }

  onModalClick(event: MouseEvent): void {
    const target = event.target as HTMLElement;
    if (target.classList.contains('recipe-modal')) {
      this.closeRecipeModal();
    }
  }

  // Метод для форматирования списка ингредиентов
  formatProducts(products: any[]): string {
    return products.map(p => p.name).join(', ');
  }

  // Метод для получения подробной информации о рецепте
  getRecipeDetails(recipeId: string): void {
    this.loading = true;
    this.recipeService.getById(recipeId).subscribe({
      next: (recipe) => {
        this.selectedRecipe = recipe;
        this.showRecipeModal = true;
      },
      error: (error) => this.handleError(error),
      complete: () => {
        this.loading = false;
      }
    });
  }

  // Метод для форматирования списка ингредиентов
  formatIngredients(ingredients: any[]): string {
    return ingredients.map(ing => `${ing.name}: ${ing.amount} ${ing.unit}`).join(', ');
  }

}
