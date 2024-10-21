// src/app/app.routes.ts
import { Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import {DietaryRestrictionsComponent} from "./components/dietary-restrictions/dietary-restrictions.component";
import {CuisineTypesComponent} from "./components/cuisine-types/cuisine-types.component";
import {MenusComponent} from "./components/menus/menus.component";
import {MenuHistoryComponent} from "./components/menu-history/menu-history.component";
import {ProductsComponent} from "./components/products/products.component";
import {RecipesComponent} from "./components/recipes/recipes.component";
import {UserDetailComponent} from "./components/users/user-detail.component";
import {UsersComponent} from "./components/users/users.component";

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'cuisine-types', component: CuisineTypesComponent },
  { path: 'dietary-restrictions', component: DietaryRestrictionsComponent },
  { path: 'menus', component: MenusComponent },
  { path: 'menu-history', component: MenuHistoryComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'products', component: ProductsComponent },
  { path: 'recipes', component: RecipesComponent },
  { path: 'users', component: UsersComponent },
  { path: 'user/:id', component: UserDetailComponent },
];
