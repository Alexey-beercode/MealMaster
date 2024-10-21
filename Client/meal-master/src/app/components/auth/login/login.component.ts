// src/app/auth/login/login.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { TokenService } from '../../../services/token.service';
import { LoginDto } from '../../../models/login.dto';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  imports: [CommonModule, FormsModule]  // Импортируем необходимые модули (например, для работы с формами)
})
export class LoginComponent {
  username = '';
  password = '';

  constructor(
    private authService: AuthService,
    private tokenService: TokenService,
    private router: Router
  ) {}

  login() {
    const loginDto: LoginDto = { username: this.username, password: this.password };
    this.authService.login(loginDto).subscribe((response) => {
      this.tokenService.setAccessToken(response.accessToken);
      this.tokenService.setRefreshToken(response.refreshToken);
      this.router.navigate(['/dashboard']);
    });
  }
}
