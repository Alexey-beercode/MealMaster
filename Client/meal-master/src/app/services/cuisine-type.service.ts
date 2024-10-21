// src/app/services/cuisine-type.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CuisineTypeResponseDto } from '../models/cuisine-type-response.dto';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CuisineTypeService {
  private baseUrl = `${environment.apiUrl}/api/CuisineType`;

  constructor(private http: HttpClient) {}

  // Получение всех типов кухни
  getAll(): Observable<CuisineTypeResponseDto[]> {
    return this.http.get<CuisineTypeResponseDto[]>(this.baseUrl);
  }

  // Получение типа кухни по ID
  getById(id: string): Observable<CuisineTypeResponseDto> {
    return this.http.get<CuisineTypeResponseDto>(`${this.baseUrl}/${id}`);
  }

  // Получение типа кухни по названию
  getByName(name: string): Observable<CuisineTypeResponseDto> {
    return this.http.get<CuisineTypeResponseDto>(`${this.baseUrl}/name/${name}`);
  }
}
