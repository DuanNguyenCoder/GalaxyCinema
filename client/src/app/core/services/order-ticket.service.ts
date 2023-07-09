import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import {
  Bill,
  DateInfo,
  Movie,
  MovieShowTime,
  Product,
  Seat,
} from 'src/app/shared/interface/project';
import { SeatService } from './seat.service';
import { ClientService } from './client.service';

@Injectable({
  providedIn: 'root',
})
export class OrderTicketService {
  /// tao bill
  public bill: Bill = new Bill();
  private product: Product[] = [];

  //// số lượng
  public adultQuantity$ = new BehaviorSubject<number>(0);
  public childQuantity$ = new BehaviorSubject<number>(0);

  public cb1_22$ = new BehaviorSubject<number>(0);
  public cb1_32$ = new BehaviorSubject<number>(0);
  public cb2_32$ = new BehaviorSubject<number>(0);
  public cbf1_snack$ = new BehaviorSubject<number>(0);
  public cbf2_snack$ = new BehaviorSubject<number>(0);
  public cbf2_food$ = new BehaviorSubject<number>(0);
  /////

  //// danh sách ghế mà người dùng chọn trong bill
  public userSelectSeat$ = new BehaviorSubject<Seat[]>([]);

  //// luu ngay ma client chon de xem cac phim chua trong ngay hom do
  public allMovieByDate$ = new BehaviorSubject<DateInfo>({
    dayOfWeek: '',
    day: 0,
    month: '',
  });
  ////  chua cac bo phim trong phan mua ve cac phim trong ngay
  public showTimeMovie$ = new BehaviorSubject<Movie[]>([]);

  /// tien trinh cua breadcrumb
  public stepBread$ = new BehaviorSubject<number>(1);

  /// phim ma khach dang chon, de cho vao hoa don
  public currentMovie$ = new BehaviorSubject<MovieShowTime>({
    filmID: 0,
    ageLimited: 0,
    image: null,
    showTimes: [{ showTimeID: 0, timeShow: '', screen: '' }],
    time: '',
    name: '',
  });
  public currentShowTime$ = new BehaviorSubject<object>({
    showTimeID: 0,
    timeShow: '',
    screen: '',
  });

  constructor(private ClienSer: ClientService) {}

  resetOrder() {
    this.adultQuantity$.next(0);
    this.childQuantity$.next(0);
    this.cb1_22$.next(0);
    this.cb1_32$.next(0);
    this.cb2_32$.next(0);
    this.cbf1_snack$.next(0);
    this.cbf2_food$.next(0);
    this.cbf2_snack$.next(0);

    // reset cac ghe nguoi dung da dien trong bill
    this.userSelectSeat$.next([]);
    // reset ghe treb giao dien

    this.stepBread$.next(1);
    this.currentShowTime$.next({
      showTimeID: 0,
      timeShow: '',
      screen: '',
    });
    this.currentMovie$.next({
      filmID: 0,
      ageLimited: 0,
      image: null,
      showTimes: [{ showTimeID: 0, timeShow: '', screen: '' }],
      time: '',
      name: '',
    });
    this.allMovieByDate$.next({
      dayOfWeek: '',
      day: 0,
      month: '',
    });

    this.bill = new Bill();
  }

  getTotal(): number {
    return (
      this.adultQuantity$.getValue() * 75000 +
      this.childQuantity$.getValue() * 60000 +
      this.cb1_22$.getValue() * 76000 +
      this.cb1_32$.getValue() * 79000 +
      this.cb2_32$.getValue() * 92000 +
      this.cbf1_snack$.getValue() * 129000 +
      this.cbf2_snack$.getValue() * 179000 +
      this.cbf2_food$.getValue() * 179000
    );
  }
  //  cb1_22$ 1b-1n : 4-26
  //  cb1_32$ 1b-1n : 4-5
  //  cb2_32$ 1b-2n : 4-5
  //  cbf1_snack$  1b-3n-kitkat :  4-5-28
  //  cbf2_snack$  2b-4n-kitkat :  4-5-28
  //  cbf2_food$   2b-4n-hotdog :  4-5-34

