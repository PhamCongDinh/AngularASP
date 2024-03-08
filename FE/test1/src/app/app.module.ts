import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { LstStudentComponent } from './lst-student/lst-student.component';
import { EditStudentComponent } from './edit-student/edit-student.component';
import { AddstudentComponent } from './addstudent/addstudent.component';
import { FormsModule } from '@angular/forms';
import { DetialComponent } from './detial/detial.component';
@NgModule({
  declarations: [
    AppComponent,
    LstStudentComponent,
    EditStudentComponent,
    AddstudentComponent,
    DetialComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
