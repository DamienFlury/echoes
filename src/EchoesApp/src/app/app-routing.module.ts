import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AssignmentsComponent } from './assignments/assignments.component';
import { LoginComponent } from './login/login.component';
import { ClassesComponent } from './classes/classes.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'assignments', component: AssignmentsComponent },
  { path: 'classes', component: ClassesComponent },
  { path: 'login', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
