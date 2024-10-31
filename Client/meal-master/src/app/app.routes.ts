import { Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import {RecipesComponent} from "./components/recipes/recipes.component";
import {ProfileComponent} from "./components/users/profile.component";
import {MenuHistoryComponent} from "./components/menu-history/menu-history.component";
import {EditProfileComponent} from "./components/edit-profile/edit-profile.component";
import {UserRecipesComponent} from "./components/user-recipes/user-recipes.component";
import {UserMenusComponent} from "./components/user-menus/user-menus.component";
import {MenuGeneratorComponent} from "./components/menu-generator/menu-generator.component";

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'recipes', component: RecipesComponent },
  {path: 'profile',component:ProfileComponent},
  {path: 'menu-history',component: MenuHistoryComponent},
  {path: 'edit-profile',component: EditProfileComponent},
  {path: 'user-recipes',component: UserRecipesComponent},
  {path: 'user-menus',component:UserMenusComponent},
  {path: 'menu-generator',component: MenuGeneratorComponent},
  { path: '', redirectTo: '/recipes', pathMatch: 'full' },
  { path: '**', redirectTo: '/login' },
];
