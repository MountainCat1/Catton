import {Component, OnInit} from '@angular/core';
import {TicketTemplateService} from "../../services/generated-api/conventions";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute} from "@angular/router";
import {NavigationService} from "../../services/navigation.service";

@Component({
  selector: 'app-ticket-template-edit',
  templateUrl: './ticket-template-edit.component.html',
  styleUrls: ['./ticket-template-edit.component.scss']
})
export class TicketTemplateEditComponent implements OnInit {
  private ticketTemplateId!: string;
  private conventionId!: string;
  ticketTemplateForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private ticketTemplateService: TicketTemplateService,
    private route: ActivatedRoute,
    private navigationService: NavigationService
  ) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.conventionId = params['conventionId'];
      this.ticketTemplateId = params['ticketTemplateId'];
      this.loadTicketTemplate(this.conventionId, this.ticketTemplateId);
    });

    this.initForm();
  }

  private initForm() {
    this.ticketTemplateForm = this.fb.group({
      name: [null, Validators.required],
      description: [null, Validators.required],
      price: [null, [Validators.required, Validators.min(0.01)]]
      // add other fields here
    });
  }

  private loadTicketTemplate(conventionId: string, ticketTemplateId: string) {
    this.ticketTemplateService.apiConventionsConventionIdTicketTemplatesTicketTemplateIdGet(conventionId, ticketTemplateId)
      .subscribe(ticketTemplate => {
        this.ticketTemplateForm.patchValue(ticketTemplate);
      });
  }

  onSubmit() {
    if (!this.ticketTemplateForm.valid) {
      return;
    }
    console.log(this.ticketTemplateForm.value);
    this.ticketTemplateService.apiConventionsConventionIdTicketTemplatesTicketTemplateIdPut(this.conventionId, this.ticketTemplateId, this.ticketTemplateForm.value)
      .subscribe(async () => {
        await this.navigationService.toTicketTemplates();
      });

  }
}
