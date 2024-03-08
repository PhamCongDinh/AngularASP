import { Component, OnInit } from '@angular/core';
import { AddstudentService } from '../service/add/addstudent.service';
import { student } from '../model/Students.model';
import { ActivatedRoute, Router } from '@angular/router';
import { GetclassesService } from '../service/get/getclasses.service';
import { Classes } from '../model/Classes.model';
@Component({
  selector: 'app-addstudent',
  templateUrl: './addstudent.component.html',
  styleUrl: './addstudent.component.scss'
})
export class AddstudentComponent implements OnInit {
  constructor(private route: ActivatedRoute, private classService: GetclassesService, private router: Router, private studentService: AddstudentService) { }

  addStudent(studentForm: any) {
    if (studentForm.valid) {
      const studentData = {
        "id": studentForm.value.id,
        "studentName": studentForm.value.name,
        "dateOfBirth": studentForm.value.dateOfBirth,
        "town": studentForm.value.town,
        "nameClass": studentForm.value.nameClass
      };

      this.studentService.addStudent(studentData).subscribe(
        response => {
          console.log('Student added successfully', response);
          this.router.navigate(['']);
        },
        error => {

          alert("StudentID already exists. Please choose a different ID.");

        }
      );
    }

  }
  ngOnInit(): void {
    this.getclasses();
  }
  datas: Classes[] = [];
  getclasses() {
    this.classService.Getclasses().subscribe((res: any) => {
      this.datas = res.data;
      console.log(this.datas); // Kiểm tra dữ liệu nhận được
    });
  }
}
