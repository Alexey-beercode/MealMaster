// services/storage.service.ts
import { Injectable } from '@angular/core';
import {AuthTokens} from "../models/auth/auth-tokens";

@Injectable({
  providedIn: 'root'
})
export class StorageService {
  private readonly STORAGE_KEY = 'auth_data';

  saveAuthData(data: AuthTokens): void {
    console.log('Saving auth data:', data);
    localStorage.setItem(this.STORAGE_KEY, JSON.stringify(data));
  }

  getAuthData(): AuthTokens | null {
    const data = localStorage.getItem(this.STORAGE_KEY);
    console.log('Retrieved auth data:', data);
    return data ? JSON.parse(data) : null;
  }

  clearAuthData(): void {
    console.log('Clearing auth data');
    localStorage.removeItem(this.STORAGE_KEY);
  }
}
