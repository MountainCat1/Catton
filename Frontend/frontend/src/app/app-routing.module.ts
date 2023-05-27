import {inject, NgModule} from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivateFn,
  Router,
  RouterModule,
  RouterStateSnapshot,
  Routes
} from '@angular/router';
import {SignInComponent} from "./components/sign-in/sign-in.component";
import {PublicComponent} from "./generic-components/public/public.component";
import {SecureComponent} from "./generic-components/secure/secure.component";
import {catchError, of} from "rxjs";
import {PublicPopupComponent} from "./generic-components/public-popup/public-popup.component";
import {AuthenticationService} from "./services/openapi-generated";
import {AuthService} from "./services/auth.service";
import {SelectConventionComponent} from "./components/select-convention/select-convention.component";

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

const PUBLIC_ROUTES: Routes = [
]
const PUBLIC_POPUP_ROUTES: Routes = [
  {path: 'sign-in', component: SignInComponent}
]
const SECURE_ROUTES: Routes = [
  {path: 'convetions', component: SelectConventionComponent}
]


const APP_ROUTES: Routes = [
  {path: '', component: SecureComponent, canActivate: [guard], data: {title: 'Secure Views'}, children: SECURE_ROUTES},
  {path: '', component: PublicPopupComponent, data: {title: "Public Popups"}, children: PUBLIC_POPUP_ROUTES},
  {path: '', component: PublicComponent, data: {title: 'Public Views'}, children: PUBLIC_ROUTES},
];

@NgModule({
  imports: [RouterModule.forRoot(APP_ROUTES)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
