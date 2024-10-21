// src/app/components/cuisine-types/cuisine-types.component.ts
import { Component, OnInit } from '@angular/core';
import { CuisineTypeService } from '../../services/cuisine-type.service';
import { CuisineTypeResponseDto } from '../../models/cuisine-type-response.dto';

@Component({
  selector: 'app-cuisine-types',
  templateUrl: './cuisine-types.component.html',
  standalone: true
})
export class CuisineTypesComponent implements OnInit {
  cuisineTypes: CuisineTypeResponseDto[] = [];

  constructor(private cuisineTypeService: CuisineTypeService) {}

  ngOnInit(): void {
    this.loadCuisineTypes();
  }

  loadCuisineTypes(): void {
    this.cuisineTypeService.getAll().subscribe((data) => {
      this.cuisineTypes = data;
    });
  }
}
