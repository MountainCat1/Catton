export * from './attendee.service';
import { AttendeeService } from './attendee.service';
export * from './convention.service';
import { ConventionService } from './convention.service';
export * from './organizer.service';
import { OrganizerService } from './organizer.service';
export * from './ticketTemplate.service';
import { TicketTemplateService } from './ticketTemplate.service';
export const APIS = [AttendeeService, ConventionService, OrganizerService, TicketTemplateService];
