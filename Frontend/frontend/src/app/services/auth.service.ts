import {Injectable} from '@angular/core';
import {CookieService} from "ngx-cookie-service";
import {HttpClient} from "@angular/common/http";
import 'url-join';
import {AccountDto, AccountService} from "./generated-api/accounts";
import {AuthRequestModel} from "../models/authRequestModel";
import {firstValueFrom, Observable, of} from "rxjs";
import urlJoin from "url-join";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly authCookieName = 'auth_token'
  private readonly accountCookieName = 'account'

  constructor(private _cookieService: CookieService,
              private http: HttpClient,
              private accountService: AccountService) {
  }


  public getToken(): string | undefined {
    return this._cookieService.get(this.authCookieName);
  }

  public setToken(token: string): void {

    this._cookieService.set(this.authCookieName, token)

    this.accountService.apiAccountsMeGet().subscribe(dto => {
      this.setAccount(dto);
    })
  }

  private setAccount(dto: AccountDto): void {
    localStorage.setItem(this.accountCookieName, JSON.stringify(dto));
  }

  getAccount(): Observable<AccountDto> {
    const objectString = localStorage.getItem(this.accountCookieName);

    if (objectString == null)
      throw Error("No user info cached")

    return of(JSON.parse(objectString) as AccountDto);
  }

  tryGetAccount(): Observable<AccountDto | undefined> {
    const objectString = localStorage.getItem(this.accountCookieName);

    if(objectString == undefined)
      return of(undefined);

    return of(JSON.parse(objectString) as AccountDto);
  }

  public async authUser(authRequest: AuthRequestModel): Promise<string | undefined> {
    try {
      // Fetch user token from backend
      let headers : any = {
        // 'Authorization': `Bearer ${authRequest.token}`
      };

      let authToken = await firstValueFrom(this.http.post(urlJoin(environment.API_BASE_PATH, "api/auth/google"), authRequest, {responseType: 'text', headers: headers}));

      // Set token to cookies
      this._cookieService.set("auth_token", authToken);

      // Return token
      return authToken

    } catch (error) {
      console.error(error);
      return undefined;
    }
  }
}
