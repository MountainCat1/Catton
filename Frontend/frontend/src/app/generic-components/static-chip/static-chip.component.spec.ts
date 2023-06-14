import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaticChipComponent } from './static-chip.component';

describe('StaticChipComponent', () => {
  let component: StaticChipComponent;
  let fixture: ComponentFixture<StaticChipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StaticChipComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StaticChipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
