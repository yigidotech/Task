import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertTypeModel } from '../models/alert-types.model';
import { LoginRequestModel } from '../models/login-request.model';
import { LoginResponseModel } from '../models/login-response.model';
import { UserService } from '../user/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginRequest = new LoginRequestModel();

  showAlert: boolean = false;
  alertType: string = AlertTypeModel.danger;
  alertMessage!: string;

  constructor(private userService: UserService
    , private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    this.userService.login(this.loginRequest).subscribe((res) => {
      if (res) {
        const loginResponse: LoginResponseModel = res;
        if (loginResponse.token) {
          sessionStorage.setItem('login', JSON.stringify(loginResponse));
          window.open('/task', '_self');
        } else {
          this.alertMessage = 'Token alınamadı.';
          this.alertType = AlertTypeModel.danger;
          this.showAlert = true;
          sessionStorage.setItem('login', '');
          // console.log(this.traslateService.get('login.login-failed'));
        }
      } else {
        this.alertMessage = 'Kullanıcı adı ya da şifre hatalı.';
        this.alertType = AlertTypeModel.danger;
        this.showAlert = true;
      }
    }, (error) => {
      this.alertMessage = 'Hata alındı. Console\'a bakınz.';
      this.alertType = AlertTypeModel.danger;
      this.showAlert = true;
      console.log(error);
    });
  }

  signIn() {
    this.router.navigate(['/sign-in']);
  }
}
