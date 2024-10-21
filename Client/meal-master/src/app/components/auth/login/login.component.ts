// src/app/components/auth/login/login.component.ts
import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { TokenService } from '../../../services/token.service';
import { LoginDto } from '../../../models/login.dto';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [CommonModule, FormsModule, RouterLink, HttpClientModule],
  providers: [AuthService],
})
export class LoginComponent {
  username = '';
  password = '';
  errorMessage: string | null = null;

  constructor(
    private authService: AuthService,
    private tokenService: TokenService,
    private router: Router
  ) {
    this.tokenService.checkTokenStatus();
  }

  login() {
    const loginDto: LoginDto = { username: this.username, password: this.password };
    this.authService.login(loginDto).subscribe({
      next: (response) => {
        this.tokenService.setAccessToken(response.accessToken);
        this.tokenService.setRefreshToken(response.refreshToken);
        this.router.navigate(['/recipes']);
      },
      error: (error) => {
        this.errorMessage = error.message;
        console.error('Login failed:', error);
      }
    });
  }
}
