import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { environment } from '../environments/environment';
import { AuthTokens } from '../models/auth/auth-tokens';
import { LoginDto } from '../models/login.dto';
import { RegisterDto } from '../models/register.dto';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly API_URL = `${environment.apiUrl}/api/auth`;
  private isAuthenticated = new BehaviorSubject<boolean>(false);

  constructor(
    private http: HttpClient,
    private tokenService: TokenService
  ) {
    this.checkAuthState();
  }

  login(credentials: LoginDto): Observable<AuthTokens> {
    return this.http.post<AuthTokens>(`${this.API_URL}/login`, credentials).pipe(
      tap(tokens => {
        this.tokenService.setTokens(tokens);
        this.isAuthenticated.next(true);
      }),
      catchError(error => throwError(() => error))
    );
  }

  register(registerDto: RegisterDto): Observable<AuthTokens> {
    return this.http.post<AuthTokens>(`${this.API_URL}/register`, registerDto).pipe(
      tap(tokens => {
        this.tokenService.setTokens(tokens);
        this.isAuthenticated.next(true);
      }),
      catchError(error => throwError(() => error))
    );
  }

  logout(): Observable<void> {
    const refreshToken = this.tokenService.getRefreshToken();
    // Изменим формат отправки токена
    return this.http.post<void>(`${this.API_URL}/logout`, { token: refreshToken }).pipe(
      tap(() => {
        this.tokenService.clearTokens();
        this.isAuthenticated.next(false);
      }),
      catchError(error => throwError(() => error))
    );
  }

  isAuthenticated$(): Observable<boolean> {
    return this.isAuthenticated.asObservable();
  }

  private checkAuthState(): void {
    const token = this.tokenService.getAccessToken();
    this.isAuthenticated.next(!!token);
  }
}
