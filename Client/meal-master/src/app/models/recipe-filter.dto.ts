// src/app/models/recipe-filter.dto.ts
export interface RecipeFilterDto {
  userId: string;
  searchTerm: string;
  minCalories?: number;
  maxCalories?: number;
  minPreparationTime?: number;
  maxPreparationTime?: number;
  cuisineTypeId?: string;
  restrictionId?: string;
}
