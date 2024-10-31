// src/app/services/user.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { UserResponseDto } from '../models/user-response.dto';
import {UpdateUserDto} from "../models/update-user.dto";

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private baseUrl = `${environment.apiUrl}/api/User`;

  constructor(private http: HttpClient) {}

  // Получение всех пользователей
  getAll(): Observable<UserResponseDto[]> {
    return this.http.get<UserResponseDto[]>(this.baseUrl);
  }

  // Получение пользователя по ID
  getById(id: string): Observable<UserResponseDto> {
    return this.http.get<UserResponseDto>(`${this.baseUrl}/${id}`);
  }

  // Получение пользователя по имени
  getByUserName(userName: string): Observable<UserResponseDto> {
    return this.http.get<UserResponseDto>(`${this.baseUrl}/username/${userName}`);
  }

  // Удаление пользователя
  deleteUser(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
  update(userId: string, updateUserDto: UpdateUserDto): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/update/${userId}`, updateUserDto);
  }
}
