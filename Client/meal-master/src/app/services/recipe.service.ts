// src/app/services/recipe.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { RecipeResponseDto } from '../models/recipe-response.dto';
import { CreateRecipeDto } from '../models/create-recipe.dto';
import { UpdateRecipeDto } from '../models/update-recipe.dto';
import { DeleteRecipeDto } from '../models/delete-recipe.dto';
import { RecipeFilterDto } from '../models/recipe-filter.dto';
import { ProductToRecipeOperationDto } from '../models/product-to-recipe-operation.dto';

@Injectable({
  providedIn: 'root',
})
export class RecipeService {
  private baseUrl = `${environment.apiUrl}/api/Recipe`;

  constructor(private http: HttpClient) {}

  // Получение всех рецептов
  getAll(): Observable<RecipeResponseDto[]> {
    return this.http.get<RecipeResponseDto[]>(this.baseUrl);
  }

  // Получение рецепта по ID
  getById(id: string): Observable<RecipeResponseDto> {
    return this.http.get<RecipeResponseDto>(`${this.baseUrl}/${id}`);
  }

  // Фильтрация рецептов
  getByFilter(filter: RecipeFilterDto): Observable<RecipeResponseDto[]> {
    return this.http.post<RecipeResponseDto[]>(`${this.baseUrl}/filter`, filter);
  }

  // Создание рецепта
  createRecipe(createRecipeDto: CreateRecipeDto): Observable<void> {
    return this.http.post<void>(this.baseUrl, createRecipeDto);
  }

  // Обновление рецепта
  updateRecipe(updateRecipeDto: UpdateRecipeDto): Observable<void> {
    return this.http.put<void>(this.baseUrl, updateRecipeDto);
  }

  // Удаление рецепта
  deleteRecipe(deleteRecipeDto: DeleteRecipeDto): Observable<void> {
    return this.http.request<void>('delete', this.baseUrl, { body: deleteRecipeDto });
  }

  // Операции с продуктами в рецепте (добавление/удаление)
  productToRecipeOperation(dto: ProductToRecipeOperationDto): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/product-operation`, dto);
  }
}
