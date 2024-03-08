import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Classes } from '../../model/Classes.model';




const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'Application/json' })
}

@Injectable({
  providedIn: 'root'
})
export class GetclassesService {
  private apiurl = 'http://localhost:5238/api/Student/classbyid';
  constructor(private httpClient: HttpClient) { }
  Getclasses(): Observable<Classes[]> {
    return this.httpClient.get<Classes[]>(this.apiurl).pipe()
  }
}
