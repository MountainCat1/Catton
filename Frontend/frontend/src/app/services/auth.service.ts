import {Injectable} from '@angular/core';
import {SocialUser} from "@abacritt/angularx-social-login";
import {CookieService} from "ngx-cookie-service";
import {HttpClient} from "@angular/common/http";
import {environment} from "src/environments/environment";
import {firstValueFrom} from "rxjs";
import {AuthRequestModel} from "../models/authRequestModel";
import 'url-join';
import urlJoin from "url-join";
import {Configuration as ConventionConfiguration} from "./generated-api/convention/openapi-generated";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUri = environment.apiEndpoint;
  private readonly authCookieName = 'auth_token'

  constructor(private _cookieService: CookieService, private http: HttpClient) {
  }

  public getUser(): SocialUser | undefined {
    // TODO

    return undefined;
  }

  public async authUser(authRequest: AuthRequestModel): Promise<string | undefined> {
    try {
      // Fetch user token from backend
      let headers : any = {
        // 'Authorization': `Bearer ${authRequest.token}`
      };

      let authToken = await firstValueFrom(this.http.post(urlJoin(this.apiUri, "auth/google"), authRequest, {responseType: 'text', headers: headers}));

      // Set token to cookies
      this._cookieService.set("auth_token", authToken);

      // Return token
      return authToken

    } catch (error) {
      console.error(error);
      return undefined;
    }
  }

  public getToken() : string | undefined {
    return this._cookieService.get(this.authCookieName);
  }

  public setToken(token : string) : void {
    return this._cookieService.set(this.authCookieName, token);
  }
}
