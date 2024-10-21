// src/app/models/menu-history-response.dto.ts
import { MenuResponseDto } from './menu-response.dto';

export interface MenuHistoryResponseDto {
  createdDate: string; // ISO Date string
  menu: MenuResponseDto;
  userId: string;
}
