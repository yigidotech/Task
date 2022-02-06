import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserModel } from './models/user.model';
import { UserService } from './user/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TaskUI';
  user!: UserModel;
  constructor(private userService: UserService
    , private router: Router) {
    this.user = this.userService.getUser();
  }

  logout() {
    this.userService.logout();
  }
}
