import {Injectable} from '@angular/core';
import {ActivatedRoute, ActivationEnd, Params, Router} from "@angular/router";
import {filter, firstValueFrom, lastValueFrom} from "rxjs";
import {map} from "rxjs/operators";

@Injectable({
  providedIn: 'root',
})
export class NavigationService {

  constructor(
    private router: Router,
    private activeRoute: ActivatedRoute) {
  }

  public toMenu = async () => {
    this.activeRoute.params.subscribe(params => {
      const conventionId = params["conventionId"];
      this.router.navigate([`/${conventionId}`]);
    })
  }

  public toOrganizers = async () => {

    this.activeRoute.params.subscribe(params => {
      const conventionId = params["conventionId"];
      this.router.navigate([`/${conventionId}/organizers`]);
    })
  }

  public async toTickets(): Promise<boolean> {
    const params = await this.getParams();
    const conventionId = params['conventionId'];

    if (conventionId == undefined) {
      this.warnAboutEmptyParams()
    }

    return await this.router.navigate([`/${conventionId}/tickets`]);
  }

  public async toSelectConvention() {
    return await this.router.navigate([`/select-convention`]);
  }

  private async getParams(): Promise<Params> {

    return await lastValueFrom(this.activeRoute.params);
  }

  private warnAboutEmptyParams = () => {
    console.warn("Route param is undefined. Please check this: " +
      "https://stackoverflow.com/questions/39977962/angular-2-0-2-activatedroute-is-empty-in-a-service")
  }

  params()  {
    this.activeRoute.params.subscribe(x => {
      console.log(x)
    })
  }
}
