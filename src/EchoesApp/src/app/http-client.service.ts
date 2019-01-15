import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  constructor(private http: HttpClient, private auth: AuthService) { }

  get<T>(url: string): Observable<T> {
    return this.http.get<T>(environment.apiUrl + url, {
      headers: {Authorization: 'Bearer ' + this.auth.token}
    });
  }

    put<T>(url: string, object: any): Observable<T> {
    return this.http.put<T>(environment.apiUrl + url, object, {
      headers: { Authorization: 'Bearer ' + this.auth.token }
    });
  }

  post<T>(url: string, object: any): Observable<T> {
    return this.http.post<T>(environment.apiUrl + url, object, {
      headers: { Authorization: 'Bearer ' + this.auth.token }
    });
  }

  delete<T>(url: string, id: number): Observable<T> {
    return this.http.delete<T>(environment.apiUrl + url + id, {
      headers: { Authorization: 'Bearer ' + this.auth.token }
    });
  }
}
