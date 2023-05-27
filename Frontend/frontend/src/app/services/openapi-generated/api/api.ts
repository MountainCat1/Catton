export * from './authentication.service';
import { AuthenticationService } from './authentication.service';
export * from './claims.service';
import { ClaimsService } from './claims.service';
export * from './emailPasswordAuthentication.service';
import { EmailPasswordAuthenticationService } from './emailPasswordAuthentication.service';
export const APIS = [AuthenticationService, ClaimsService, EmailPasswordAuthenticationService];
