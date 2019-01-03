import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { LoginViewModel } from './loginViewModel';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) {}

  token = '';
  tokenExpiration: Date;

  login(credentials: LoginViewModel): Observable<boolean> {
    return this.http.post(environment.apiUrl + '/api/auth', credentials).pipe(
      map(data => {
        this.token = data['token'];
        this.tokenExpiration = data['expiration'];
        localStorage.setItem('jwt-token', this.token);
        return true;
      })
    );
  }

  loginFromCookie(): boolean {
    const token = localStorage.getItem('jwt-token');
    if (!token) { return false; }
    this.token = token;
    return true;
  }

  get isLoggedIn(): boolean {
    return this.token !== '';
  }

  logout() {
    localStorage.removeItem('jwt-token');
    this.token = '';
  }
}
