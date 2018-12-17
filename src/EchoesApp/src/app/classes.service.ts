import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClassesService {

  constructor(private http: HttpClient, private auth: AuthService) { }

  getClasses() {
    return this.http.get(environment.apiUrl + '/api/classes', { headers: {
      Authorization: 'Bearer ' + this.auth.token
    }});
  }
}
