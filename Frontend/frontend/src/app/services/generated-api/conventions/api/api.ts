export * from './convention.service';
import { ConventionService } from './convention.service';
export * from './organizer.service';
import { OrganizerService } from './organizer.service';
export * from './ticketTemplate.service';
import { TicketTemplateService } from './ticketTemplate.service';
export const APIS = [ConventionService, OrganizerService, TicketTemplateService];
