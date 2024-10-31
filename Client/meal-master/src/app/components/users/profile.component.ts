import { Component, OnInit } from "@angular/core";
import { UserService } from '../../services/user.service';
import { AuthService } from '../../services/auth.service';
import { UserResponseDto } from '../../models/user-response.dto';
import { TokenService } from "../../services/token.service";
import { NgIf, NgFor, Location } from "@angular/common";
import { Router } from "@angular/router";
import { AuthBaseComponent } from "../base/auth-base.component";
import {GenerateMenuDto} from "../../models/generate-menu.dto";
import {FormsModule} from "@angular/forms";
import {MenuDataService} from "../../services/menu-data.service";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  imports: [NgIf, NgFor, FormsModule],
  standalone: true
})
export class ProfileComponent extends AuthBaseComponent implements OnInit {
  user: UserResponseDto | null = null;
  showGenerateMenuModal: boolean = false;  // Для отображения модального окна
  generateMenuData: GenerateMenuDto = { userId: '', recipeCount: 0, calories: 0 };

  constructor(
    protected override authService: AuthService,
    protected override tokenService: TokenService,
    protected override router: Router,
    private userService: UserService,
    private location: Location,
    private menuDataService: MenuDataService
  ) {
    super(authService, tokenService, router);
  }

  ngOnInit(): void {
    this.tokenService.checkTokenStatus().subscribe({
      next: (isValid) => {
        if (isValid) {
          const userId = this.tokenService.getUserId();
          if (userId) {
            this.loadUser(userId);
          } else {
            this.router.navigate(['/login']);
          }
        } else {
          this.router.navigate(['/login']);
        }
      },
      error: () => this.router.navigate(['/login'])
    });
  }

  loadUser(id: string): void {
    this.loading = true;
    this.userService.getById(id).subscribe({
      next: (user: UserResponseDto) => {
        this.user = user;
        this.generateMenuData.userId = id;
        this.loading = false;
      },
      error: (error) => {
        this.handleError(error);
      }
    });
  }

  goBack(): void {
    this.location.back();
  }

  logout(): void {
    this.loading = true;
    this.authService.logout().subscribe({
      next: () => {
        this.loading = false;
        this.tokenService.clearTokens();
        this.router.navigate(['/login']);
      },
      error: (error) => {
        console.error('Logout error:', error);
        this.loading = false;
        // Даже при ошибке выхода, очищаем токены и перенаправляем
        this.tokenService.clearTokens();
        this.router.navigate(['/login']);
      }
    });
  }

  viewMyMenus():void{
    this.router.navigate(['user-menus']);
  }
  viewMenuHistory(): void {
    this.router.navigate(['menu-history']);
  }

  viewMyRecipes(): void {
    this.router.navigate(['user-recipes']);
  }

  editProfile(): void {
    this.router.navigate(['edit-profile'])
  }

  openGenerateMenuModal(): void {
    this.showGenerateMenuModal = true;
  }

  // Закрытие модального окна
  closeGenerateMenuModal(): void {
    this.showGenerateMenuModal = false;
  }

  // Обработка генерации меню
  generateMenu(): void {
    console.log('Данные для передачи:', this.generateMenuData);  // Логирование данных перед передачей
    this.menuDataService.setGenerateMenuData(this.generateMenuData);  // Передаем данные в сервис
    this.showGenerateMenuModal = false;
    this.router.navigate(['menu-generator']);
  }
}
