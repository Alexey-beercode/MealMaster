// src/app/components/dietary-restrictions/dietary-restrictions.component.ts
import { Component, OnInit } from '@angular/core';
import { DietaryRestrictionService } from '../../services/dietary-restriction.service';
import { DietaryRestrictionResponseDto } from '../../models/dietary-restriction-response.dto';

@Component({
  selector: 'app-dietary-restrictions',
  templateUrl: './dietary-restrictions.component.html',
  standalone: true
})
export class DietaryRestrictionsComponent implements OnInit {
  dietaryRestrictions: DietaryRestrictionResponseDto[] = [];

  constructor(private dietaryRestrictionService: DietaryRestrictionService) {}

  ngOnInit(): void {
    this.loadDietaryRestrictions();
  }

  loadDietaryRestrictions(): void {
    this.dietaryRestrictionService.getAll().subscribe((data) => {
      this.dietaryRestrictions = data;
    });
  }
}
