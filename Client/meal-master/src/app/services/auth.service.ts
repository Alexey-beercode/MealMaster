import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Observable, throwError, BehaviorSubject, of } from 'rxjs';
import { catchError, switchMap, tap } from 'rxjs/operators';
import { AuthResponseDto } from '../models/auth-response.dto';
import { LoginDto } from '../models/login.dto';
import { RegisterDto } from '../models/register.dto';
import { TokenService } from './token.service';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = `${environment.apiUrl}/api/Auth`;
  private isRefreshing = false;
  private refreshTokenSubject: BehaviorSubject<string | null> = new BehaviorSubject<string | null>(null);

  constructor(
    private http: HttpClient,
    private tokenService: TokenService
  ) {}

  // Логин пользователя
  login(loginDto: LoginDto): Observable<AuthResponseDto> {
    return this.http.post<AuthResponseDto>(`${this.baseUrl}/login`, loginDto).pipe(
      tap(response => {
        this.tokenService.setAccessToken(response.accessToken);
        this.tokenService.setRefreshToken(response.refreshToken);
        this.tokenService.setUserId(response.userId);
      }),
      catchError(this.handleError)
    );
  }

  // Регистрация пользователя
  register(registerDto: RegisterDto): Observable<AuthResponseDto> {
    return this.http.post<AuthResponseDto>(`${this.baseUrl}/register`, registerDto).pipe(
      tap(response => {
        this.tokenService.setAccessToken(response.accessToken);
        this.tokenService.setRefreshToken(response.refreshToken);
        this.tokenService.setUserId(response.userId);
      }),
      catchError(this.handleError)
    );
  }

  // Обновление токена
  refreshToken(): Observable<AuthResponseDto> {
    const refreshToken = this.tokenService.getRefreshToken();
    if (!refreshToken) {
      return throwError(() => new Error('No refresh token available'));
    }

    return this.http.post<AuthResponseDto>(`${this.baseUrl}/refresh`, { refreshToken }).pipe(
      tap(response => {
        this.tokenService.setAccessToken(response.accessToken);
        this.tokenService.setRefreshToken(response.refreshToken);
      }),
      catchError(this.handleError)
    );
  }

  // Логаут пользователя
  logout(): Observable<void> {
    const refreshToken = this.tokenService.getRefreshToken();
    return this.http.post<void>(`${this.baseUrl}/logout`, { refreshToken }).pipe(
      tap(() => this.tokenService.clearTokens()),
      catchError(this.handleError)
    );
  }

  // Обработчик ошибок
  private handleError(error: HttpErrorResponse): Observable<never> {
    let errorMessage = 'An unknown error occurred!';
    if (error.error instanceof ErrorEvent) {
      // Client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(() => new Error(errorMessage));
  }

  // Интерсептор для автоматического обновления токена
  interceptRequest(request: HttpRequest<any>): Promise<HttpRequest<any>> {
    return new Promise<HttpRequest<any>>(resolve => {
      const accessToken = this.tokenService.getAccessToken();
      if (accessToken) {
        resolve(this.addTokenToRequest(request, accessToken));
      } else {
        resolve(request);
      }
    });
  }

  // Добавление токена к запросу
  private addTokenToRequest(request: HttpRequest<any>, token: string): HttpRequest<any> {
    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });
    return request.clone({ headers });
  }

  // Обработка ошибок авторизации и обновление токена
  handleAuthError(error: HttpErrorResponse, request: HttpRequest<any>): Observable<HttpRequest<any>> {
    if (error.status === 401 && !this.isRefreshing) {
      this.isRefreshing = true;
      const refreshToken = this.tokenService.getRefreshToken();

      if (refreshToken) {
        return this.refreshToken().pipe(
          switchMap((response: AuthResponseDto) => {
            this.isRefreshing = false;
            this.tokenService.setAccessToken(response.accessToken);
            this.refreshTokenSubject.next(response.accessToken);
            return of(this.addTokenToRequest(request, response.accessToken)); // Wrap in 'of'
          }),
          catchError(err => {
            this.isRefreshing = false;
            this.tokenService.clearTokens();
            return throwError(() => err);
          }),
          tap(() => this.isRefreshing = false) // Ensure isRefreshing is reset
        );
      } else {
        this.isRefreshing = false; // Reset here as well
        return throwError(() => new Error('No refresh token available'));
      }
    }

    return throwError(() => error); // Return outside the initial 'if'
  }
}
