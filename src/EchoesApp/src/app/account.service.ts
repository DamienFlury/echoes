import { Injectable } from '@angular/core';
import { LoginViewModel } from './loginViewModel';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClientService) { }

  createAccount(credentials: LoginViewModel) {
    return this.http.post('/api/account', credentials);
  }
}
