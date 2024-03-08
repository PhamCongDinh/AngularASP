import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EditstudentService } from '../service/edit/editstudent.service';
import { GetclassesService } from '../service/get/getclasses.service';
import { Classes } from '../model/Classes.model';
@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.scss']
})
export class EditStudentComponent implements OnInit {
  studentId: number;
  studentdata: any = {};  // Khởi tạo đối tượng rỗng

  constructor(private route: ActivatedRoute, private classService: GetclassesService, private editService: EditstudentService, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.studentId = +params['id'];
      console.log('Student ID:', this.studentId);
      this.getStudentDetails();
      this.getclasses();

    });
  }

  getStudentDetails() {
    this.editService.getStudentById(this.studentId).subscribe(
      response => {
        this.studentdata = response.data[0]; console.log(this.studentdata);
        this.studentdata.dateOfBirth = this.studentdata.dateOfBirth.split('T')[0];
      },
      error => {
        console.error('Error fetching student details', error);
      }
    );
  }

  updateStudent() {
    this.editService.updateStudent(this.studentdata).subscribe(
      response => {
        console.log('Student updated successfully', response);
        this.router.navigate(['']);
      },
      error => {
        console.error('Error updating student', error);
      }
    );
  }
  datas: Classes[] = [];

  getclasses() {
    this.classService.Getclasses().subscribe((res: any) => {
      this.datas = res.data;
      console.log(this.datas); // Kiểm tra dữ liệu nhận được
    });
  }

}
