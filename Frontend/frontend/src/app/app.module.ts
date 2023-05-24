import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestAuthComponent } from './test-auth/test-auth.component';
import {GoogleLoginProvider, GoogleSigninButtonModule, SocialAuthServiceConfig} from "@abacritt/angularx-social-login";
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {CustomHttpInterceptor} from "./services/http-interceptor";
import { PageComponent } from './page/page.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { PublicComponent } from './public/public.component';
import { PrivateComponent } from './private/private.component';
import { SecureComponent } from './secure/secure.component';
import { PanelComponent } from './panel/panel.component';
import { PublicPopupComponent } from './public-popup/public-popup.component';

@NgModule({
  declarations: [
    AppComponent,
    TestAuthComponent,
    PageComponent,
    SignInComponent,
    PublicComponent,
    PrivateComponent,
    SecureComponent,
    PanelComponent,
    PublicPopupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    GoogleSigninButtonModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              '934344019711-htpk4uv143hibkpol9vka7fk9qaasq86.apps.googleusercontent.com'
            )
          }
        ],
        onError: (err) => {
          console.error(err);
        }
      } as SocialAuthServiceConfig,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
