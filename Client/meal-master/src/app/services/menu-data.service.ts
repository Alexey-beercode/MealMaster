import { Injectable } from '@angular/core';
import { GenerateMenuDto } from '../models/generate-menu.dto';

@Injectable({
  providedIn: 'root',
})
export class MenuDataService {
  private generateMenuData: GenerateMenuDto | null = null;

  setGenerateMenuData(data: GenerateMenuDto): void {
    this.generateMenuData = data;
  }

  getGenerateMenuData(): GenerateMenuDto | null {
    return this.generateMenuData;
  }

  clearGenerateMenuData(): void {
    this.generateMenuData = null;
  }
}
