
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class EditstudentService {
  private apiUrl = 'http://localhost:5238/api/Student';

  constructor(private http: HttpClient) { }

  getStudentById(id: number): Observable<any> {
    const url = `${this.apiUrl}/Getstubyid?id=${id}`;
    return this.http.get(url, httpOptions).pipe(
      catchError(this.handleError)
    );
  }

  updateStudent(studentData: any): Observable<any> {
    const url = `${this.apiUrl}/Update`;
    return this.http.put(url, studentData, httpOptions);
  }
  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('Đã xảy ra lỗi:', error.error.message);
    } else {
      console.error(`Dịch vụ trả về mã ${error.status}, nội dung là: ${error.error}`);
    }
    return throwError('Có lỗi xảy ra; vui lòng thử lại sau.');
  }
}
