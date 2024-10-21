// src/app/services/product.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { ProductResponseDto } from '../models/product-response.dto';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private baseUrl = `${environment.apiUrl}/api/Product`;

  constructor(private http: HttpClient) {}

  // Получение всех продуктов
  getAll(): Observable<ProductResponseDto[]> {
    return this.http.get<ProductResponseDto[]>(this.baseUrl);
  }

  // Получение продукта по названию
  getByName(name: string): Observable<ProductResponseDto> {
    return this.http.get<ProductResponseDto>(`${this.baseUrl}/name/${name}`);
  }

  // Получение продукта по ID
  getById(id: string): Observable<ProductResponseDto> {
    return this.http.get<ProductResponseDto>(`${this.baseUrl}/id/${id}`);
  }
}
