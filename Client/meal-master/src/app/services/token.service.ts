import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from '../environments/environment';
import { isPlatformBrowser } from '@angular/common';
import { AuthTokens } from '../models/auth/auth-tokens';
import { StorageService } from './storage.service';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  private readonly API_URL = `${environment.apiUrl}/api/auth`;
  private currentTokens: AuthTokens | null = null;

  constructor(
    private http: HttpClient,
    private storageService: StorageService,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {
    if (isPlatformBrowser(this.platformId)) {
      this.currentTokens = this.storageService.getAuthData();
    }
  }

  getAccessToken(): string | null {
    return this.currentTokens?.accessToken || null;
  }

  getRefreshToken(): string | null {
    return this.currentTokens?.refreshToken || null;
  }

  getUserId(): string | null {
    return this.currentTokens?.userId || null;
  }

  clearTokens(): void {
    this.currentTokens = null;
    if (isPlatformBrowser(this.platformId)) {
      this.storageService.clearAuthData();
    }
  }

  checkTokenStatus(): Observable<boolean> {
    const accessToken = this.getAccessToken();
    console.log('Checking token status with token:', accessToken);

    if (!accessToken) {
      console.log('No token found');
      this.clearTokens();
      return of(false);
    }

    // Добавим проверку формата токена
    if (!this.isValidTokenFormat(accessToken)) {
      console.log('Invalid token format');
      this.clearTokens();
      return of(false);
    }

    return this.http.get(`${this.API_URL}/token-status`, {
      headers: { 'Authorization': `Bearer ${accessToken}` },
      observe: 'response',
      responseType: 'text'
    }).pipe(
      map(response => {
        console.log('Token status response:', response);
        return response.status === 200;
      }),
      catchError((error) => {
        console.error('Token status error:', error);
        if (error.status === 401) {
          return this.refresh();
        }
        this.clearTokens();
        return of(false);
      })
    );
  }

  private isValidTokenFormat(token: string): boolean {
    // Простая проверка формата JWT
    const parts = token.split('.');
    return parts.length === 3;
  }

  refresh(): Observable<boolean> {
    const refreshToken = this.getRefreshToken();
    console.log('Attempting refresh with token:', refreshToken);

    if (!refreshToken) {
      console.log('No refresh token available');
      this.clearTokens();
      return of(false);
    }

    return this.http.post<AuthTokens>(`${this.API_URL}/refresh`, refreshToken).pipe(
      map(tokens => {
        console.log('Refresh successful, new tokens:', tokens);
        if (tokens && tokens.accessToken && tokens.refreshToken) {
          this.setTokens(tokens);
          return true;
        }
        return false;
      }),
      catchError(error => {
        console.error('Refresh error:', error);
        this.clearTokens();
        return of(false);
      })
    );
  }

  setTokens(tokens: AuthTokens): void {
    console.log('Setting tokens:', tokens);
    this.currentTokens = tokens;
    if (isPlatformBrowser(this.platformId)) {
      this.storageService.saveAuthData(tokens);
    }
  }
}
