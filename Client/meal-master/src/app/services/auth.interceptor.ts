// src/app/services/auth.interceptor.ts
import { HttpInterceptorFn } from '@angular/common/http';
import { TokenService } from './token.service';
import { inject } from '@angular/core';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const tokenService = inject(TokenService);
  const accessToken = tokenService.getAccessToken();

  if (accessToken) {
    const clonedReq = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${accessToken}`)
    });
    return next(clonedReq);
  }

  return next(req);
};
