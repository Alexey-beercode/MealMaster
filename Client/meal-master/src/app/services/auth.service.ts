// src/app/services/auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthResponseDto } from '../models/auth-response.dto';
import { LoginDto } from '../models/login.dto';
import { RegisterDto } from '../models/register.dto';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root',  // Автоматическая регистрация сервиса
})
export class AuthService {
  private baseUrl = `${environment.apiUrl}/api/Auth`;

  constructor(private http: HttpClient) {}

  login(loginDto: LoginDto): Observable<AuthResponseDto> {
    return this.http.post<AuthResponseDto>(`${this.baseUrl}/login`, loginDto);
  }

  register(registerDto: RegisterDto): Observable<AuthResponseDto> {
    return this.http.post<AuthResponseDto>(`${this.baseUrl}/register`, registerDto);
  }

  refreshToken(refreshToken: string): Observable<AuthResponseDto> {
    return this.http.post<AuthResponseDto>(`${this.baseUrl}/refresh`, { refreshToken });
  }

  logout(refreshToken: string): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/logout`, { refreshToken });
  }
}
