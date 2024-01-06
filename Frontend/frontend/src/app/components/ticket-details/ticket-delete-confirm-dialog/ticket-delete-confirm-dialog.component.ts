import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {AttendeeService, TicketService} from "../../../services/generated-api/conventions";
import {ActivatedRoute} from "@angular/router";
import {NavigationService} from "../../../services/navigation.service";

export interface TicketDeleteConfirmDialog {
  ticketId: string,
  attendeeId: string,
  conventionId: string
}

@Component({
  selector: 'app-ticket-delete-confirm-dialog',
  templateUrl: './ticket-delete-confirm-dialog.component.html',
})
export class TicketDeleteConfirmDialogComponent {
  private conventionId!: string;

  constructor(
    public dialogRef: MatDialogRef<TicketDeleteConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: TicketDeleteConfirmDialog,
    private ticketService: TicketService,
    private route: ActivatedRoute,
    private navigation: NavigationService
  ) {
  }

  ngOnInit(): void {

  }

  async removeTicket() {
    this.ticketService
      .apiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDelete(
        this.data.conventionId,
        this.data.ticketId,
        this.data.attendeeId)
      .subscribe(async x => {
        await this.navigation.toTickets()
      })
  }
}
