// components/register/register.component.ts
import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { TokenService } from '../../../services/token.service';
import { RegisterDto } from '../../../models/register.dto';
import { DietaryRestrictionService } from '../../../services/dietary-restriction.service';
import { DietaryRestrictionResponseDto } from '../../../models/dietary-restriction-response.dto';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink, NgOptimizedImage],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  errorMessage: string | null = null;
  dietaryRestrictions: DietaryRestrictionResponseDto[] = [];

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private tokenService: TokenService,
    private dietaryRestrictionService: DietaryRestrictionService,
    private router: Router
  ) {
    this.initForm();
  }

  ngOnInit() {
    this.tokenService.checkTokenStatus().subscribe({
      next: (isValid) => {
        if (isValid) {
          this.router.navigate(['/recipes']);
        }
      }
    });

    this.loadDietaryRestrictions();
  }

  private loadDietaryRestrictions(): void {
    this.dietaryRestrictionService.getAll().subscribe({
      next: (restrictions) => {
        this.dietaryRestrictions = restrictions;
      },
      error: (error) => {
        console.error('Ошибка загрузки диетических ограничений:', error);
        this.errorMessage = 'Не удалось загрузить диетические ограничения';
      }
    });
  }

  private initForm(): void {
    this.registerForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      email: ['', [Validators.required, Validators.email]],
      name: ['', [Validators.required]],
      age: [null, [Validators.required, Validators.min(0)]],
      dietaryRestrictionsIds: [[]]
    });
  }

  toggleRestriction(restrictionId: string): void {
    const currentRestrictions = this.registerForm.get('dietaryRestrictionsIds')?.value || [];
    const index = currentRestrictions.indexOf(restrictionId);

    if (index === -1) {
      currentRestrictions.push(restrictionId);
    } else {
      currentRestrictions.splice(index, 1);
    }

    this.registerForm.patchValue({ dietaryRestrictionsIds: currentRestrictions });
  }

  isRestrictionSelected(restrictionId: string): boolean {
    const currentRestrictions = this.registerForm.get('dietaryRestrictionsIds')?.value || [];
    return currentRestrictions.includes(restrictionId);
  }

  isFieldInvalid(fieldName: string): boolean {
    const field = this.registerForm.get(fieldName);
    return field ? (field.invalid && (field.dirty || field.touched)) : false;
  }

  onSubmit(): void {
    if (this.registerForm.valid) {
      const registerDto: RegisterDto = {
        ...this.registerForm.value,
        dietaryRestrictionsIds: this.registerForm.value.dietaryRestrictionsIds || []
      };

      this.authService.register(registerDto).subscribe({
        next: () => {
          this.router.navigate(['/recipes']);
        },
        error: (err) => {
          this.errorMessage = err.message || 'Ошибка регистрации';
        }
      });
    } else {
      Object.keys(this.registerForm.controls).forEach(key => {
        const control = this.registerForm.get(key);
        if (control) {
          control.markAsTouched();
        }
      });
    }
  }
}
