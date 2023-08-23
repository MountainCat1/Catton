import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {Router} from "@angular/router";
import {HttpErrorResponse} from "@angular/common/http";
import {AccountService, AuthTokenResponseContract} from "../../services/generated-api/accounts";
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
    private accountService : AccountService,
    private authService : AuthService,
    private router : Router
  ) {
  }

  ngOnInit(): void {

  }

  togglePasswordVisibility() {
    this.hide = !this.hide;
  }

  signIn() {
    console.log('Signing in...');

    this.authenticate$ = this.accountService.apiAccountsLoginPost({
      email: this.email,
      password:this.password
    });


    this.authenticate$.subscribe(x => {
      this.authService.setToken(x.authToken as string);

      this.router.navigate(["/"])
    })
  }

  protected readonly Error = Error;

  getUserFriendlyErrorMessage(error: HttpErrorResponse | undefined) {
    return error?.statusText;
  }
}
