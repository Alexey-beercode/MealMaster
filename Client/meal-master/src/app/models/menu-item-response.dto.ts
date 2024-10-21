// src/app/models/menu-item-response.dto.ts
import { RecipeResponseDto } from './recipe-response.dto';

export interface MenuItemResponseDto {
  portionSize: number;
  recipeResponseDto: RecipeResponseDto;
}
