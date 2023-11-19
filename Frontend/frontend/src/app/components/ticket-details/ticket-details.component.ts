import {Component, OnInit} from '@angular/core';
import {Observable, tap} from "rxjs";
import {AttendeeService, TicketDto, TicketService} from "../../services/generated-api/conventions";
import {MatDialog} from "@angular/material/dialog";
import {ActivatedRoute} from "@angular/router";
import {SubdomainService} from "../../services/subdomain.service";
import {NavigationService} from "../../services/navigation.service";
import {map} from "rxjs/operators";
import {Location} from "@angular/common";

@Component({
  selector: 'app-ticket-details',
  templateUrl: './ticket-details.component.html',
  styleUrls: ['./ticket-details.component.scss']
})
export class TicketDetailsComponent implements OnInit{
  private conventionId!: string;
  private ticketId!: string;

  public attendee$!: Observable<TicketDto>;

  private attendee! : TicketDto;

  constructor(
    public dialog: MatDialog,
    private route: ActivatedRoute,
    private ticketService: TicketService,
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
      this.ticketId = params['ticketId'];
      this.attendee$ = this.ticketService.apiConventionsConventionIdTicketsTicketIdGet(this.conventionId, this.ticketId);
    });
  }

  protected readonly console = console;
}
