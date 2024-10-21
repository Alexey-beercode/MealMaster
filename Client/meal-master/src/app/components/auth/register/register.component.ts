// src/app/auth/register/register.component.ts
import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { TokenService } from '../../../services/token.service';
import { RegisterDto } from '../../../models/register.dto';

@Component({
  selector: 'app-register',
  standalone: true,
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  imports: [CommonModule, FormsModule, RouterLink, NgOptimizedImage],
})
export class RegisterComponent {
  username = '';
  password = '';
  email = '';
  name = '';
  age = 0;
  dietaryRestrictionsIds: string[] = [];
  errorMessage: string | null = null; // Add errorMessage property


  constructor(
    private authService: AuthService,
    private tokenService: TokenService,
    private router: Router
  ) {
    this.tokenService.checkTokenStatus()
  }

  register() {
    const registerDto: RegisterDto = {
      username: this.username,
      password: this.password,
      email: this.email,
      name: this.name,
      age: this.age,
      dietaryRestrictionsIds: this.dietaryRestrictionsIds,
    };

    this.authService.register(registerDto).subscribe({
      next: (response) => {
        this.tokenService.setAccessToken(response.accessToken);
        this.tokenService.setRefreshToken(response.refreshToken);
        this.router.navigate(['/recipes']);
      },
      error: (err) => {
        this.errorMessage = err.message;
      }
    });
  }
}
