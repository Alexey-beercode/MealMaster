// src/app/models/update-recipe.dto.ts
export interface UpdateRecipeDto {
  id: string;
  name: string;
  description: string;
  calories: number;
  preparationTime: number;
  cuisineTypeId: string;
  restrictionId: string;
}
