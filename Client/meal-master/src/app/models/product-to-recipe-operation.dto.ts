// src/app/models/product-to-recipe-operation.dto.ts
export interface ProductToRecipeOperationDto {
  userId: string;
  recipeId: string;
  productId: string;
  isAdding: boolean;
}
