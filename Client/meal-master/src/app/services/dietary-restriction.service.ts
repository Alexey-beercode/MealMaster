// src/app/services/dietary-restriction.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DietaryRestrictionResponseDto } from '../models/dietary-restriction-response.dto';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class DietaryRestrictionService {
  private baseUrl = `${environment.apiUrl}/api/DietaryRestriction`;

  constructor(private http: HttpClient) {}

  // Получение всех диетических ограничений
  getAll(): Observable<DietaryRestrictionResponseDto[]> {
    return this.http.get<DietaryRestrictionResponseDto[]>(this.baseUrl);
  }

  // Получение диетического ограничения по ID
  getById(id: string): Observable<DietaryRestrictionResponseDto> {
    return this.http.get<DietaryRestrictionResponseDto>(`${this.baseUrl}/${id}`);
  }

  // Получение диетических ограничений по ID пользователя
  getByUserId(userId: string): Observable<DietaryRestrictionResponseDto[]> {
    return this.http.get<DietaryRestrictionResponseDto[]>(`${this.baseUrl}/user/${userId}`);
  }
}
