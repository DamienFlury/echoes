import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { FormControl, Validators } from '@angular/forms';
import { LoginViewModel } from '../loginViewModel';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  constructor(
    private auth: AuthService,
    private router: Router,
    private account: AccountService
  ) {}

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email
  ]);
  passwordFormControl = new FormControl('', [Validators.required]);
  passwordRepeatFormControl = new FormControl('', [Validators.required]);
  showError = false;

  ngOnInit() {}

  onSubmit() {
    const email = this.emailFormControl.value;
    const password = this.passwordFormControl.value;
    this.account
      .createAccount(new LoginViewModel(email, password))
      .subscribe(() =>
        this.auth
          .login(new LoginViewModel(email, password))
          .subscribe(() => this.router.navigate(['/']))
      );
  }
}
