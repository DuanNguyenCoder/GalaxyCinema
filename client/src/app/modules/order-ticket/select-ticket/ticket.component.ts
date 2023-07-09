import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DateService } from 'src/app/core/services/date.service';
import { OrderTicketService } from 'src/app/core/services/order-ticket.service';
import { ToastService } from 'src/app/core/services/toast.service';
import { TypeTicket } from 'src/app/shared/interface/enum';
import {
  DateInfo,
  Movie,
  MovieShowTime,
} from 'src/app/shared/interface/project';
@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.scss'],
})
export class TicketComponent implements OnInit {
  public dataMovie!: MovieShowTime;
  public dataMovieShowTime!: any;
  public dateFomatMovie!: DateInfo;
  public adultQuantity!: number;
  public childQuantity!: number;
  public adultTotal!: number;
  public childTotal!: number;
  public type!: TypeTicket;

  constructor(
    private orderTickSer: OrderTicketService,
    private router: Router,
    private toastSer: ToastService,
    private dateSer: DateService
  ) {
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
    orderTickSer.currentMovie$.subscribe((res) => (this.dataMovie = res));
    orderTickSer.currentShowTime$.subscribe(
      (res) => (this.dataMovieShowTime = res)
    );
    this.orderTickSer.adultQuantity$.subscribe((res) => {
      this.adultQuantity = res;
      console.warn(res);
    });
    this.orderTickSer.childQuantity$.subscribe((res) => {
      this.childQuantity = res;
    });
    this.adultTotal = 0;
    this.childTotal = 0;

    console.warn(
      'showTime id: ' +
        this.dataMovieShowTime.showTimeID +
        '---' +
        'film name: ' +
        this.dataMovie.name
    );
  }

  ngOnInit(): void {}

  byteToImage(): string {
    console.warn(this.dataMovie);

    return 'data:image/png;base64,' + this.dataMovie.image;
  }

  increment(type: TypeTicket) {
    if (type === TypeTicket.adult) {
      this.adultQuantity += 1;
      this.orderTickSer.adultQuantity$.next(this.adultQuantity);
    } else if (type === TypeTicket.children) {
      this.childQuantity += 1;
      this.orderTickSer.childQuantity$.next(this.childQuantity);
    }
    this.calculate(type);
  }

  decrement(type: TypeTicket) {
    if (type === TypeTicket.adult) {
      this.adultQuantity === 0
        ? (this.adultQuantity = 0)
        : (this.adultQuantity -= 1);
      this.orderTickSer.adultQuantity$.next(this.adultQuantity);
    } else if (type === TypeTicket.children) {
      this.childQuantity === 0
        ? (this.childQuantity = 0)
        : (this.childQuantity -= 1);
      this.orderTickSer.childQuantity$.next(this.childQuantity);
    }
    this.calculate(type);
  }

  calculate(type: TypeTicket) {
    if (type === TypeTicket.adult) {
      this.adultTotal = 75000 * this.adultQuantity;
    } else if (type === TypeTicket.children) {
      this.childTotal = 60000 * this.childQuantity;
    }
  }

  nextStep() {
    if (
      this.orderTickSer.adultQuantity$.getValue() === 0 &&
      this.orderTickSer.childQuantity$.getValue() === 0
    ) {
      this.toastSer.showError('Thông báo', 'Bạn chưa chọn số lượng vé');
    } else {
      this.orderTickSer.stepBread$.next(
        this.orderTickSer.stepBread$.getValue() + 1
      );
      this.router.navigate(['/ticket/selectSeat']);
    }
  }
}
