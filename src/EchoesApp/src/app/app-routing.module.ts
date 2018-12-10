import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MyAssignmentsComponent } from './my-assignments/my-assignments.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'my-assignments', component: MyAssignmentsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
