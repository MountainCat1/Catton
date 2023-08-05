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
import {PublicComponent} from "./generic-components/public/public.component";
import {SecureComponent} from "./generic-components/secure/secure.component";
import {of} from "rxjs";
import {PublicPopupComponent} from "./generic-components/public-popup/public-popup.component";
import {AuthService} from "./services/auth.service";
import {SelectConventionComponent} from "./components/select-convention/select-convention.component";
import {MainMenuComponent} from "./components/main-menu/main-menu.component";
import {OrganizersComponent} from "./components/organizers/organizers.component";

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

const PUBLIC_ROUTES: Routes = []
const PUBLIC_POPUP_ROUTES: Routes = [
  {path: 'sign-in', component: SignInComponent}
]

const SECURE_ROUTES_CONVENTION_SELECTED = [
  {path: '', component: MainMenuComponent},
  {path: 'organizers', component: OrganizersComponent},
]

const SECURE_ROUTES: Routes = [
  {path: '', pathMatch: "full", redirectTo: '/select-convention'},
  {path: 'select-convention', component: SelectConventionComponent},
  {path: ':conventionId', children: SECURE_ROUTES_CONVENTION_SELECTED},
]

const APP_ROUTES: Routes = [
  {path: '', component: SecureComponent, canActivate: [guard], data: {title: 'Secure Views'}, children: SECURE_ROUTES},
  {path: '', component: PublicPopupComponent, data: {title: "Public Popups"}, children: PUBLIC_POPUP_ROUTES},
  {path: '', component: PublicComponent, data: {title: 'Public Views'}, children: PUBLIC_ROUTES},
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
