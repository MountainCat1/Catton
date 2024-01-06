import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketTemplateEditComponent } from './ticket-template-edit.component';

describe('TicketTemplateEditComponent', () => {
  let component: TicketTemplateEditComponent;
  let fixture: ComponentFixture<TicketTemplateEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TicketTemplateEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TicketTemplateEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
