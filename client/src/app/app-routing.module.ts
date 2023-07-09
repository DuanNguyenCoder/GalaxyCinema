import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { NotFoundComponent } from './modules/not-found/not-found.component';

import { AuthGuard } from '../../src/app/core/guards/auth.guard';
import { MainComponent } from './modules/main/main.component';
import { OrderTicketComponent } from './modules/order-ticket/order-ticket.component';
import { SeatComponent } from './modules/order-ticket/select-seat/seat.component';
import { TicketComponent } from './modules/order-ticket/select-ticket/ticket.component';
import { ShowTimeComponent } from './modules/show-time/show-time.component';
import { ReviewComponent } from './modules/review/review.component';
import { FoodComponent } from './modules/order-ticket/select-food/food.component';
import { ConfirmComponent } from './modules/order-ticket/confirm/confirm.component';
import { OrderSuccessComponent } from './modules/order-ticket/order-success/order-success.component';
import { TicketShowtimeComponent } from './modules/main/ticket-showtime/ticket-showtime.component';

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
  },
  {
    path: 'ticket',
    component: OrderTicketComponent,
    children: [
      { path: 'selectTicket', component: TicketComponent },
      { path: 'selectSeat', component: SeatComponent },
      { path: 'selectFood', component: FoodComponent },
      { path: 'confirm', component: ConfirmComponent },
      { path: 'payment_infor', component: OrderSuccessComponent },
    ],
  },
  {
    path: 'show-time',
    component: ShowTimeComponent,
  },
  {
    path: 'movie',
    component: TicketShowtimeComponent,
  },
  {
    path: 'review',
    component: ReviewComponent,
  },

  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
