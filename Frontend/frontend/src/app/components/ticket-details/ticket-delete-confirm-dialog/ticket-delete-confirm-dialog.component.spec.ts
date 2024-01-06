import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketDeleteConfirmDialogComponent } from './ticket-delete-confirm-dialog.component';

describe('TicketDeleteConfirmDialogComponent', () => {
  let component: TicketDeleteConfirmDialogComponent;
  let fixture: ComponentFixture<TicketDeleteConfirmDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TicketDeleteConfirmDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TicketDeleteConfirmDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
