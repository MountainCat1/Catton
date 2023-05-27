import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {TestAuthComponent} from './components/test-auth/test-auth.component';
import {GoogleLoginProvider, GoogleSigninButtonModule, SocialAuthServiceConfig} from "@abacritt/angularx-social-login";
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {PageComponent} from './generic-components/page/page.component';
import {SignInComponent} from './components/sign-in/sign-in.component';
import {PublicComponent} from './generic-components/public/public.component';
import {PrivateComponent} from './generic-components/private/private.component';
import {SecureComponent} from './generic-components/secure/secure.component';
import {PanelComponent} from './generic-components/panel/panel.component';
import {PublicPopupComponent} from './generic-components/public-popup/public-popup.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatSlideToggleModule} from "@angular/material/slide-toggle";
import {MatInputModule} from "@angular/material/input";
import {MatSelectModule} from "@angular/material/select";
import {MatButtonModule} from "@angular/material/button";
import {MatIconModule} from "@angular/material/icon";
import {MatChipsModule} from "@angular/material/chips";
import {ApiModule, BASE_PATH, Configuration} from "./services/openapi-generated";
import {FormsModule} from "@angular/forms";
import {environment} from "../environments/environment";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import {WithLoadingPipe} from "./with-loading.pipe";
import {AuthService} from "./services/auth.service";
import {JwtInterceptor} from "./jwt-interceptor";

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

    WithLoadingPipe
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
    FormsModule,
    MatProgressSpinnerModule
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
    },
    {
      provide: Configuration,
      useFactory: (authService: AuthService) => new Configuration(
        {
          basePath: environment.API_BASE_PATH,
          credentials : {
            bearer: () => authService.getToken(),
          },
        }
      ),
      deps: [AuthService],
      multi: false
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
