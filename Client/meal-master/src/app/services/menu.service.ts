// src/app/services/menu.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { MenuResponseDto } from '../models/menu-response.dto';
import { CreateMenuDto } from '../models/create-menu.dto';
import { GenerateMenuDto } from '../models/generate-menu.dto';
import { SetMenuToUserDto } from '../models/set-menu-to-user.dto';
import { DeleteMenuDto } from '../models/delete-menu.dto';

@Injectable({
  providedIn: 'root',
})
export class MenuService {
  private baseUrl = `${environment.apiUrl}/api/Menu`;

  constructor(private http: HttpClient) {}

  // Получение всех меню
  getAll(): Observable<MenuResponseDto[]> {
    return this.http.get<MenuResponseDto[]>(this.baseUrl);
  }

  // Получение меню по ID пользователя
  getByUserId(userId: string): Observable<MenuResponseDto[]> {
    return this.http.get<MenuResponseDto[]>(`${this.baseUrl}/user/${userId}`);
  }

  // Генерация меню
  generateMenu(generateMenuDto: GenerateMenuDto): Observable<MenuResponseDto> {
    return this.http.post<MenuResponseDto>(`${this.baseUrl}/generate`, generateMenuDto);
  }

  // Добавление меню пользователю
  addMenuToUser(setMenuToUserDto: SetMenuToUserDto): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/addtouser`, setMenuToUserDto);
  }

  // Создание меню
  createMenu(createMenuDto: CreateMenuDto): Observable<void> {
    return this.http.post<void>(this.baseUrl, createMenuDto);
  }

  // Удаление меню
  deleteMenu(deleteMenuDto: DeleteMenuDto): Observable<void> {
    return this.http.request<void>('delete', this.baseUrl, { body: deleteMenuDto });
  }
}
