import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertTypeModel } from '../models/alert-types.model';
import { ErrorModel } from '../models/error.model';
import { UserModel } from '../models/user.model';
import { UserService } from '../user/user.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  user = new UserModel();

  showAlert: boolean = false;
  alertType: string = AlertTypeModel.danger;
  alertMessage!: string;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
  }

  signIn() {
    this.userService.signIn(this.user).subscribe(
      (res) => {
        if (res) {
          this.router.navigate(['/login']);
        } else {
          this.alertMessage = 'Kullanıcı kayıt edilemedi.';
          this.alertType = AlertTypeModel.danger;
          this.showAlert = true;
        }
      },
      (error) => {
        const err: ErrorModel = error;
        this.alertType = AlertTypeModel.danger;
        this.showAlert = true;
        if (err.message) {
          this.alertMessage = err.error;
        } else {

        }
        console.log(error);
      }
    );
  }

}
