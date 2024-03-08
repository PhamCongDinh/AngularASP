import { Component, OnInit } from '@angular/core';
import { student } from '../model/Students.model';
import { StudentService } from '../service/get/student.service';
@Component({
  selector: 'app-lst-student',
  templateUrl: './lst-student.component.html',
  styleUrl: './lst-student.component.scss'
})
export class LstStudentComponent implements OnInit {
  datas: student[] = [];
  constructor(private Studentsevice: StudentService) { }
  ngOnInit(): void {
    this.getAll();
  }

  deleteStudent(id: number): void {
    const confirmDelete = confirm('Are you sure you want to delete this student?');
    if (confirmDelete) {
      this.Studentsevice.deletebyid(id).subscribe(
        () => {
          // Refresh the data after deletion
          this.getAll();
        },
        error => {
          console.error('Error deleting student:', error);
        }
      );
    }
  }
  getAll() {

    this.Studentsevice.getAll().subscribe((res: any) => this.datas = res.data);

  }
}
