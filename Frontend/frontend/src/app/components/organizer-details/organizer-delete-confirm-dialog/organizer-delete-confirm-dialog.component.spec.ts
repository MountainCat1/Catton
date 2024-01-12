import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganizerDeleteConfirmDialogComponent } from './organizer-delete-confirm-dialog.component';

describe('OrganizerDeleteConfirmDialogComponent', () => {
  let component: OrganizerDeleteConfirmDialogComponent;
  let fixture: ComponentFixture<OrganizerDeleteConfirmDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrganizerDeleteConfirmDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrganizerDeleteConfirmDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
