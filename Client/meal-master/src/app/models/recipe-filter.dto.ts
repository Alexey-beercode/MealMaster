export interface RecipeFilterDto {
  userId: string;
  searchTerm: string;
  minCalories?: number | null;
  maxCalories?: number | null;
  minPreparationTime?: number | null;
  maxPreparationTime?: number | null;
  cuisineTypeId?: string | null;
  restrictionId?: string | null;
}
