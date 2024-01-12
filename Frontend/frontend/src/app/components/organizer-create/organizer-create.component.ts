import {Component} from '@angular/core';
import {
  OrganizerCreateDto,
  OrganizerService,
  TicketTemplateCreateDto,
  TicketTemplateService
} from "../../services/generated-api/conventions";
import {ActivatedRoute} from "@angular/router";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {NavigationService} from "../../services/navigation.service";

@Component({
  selector: 'app-organizer-create',
  templateUrl: './organizer-create.component.html',
  styleUrls: ['./organizer-create.component.scss']
})
export class OrganizerCreateComponent {
  private conventionId!: string;

  organizerForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private organizerService: OrganizerService,
    private route: ActivatedRoute,
    private navigationService: NavigationService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.conventionId = params['conventionId'];
    });

    this.organizerForm = this.fb.group({
      accountId: [null, Validators.required],
    });
  }

  onSubmit() {
    if (this.organizerForm.valid) {
      console.log(this.organizerForm.value);
      const createDto : OrganizerCreateDto = {
        accountId: this.organizerForm.value.accountId,
      };

      this.organizerService.apiConventionsConventionIdOrganizersPost(this.conventionId, this.organizerForm.value)
        .subscribe(async ticketTemplate => {
          console.log(ticketTemplate);
          await this.navigationService.toOrganizers();
        });
    }
  }

  async createOrganizer() {
    const createDto: OrganizerCreateDto = {
      accountId: "string",
    }
    this.organizerService.apiConventionsConventionIdOrganizersPost(this.conventionId, createDto).subscribe(x => {
      console.log(x);
    })
  }
}
