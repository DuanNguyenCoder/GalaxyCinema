import { Component } from '@angular/core';
import { ProjectService } from './core/services/project.service';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Movie } from './shared/interface/project';
import { OrderTicketService } from './core/services/order-ticket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'todo';
  private itemCarousel: Object[] = [];

  constructor(
    private http: HttpClient,
    private projectSer: ProjectService,
    private orderTicketSer: OrderTicketService
  ) {
    this.http
      .get<any>(environment.BASE_URL + 'movie/active')
      .subscribe((res) => {
        this.projectSer.dataMovieActive$.next(res);

        for (let i = 0; i < res.length; i += 4) {
          const chunk = res.slice(i, i + 4);
          this.itemCarousel.push(chunk);
        }
        this.projectSer.itemCarousel$.next(this.itemCarousel);
        console.log(this.projectSer.itemCarousel$.getValue());
      });

    const dateToday = new Date();
    const params = {
      day: dateToday.getDate(),
      month: dateToday.getMonth() + 1,
      year: '2023',
    };
    this.http
      .get<any>(environment.BASE_URL + 'movie', { params })
      .subscribe((res) => {
        console.warn(res);

        this.orderTicketSer.showTimeMovie$.next(res);

        console.log(res);
      });
  }
}
