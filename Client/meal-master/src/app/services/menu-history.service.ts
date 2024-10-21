// src/app/services/menu-history.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { MenuHistoryResponseDto } from '../models/menu-history-response.dto';

@Injectable({
  providedIn: 'root',
})
export class MenuHistoryService {
  private baseUrl = `${environment.apiUrl}/api/MenuHistory`;

  constructor(private http: HttpClient) {}

  // Получение истории меню по ID пользователя
  getByUserId(userId: string): Observable<MenuHistoryResponseDto> {
    return this.http.get<MenuHistoryResponseDto>(`${this.baseUrl}/user/${userId}`);
  }
}
