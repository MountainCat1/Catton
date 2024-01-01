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
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {environment} from "../environments/environment";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import {WithHttpLoadingPipe} from "./with-loading.pipe";
import {AuthService} from "./services/auth.service";
import {JwtInterceptor} from "./jwt-interceptor";
import {SelectConventionComponent} from './components/select-convention/select-convention.component';
import {LayoutModule} from '@angular/cdk/layout';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {Configuration as AccountConfiguration} from "./services/generated-api/accounts";
import {
  Configuration as ConventionConfiguration,
  ConventionService
} from "./services/generated-api/conventions";
import {MatCardModule} from "@angular/material/card";
import { StaticChipComponent } from './generic-components/static-chip/static-chip.component';
import { MainMenuComponent } from './components/main-menu/main-menu.component';
import { UserInfoComponent } from './components/user-info/user-info.component';
import {MatRippleModule} from "@angular/material/core";
import { OrganizersComponent } from './components/organizers/organizers.component';
import { InitialRedirectComponent } from './components/initial-redirect/initial-redirect.component';
import {NgOptimizedImage} from "@angular/common";
import { AttendeesComponent } from './components/attendees/attendees.component';
import {MatTableModule} from "@angular/material/table";
import {MatPaginatorModule} from "@angular/material/paginator";
import {MatSortModule} from "@angular/material/sort";
import { AttendeeDetailsComponent } from './components/attendee-details/attendee-details.component';
import { AttendeeDeleteConfirmDialogComponent } from './components/attendee-details/attendee-delete-confirm/attendee-delete-confirm-dialog.component';
import {MatDialogModule} from "@angular/material/dialog";
import { TicketsComponent } from './components/tickets/tickets.component';
import { TicketDetailsComponent } from './components/ticket-details/ticket-details.component';
import { TicketTemplatesComponent } from './components/ticket-templates/ticket-templates.component';
import { TicketDeleteConfirmDialogComponent } from './components/ticket-details/ticket-delete-confirm-dialog/ticket-delete-confirm-dialog.component';
import { TicketTemplateDetailsComponent } from './components/ticket-template-details/ticket-template-details.component';
import { TicketTemplateDeleteConfirmComponent } from './components/ticket-template-details/ticket-template-delete-confirm/ticket-template-delete-confirm.component';
import { TicketTemplateCreateComponent } from './components/ticket-template-create/ticket-template-create.component';

const RegisterBackendConfiguration = (authService: AuthService) => new AccountConfiguration(
  {
    basePath: environment.API_BASE_PATH,
    credentials: {
      bearer: () => authService.getToken(),
    },
  }
)


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

    WithHttpLoadingPipe,
    SelectConventionComponent,
    StaticChipComponent,
    MainMenuComponent,
    UserInfoComponent,
    OrganizersComponent,
    InitialRedirectComponent,
    AttendeesComponent,
    AttendeeDetailsComponent,
    AttendeeDeleteConfirmDialogComponent,
    TicketsComponent,
    TicketDetailsComponent,
    TicketTemplatesComponent,
    TicketDeleteConfirmDialogComponent,
    TicketTemplateDetailsComponent,
    TicketTemplateDeleteConfirmComponent,
    TicketTemplateCreateComponent,
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
        FormsModule,
        MatProgressSpinnerModule,
        LayoutModule,
        MatToolbarModule,
        MatSidenavModule,
        MatListModule,
        MatCardModule,
        MatRippleModule,
        NgOptimizedImage,
        MatTableModule,
        MatPaginatorModule,
        MatSortModule,
        MatDialogModule,
        ReactiveFormsModule
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
      provide: AccountConfiguration,
      useFactory: RegisterBackendConfiguration,
      // deps: [AuthService],
      multi: false
    },
    {
      provide: ConventionConfiguration,
      useFactory: RegisterBackendConfiguration,
      // deps: [AuthService],
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

