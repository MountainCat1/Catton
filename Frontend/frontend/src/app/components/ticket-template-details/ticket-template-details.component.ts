import {Component} from '@angular/core';
import {Observable, tap} from "rxjs";
import {
  AttendeeDto,
  AttendeeService,
  TicketTemplateDto,
  TicketTemplateService
} from "../../services/generated-api/conventions";
import {MatDialog} from "@angular/material/dialog";
import {ActivatedRoute} from "@angular/router";
import {SubdomainService} from "../../services/subdomain.service";
import {NavigationService} from "../../services/navigation.service";
import {Location} from "@angular/common";
import {map} from "rxjs/operators";
import {
  AttendeeDeleteConfirmDialogComponent
} from "../attendee-details/attendee-delete-confirm/attendee-delete-confirm-dialog.component";
import {
  TicketTemplateDeleteConfirmComponent
} from "./ticket-template-delete-confirm/ticket-template-delete-confirm.component";

@Component({
  selector: 'app-ticket-template-details',
  templateUrl: './ticket-template-details.component.html',
  styleUrls: ['./ticket-template-details.component.scss']
})
export class TicketTemplateDetailsComponent {
  private conventionId!: string;
  private ticketTemplateId!: string;

  public ticketTemplate$!: Observable<TicketTemplateDto>;

  private ticketTemplate!: AttendeeDto;

  constructor(
    public dialog: MatDialog,
    private route: ActivatedRoute,
    private ticketTemplatesService: TicketTemplateService,
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
      this.ticketTemplateId = params['ticketTemplateId'];
      this.ticketTemplate$ = this.ticketTemplatesService.apiConventionsConventionIdTicketTemplatesTicketTemplateIdGet(this.conventionId, this.ticketTemplateId);
    });
  }

  openDeleteDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.ticketTemplate$
      .pipe(
        map(ticketTemplate => ({
          ticketTemplateName: ticketTemplate.name!,
          ticketTemplateId: ticketTemplate.id!,
          conventionId: this.conventionId
        })),
        tap(data => this.dialog.open(TicketTemplateDeleteConfirmComponent, {
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
