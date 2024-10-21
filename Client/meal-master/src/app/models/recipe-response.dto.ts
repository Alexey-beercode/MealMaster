// src/app/models/recipe-response.dto.ts
import { ProductResponseDto } from './product-response.dto';
import { CuisineTypeResponseDto } from './cuisine-type-response.dto';
import { DietaryRestrictionResponseDto } from './dietary-restriction-response.dto';

export interface RecipeResponseDto {
  id: string;
  userId: string;
  name: string;
  description: string;
  calories: number;
  preparationTime: number;
  cuisineType: CuisineTypeResponseDto;
  createdDate: string; // ISO Date string
  restriction: DietaryRestrictionResponseDto;
  products: ProductResponseDto[];
}
