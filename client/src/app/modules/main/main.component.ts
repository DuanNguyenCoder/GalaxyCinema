import { HttpClient } from '@angular/common/http';
import { Component, ElementRef } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ClientService } from 'src/app/core/services/client.service';
import { OrderTicketService } from 'src/app/core/services/order-ticket.service';
import { ProjectService } from 'src/app/core/services/project.service';
import { SeatService } from 'src/app/core/services/seat.service';
import { Customer, Movie } from 'src/app/shared/interface/project';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
})
export class MainComponent {
  dataCus: Customer[] = [];
  states: string[] = ['test', 'dgsagd', 'dsagd', 'dsagdgas'];
  dataMovieActive: any[] = [];

  slideConfig = {
    slidesToShow: 1,
    slidesToScroll: 1,
    dots: true,
  };
  constructor(
    private router: Router,
    private http: HttpClient,
    private elementRef: ElementRef,
    private projectSer: ProjectService,
    private clientSer: ClientService,
    private orderTickSer: OrderTicketService,
    private seatSer: SeatService,
    public dialog: MatDialog
  ) {
    console.warn('chay main');

    console.log(this.projectSer.reLog$.getValue());
    clientSer.dataClientLogin$.subscribe((log) => {
      if (!log.isLogin) {
        this.projectSer.itemCarousel$.subscribe((res1) => {
          this.dataMovieActive = res1;
        });
      } else if (this.projectSer.reLog$.getValue() == true) {
        console.warn('zo');

        this.projectSer.itemCarousel$.subscribe((res1) => {
          this.dataMovieActive = res1;
        });
      } else if (log.isLogin) {
        this.projectSer.dataMovieRecommend$.subscribe((res2) => {
          const temp = [];
          for (let i = 0; i < res2.length; i += 4) {
            const chunk = res2.slice(i, i + 4);
            temp.push(chunk);
          }
          this.dataMovieActive = temp;
          console.warn(this.dataMovieActive);
        });
      }
    });
  }

  orderTicket() {
    this.router.navigate(['/show-time']);
    console.warn('next');
  }
}
