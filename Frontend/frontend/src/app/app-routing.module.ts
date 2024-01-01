import {inject, NgModule} from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivateFn, ExtraOptions,
  Router,
  RouterModule,
  RouterStateSnapshot,
  Routes
} from '@angular/router';
import {SignInComponent} from "./components/sign-in/sign-in.component";
import {SecureComponent} from "./generic-components/secure/secure.component";
import {of} from "rxjs";
import {AuthService} from "./services/auth.service";
import {SelectConventionComponent} from "./components/select-convention/select-convention.component";
import {MainMenuComponent} from "./components/main-menu/main-menu.component";
import {OrganizersComponent} from "./components/organizers/organizers.component";
import {InitialRedirectComponent} from "./components/initial-redirect/initial-redirect.component";
import {PublicPopupComponent} from "./generic-components/public-popup/public-popup.component";
import {AttendeesComponent} from "./components/attendees/attendees.component";
import {AttendeeDetailsComponent} from "./components/attendee-details/attendee-details.component";
import {TicketsComponent} from "./components/tickets/tickets.component";
import {TicketDetailsComponent} from "./components/ticket-details/ticket-details.component";
import {TicketTemplatesComponent} from "./components/ticket-templates/ticket-templates.component";
import {TicketTemplateDetailsComponent} from "./components/ticket-template-details/ticket-template-details.component";
import {DetailRedirectGuardGuard} from "./services/detail-redirect-guard.guard";
import {TicketTemplateCreateComponent} from "./components/ticket-template-create/ticket-template-create.component";

const guard: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  const authToken = authService.getToken();

  if (authToken) {
    return of(true); // Allow access to the route
  } else {
    router.navigate(['/sign-in']);
    return of(false); // Prevent access to the route
  }
};


const SECURE_ROUTES_CONVENTION_SELECTED = [
  {path: '', component: MainMenuComponent},
  {path: 'organizers', component: OrganizersComponent},
  {path: 'attendees', component: AttendeesComponent},
  {path: 'attendees/:accountId', component: AttendeeDetailsComponent},
  {path: 'tickets', component: TicketsComponent},
  {path: 'tickets/:ticketId', component: TicketDetailsComponent},
  {path: 'ticket-templates', component: TicketTemplatesComponent},
  {path: 'ticket-templates/details/:ticketTemplateId', component: TicketTemplateDetailsComponent},
  {path: 'ticket-templates/create', component: TicketTemplateCreateComponent},
]

const SECURE_ROUTES: Routes = [
  {path: '', pathMatch: "full", redirectTo: '/select-convention'},
  {path: 'select-convention', component: SelectConventionComponent},

  {path: 'c/:conventionId', children: SECURE_ROUTES_CONVENTION_SELECTED},
]

const APP_ROUTES: Routes = [
  {path: 'sign-in', component: PublicPopupComponent, children: [ { path: '', component: SignInComponent }]},
  {path: '', component: SecureComponent, canActivate: [guard], data: {title: 'Secure Views'}, children: SECURE_ROUTES},
  {path: '**', component: InitialRedirectComponent },
];

export const routingConfiguration: ExtraOptions = {
  paramsInheritanceStrategy: 'always',
};

@NgModule({
  imports: [RouterModule.forRoot(APP_ROUTES, routingConfiguration)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
