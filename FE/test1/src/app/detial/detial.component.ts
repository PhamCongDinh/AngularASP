import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StudentService } from '../service/get/student.service';
import { Courses } from '../model/Courses.model';

@Component({
  selector: 'app-detial',
  templateUrl: './detial.component.html',
  styleUrl: './detial.component.scss'
})
export class DetialComponent implements OnInit {
  studentId: number;
  data: Courses[] = [];
  constructor(private route: ActivatedRoute, private studentService: StudentService) {

  }
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.studentId = +params['id'];
      console.log('Student ID:', this.studentId);
      this.Details();
    });
  }
  Details() {
    this.studentService.detialbyid(this.studentId).subscribe((res: any) => this.data = res.data);


  }
}
