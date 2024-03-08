import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { student } from '../../model/Students.model';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'Application/json' })
}
const apiUrl = 'http://localhost:5238/api/Student/lststu';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<student[]> {
    return this.httpClient.get<student[]>(apiUrl).pipe(
    )
  }
  deletebyid(id: number): Observable<any> {
    const url = `http://localhost:5238/api/Student/delete?id=${id}`;
    return this.httpClient.delete(url, httpOptions).pipe();
  }
  detialbyid(id: number): Observable<any> {
    const url = `http://localhost:5238/api/Student/lstallpoint?id=${id}`;
    return this.httpClient.get(url, httpOptions).pipe();

  }
}
