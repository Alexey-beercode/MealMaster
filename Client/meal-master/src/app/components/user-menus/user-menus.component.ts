import { Component, OnInit } from '@angular/core';
import { DatePipe, Location, CommonModule } from '@angular/common';
import { MenuService } from '../../services/menu.service';
import { MenuResponseDto } from '../../models/menu-response.dto';
import { TokenService } from "../../services/token.service";
import { Router } from "@angular/router";
import { FormsModule } from '@angular/forms';
import { AuthBaseComponent } from "../base/auth-base.component";
import { AuthService } from "../../services/auth.service";
import { takeUntil } from "rxjs/operators";
import { SetMenuToUserDto } from "../../models/set-menu-to-user.dto";

@Component({
  selector: 'app-user-menus',
  templateUrl: './user-menus.component.html',
  standalone: true,
  imports: [
    CommonModule,
    DatePipe,
    FormsModule
  ],
  styleUrls: ['./user-menus.component.css']
})
export class UserMenusComponent extends AuthBaseComponent implements OnInit {
  menus: MenuResponseDto[] = [];
  filteredMenus: MenuResponseDto[] = [];
  dateFilter: string = '';
  caloriesFilter: string = '';

  constructor(
    protected override authService: AuthService,
    protected override tokenService: TokenService,
    protected override router: Router,
    private menuService: MenuService,
    private location: Location
  ) {
    super(authService, tokenService, router);
  }

  ngOnInit(): void {
    this.tokenService.checkTokenStatus()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (isValid) => {
          if (isValid) {
            this.loadMenus();
          } else {
            this.router.navigate(['/login']);
          }
        },
        error: (error) => this.handleError(error)
      });
  }

  private loadMenus(): void {
    const userId = this.tokenService.getUserId();
    if (!userId) {
      this.router.navigate(['/login']);
      return;
    }

    this.loading = true;
    this.menuService.getByUserId(userId)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (response: MenuResponseDto[]) => {
          this.menus = response;
          this.applyFilters();
          this.loading = false;
        },
        error: (error) => this.handleError(error)
      });
  }

  applyFilters(): void {
    let filtered = [...this.menus];

    if (this.dateFilter) {
      filtered = filtered.filter(menu =>
        new Date(menu.date).toDateString() === new Date(this.dateFilter).toDateString()
      );
    }

    if (this.caloriesFilter) {
      filtered.sort((a, b) => {
        const diff = a.totalCalories - b.totalCalories;
        return this.caloriesFilter === 'asc' ? diff : -diff;
      });
    }

    this.filteredMenus = filtered;
  }

  regenerateMenu(menu: MenuResponseDto): void {
    const userId = this.tokenService.getUserId();
    if (!userId) {
      this.router.navigate(['/login']);
      return;
    }

    this.loading = true;

    const setMenuToUserDto: SetMenuToUserDto = {
      menuId: menu.id,
      userId: userId
    };

    this.menuService.addMenuToUser(setMenuToUserDto)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => {
          this.loading = false;
          this.loadMenus();
        },
        error: (error) => {
          this.handleError(error);
          this.loading = false;
        }
      });
  }

  goBack(): void {
    this.location.back();
  }
}
