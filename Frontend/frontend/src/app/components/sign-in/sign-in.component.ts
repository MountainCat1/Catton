import {Component, OnInit} from '@angular/core';
import {
  AuthenticationService, AuthTokenResponseContract,
  AuthViaPasswordRequestContract, ClaimsService,
  EmailPasswordAuthenticationService
} from "../../services/openapi-generated";
import {Observable} from "rxjs";
import {AuthService} from "../../services/auth.service";

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
  email: string = "";
  password: string = "";
  hide: boolean = true;

  authenticate$! : Observable<AuthTokenResponseContract>

  constructor(
    private authenticationService : EmailPasswordAuthenticationService,
    private authService : AuthService,
    private claimsService : ClaimsService,
  ) {
  }


  ngOnInit(): void {

  }

  togglePasswordVisibility() {
    this.hide = !this.hide;
  }


  signIn() {
    console.log('Signing in...');

    this.authenticate$ = this.authenticationService.apiAuthenticationAuthPost({
      email: this.email,
      password:this.password
    });

    this.authenticate$.subscribe(x => {
      console.log(x)
      this.authService.setToken(x.authToken as string);

      this.claimsService.apiAuthenticationClaimsGet().subscribe(x => console.log(x));
    })
  }

}
