import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketTemplatesComponent } from './ticket-templates.component';

describe('TicketTemplatesComponent', () => {
  let component: TicketTemplatesComponent;
  let fixture: ComponentFixture<TicketTemplatesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TicketTemplatesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TicketTemplatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
