import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'Application/json' })
}
@Injectable({
  providedIn: 'root'
})


export class AddstudentService {
  private apiUrl = 'http://localhost:5238/api/Student/Add';

  constructor(private httpClient: HttpClient) { }
  addStudent(Studentdata: any): Observable<any> {
    const url = `${this.apiUrl}`;
    return this.httpClient.post(url, Studentdata);

  }
}
