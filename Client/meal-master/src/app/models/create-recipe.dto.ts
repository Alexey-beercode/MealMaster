// src/app/models/create-recipe.dto.ts
export interface CreateRecipeDto {
  userId: string;
  name: string;
  description: string;
  calories: number;
  preparationTime: number;
  cuisineTypeId: string;
  restrictionId: string;
  productIds: string[];
}
