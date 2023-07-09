import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OrderTicketService } from 'src/app/core/services/order-ticket.service';
import { SeatService } from 'src/app/core/services/seat.service';

@Component({
  selector: 'app-order-ticket',
  templateUrl: './order-ticket.component.html',
  styleUrls: ['./order-ticket.component.scss'],
})
export class OrderTicketComponent implements OnDestroy {
  constructor(
    private router: Router,
    private orderTickSer: OrderTicketService,
    private seatSer: SeatService
  ) {}
  ngOnDestroy(): void {
    console.warn('-----------------chay destroy---------------');
    this.orderTickSer.resetOrder();
    this.seatSer.turnOffAllSeat();
  }

  nextStep() {
    this.router.navigate(['/ticket/selectSeat']);
  }
}
