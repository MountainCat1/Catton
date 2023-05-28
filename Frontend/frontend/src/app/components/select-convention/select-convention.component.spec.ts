import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectConventionComponent } from './select-convention.component';

describe('SelectConventionComponent', () => {
  let component: SelectConventionComponent;
  let fixture: ComponentFixture<SelectConventionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectConventionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SelectConventionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
