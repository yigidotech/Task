import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatInputModule } from '@angular/material/input';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TaskComponent } from './task/task.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { TaskUpdatePartialComponent } from './task/partial/task-update-partial/task-update-partial.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDividerModule } from '@angular/material/divider';
import { UserService } from './user/user.service';
import { MatMenuModule } from '@angular/material/menu';
import { LoginGuard } from './user/login-guard';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './login/login.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatIconModule } from '@angular/material/icon';
@NgModule({
  declarations: [
    AppComponent,
    TaskComponent,
    TaskUpdatePartialComponent
    , UserComponent, LoginComponent, SignInComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
    , MatTableModule, NgbModule
    , HttpClientModule
    , MatCheckboxModule
    , FormsModule
    , MatFormFieldModule
    , MatInputModule
    , MatDatepickerModule
    , MatNativeDateModule
    , MatButtonModule
    , MatListModule
    , MatDividerModule
    , CommonModule
    , MatTooltipModule
    , MatMenuModule
    , MatIconModule
    , MatToolbarModule
  ],
  providers: [UserService, LoginGuard],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
