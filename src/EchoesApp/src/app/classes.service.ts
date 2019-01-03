import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Class } from './model/class';

@Injectable({
  providedIn: 'root'
})
export class ClassesService {

  constructor(private http: HttpClient, private auth: AuthService) { }

  getClasses(): Observable<Class[]> {
    return this.http.get<Class[]>(environment.apiUrl + '/api/classes', { headers: {
      Authorization: 'Bearer ' + this.auth.token
    }});
  }

  getClassById(id: number): Observable<Class> {
    return this.http.get<Class>(environment.apiUrl + '/api/classes/' + id, { headers: {
      Authorization: 'Bearer ' + this.auth.token
    }});
  }

  createClass(cls: Class) {
    return this.http.post(environment.apiUrl + '/api/classes', cls, { headers: {
      Authorization: 'Bearer ' + this.auth.token
    }});
  }
}
