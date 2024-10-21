// src/app/components/menu-history/menu-history.component.ts
import { Component, OnInit } from '@angular/core';
import { MenuHistoryService } from '../../services/menu-history.service';
import { MenuHistoryResponseDto } from '../../models/menu-history-response.dto';

@Component({
  selector: 'app-menu-history',
  templateUrl: './menu-history.component.html',
  standalone: true
})
export class MenuHistoryComponent implements OnInit {
  menuHistory: MenuHistoryResponseDto | null = null;

  constructor(private menuHistoryService: MenuHistoryService) {}

  ngOnInit(): void {
    this.loadMenuHistory('some-user-id'); // Замените 'some-user-id' на реальный ID пользователя
  }

  loadMenuHistory(userId: string): void {
    this.menuHistoryService.getByUserId(userId).subscribe((data) => {
      this.menuHistory = data;
    });
  }
}
