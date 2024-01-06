import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketTemplateDetailsComponent } from './ticket-template-details.component';

describe('TicketTemplateDetailsComponent', () => {
  let component: TicketTemplateDetailsComponent;
  let fixture: ComponentFixture<TicketTemplateDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TicketTemplateDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TicketTemplateDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
