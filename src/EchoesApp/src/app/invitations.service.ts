import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { Observable } from 'rxjs';
import { Class } from './model/class';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class InvitationsService {
  constructor(private http: HttpClientService) {}

  invite(classId: number, email: string) {
    return this.http.post('/api/invitations', {
      classId: classId,
      email: email
    });
  }

  getReceivedClasses(): Observable<Class[]> {
    return this.http.get('/api/invitations');
  }

  accept(classId: number): Observable<Class[]> {
    return this.http.get('/api/invitations/accept/' + classId);
  }
}
