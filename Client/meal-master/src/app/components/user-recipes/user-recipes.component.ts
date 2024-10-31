import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RecipeService } from '../../services/recipe.service';
import { ProductService } from '../../services/product.service';
import { CuisineTypeService } from '../../services/cuisine-type.service';
import { DietaryRestrictionService } from '../../services/dietary-restriction.service';
import { TokenService } from '../../services/token.service';
import { RecipeResponseDto } from '../../models/recipe-response.dto';
import { ProductResponseDto } from '../../models/product-response.dto';
import { CuisineTypeResponseDto } from '../../models/cuisine-type-response.dto';
import { DietaryRestrictionResponseDto } from '../../models/dietary-restriction-response.dto';
import { AuthBaseComponent } from '../base/auth-base.component';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { takeUntil } from 'rxjs/operators';
import { Location } from '@angular/common';

@Component({
  selector: 'app-user-recipes',
  templateUrl: './user-recipes.component.html',
  styleUrls: ['./user-recipes.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class UserRecipesComponent extends AuthBaseComponent implements OnInit {
  recipes: RecipeResponseDto[] = [];
  products: ProductResponseDto[] = [];
  cuisineTypes: CuisineTypeResponseDto[] = [];
  restrictions: DietaryRestrictionResponseDto[] = [];
  showCreateModal = false;
  showEditModal = false;
  selectedRecipe: RecipeResponseDto | null = null;
  originalProducts: ProductResponseDto[] = []; // Для отслеживания изменений продуктов

  newRecipe = {
    name: '',
    description: '',
    calories: 0,
    preparationTime: 0,
    cuisineTypeId: '',
    restrictionId: '',
    productIds: [] as string[]
  };

  constructor(
    protected override authService: AuthService,
    protected override tokenService: TokenService,
    protected override router: Router,
    private recipeService: RecipeService,
    private productService: ProductService,
    private cuisineTypeService: CuisineTypeService,
    private restrictionService: DietaryRestrictionService,
    public location: Location
  ) {
    super(authService, tokenService, router);
  }

  ngOnInit(): void {
    this.loadInitialData();
  }

  private loadInitialData(): void {
    const userId = this.tokenService.getUserId();
    if (!userId) {
      this.router.navigate(['/login']);
      return;
    }

    this.loading = true;

    this.recipeService.getByUserPreferences(userId)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (recipes) => {
          this.recipes = recipes;
          this.loading = false;
        },
        error: (error) => this.handleError(error)
      });

    this.loadProducts();
    this.loadCuisineTypes();
    this.loadRestrictions();
  }

  private loadProducts(): void {
    this.productService.getAll()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (products) => this.products = products,
        error: (error) => this.handleError(error)
      });
  }

  private loadCuisineTypes(): void {
    this.cuisineTypeService.getAll()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (types) => this.cuisineTypes = types,
        error: (error) => this.handleError(error)
      });
  }

  private loadRestrictions(): void {
    this.restrictionService.getAll()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (restrictions) => this.restrictions = restrictions,
        error: (error) => this.handleError(error)
      });
  }

  isProductSelected(productId: string): boolean {
    return !!this.selectedRecipe && this.selectedRecipe.products.some(p => p.id === productId);
  }

  // Этот метод будет отправлять запрос на добавление/удаление продукта из рецепта
  private handleProductOperation(productId: string, isAdding: boolean): void {
    const userId = this.tokenService.getUserId();
    if (!userId || !this.selectedRecipe) return;

    const productToRecipeOperationDto = {
      userId,
      recipeId: this.selectedRecipe.id,
      productId,
      isAdding
    };

    this.recipeService.productToRecipeOperation(productToRecipeOperationDto)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => {
          this.loadInitialData(); // Обновляем данные после изменения
        },
        error: (error) => this.handleError(error)
      });
  }

  toggleProductInRecipe(productId: string): void {
    if (!this.selectedRecipe) return;

    const existingProduct = this.selectedRecipe.products.find(p => p.id === productId);
    if (existingProduct) {
      // Удаление продукта
      this.selectedRecipe.products = this.selectedRecipe.products.filter(p => p.id !== productId);
      this.handleProductOperation(productId, false);
    } else {
      // Добавление продукта
      const product = this.products.find(p => p.id === productId);
      if (product) {
        this.selectedRecipe.products.push(product);
        this.handleProductOperation(productId, true);
      }
    }
  }

  // Метод для обновления рецепта (без изменения продуктов)
  updateRecipe(): void {
    if (!this.selectedRecipe) return;

    const updateDto = {
      id: this.selectedRecipe.id,
      name: this.selectedRecipe.name,
      description: this.selectedRecipe.description,
      calories: this.selectedRecipe.calories,
      preparationTime: this.selectedRecipe.preparationTime,
      cuisineTypeId: this.selectedRecipe.cuisineType.id,
      restrictionId: this.selectedRecipe.restriction.id
    };

    this.recipeService.updateRecipe(updateDto)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => {
          this.loadInitialData();
          this.showEditModal = false;
          this.selectedRecipe = null;
        },
        error: (error) => this.handleError(error)
      });
  }

  // Метод для создания рецепта
  createRecipe(): void {
    const userId = this.tokenService.getUserId();
    if (!userId) return;

    const createDto = {
      ...this.newRecipe,
      userId
    };

    this.recipeService.createRecipe(createDto)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => {
          this.loadInitialData();
          this.showCreateModal = false;
          this.resetNewRecipe();
        },
        error: (error) => this.handleError(error)
      });
  }

  deleteRecipe(recipe: RecipeResponseDto): void {
    const userId = this.tokenService.getUserId();
    if (!userId) return;

    const deleteDto = {
      userId,
      recipeId: recipe.id
    };

    this.recipeService.deleteRecipe(deleteDto)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => this.loadInitialData(),
        error: (error) => this.handleError(error)
      });
  }

  toggleProduct(productId: string): void {
    const index = this.newRecipe.productIds.indexOf(productId);
    if (index === -1) {
      this.newRecipe.productIds.push(productId);
    } else {
      this.newRecipe.productIds.splice(index, 1);
    }
  }

  private resetNewRecipe(): void {
    this.newRecipe = {
      name: '',
      description: '',
      calories: 0,
      preparationTime: 0,
      cuisineTypeId: '',
      restrictionId: '',
      productIds: []
    };
  }

  goBack(): void {
    this.location.back();
  }
}
