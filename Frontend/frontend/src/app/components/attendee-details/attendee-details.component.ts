import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {AttendeeDto, AttendeeService} from "../../services/generated-api/conventions";
import {SubdomainService} from "../../services/subdomain.service";
import {NavigationService} from "../../services/navigation.service";
import {Observable} from "rxjs";
import { Location } from '@angular/common'
@Component({
  selector: 'app-attendee-details',
  templateUrl: './attendee-details.component.html',
  styleUrls: ['./attendee-details.component.scss']
})
export class AttendeeDetailsComponent implements OnInit {
  private conventionId!: string;
  private attendeeId!: string;

  public attendee$!: Observable<AttendeeDto>;

  constructor(
    private route: ActivatedRoute,
    private attendeeService: AttendeeService,
    private subdomainService: SubdomainService,
    private navigationService: NavigationService,
    private location: Location
  ) {
  }

  back(): void {
    this.location.back()
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.conventionId = params['conventionId'];
      this.attendeeId = params['accountId'];
      this.attendee$ = this.attendeeService.apiConventionsConventionIdAttendeesAccountIdGet(this.conventionId, this.attendeeId);
    });

  }
}
