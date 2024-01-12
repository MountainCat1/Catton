import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {OrganizerService, TicketService} from "../../../services/generated-api/conventions";
import {ActivatedRoute} from "@angular/router";
import {NavigationService} from "../../../services/navigation.service";

export interface OrganizerDeleteConfirmDialog {
  accountId: string,
  conventionId: string
}

@Component({
  selector: 'app-organizer-delete-confirm-dialog',
  templateUrl: './organizer-delete-confirm-dialog.component.html',
})
export class OrganizerDeleteConfirmDialogComponent {
  private conventionId!: string;

  constructor(
    public dialogRef: MatDialogRef<OrganizerDeleteConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: OrganizerDeleteConfirmDialog,
    private organizerService: OrganizerService,
    private route: ActivatedRoute,
    private navigation: NavigationService
  ) {
  }

  ngOnInit(): void {

  }

  async removeTicket() {
    this.organizerService
      .apiConventionsConventionIdOrganizersOrganizerIdDelete(
        this.data.conventionId,
        this.data.accountId)
      .subscribe(async x => {
        await this.navigation.toTickets()
      })
  }
}
