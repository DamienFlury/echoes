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

  getInvitedClasses(): Observable<Class[]> {
    return this.http.get('/api/invitations');
  }

}
