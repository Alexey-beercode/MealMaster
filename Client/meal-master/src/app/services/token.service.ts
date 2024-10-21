// src/app/services/token.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, switchMap } from 'rxjs/operators';
import { environment } from '../environments/environment';
import { AuthResponseDto } from '../models/auth-response.dto';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  private readonly accessTokenKey = 'access-token';
  private readonly refreshTokenKey = 'refresh-token';
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  setAccessToken(token: string): void {
    localStorage.setItem(this.accessTokenKey, token);
  }

  getAccessToken(): string | null {
    return localStorage.getItem(this.accessTokenKey);
  }

  setUserId(userId: string): void {
    localStorage.setItem('userId', userId);
  }

  getUserId(): string | null {
    if (typeof localStorage !== 'undefined') {
      return localStorage.getItem('userId');
    }
    return null;
  }

  setRefreshToken(token: string): void {
    localStorage.setItem(this.refreshTokenKey, token);
  }

  getRefreshToken(): string | null {
    return localStorage.getItem(this.refreshTokenKey);
  }

  clearTokens(): void {
    localStorage.removeItem(this.accessTokenKey);
    localStorage.removeItem(this.refreshTokenKey);
  }

  checkTokenStatus(): Observable<any> {
    return this.http.get(`${this.apiUrl}/api/auth/token-status`).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401) {
          // Если токен недействителен, пытаемся обновить его
          return this.refreshToken().pipe(
            switchMap((response: AuthResponseDto) => {
              // Сохраняем новый токен
              this.setAccessToken(response.accessToken);
              this.setRefreshToken(response.refreshToken);

              return this.http.get(`${this.apiUrl}/api/auth/token-status`);
            })
          );
        }
        // Если ошибка не 401, пробрасываем её дальше
        return throwError(() => error);
      })
    );
  }

  private refreshToken(): Observable<AuthResponseDto> {
    const refreshToken = this.getRefreshToken();
    return this.http.post<AuthResponseDto>(`${this.apiUrl}/api/auth/refresh`, { refreshToken });
  }
}
