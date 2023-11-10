import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {AttendeeService} from "../../../services/generated-api/conventions";


export interface AttendeeDeleteConfirmDialog {
  attendeeUsername: string,
  attendeeId: string
}

@Component({
  selector: 'app-attendee-delete-confirm',
  templateUrl: './attendee-delete-confirm-dialog.component.html',
})
export class AttendeeDeleteConfirmDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<AttendeeDeleteConfirmDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: AttendeeDeleteConfirmDialog,
    private attendeeService : AttendeeService
  ) {}

  removeAttendee() {
    console.log("Attendee is not removed coz this shit is not implemented")
    // TODO: IMPLEMENT THIS!
  }
}
