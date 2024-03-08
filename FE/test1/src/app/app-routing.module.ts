import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LstStudentComponent } from './lst-student/lst-student.component';
import { AddstudentComponent } from './addstudent/addstudent.component';
import { EditStudentComponent } from './edit-student/edit-student.component';
import { DetialComponent } from './detial/detial.component';

const routes: Routes = [
  { path: '', component: LstStudentComponent },
  { path: 'addstudent', component: AddstudentComponent },
  { path: 'edit/:id', component: EditStudentComponent },
  { path: 'detial/:id', component: DetialComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
