// src/app/components/users/users.component.ts
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { UserResponseDto } from '../../models/user-response.dto';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  standalone: true
})
export class UsersComponent implements OnInit {
  users: UserResponseDto[] = [];

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.getAll().subscribe((data) => {
      this.users = data;
    });
  }
}
