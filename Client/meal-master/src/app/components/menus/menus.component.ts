// src/app/components/menus/menus.component.ts
import { Component, OnInit } from '@angular/core';
import { MenuService } from '../../services/menu.service';
import { MenuResponseDto } from '../../models/menu-response.dto';

@Component({
  selector: 'app-menus',
  templateUrl: './menus.component.html',
  standalone: true
})
export class MenusComponent implements OnInit {
  menus: MenuResponseDto[] = [];

  constructor(private menuService: MenuService) {}

  ngOnInit(): void {
    this.loadMenus();
  }

  loadMenus(): void {
    this.menuService.getAll().subscribe((data) => {
      this.menus = data;
    });
  }
}
