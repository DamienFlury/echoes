import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AssignmentsComponent } from './assignments/assignments.component';
import { LoginComponent } from './login/login.component';
import { ClassesComponent } from './classes/classes.component';
import { AccountComponent } from './account/account.component';
import { CreateClassComponent } from './create-class/create-class.component';
import { CreateAssignmentComponent } from './create-assignment/create-assignment.component';
import { ClassDetailComponent } from './class-detail/class-detail.component';
import { AssignmentDetailComponent } from './assignment-detail/assignment-detail.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'assignments', component: AssignmentsComponent },
  { path: 'assignments/:id', component: AssignmentDetailComponent },
  { path: 'classes', component: ClassesComponent },
  { path: 'classes/:id', component: ClassDetailComponent },
  { path: 'create-class', component: CreateClassComponent },
  { path: 'create-assignment', component: CreateAssignmentComponent },
  { path: 'login', component: LoginComponent },
  { path: 'account', component: AccountComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
