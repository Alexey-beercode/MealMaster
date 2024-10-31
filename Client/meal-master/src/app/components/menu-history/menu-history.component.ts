import { Component, OnInit } from '@angular/core';
import { DatePipe, Location, CommonModule } from '@angular/common';
import { MenuHistoryService } from '../../services/menu-history.service';
import { MenuHistoryResponseDto } from '../../models/menu-history-response.dto';
import { TokenService } from "../../services/token.service";
import { Router } from "@angular/router";
import { FormsModule } from '@angular/forms';
import { AuthBaseComponent } from "../base/auth-base.component";
import { AuthService } from "../../services/auth.service";
import {takeUntil} from "rxjs/operators";
import {SetMenuToUserDto} from "../../models/set-menu-to-user.dto";
import {MenuService} from "../../services/menu.service";

@Component({
  selector: 'app-menu-history',
  templateUrl: 'menu-history.component.html',
  standalone: true,
  imports: [
    CommonModule,
    DatePipe,
    FormsModule
  ],
  styleUrls: ['./menu-history.component.css']
})
export class MenuHistoryComponent extends AuthBaseComponent implements OnInit {
  menuHistory: MenuHistoryResponseDto[] = [];
  filteredMenuHistory: MenuHistoryResponseDto[] = [];
  dateFilter: string = '';
  caloriesFilter: string = '';

  constructor(
    protected override authService: AuthService,
    protected override tokenService: TokenService,
    protected override router: Router,
    private menuHistoryService: MenuHistoryService,
    private location: Location,
    private menuService:MenuService
  ) {
    super(authService, tokenService, router);
  }

  ngOnInit(): void {
    this.tokenService.checkTokenStatus()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (isValid) => {
          if (isValid) {
            this.loadMenuHistory();
          } else {
            this.router.navigate(['/login']);
          }
        },
        error: (error) => this.handleError(error)
      });
  }

  private loadMenuHistory(): void {
    const userId = this.tokenService.getUserId();
    if (!userId) {
      this.router.navigate(['/login']);
      return;
    }

    this.loading = true;
    this.menuHistoryService.getByUserId(userId)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (response: any) => {
          this.menuHistory = Array.isArray(response) ? response : [response];
          this.applyFilters();
          this.loading = false;
        },
        error: (error) => this.handleError(error)
      });
  }

  applyFilters(): void {
    let filtered = [...this.menuHistory];

    if (this.dateFilter) {
      filtered = filtered.filter(item =>
        new Date(item.createdDate).toDateString() === new Date(this.dateFilter).toDateString()
      );
    }

    if (this.caloriesFilter) {
      filtered.sort((a, b) => {
        const diff = a.menu.totalCalories - b.menu.totalCalories;
        return this.caloriesFilter === 'asc' ? diff : -diff;
      });
    }

    this.filteredMenuHistory = filtered;
  }

  regenerateMenu(menuHistory: MenuHistoryResponseDto): void {
    const userId = this.tokenService.getUserId();
    if (!userId) {
      this.router.navigate(['/login']);
      return;
    }

    this.loading = true;

    const setMenuToUserDto: SetMenuToUserDto = {
      menuId: menuHistory.menu.id,
      userId: userId
    };

    this.menuService.addMenuToUser(setMenuToUserDto)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => {
          this.loading = false;
          this.loadMenuHistory();
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
