import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserModel } from '../models/user.model';
import { environment } from '../../environments/environment';
import { LoginRequestModel } from '../models/login-request.model';
import { LoginResponseModel } from '../models/login-response.model';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  signIn(user: UserModel): Observable<any> {
    return this.http.post(environment.apiUrl + '/User/sign-in', user);
  }

  login(loginRequest: LoginRequestModel): Observable<any> {
    return this.http.post(environment.apiUrl + '/User/login', loginRequest);
  }

  isLoggedIn(): boolean {
    let result = false;
    debugger;
    if (sessionStorage.login) {
      let loginResponse: LoginResponseModel = JSON.parse(sessionStorage.login);
      if (loginResponse) {
        if (loginResponse.token && loginResponse.token != '') {
          result = true;
        }
      }
    }
    return result;
  }

  getUser(): UserModel {
    let result = null;
    if (sessionStorage.login) {
      const token = JSON.parse(sessionStorage.login);
      if (token) {
        result = token;
      }
    }
    return result;
  }

  logout() {
    sessionStorage.removeItem('login');
    window.open('/login','_self');
  }
}
