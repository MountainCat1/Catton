import {Component} from '@angular/core';
import {GoogleLoginProvider, SocialAuthService,} from '@abacritt/angularx-social-login';
import {AuthService} from "../services/auth.service";
import {AuthMethod, AuthRequestModel} from "../models/authRequestModel";

@Component({
  selector: 'app-test-auth',
  templateUrl: './test-auth.component.html',
  styleUrls: ['./test-auth.component.scss']
})
export class TestAuthComponent {
  user: any;
  loggedIn: any;


  constructor(private _socialAuthService: SocialAuthService,
              private _authService: AuthService) {
  }

  ngOnInit() {

    this._socialAuthService.authState.subscribe((user) => {
      this.user = user;
      this.loggedIn = (user != null);
      console.log(this.user)


      let authRequest: AuthRequestModel = {
        token: this.user.idToken,
        method: AuthMethod.Google
      }
      this._authService.authUser(authRequest)
    });
  }


  signInWithGoogle(): void {
    const headers = {'Referrer-Policy': 'strict-origin-when-cross-origin'};
    this._socialAuthService.signIn(GoogleLoginProvider.PROVIDER_ID, {headers}).then((user) => {
      this.user = user;
      this.loggedIn = true;
      console.log(this.user);
    });
  }

  public forceAuth() {
    let authRequest: AuthRequestModel = {
      token: this.user.idToken,
      method: AuthMethod.Google
    }

    console.log(authRequest)

    this._authService.authUser(authRequest).then(r => console.log(r));
  }
}
