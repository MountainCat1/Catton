export * from './account.service';
import { AccountService } from './account.service';
export * from './claims.service';
import { ClaimsService } from './claims.service';
export const APIS = [AccountService, ClaimsService];
