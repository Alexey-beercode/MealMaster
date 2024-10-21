import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../../services/recipe.service';
import { RecipeResponseDto } from '../../models/recipe-response.dto';
import { RecipeFilterDto } from '../../models/recipe-filter.dto';
import { CuisineTypeService } from '../../services/cuisine-type.service';
import { DietaryRestrictionService } from '../../services/dietary-restriction.service';
import { CuisineTypeResponseDto } from '../../models/cuisine-type-response.dto';
import { DietaryRestrictionResponseDto } from '../../models/dietary-restriction-response.dto';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TokenService } from '../../services/token.service';
import { Router } from '@angular/router';
import {MenuService} from "../../services/menu.service";
import {CreateMenuDto} from "../../models/create-menu.dto";
import {MenuItemDto} from "../../models/menu-item.dto";

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class RecipesComponent implements OnInit {
  recipes: RecipeResponseDto[] = [];
  filter: RecipeFilterDto = {userId: '', searchTerm: '', cuisineTypeId: '', restrictionId: ''};
  cuisineTypes: CuisineTypeResponseDto[] = [];
  dietaryRestrictions: DietaryRestrictionResponseDto[] = [];
  selectedRecipes: string[] = [];
  showPortionSizeModal: boolean = false;
  menuItems: MenuItemDto[] = [];

  constructor(
    private recipeService: RecipeService,
    private cuisineTypeService: CuisineTypeService,
    private dietaryRestrictionService: DietaryRestrictionService,
    private tokenService: TokenService,
    private menuService:MenuService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadRecipes();
    this.loadCuisineTypes();
    this.loadDietaryRestrictions();

    const userId = this.tokenService.getUserId();
    if (userId) {
      this.filter.userId = userId;
    }
  }

  loadFilterRecipes(): void {
    if (this.filter.cuisineTypeId === '') {
      this.filter.cuisineTypeId = undefined;
    }
    if (this.filter.restrictionId === '') {
      this.filter.restrictionId = undefined;
    }
    this.recipeService.getByFilter(this.filter).subscribe((data) => {
      this.recipes = data;
    });
  }

  loadRecipes(): void {
    this.recipeService.getAll().subscribe((data) => {
      this.recipes = data;
    });
  }

  loadCuisineTypes(): void {
    this.cuisineTypeService.getAll().subscribe(data => {
      this.cuisineTypes = data;
    });
  }

  loadDietaryRestrictions(): void {
    this.dietaryRestrictionService.getAll().subscribe(data => {
      this.dietaryRestrictions = data;
    });
  }

  applyFilter() {
    this.loadFilterRecipes();
  }

  toggleRecipeSelection(recipeId: string) {
    const index = this.selectedRecipes.indexOf(recipeId);
    if (index > -1) {
      this.selectedRecipes.splice(index, 1);
    } else {
      this.selectedRecipes.push(recipeId);
    }
  }

  createMenu() {
    if (this.selectedRecipes.length === 0) {
      console.error('Выберите хотя бы один рецепт для создания меню');
      return;
    }

    this.menuItems = this.selectedRecipes.map(recipeId => ({
      recipeId: recipeId,
      portionSize: 0
    }));

    this.showPortionSizeModal = true;
  }

  submitMenu() {
    const userId = this.tokenService.getUserId();
    if (!userId) {
      console.error('Пользователь не авторизован');
      return;
    }

    const totalCalories = this.calculateTotalCalories();

    const createMenuDto: CreateMenuDto = {
      menuItems: this.menuItems,
      userId: userId,
      totalCalories: totalCalories
    };

    this.menuService.createMenu(createMenuDto).subscribe(
      () => {
        console.log('Меню успешно создано');
        this.selectedRecipes = [];
        this.showPortionSizeModal = false;
      },
      error => {
        console.error('Ошибка при создании меню', error);
        if (error.status === 401) {
          console.error('Ошибка аутентификации. Пожалуйста, войдите в систему снова.');
          this.router.navigate(['/login']);
        }
      }
    );
  }

  private calculateTotalCalories(): number {
    return this.menuItems.reduce((total, item) => {
      const recipe = this.recipes.find(r => r.id === item.recipeId);
      return total + (recipe ? recipe.calories * (item.portionSize / 100) : 0);
    }, 0);
  }

  closeModal() {
    this.showPortionSizeModal = false;
  }

  goToProfile() {
    this.router.navigate(['/profile']);
  }

  getRecipeName(recipeId: string): string {
    const recipe = this.recipes.find(r => r.id === recipeId);
    return recipe ? recipe.name : '';
  }
}
