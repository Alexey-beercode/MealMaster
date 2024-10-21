// src/app/models/register.dto.ts
export interface RegisterDto {
  username: string;
  password: string;
  email: string;
  name: string;
  age: number;
  dietaryRestrictionsIds: string[];  // В Angular используем string для Guid
}
