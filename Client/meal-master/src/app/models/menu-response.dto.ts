// src/app/models/menu-response.dto.ts
import { MenuItemResponseDto } from './menu-item-response.dto';

export interface MenuResponseDto {
  userId: string;
  date: string; // ISO Date string
  totalCalories: number;
  mealCount: number;
  menuItems: MenuItemResponseDto[];
}