import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) {}

  token: string;
  tokenExpiration: Date;

  login(credentials): Observable<boolean> {
    return this.http.post(environment.apiUrl + '/api/auth', credentials).pipe(
      map(data => {
        this.token = data['token'];
        this.tokenExpiration = data['expiration'];
        return true;
      })
    );
  }
}
