import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MenuService } from '../../services/menu.service';
import { TokenService } from '../../services/token.service';
import { MenuResponseDto } from '../../models/menu-response.dto';
import { GenerateMenuDto } from '../../models/generate-menu.dto';
import { RecipeResponseDto } from '../../models/recipe-response.dto';
import { DatePipe, CommonModule } from "@angular/common";
import { Location } from "@angular/common";
import { MenuDataService } from "../../services/menu-data.service";
import { CreateMenuDto} from '../../models/create-menu.dto';
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-menu-generator',
  templateUrl: './menu-generator.component.html',
  styleUrls: ['./menu-generator.component.css'],
  imports: [
    DatePipe,
    CommonModule,
    FormsModule
  ],
  standalone: true
})
export class MenuGeneratorComponent implements OnInit {
  menu: MenuResponseDto | null = null;
  generateMenuData: GenerateMenuDto | null = null;
  loading: boolean = false;
  selectedRecipe: RecipeResponseDto | null = null;
  showRecipeModal: boolean = false;

  constructor(
    private menuService: MenuService,
    private tokenService: TokenService,
    private router: Router,
    private location: Location,
    private menuDataService: MenuDataService,
  ) {}

  ngOnInit(): void {
    this.generateMenuData = this.menuDataService.getGenerateMenuData();
    console.log('Полученные данные для генерации меню из сервиса:', this.generateMenuData);

    if (this.generateMenuData) {
      this.generateMenu();
    } else {
      console.log('Данные для генерации меню отсутствуют');
    }
  }

  generateMenu(): void {
    if (!this.generateMenuData) return;

    console.log('Отправляемые данные:', this.generateMenuData);

    this.loading = true;
    this.menuService.generateMenu(this.generateMenuData).subscribe({
      next: (menu) => {
        this.menu = menu;
        this.loading = false;
      },
      error: (err) => {
        console.error('Ошибка генерации меню:', err);
        this.loading = false;
      }
    });
  }

  // Метод для отправки данных меню на сервер
  useMenu(): void {
    if (!this.menu) {
      console.error('Меню не сгенерировано');
      return;
    }

    // Получаем ID пользователя
    const userId = this.tokenService.getUserId();
    if (!userId) {
      console.error('Пользователь не авторизован');
      this.router.navigate(['/login']);
      return;
    }

    // Формируем данные для создания меню
    const createMenuDto: CreateMenuDto = {
      userId: userId,
      menuItems: this.menu.menuItems.map(item => ({
        recipeId: item.recipeResponseDto.id,
        portionSize: item.portionSize || 100 // По умолчанию 100 грамм, если не указано
      })),
      totalCalories: Math.round(this.calculateTotalCalories()) // Округляем до целого числа
    };

    console.log('Отправляемый объект CreateMenuDto:', createMenuDto);
    // Отправляем данные на сервер
    this.loading = true;
    this.menuService.createMenu(createMenuDto).subscribe({
      next: () => {
        this.loading = false;
        console.log('Меню успешно сохранено');
        this.router.navigate(['/user-menus']);
      },
      error: (error) => {
        this.loading = false;
        console.error('Ошибка при сохранении меню:', error);
      }
    });
  }

  // Метод для вычисления общего числа калорий
// Метод для вычисления общего числа калорий
  calculateTotalCalories(): number {
    return this.menu?.menuItems.reduce((total, item) => {
      const caloriesPerServing = item?.recipeResponseDto?.calories || 0;
      const portionSize = item?.portionSize || 100; // По умолчанию 100 г
      return total + (caloriesPerServing * portionSize / 100);
    }, 0) || 0; // Возвращаем 0, если результат undefined или null
  }

  openRecipe(recipe: RecipeResponseDto | undefined): void {
    this.selectedRecipe = recipe ?? null;
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

  goBack(): void {
    this.location.back();
  }
}
