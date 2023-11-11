import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {AttendeeService} from "../../../services/generated-api/conventions";
import {ActivePerfRecorder} from "@angular/compiler-cli/src/ngtsc/perf";
import {ActivatedRoute} from "@angular/router";
import {NavigationService} from "../../../services/navigation.service";


export interface AttendeeDeleteConfirmDialog {
  attendeeUsername: string,
  attendeeId: string,
  conventionId: string
}

@Component({
  selector: 'app-attendee-delete-confirm',
  templateUrl: './attendee-delete-confirm-dialog.component.html',
})
export class AttendeeDeleteConfirmDialogComponent implements OnInit {
  private conventionId!: string;

  constructor(
    public dialogRef: MatDialogRef<AttendeeDeleteConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AttendeeDeleteConfirmDialog,
    private attendeeService: AttendeeService,
    private route: ActivatedRoute,
    private navigation: NavigationService
  ) {
  }

  ngOnInit(): void {

  }

  async removeAttendee() {
    this.attendeeService
      .apiConventionsConventionIdAttendeesAccountIdDelete(this.data.conventionId, this.data.attendeeId)
      .subscribe(async x => {
        await this.navigation.toAttendees()
      })
  }


}
