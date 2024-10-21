// src/app/components/recipes/recipes.component.ts
import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../../services/recipe.service';
import { RecipeResponseDto } from '../../models/recipe-response.dto';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  standalone: true
})
export class RecipesComponent implements OnInit {
  recipes: RecipeResponseDto[] = [];

  constructor(private recipeService: RecipeService) {}

  ngOnInit(): void {
    this.loadRecipes();
  }

  loadRecipes(): void {
    this.recipeService.getAll().subscribe((data) => {
      this.recipes = data;
    });
  }
}
