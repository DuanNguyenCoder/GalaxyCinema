import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientService } from 'src/app/core/services/client.service';
import { OrderTicketService } from 'src/app/core/services/order-ticket.service';
import { ProjectService } from 'src/app/core/services/project.service';
import { Bill } from 'src/app/shared/interface/project';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-order-success',
  templateUrl: './order-success.component.html',
  styleUrls: ['./order-success.component.scss'],
})
export class OrderSuccessComponent implements OnInit {
  dataBill!: Bill;
  orderSuccess: boolean = false;
  private itemCarousel: Object[] = [];
  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    private clientSer: ClientService,
    private projectSer: ProjectService,
    private ticketSer: OrderTicketService,
    private router: Router
  ) {
    this.route.queryParams.subscribe((params) => {
      // this.dataBill = this.ticketSer.createBill();
      const vnpBankCode = params['vnp_ResponseCode'];
      console.warn(this.dataBill);

      if (vnpBankCode == '00') {
        this.orderSuccess = true;
        this.http
          .get<any>(environment.BASE_URL + 'insertData')
          .subscribe((res) => {});
      }
      //////////////////////
    });
    projectSer.reLog$.next(true);
    // this.http
    //   .get<any>(environment.BASE_URL + 'movie/active')
    //   .subscribe((res) => {
    //     this.projectSer.dataMovieActive$.next(res);

    //     for (let i = 0; i < res.length; i += 4) {
    //       const chunk = res.slice(i, i + 4);
    //       this.itemCarousel.push(chunk);
    //     }
    //     this.projectSer.itemCarousel$.next(this.itemCarousel);
    //     console.log(this.projectSer.itemCarousel$.getValue());
    //   });
    // const dateToday = new Date();
    // const params = {
    //   day: dateToday.getDate(),
    //   month: dateToday.getMonth() + 1,
    //   year: '2023',
    // };
    // this.http
    //   .get<any>(environment.BASE_URL + 'movie', { params })
    //   .subscribe((res) => {
    //     console.warn(res);

    //     this.ticketSer.showTimeMovie$.next(res);

    //     console.log(res);
    //   });
    const id = this.clientSer.getUserIDDataFromLocalStorage();
    const name = this.clientSer.getUserNameDataFromLocalStorage();
    this.clientSer.dataClientLogin$.next({
      customerID: id,
      name: name,
      isLogin: true,
    });
    // console.warn('chay ham');
  }
  ngOnInit(): void {}

  reidirect() {
    this.router.navigate(['/']);
  }
}