  createBill() {
    /// create concession
    console.warn(this.product);

    if (this.cb1_22$.getValue() !== 0) {
      console.warn('co');

      this.product.push(
        {
          productID: 4,
          quantity: this.cb1_22$.getValue(),
          details: 'combo1 small_BẮP NGỌT_4',
        },
        {
          productID: 26,
          quantity: this.cb1_22$.getValue(),
          details: 'combo1 small_PEPSI_26',
        }
      );
    }
    if (this.cb1_32$.getValue() !== 0) {
      console.warn('co');
      this.product.push(
        {
          productID: 4,
          quantity: this.cb1_32$.getValue(),
          details: 'combo1 big_BẮP NGỌT_4',
        },
        {
          productID: 5,
          quantity: this.cb1_32$.getValue(),
          details: 'combo1 big_PEPSI_5',
        }
      );
    }
    if (this.cb2_32$.getValue() !== 0) {
      console.warn('co');
      this.product.push(
        {
          productID: 4,
          quantity: this.cb2_32$.getValue(),
          details: 'combo2 big_BẮP NGỌT_4',
        },
        {
          productID: 5,
          quantity: this.cb2_32$.getValue() * 2,
          details: 'combo2 big_PEPSI_5',
        }
      );
    }
    if (this.cbf1_snack$.getValue() !== 0) {
      console.warn('co');
      this.product.push(
        {
          productID: 4,
          quantity: this.cbf1_snack$.getValue(),
          details: 'combo family1 snack_PEPSI_4',
        },
        {
          productID: 5,
          quantity: this.cbf1_snack$.getValue() * 3,
          details: 'combo family1 snack_PEPSI_5',
        },
        {
          productID: 28,
          quantity: this.cbf1_snack$.getValue(),
          details: 'combo family1 snack_PEPSI_28',
        }
      );
    }
    if (this.cbf2_snack$.getValue() !== 0) {
      console.warn('co');
      this.product.push(
        {
          productID: 4,
          quantity: this.cbf2_snack$.getValue() * 2,
          details: 'combo family2 snack_PEPSI_4',
        },
        {
          productID: 5,
          quantity: this.cbf2_snack$.getValue() * 4,
          details: 'combo family2 snack_PEPSI_5',
        },
        {
          productID: 28,
          quantity: this.cbf2_snack$.getValue(),
          details: 'combo family2 snack_PEPSI_28',
        }
      );
    }
    if (this.cbf2_food$.getValue() !== 0) {
      console.warn('co');
      this.product.push(
        {
          productID: 4,
          quantity: this.cbf2_food$.getValue() * 2,
          details: 'combo family2ff_PEPSI_4',
        },
        {
          productID: 5,
          quantity: this.cbf2_food$.getValue() * 4,
          details: 'combo family2ff_PEPSI_5',
        },
        {
          productID: 34,
          quantity: this.cbf2_food$.getValue(),
          details: 'combo family2ff_PEPSI_34',
        }
      );
    }

    this.bill.product = this.product;

    /// create orderfilm
    this.userSelectSeat$
      .getValue()
      .forEach((e) => this.bill.seat.push(e.row + ' ' + e.number));

    /// create total bill
    this.bill.total = this.getTotal();

    // lay ID cua nguoi dung
    this.bill.customerID = this.ClienSer.dataClientLogin$.getValue().customerID;

    // lay mail
    this.bill.mail = this.ClienSer.dataClientLogin$.getValue().email;

    // create order film
    return this.bill;
  }

  getTicketCount(): number {
    return this.adultQuantity$.getValue() + this.childQuantity$.getValue();
  }

  formatDataMovie(dataMovie: Movie[]): any {
    console.warn(dataMovie);

    const newData = dataMovie.reduce((acc, curr) => {
      const { name, time, image, showTimeID, filmID, ageLimited, screen } =
        curr;

      const existingPhim = acc.find((item) => item.name === name);
      const timeShow = time.substring(0, 5) + ' ' + time.substring(9, 11);

      if (existingPhim) {
        existingPhim.showTimes.push({ showTimeID, timeShow, screen });
      } else {
        const newPhim = {
          // showTimeID: showTimeID,
          filmID: filmID,
          name: name,
          ageLimited: ageLimited,
          image: image,
          showTimes: [{ showTimeID, timeShow, screen }],
        };
        acc.push(newPhim);
      }

      return acc;
    }, [] as { name: string; showTimes: object[] }[]);
    console.warn(newData);

    return newData;
  }
}
