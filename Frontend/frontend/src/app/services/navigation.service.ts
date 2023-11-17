import {Inject, Injectable} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {DOCUMENT} from "@angular/common";

@Injectable({
  providedIn: 'root',
})
export class NavigationService {

  constructor(
    @Inject(DOCUMENT) private document: Document,
    private router: Router,
    private activeRoute: ActivatedRoute) {
  }

  public async toConvention(conventionId: string) {
    var newHostname = new URL(this.changeSubdomain(conventionId));

    document.location.href = `${newHostname.protocol}//${newHostname.hostname}:${newHostname.port}`

    // await this.router.navigate([`c/${conventionId}`]);
  }

  public async toMenu() {
    const conventionId = this.getParam('conventionId')
    await this.router.navigate([`c/${conventionId}`]);
  }

  public toOrganizers = async () => {
    console.log('Xd')
    const conventionId = this.getParam('conventionId')
    await this.router.navigate([`c/${conventionId}/organizers`]);
  }

  public async toTickets() {
    const conventionId = this.getParam('conventionId')
    return await this.router.navigate([`c/${conventionId}/tickets`]);
  }

  public async toAttendees() {
    const conventionId = this.getParam('conventionId')
    return await this.router.navigate([`c/${conventionId}/attendees`]);
  }

  public async toAttendeeDetails(accountId: string) {
    const conventionId = this.getParam('conventionId')
    return await this.router.navigate([`c/${conventionId}/attendees/${accountId}`]);
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

  private getTopDomain() {
    // Get the full hostname
    const fullHostname = this.document.location.hostname;

    // Split the hostname by periods (.)
    const hostnameParts = fullHostname.split('.');

    // Extract the top-level domain (TLD)
    return hostnameParts[hostnameParts.length - 1];
  }

  changeSubdomain(newSubdomain: string): string {
    const {protocol, hostname, pathname} = window.location;

    var urlParts = document.URL
      .split('://')[1] // remove protocol
      .split('.');

    if(urlParts.length == 1){
      return `${protocol}//${newSubdomain}.${urlParts[0]}`;
    }

    urlParts[urlParts.length - 2] = newSubdomain;

    return `${protocol}//${urlParts.join('.')}`;
  }
}
