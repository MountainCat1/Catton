import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {AttendeeService, TicketTemplateService} from "../../../services/generated-api/conventions";
import {ActivatedRoute} from "@angular/router";
import {NavigationService} from "../../../services/navigation.service";

export interface TicketTemplateDeleteConfirmDialogData {
  ticketTemplateName: string,
  ticketTemplateId: string,
  conventionId: string
}


@Component({
  selector: 'app-ticket-template-delete-confirm',
  templateUrl: './ticket-template-delete-confirm.component.html',
})
export class TicketTemplateDeleteConfirmComponent {
  private conventionId!: string;

  constructor(
    public dialogRef: MatDialogRef<TicketTemplateDeleteConfirmComponent>,
    @Inject(MAT_DIALOG_DATA) public data: TicketTemplateDeleteConfirmDialogData,
    private ticketTemplateService: TicketTemplateService,
    private route: ActivatedRoute,
    private navigation: NavigationService
  ) {
  }

  ngOnInit(): void {

  }

  async removeTicketTemplate() {
    this.ticketTemplateService
      .apiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete(this.data.conventionId, this.data.ticketTemplateId)
      .subscribe(async x => {
        await this.navigation.toTicketTemplates()
      })
  }
}
