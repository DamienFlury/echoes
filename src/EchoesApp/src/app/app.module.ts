import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HomeComponent } from './home/home.component';
import { AssignmentsComponent } from './assignments/assignments.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ClassesComponent } from './classes/classes.component';
import { AccountComponent } from './account/account.component';
import { CreateClassComponent } from './create-class/create-class.component';
import { CreateAssignmentComponent } from './create-assignment/create-assignment.component';
import { ClassDetailComponent } from './class-detail/class-detail.component';
import { AssignmentDetailComponent } from './assignment-detail/assignment-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
    AssignmentsComponent,
    LoginComponent,
    ClassesComponent,
    AccountComponent,
    CreateClassComponent,
    CreateAssignmentComponent,
    ClassDetailComponent,
    AssignmentDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
