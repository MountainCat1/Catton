import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketTemplateCreateComponent } from './ticket-template-create.component';

describe('TicketTemplateCreateComponent', () => {
  let component: TicketTemplateCreateComponent;
  let fixture: ComponentFixture<TicketTemplateCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TicketTemplateCreateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TicketTemplateCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
