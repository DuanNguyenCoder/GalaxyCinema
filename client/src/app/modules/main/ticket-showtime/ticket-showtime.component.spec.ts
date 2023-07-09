import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketShowtimeComponent } from './ticket-showtime.component';

describe('TicketShowtimeComponent', () => {
  let component: TicketShowtimeComponent;
  let fixture: ComponentFixture<TicketShowtimeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TicketShowtimeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TicketShowtimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
