import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Class } from './model/class';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class ClassesService {
  constructor(private http: HttpClientService) {}

  getClasses(): Observable<Class[]> {
    return this.http.get<Class[]>('/api/classes');
  }

  getClassById(id: number): Observable<Class> {
    return this.http.get<Class>('/api/classes/' + id);
  }

  createClass(cls: Class) {
    return this.http.post('/api/classes', cls);
  }

  leaveClass(id: number) {
    return this.http.delete('/api/classes/leave/', id);
  }
}
