// src/app/auth/register/register.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { TokenService } from '../../../services/token.service';
import { RegisterDto } from '../../../models/register.dto';

@Component({
  selector: 'app-register',
  standalone: true,
  templateUrl: './register.component.html',
  imports: [CommonModule, FormsModule]  // Импортируем необходимые модули (например, для работы с формами)
})
export class RegisterComponent {
  username = '';
  password = '';
  email = '';
  name = '';
  age = 0;
  dietaryRestrictionsIds: string[] = [];

  constructor(
    private authService: AuthService,
    private tokenService: TokenService,
    private router: Router
  ) {}

  register() {
    const registerDto: RegisterDto = {
      username: this.username,
      password: this.password,
      email: this.email,
      name: this.name,
      age: this.age,
      dietaryRestrictionsIds: this.dietaryRestrictionsIds,
    };

    this.authService.register(registerDto).subscribe((response) => {
      this.tokenService.setAccessToken(response.accessToken);
      this.tokenService.setRefreshToken(response.refreshToken);
      this.router.navigate(['/dashboard']);
    });
  }
}
