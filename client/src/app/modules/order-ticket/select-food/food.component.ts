import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OrderTicketService } from 'src/app/core/services/order-ticket.service';

@Component({
  selector: 'app-food',
  templateUrl: './food.component.html',
  styleUrls: ['./food.component.scss'],
})
export class FoodComponent implements OnInit {
  constructor(
    private router: Router,
    public orderTickSer: OrderTicketService
  ) {}

  ngOnInit(): void {}

  nextStep() {
    this.orderTickSer.stepBread$.next(
      this.orderTickSer.stepBread$.getValue() + 1
    );
    this.router.navigate(['/ticket/confirm']);
  }

  addQuantityCombo(num: any) {
    const newQuan = num.getValue() + 1;
    num.next(newQuan);
  }

  subQuantityCombo(num: any) {
    const newQuan = num.getValue() - 1;
    if (newQuan < 0) {
      return;
    }
    num.next(newQuan);
  }
}
