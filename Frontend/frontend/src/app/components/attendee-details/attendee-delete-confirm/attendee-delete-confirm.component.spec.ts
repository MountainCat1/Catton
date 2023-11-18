import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendeeDeleteConfirmComponent } from './attendee-delete-confirm.component';

describe('AttendeeDeleteConfirmComponent', () => {
  let component: AttendeeDeleteConfirmComponent;
  let fixture: ComponentFixture<AttendeeDeleteConfirmComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AttendeeDeleteConfirmComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AttendeeDeleteConfirmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
