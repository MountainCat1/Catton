import { Component } from '@angular/core';
import {TicketTemplateCreateDto, TicketTemplateService} from "../../services/generated-api/conventions";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute} from "@angular/router";
import {NavigationService} from "../../services/navigation.service";

@Component({
  selector: 'app-ticket-template-create',
  templateUrl: './ticket-template-create.component.html',
  styleUrls: ['./ticket-template-create.component.scss']
})
export class TicketTemplateCreateComponent {
  private conventionId!: string;

  ticketTemplateForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private ticketTemplateService: TicketTemplateService,
    private route: ActivatedRoute,
    private navigationService: NavigationService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.conventionId = params['conventionId'];
    });

    this.ticketTemplateForm = this.fb.group({
      name: [null, Validators.required],
      description: [null, Validators.required],
      price: [null, [Validators.required, Validators.min(0.01)]]
      // add other fields here
    });
  }

  onSubmit() {
    if (this.ticketTemplateForm.valid) {
      console.log(this.ticketTemplateForm.value);
      const createDto : TicketTemplateCreateDto = {
        name: this.ticketTemplateForm.value.name,
        description: this.ticketTemplateForm.value.description,
        price: this.ticketTemplateForm.value.price,
      };

      this.ticketTemplateService.apiConventionsConventionIdTicketTemplatesPost(this.conventionId, this.ticketTemplateForm.value)
        .subscribe(async ticketTemplate => {
          console.log(ticketTemplate);
           await this.navigationService.toTicketTemplates();
        });
    }
  }
}
