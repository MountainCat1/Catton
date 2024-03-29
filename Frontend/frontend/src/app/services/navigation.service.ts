import {Injectable} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";

@Injectable({
  providedIn: 'root',
})
export class NavigationService {

  constructor(
    private router: Router,
    private activeRoute: ActivatedRoute) {
  }

  public async toConvention(conventionId: string) {
    await this.router.navigate([`c/${conventionId}`]);
  }

  public async toMenu() {
    const conventionId = this.getParam('conventionId')
    await this.router.navigate([`c/${conventionId}`]);
  }

  public toOrganizers = async () => {
    const conventionId = this.getParam('conventionId')
    await this.router.navigate([`c/${conventionId}/organizers`]);
  }

  public toOrganizerDetails = async (accountId: string) => {
    const conventionId = this.getParam('conventionId')
    await this.router.navigate([`c/${conventionId}/organizers/${accountId}`]);
  }

  async toCreateOrganizer() {
    const conventionId = this.getParam('conventionId')
    await this.router.navigate([`c/${conventionId}/organizers/create`]);
  }

  async toEditOrganizer(accountId : string) {
    const conventionId = this.getParam('conventionId')
    await this.router.navigate([`c/${conventionId}/organizers/edit/${accountId}`]);
  }

  public async toTickets() {
    const conventionId = this.getParam('conventionId')
    return await this.router.navigate([`c/${conventionId}/tickets`]);
  }

  public async toAttendees() {
    const conventionId = this.getParam('conventionId')
    return await this.router.navigate([`c/${conventionId}/attendees`]);
  }
  public async toAttendeeDetails(accountId : string) {
    const conventionId = this.getParam('conventionId')
    return await this.router.navigate([`c/${conventionId}/attendees/${accountId}`]);
  }

  public async toTicketTemplates() {
    const conventionId = this.getParam('conventionId')
    return await this.router.navigate([`c/${conventionId}/ticket-templates`]);
  }

  async toTicketTemplateDetails(id : string) {
    const conventionId = this.getParam('conventionId')
    return await this.router.navigate([`c/${conventionId}/ticket-templates/details/${id}`]);
  }

  async toTicketTemplateCreate(id : string) {
    const conventionId = this.getParam('conventionId')
    return await this.router.navigate([`c/${conventionId}/ticket-templates/create`]);
  }

  async toTicketTemplateEdit(ticketId : string) {
    const conventionId = this.getParam('conventionId')
    return await this.router.navigate([`c/${conventionId}/ticket-templates/edit/${ticketId}`]);
  }

  public async navigateToTickets() {
    const conventionId = this.getParam('conventionId')
    return await this.router.navigate([`c/${conventionId}/tickets`]);
  }

  async toTicketDetails(ticketId : string) {
    const conventionId = this.getParam('conventionId')
    return await this.router.navigate([`c/${conventionId}/tickets/${ticketId}`]);
  }

  async toSignIn() {
    return await this.router.navigate([`/sign-in`]);
  }

  public async toSelectConvention() {
    return await this.router.navigate([`/select-convention`]);
  }
  private getParam(key: string) {
    let child = this.activeRoute.snapshot;

    while (child.firstChild) {
      child = child.firstChild;
    }

    return child.params[key];
  }

  private warnAboutEmptyParams = () => {
    console.warn("Route param is undefined. Please check this: " +
      "https://stackoverflow.com/questions/39977962/angular-2-0-2-activatedroute-is-empty-in-a-service")
  }
}
