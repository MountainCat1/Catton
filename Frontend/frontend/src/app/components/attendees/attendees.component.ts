import { Component } from '@angular/core';
import {Observable} from "rxjs";
import {AttendeeDto, AttendeeService, OrganizerDto, OrganizerService} from "../../services/generated-api/conventions";
import {ActivatedRoute} from "@angular/router";
import {NavigationService} from "../../services/navigation.service";
import {getFriendlyErrorMessage} from "../../utilities/errorUtilities";

@Component({
  selector: 'app-attendees',
  templateUrl: './attendees.component.html',
  styleUrls: ['./attendees.component.scss']
})
export class AttendeesComponent {
  private conventionId! : string;
  attendees$!: Observable<Array<AttendeeDto>>;


  constructor(
    private route: ActivatedRoute,
    private attendeeService : AttendeeService,
    private navigationService : NavigationService
  ) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.conventionId = params['conventionId'];
      this.attendees$ = this.attendeeService.apiConventionsConventionIdAttendeesGet(this.conventionId);
    });

  }

  protected readonly getFriendlyErrorMessage = getFriendlyErrorMessage;
}
