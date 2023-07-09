import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClientService } from 'src/app/core/services/client.service';
import { OrderTicketService } from 'src/app/core/services/order-ticket.service';
import { ToastService } from 'src/app/core/services/toast.service';
import {
  Bill,
  DateInfo,
  MovieShowTime,
  Seat,
} from 'src/app/shared/interface/project';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-confirm',
  templateUrl: './confirm.component.html',
  styleUrls: ['./confirm.component.scss'],
})
export class ConfirmComponent implements OnInit {
  dataBill!: Bill;
  dateFomatMovie!: DateInfo;
  dataMovie!: MovieShowTime;
  dataSeat!: Seat[];
  dataMovieShowTime!: any;
  constructor(
    private http: HttpClient,
    private router: Router,
    public orderTickSer: OrderTicketService,
    private clientSer: ClientService,
    private toastSer: ToastService
  ) {
    /// lay ten suat chieu
    this.orderTickSer.currentMovie$.subscribe((res) => {
      this.dataMovie = res;
    });

    /// lay suat chieu
    this.orderTickSer.currentShowTime$.subscribe((res) => {
      this.dataMovieShowTime = res;
    });

    // lay ghe
    this.orderTickSer.userSelectSeat$.subscribe((res) => {
      this.dataSeat = res;
    });

    this.orderTickSer.currentMovie$.subscribe((res) => {
      this.dataMovie = res;
    });
    /// lay thong tin ngay gio chieu
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

  pay() {
    if (this.clientSer.dataClientLogin$.getValue().isLogin) {
      this.dataBill = this.orderTickSer.createBill();
      this.http
        .post<any>(environment.BASE_URL + 'create_payment', this.dataBill)
        .subscribe((res) => {
          console.warn(res.url);
          window.location.href = res.url;
        });
    } else {
      this.toastSer.showError('Thông báo', 'Vui lòng đăng nhập');
    }
    console.log(this.dataBill);
  }
  test() {
    this.dataBill = this.orderTickSer.createBill();
    console.warn(this.dataBill);
  }
}
