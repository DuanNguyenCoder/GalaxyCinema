import { Component, Input, OnInit } from '@angular/core';
import { OrderTicketService } from 'src/app/core/services/order-ticket.service';

@Component({
  selector: 'app-bill',
  templateUrl: './bill.component.html',
  styleUrls: ['./bill.component.scss'],
})
export class BillComponent implements OnInit {
  public adultQuantity!: number;
  public childQuantity!: number;
  public cb1_22!: number;
  public cb1_32!: number;
  public cb2_32!: number;
  public cbf1_snack!: number;
  public cbf2_snack!: number;
  public cbf2_food!: number;
  public movieName?: string;

  constructor(public orderTickSer: OrderTicketService) {
    orderTickSer.adultQuantity$.subscribe((res) => (this.adultQuantity = res));
    orderTickSer.childQuantity$.subscribe((res) => (this.childQuantity = res));
    orderTickSer.cb1_22$.subscribe((res) => (this.cb1_22 = res));
    orderTickSer.cb1_32$.subscribe((res) => (this.cb1_32 = res));
    orderTickSer.cb2_32$.subscribe((res) => (this.cb2_32 = res));
    orderTickSer.cbf1_snack$.subscribe((res) => (this.cbf1_snack = res));
    orderTickSer.cbf2_snack$.subscribe((res) => (this.cbf2_snack = res));
    orderTickSer.cbf2_food$.subscribe((res) => (this.cbf2_food = res));
    orderTickSer.currentMovie$.subscribe((res) => (this.movieName = res.name));
  }

  ngOnInit(): void {}
}
