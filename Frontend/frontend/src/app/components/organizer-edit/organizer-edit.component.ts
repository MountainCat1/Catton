import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import {
  OrganizerDto,
  OrganizerService,
  OrganizerUpdateDto,
  TicketTemplateService
} from "../../services/generated-api/conventions";
import { ActivatedRoute } from "@angular/router";
import { NavigationService } from "../../services/navigation.service";

export enum Roles {
  Guest = 'Guest',
  Owner = 'Owner',
  Helper = 'Helper',
  Moderator = 'Moderator',
  Announcer = 'Announcer',
  Administrator = 'Administrator',
}

@Component({
  selector: 'app-organizer-edit',
  templateUrl: './organizer-edit.component.html',
  styleUrls: ['./organizer-edit.component.scss']
})
export class OrganizerEditComponent implements OnInit {
  private accountId!: string;
  private conventionId!: string;
  organizerForm!: FormGroup;
  roles!: string[];
  organzier! : OrganizerDto;

  constructor(
    private fb: FormBuilder,
    private organizerService: OrganizerService,
    private route: ActivatedRoute,
    private navigationService: NavigationService
  ) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.conventionId = params['conventionId'];
      this.accountId = params['accountId'];
      this.loadOrganizer(this.conventionId, this.accountId);
    });
    this.initForm();
  }

  private loadOrganizer(conventionId: string, accountId: string) {
    return this.organizerService.apiConventionsConventionIdOrganizersOrganizerIdGet(conventionId, accountId)
      .subscribe(oprganizerDto => {
        this.organizerForm.patchValue(oprganizerDto);
        this.organzier = oprganizerDto;
      });
  }

  private initForm() {
    this.roles = Object.values(Roles);

    this.organizerForm = this.fb.group({
      role: [Roles.Guest, Validators.required],
    });
  }

  onSubmit() {
    if (!this.organizerForm.valid) {
      return;
    }
    console.log(this.organizerForm.value);

    const organizerUpdateDto: OrganizerUpdateDto = {
      role: this.organizerForm.value.role
    }

    this.organizerService.apiConventionsConventionIdOrganizersOrganizerIdPut(this.conventionId, this.accountId, this.organizerForm.value)
      .subscribe(async () => {
        await this.navigationService.toOrganizers();
      });
  }

  protected readonly Roles = Roles;
}
