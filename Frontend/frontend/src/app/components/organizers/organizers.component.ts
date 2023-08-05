import { Component } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {OrganizerDto, OrganizerService} from "../../services/generated-api/conventions";
import {Observable} from "rxjs";
import {getFriendlyErrorMessage} from "../../utilities/errorUtilities";
import {NavigationService} from "../../services/navigation.service";

@Component({
  selector: 'app-organizers',
  templateUrl: './organizers.component.html',
  styleUrls: ['./organizers.component.scss'],
  providers: [NavigationService]
})
export class OrganizersComponent {
  private conventionId! : string;
  organizers$!: Observable<Array<OrganizerDto>>;


  constructor(
    private route: ActivatedRoute,
    private organizerService : OrganizerService,
    private navigationService : NavigationService
    ) {
    navigationService.params()
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.conventionId = params['conventionId'];
      console.log(params )


      this.organizers$ = this.organizerService.apiConventionsConventionIdOrganizersGet(this.conventionId);
    });

  }

  protected readonly getFriendlyErrorMessage = getFriendlyErrorMessage;
}
