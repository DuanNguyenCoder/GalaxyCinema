import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Seat } from 'src/app/shared/interface/project';
import { environment } from 'src/environments/environment';
import { OrderTicketService } from './order-ticket.service';

@Injectable({
  providedIn: 'root',
})
export class SeatService {
  // Tạo mảng ghế

  public seats: Seat[] = [];
  public rows = ['A', 'B', 'C', 'D', 'E', 'F'];
  public seatOrdered: string[] = [];

  constructor(
    private http: HttpClient,
    private orderTickSer: OrderTicketService
  ) {
    this.generateSeat();
  }

  generateSeat() {
    this.rows.forEach((row) => {
      for (let i = 1; i <= 14; i++) {
        const seat: Seat = {
          number: i,
          selected: false,
          row: row,
          ordered: false,
        };
        this.seats.push(seat);
      }
    });
  }

  turnOffAllSeat() {
    if (this.seats.length !== 0) {
      this.seats.forEach((seat) => {
        for (let i = 1; i <= 14; i++) {
          if (seat.selected || seat.ordered) {
            seat.selected = false;
            seat.ordered = false;
          }
        }
      });
    }
  }

  getSeatOrdered() {
    console.warn('hello');

    this.http
      .get<any>(
        environment.BASE_URL + 'movie/' + this.orderTickSer.bill.showTimeID
      )
      .subscribe((res) => {
        this.seatOrdered = res;

        for (const seat of this.seats) {
          // Tách số và hàng của ghế
          // const [row, number] = seat.number.toString().split(' ');

          // Kiểm tra xem ghế có trong danh sách đã ordered hay không
          if (res.includes(`${seat.row} ${seat.number}`)) {
            seat.ordered = true;
          }
        }

        console.warn(this.seats);
      });
  }
}
