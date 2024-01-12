import { Component } from '@angular/core';
import {Observable, tap} from "rxjs";
import {OrganizerDto, OrganizerService, TicketDto, TicketService} from "../../services/generated-api/conventions";
import {MatDialog} from "@angular/material/dialog";
import {ActivatedRoute} from "@angular/router";
import {NavigationService} from "../../services/navigation.service";
import {Location} from "@angular/common";
import {map} from "rxjs/operators";
import {
  TicketDeleteConfirmDialogComponent
} from "../ticket-details/ticket-delete-confirm-dialog/ticket-delete-confirm-dialog.component";
import {
  OrganizerDeleteConfirmDialogComponent
} from "./organizer-delete-confirm-dialog/organizer-delete-confirm-dialog.component";

@Component({
  selector: 'app-organizer-details',
  templateUrl: './organizer-details.component.html',
  styleUrls: ['./organizer-details.component.scss']
})
export class OrganizerDetailsComponent {
  private conventionId!: string;
  private accountId!: string;

  public organizer$!: Observable<OrganizerDto>;

  private organizer! : OrganizerDto;

  constructor(
    public dialog: MatDialog,
    private route: ActivatedRoute,
    private organizerService: OrganizerService,
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
      this.accountId = params['accountId'];
      this.organizer$ = this.organizerService.apiConventionsConventionIdOrganizersOrganizerIdGet(this.conventionId, this.accountId);
    });
  }

  openDeleteDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.organizer$
      .pipe(
        map(organizer => ({
          accountId : organizer.accountId,
          conventionId: this.conventionId,
        })),
        tap(data => this.dialog.open(OrganizerDeleteConfirmDialogComponent, {
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
