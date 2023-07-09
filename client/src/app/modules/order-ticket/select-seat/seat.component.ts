import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OrderTicketService } from 'src/app/core/services/order-ticket.service';
import { SeatService } from 'src/app/core/services/seat.service';
import { ToastService } from 'src/app/core/services/toast.service';
import {
  DateInfo,
  MovieShowTime,
  Seat,
} from 'src/app/shared/interface/project';

@Component({
  selector: 'app-seat',
  templateUrl: './seat.component.html',
  styleUrls: ['./seat.component.scss'],
})
export class SeatComponent implements OnInit {
  seats: Seat[] = [];
  dataMovie!: MovieShowTime;
  dataMovieShowTime!: any;
  seatOrdered: string[] = [];
  ticketsCount!: number;
  selectedSeatsCount: number = 0;
  rows = ['A', 'B', 'C', 'D', 'E', 'F'];
  dateFomatMovie!: DateInfo;

  constructor(
    private toastSer: ToastService,
    private router: Router,
    public orderTickSer: OrderTicketService,
    private seatSer: SeatService,
    private http: HttpClient
  ) {
    this.seats = seatSer.seats;
    this.ticketsCount = orderTickSer.getTicketCount();
    this.seatSer.getSeatOrdered();

    this.orderTickSer.currentMovie$.subscribe((res) => {
      this.dataMovie = res;
    });

    this.orderTickSer.currentShowTime$.subscribe((res) => {
      this.dataMovieShowTime = res;
    });

    // th1: xu ly tinh trang chon lai so luong ve
    if (this.orderTickSer.userSelectSeat$.getValue().length != 0) {
      this.selectedSeatsCount =
        this.orderTickSer.userSelectSeat$.getValue().length;
      console.warn('th1');
    }

    orderTickSer.allMovieByDate$.subscribe((res) => {
      if (res.day === 0) {
        const d = new Date();
        this.dateFomatMovie = res;
        if (this.dateFomatMovie.day === 0) {
          this.dateFomatMovie.day = d.getDate();
          this.dateFomatMovie.month = (d.getMonth() + 1).toString();
          this.dateFomatMovie.dayOfWeek = 'Thứ ' + (d.getDay() + 1);
          console.warn(this.dateFomatMovie);
        }
      } else {
        this.dateFomatMovie = res;
      }
    });
  }

  ngOnInit(): void {}

  seatsByRow(row: string): Seat[] {
    return this.seats.filter((seat) => seat.row === row);
  }

  toggleSeat(seat: Seat) {
    if (this.canSelectSeat(seat)) {
      if (!seat.selected) {
        this.orderTickSer.userSelectSeat$.next([
          ...this.orderTickSer.userSelectSeat$.getValue(),
          seat,
        ]);
      } else {
        this.orderTickSer.userSelectSeat$.next(
          this.orderTickSer.userSelectSeat$
            .getValue()
            .filter((res) => res != seat)
        );
      }
      seat.selected = !seat.selected;
      this.selectedSeatsCount += seat.selected ? 1 : -1;
    }
    console.warn(this.orderTickSer.userSelectSeat$.getValue());
    console.log(this.selectedSeatsCount);
  }

  canSelectSeat(seat: Seat): boolean {
    return (
      (seat.selected || this.selectedSeatsCount < this.ticketsCount) &&
      !this.seatSer.seatOrdered.includes(`${seat.row}` + ' ' + `${seat.number}`)
    );
  }

  nextStep() {
    const checkSelect =
      this.orderTickSer.getTicketCount() - this.selectedSeatsCount;
    if (checkSelect !== 0) {
      this.toastSer.showError('Thông báo', `${checkSelect} chưa vé chọn ghế`);
    } else {
      this.orderTickSer.stepBread$.next(
        this.orderTickSer.stepBread$.getValue() + 1
      );

      this.router.navigate(['/ticket/selectFood']);
    }
  }
  byteToImage(): string {
    console.warn(this.dataMovie);

    return 'data:image/png;base64,' + this.dataMovie.image;
  }
}
