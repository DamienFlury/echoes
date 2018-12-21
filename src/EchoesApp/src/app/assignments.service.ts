import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Assignment } from './assignment';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AssignmentsService {
  constructor(private http: HttpClient, private auth: AuthService) {}

  getAssignments(): Observable<Assignment[]> {
    return this.http.get<Assignment[]>(
      environment.apiUrl + '/api/Assignments',
      {
        headers: {
          Authorization: 'Bearer ' + this.auth.token
        }
      }
    );
  }
}