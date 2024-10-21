// src/app/components/user-detail/user-detail.component.ts
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../services/user.service';
import { UserResponseDto } from '../../models/user-response.dto';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  standalone: true
})
export class UserDetailComponent implements OnInit {
  user: UserResponseDto | null = null;

  constructor(
    private userService: UserService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadUser(id);
    }
  }

  loadUser(id: string): void {
    this.userService.getById(id).subscribe((data) => {
      this.user = data;
    });
  }
}
