import { Component } from '@angular/core';
import {Observable} from "rxjs";
import {AccountService, AuthTokenResponseContract, ClaimsService} from "../../services/generated-api/accounts";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent {
  email: string = "";
  password: string = "";
  hide: boolean = true;

  register$! : Observable<AuthTokenResponseContract>

  constructor(
    private accountService : AccountService,
    private authService : AuthService,
    private claimsService : ClaimsService,
    private router : Router
  ) {
  }

  togglePasswordVisibility() {
    this.hide = !this.hide;
  }

  signUp() {
    console.log('Signing in...');

    this.register$ = this.accountService.apiAccountsPost({
      email: this.email,
      password:this.password
    });


    this.register$.subscribe(x => {
      this.authService.setToken(x.authToken as string);

      this.router.navigate(["/"])
    })
  }

  getUserFriendlyErrorMessage(error: HttpErrorResponse | undefined) {
    return error?.statusText;
  }
}
