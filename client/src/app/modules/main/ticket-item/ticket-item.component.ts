import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DateService } from 'src/app/core/services/date.service';
import { ProjectService } from 'src/app/core/services/project.service';
import { Movie } from 'src/app/shared/interface/project';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-ticket-item',
  templateUrl: './ticket-item.component.html',
  styleUrls: ['./ticket-item.component.scss'],
})
export class TicketItemComponent implements OnInit {
  @Input() dataMovie!: Movie;
  constructor(
    private dateSer: DateService,
    private router: Router,
    private projectSer: ProjectService,
    private http: HttpClient
  ) {}

  ngOnInit(): void {}

  redirect() {
    this.projectSer.ticketShowTime$.next(this.dataMovie);
    this.router.navigate(['/movie']);
    console.warn('next');
  }

  getBase64Image(byteArray: Uint8Array): string {
    return 'data:image/png;base64,' + byteArray;
  }
}
