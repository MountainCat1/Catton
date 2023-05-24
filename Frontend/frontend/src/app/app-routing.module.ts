import {inject, NgModule} from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivateFn,
  Router,
  RouterModule,
  RouterStateSnapshot,
  Routes
} from '@angular/router';
import {SignInComponent} from "./sign-in/sign-in.component";
import {PublicComponent} from "./public/public.component";
import {SecureComponent} from "./secure/secure.component";
import {catchError, of} from "rxjs";
import {PublicPopupComponent} from "./public-popup/public-popup.component";

const guard: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  // const authService = inject(AuthenticationService);
  // const router = inject(Router);

  return of(true);
};

const PUBLIC_ROUTES: Routes = [
]
const PUBLIC_POPUP_ROUTES: Routes = [
  {path: 'sign-in', component: SignInComponent}
]
const SECURE_ROUTES: Routes = [
]


const APP_ROUTES: Routes = [
  // { path: '', redirectTo: '', pathMatch: 'full', },
  {path: '', component: SecureComponent, canActivate: [guard], data: {title: 'Secure Views'}, children: SECURE_ROUTES},
  {path: '', component: PublicPopupComponent, data: {title: "Public Popups"}, children: PUBLIC_POPUP_ROUTES},
  {path: '', component: PublicComponent, data: {title: 'Public Views'}, children: PUBLIC_ROUTES},
];

@NgModule({
  imports: [RouterModule.forRoot(APP_ROUTES)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
