// src/app/models/create-menu.dto.ts
import { MenuItemDto } from './menu-item.dto';

export interface CreateMenuDto {
  menuItems: MenuItemDto[];
  userId: string;
  totalCalories: number;
}
