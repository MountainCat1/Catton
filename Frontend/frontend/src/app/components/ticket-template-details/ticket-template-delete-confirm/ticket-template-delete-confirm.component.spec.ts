import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketTemplateDeleteConfirmComponent } from './ticket-template-delete-confirm.component';

describe('TicketTemplateDeleteConfirmComponent', () => {
  let component: TicketTemplateDeleteConfirmComponent;
  let fixture: ComponentFixture<TicketTemplateDeleteConfirmComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TicketTemplateDeleteConfirmComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TicketTemplateDeleteConfirmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
