// src/app/components/edit-profile/edit-profile.component.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthBaseComponent } from '../base/auth-base.component';
import { AuthService } from '../../services/auth.service';
import { TokenService } from '../../services/token.service';
import { UserService } from '../../services/user.service';
import { UpdateUserDto } from '../../models/update-user.dto';
import { Location } from '@angular/common';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class EditProfileComponent extends AuthBaseComponent implements OnInit {
  updateUserDto: UpdateUserDto = {
    name: '',
    age: 0
  };

  constructor(
    protected override authService: AuthService,
    protected override tokenService: TokenService,
    protected override router: Router,
    private userService: UserService,
    private location: Location
  ) {
    super(authService, tokenService, router);
  }

  ngOnInit(): void {
    this.tokenService.checkTokenStatus().subscribe({
      next: (isValid) => {
        if (isValid) {
          const userId = this.tokenService.getUserId();
          if (userId) {
            this.loadUserData(userId);
          } else {
            this.router.navigate(['/login']);
          }
        } else {
          this.router.navigate(['/login']);
        }
      },
      error: () => this.router.navigate(['/login'])
    });
  }

  private loadUserData(userId: string): void {
    this.loading = true;
    this.userService.getById(userId).subscribe({
      next: (user) => {
        this.updateUserDto = {
          name: user.name,
          age: user.age
        };
        this.loading = false;
      },
      error: (error) => this.handleError(error)
    });
  }

  onSubmit(): void {
    const userId = this.tokenService.getUserId();
    if (!userId) {
      this.router.navigate(['/login']);
      return;
    }

    this.loading = true;
    this.userService.update(userId, this.updateUserDto).subscribe({
      next: () => {
        this.loading = false;
        this.router.navigate(['/profile']);
      },
      error: (error) => this.handleError(error)
    });
  }

  goBack(): void {
    this.location.back();
  }
}
