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
import { BsDatepickerModule } from 'ngx-bootstrap';

import { ActiveAssignmentsComponent } from './active-assignments/active-assignments.component';
import { InactiveAssignmentsComponent } from './inactive-assignments/inactive-assignments.component';
import { AllAssignmentsComponent } from './all-assignments/all-assignments.component';
import { AssignmentsListComponent } from './assignments-list/assignments-list.component';
import { InvitationsComponent } from './invitations/invitations.component';
import { InviteComponent } from './invite/invite.component';
import { EditAssignmentComponent } from './edit-assignment/edit-assignment.component';
import { CreateSubjectComponent } from './create-subject/create-subject.component';
import { SubjectsComponent } from './subjects/subjects.component';
import { SubjectDetailComponent } from './subject-detail/subject-detail.component';

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
    AssignmentDetailComponent,
    ActiveAssignmentsComponent,
    InactiveAssignmentsComponent,
    AllAssignmentsComponent,
    AssignmentsListComponent,
    InvitationsComponent,
    InviteComponent,
    EditAssignmentComponent,
    CreateSubjectComponent,
    SubjectsComponent,
    SubjectDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BsDatepickerModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
