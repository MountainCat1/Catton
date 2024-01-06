import {Component, OnInit} from '@angular/core';
import {Observable, tap} from "rxjs";
import {AttendeeService, TicketDto, TicketService} from "../../services/generated-api/conventions";
import {MatDialog} from "@angular/material/dialog";
import {ActivatedRoute} from "@angular/router";
import {SubdomainService} from "../../services/subdomain.service";
import {NavigationService} from "../../services/navigation.service";
import {map} from "rxjs/operators";
import {Location} from "@angular/common";
import {
  TicketDeleteConfirmDialogComponent
} from "./ticket-delete-confirm-dialog/ticket-delete-confirm-dialog.component";

@Component({
  selector: 'app-ticket-details',
  templateUrl: './ticket-details.component.html',
  styleUrls: ['./ticket-details.component.scss']
})
export class TicketDetailsComponent implements OnInit{
  private conventionId!: string;
  private ticketId!: string;

  public ticket$!: Observable<TicketDto>;

  private ticket! : TicketDto;

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
      this.ticket$ = this.ticketService.apiConventionsConventionIdTicketsTicketIdGet(this.conventionId, this.ticketId);
    });
  }

  openDeleteDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.ticket$
      .pipe(
        map(ticket => ({
          attendeeId : ticket.attendeeId,
          conventionId: this.conventionId,
          ticketId: this.ticketId
        })),
        tap(data => this.dialog.open(TicketDeleteConfirmDialogComponent, {
          width: '250px',
          enterAnimationDuration,
          exitAnimationDuration,
          data: data
        }))
      )
      .subscribe();
  }

  protected readonly console = console;
}
