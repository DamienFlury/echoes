import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { Subject } from './model/subject';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubjectsService {
  constructor(private http: HttpClientService) {}

  getSubjects(): Observable<Subject[]> {
    return this.http.get<Subject[]>('/api/Subjects');
  }
  getSubject(id: number): Observable<Subject> {
    return this.http.get<Subject>('/api/Subjects/' + id);
  }
  createSubject(subject: Subject) {
    return this.http.post('/api/Subjects', subject);
  }
}
