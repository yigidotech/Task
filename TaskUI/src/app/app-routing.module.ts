import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { TaskComponent } from './task/task.component';
import { LoginGuard } from './user/login-guard';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  { path: 'task', component: TaskComponent, canActivate: [LoginGuard] },
  { path: 'user', component: UserComponent },
  { path: 'sign-in', component: SignInComponent },
  { path: 'login', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
