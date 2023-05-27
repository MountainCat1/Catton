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
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSlideToggleModule} from "@angular/material/slide-toggle";
import {MatInputModule} from "@angular/material/input";
import {MatSelectModule} from "@angular/material/select";
import {MatButtonModule} from "@angular/material/button";
import {MatIconModule} from "@angular/material/icon";
import {MatChipsModule} from "@angular/material/chips";
import {ApiModule} from "../services/openapi-generated";
import {FormsModule} from "@angular/forms";

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
    PublicPopupComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    GoogleSigninButtonModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatSlideToggleModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatIconModule,
    MatChipsModule,
    ApiModule,
    FormsModule
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
