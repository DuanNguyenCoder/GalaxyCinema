import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClientService } from 'src/app/core/services/client.service';
import { DateService } from 'src/app/core/services/date.service';
import { OrderTicketService } from 'src/app/core/services/order-ticket.service';
import { ProjectService } from 'src/app/core/services/project.service';
import { ToastService } from 'src/app/core/services/toast.service';
import { DateInfo, Movie } from 'src/app/shared/interface/project';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-ticket-showtime',
  templateUrl: './ticket-showtime.component.html',
  styleUrls: ['./ticket-showtime.component.scss'],
})
export class TicketShowtimeComponent implements OnInit {
  dataMovie!: Movie;
  dataDate!: DateInfo[];
  showTimeMovie: any;
  selectedDate?: number = 0;

  constructor(
    private orderTicketSer: OrderTicketService,
    private dateSer: DateService,
    private projectSer: ProjectService,
    private http: HttpClient,
    private clientLogin: ClientService,
    private router: Router,
    private toast: ToastService
  ) {
    this.dataDate = this.dateSer.futureDates;
    this.projectSer.ticketShowTime$.subscribe((res) => (this.dataMovie = res));
    console.warn(this.dataMovie.filmID);

    this.http
      .post<any>(environment.BASE_URL + 'movie/showTime', {
        filmID: this.dataMovie.filmID,
        // time: dateSer.formatDatePostReview(),
        date: dateSer.formatDatePostReview(),
      })
      .subscribe((res) => {
        this.showTimeMovie = res;
        console.warn('chay lai constructor');
      });
  }

  ngOnInit(): void {}

  orderTicket(showTimeID: number, showTime: string) {
    console.warn(showTimeID);
    if (this.clientLogin.dataClientLogin$.getValue().isLogin) {
      this.orderTicketSer.bill.filmID = this.dataMovie.filmID;
      this.orderTicketSer.bill.showTimeID = showTimeID;
      this.orderTicketSer.currentMovie$.next(this.dataMovie);
      this.orderTicketSer.currentShowTime$.next({
        showTimeID: showTimeID,
        timeShow: showTime,
      });
      this.router.navigate(['/ticket/selectTicket']);
      console.warn(this.orderTicketSer.currentMovie$.getValue());
    } else {
      this.toast.showError('Thông báo', 'Vui lòng đăng nhập');
    }
  }
  // if (this.clientLogin.dataClientLogin$.getValue().isLogin) {
  //   this.orderTicketSer.bill.filmID = movieChoose.filmID;
  //   this.orderTicketSer.bill.showTimeID = movieShowTimeChoose.showTimeID;
  //   /////
  //   this.orderTicketSer.currentMovie$.next(movieChoose);
  //   this.orderTicketSer.currentShowTime$.next(movieShowTimeChoose);

  // } else {
  //   this.toastSer.showError('Thông báo', 'vui lòng đăng nhập');
  // }

  getBase64Image(byteArray: Uint8Array): string {
    return 'data:image/png;base64,' + byteArray;
  }

  getMovieByDate(date: DateInfo, indexDate: number) {
    this.selectedDate = indexDate;

    const datePost = 2023 + '-' + date.month + '-' + date.day;

    this.http
      .post<any>(environment.BASE_URL + 'movie/showTime', {
        filmID: this.dataMovie.filmID,
        // time: dateSer.formatDatePostReview(),
        date: datePost,
      })
      .subscribe((res) => {
        this.showTimeMovie = res;
        console.warn(res);
      });

    console.warn(date);
  }
}
