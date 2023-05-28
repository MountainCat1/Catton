import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PublicPopupComponent } from './public-popup.component';

describe('PublicPopupComponent', () => {
  let component: PublicPopupComponent;
  let fixture: ComponentFixture<PublicPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PublicPopupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PublicPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
