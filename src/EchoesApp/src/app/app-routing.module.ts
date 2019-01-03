import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AssignmentsComponent } from './assignments/assignments.component';
import { LoginComponent } from './login/login.component';
import { ClassesComponent } from './classes/classes.component';
import { AccountComponent } from './account/account.component';
import { CreateClassComponent } from './create-class/create-class.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'assignments', component: AssignmentsComponent },
  { path: 'classes', component: ClassesComponent },
  { path: 'create-class', component: CreateClassComponent},
  { path: 'login', component: LoginComponent },
  { path: 'account', component: AccountComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
