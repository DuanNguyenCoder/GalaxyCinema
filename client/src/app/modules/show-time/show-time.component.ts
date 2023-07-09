import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ClientService } from 'src/app/core/services/client.service';
import { DateService } from 'src/app/core/services/date.service';
import { OrderTicketService } from 'src/app/core/services/order-ticket.service';
import { ToastService } from 'src/app/core/services/toast.service';
import {
  DateInfo,
  Movie,
  MovieShowTime,
} from 'src/app/shared/interface/project';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-show-time',
  templateUrl: './show-time.component.html',
  styleUrls: ['./show-time.component.scss'],
})
export class ShowTimeComponent {
  dataMovie!: MovieShowTime[];
  imageSrc: string | ArrayBuffer | null = null;
  dataDate!: DateInfo[];

  dateMovie!: DateInfo;

  constructor(
    private dateSer: DateService,
    private router: Router,
    private http: HttpClient,
    private clientLogin: ClientService,
    private toastSer: ToastService,
    private orderTicketSer: OrderTicketService
  ) {
    ///
    this.orderTicketSer.showTimeMovie$.subscribe((res) => {
      this.dataMovie = this.orderTicketSer.formatDataMovie(res);
    });
    ///

    this.dataDate = this.dateSer.futureDates;

    this.orderTicketSer.allMovieByDate$.subscribe(
      (res) => (this.dateMovie = res)
    );
  }

  orderTicket(movieShowTimeChoose: any, movieChoose: MovieShowTime) {
    //// add film and showtime to bill

    if (this.clientLogin.dataClientLogin$.getValue().isLogin) {
      this.orderTicketSer.bill.filmID = movieChoose.filmID;
      this.orderTicketSer.bill.showTimeID = movieShowTimeChoose.showTimeID;
      /////
      this.orderTicketSer.currentMovie$.next(movieChoose);
      this.orderTicketSer.currentShowTime$.next(movieShowTimeChoose);
      this.router.navigate(['/ticket/selectTicket']);
    } else {
      this.toastSer.showError('Thông báo', 'vui lòng đăng nhập');
    }
  }

  getBase64Image(byteArray: Uint8Array): string {
    return 'data:image/png;base64,' + byteArray;
  }

  getMovieByDate(date: DateInfo) {
    console.warn(date);
    this.orderTicketSer.allMovieByDate$.next(date);

    const params = { day: date.day, month: date.month, year: '2023' };
    this.http
      .get<any>(environment.BASE_URL + 'movie', { params })
      .subscribe((res) => {
        console.warn(res);

        this.orderTicketSer.showTimeMovie$.next(res);
        this.dataMovie = this.orderTicketSer.formatDataMovie(
          this.orderTicketSer.showTimeMovie$.value
        );
        console.log(this.dataMovie);
      });
  }
}
