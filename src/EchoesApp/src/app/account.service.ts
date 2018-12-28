import { Injectable } from '@angular/core';
import { LoginViewModel } from './loginViewModel';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient) { }

  createAccount(credentials: LoginViewModel) {
    return this.http.post(environment.apiUrl + '/api/account', credentials);
  }
}
