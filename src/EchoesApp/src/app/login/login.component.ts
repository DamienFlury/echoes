import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { LoginViewModel } from '../loginViewModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private auth: AuthService, private router: Router) {}

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email
  ]);
  passwordFormControl = new FormControl('', [Validators.required]);

  ngOnInit() {}

  onSubmit() {
    this.auth
      .login(
        new LoginViewModel(
          this.emailFormControl.value,
          this.passwordFormControl.value
        )
      )
      .subscribe(success => this.router.navigate(['']),
      error => console.log('error'));
    console.log(this.emailFormControl.value, this.passwordFormControl.value);
  }
}
