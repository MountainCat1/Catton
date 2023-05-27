import { Component } from '@angular/core';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent {
  email: string = "";
  password: string = "";
  hide: boolean = true;

  togglePasswordVisibility() {
    this.hide = !this.hide;
  }

  signIn() {
    // Implement your sign-in logic here
    console.log('Signing in...');
    console.log('Username:', this.email);
    console.log('Password:', this.password);
  }
}
