// auth.interceptor.service.ts
import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError, from } from 'rxjs'; // Import 'from'
import { AuthService } from './auth.service';
import { catchError, switchMap, mergeMap } from 'rxjs/operators';


@Injectable()
export class AuthInterceptorService implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    // Use mergeMap to handle the Observable from interceptRequest
    return from(this.authService.interceptRequest(req)).pipe(
      mergeMap(authReq => {
        return next.handle(authReq).pipe(
          catchError((error: HttpErrorResponse) => {
            if (error.status === 401) {
              return this.authService.handleAuthError(error, req).pipe(
                switchMap(updatedReq => next.handle(updatedReq))
              );
            }
            return throwError(() => error);
          })
        );
      })
    );
  }
}
