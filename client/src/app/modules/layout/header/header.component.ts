import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClientService } from 'src/app/core/services/client.service';
import { DialogService } from 'src/app/core/services/dialog.service';
import { OrderTicketService } from 'src/app/core/services/order-ticket.service';
import { ProjectService } from 'src/app/core/services/project.service';
import { Customer, Movie } from 'src/app/shared/interface/project';
import { environment } from 'src/environments/environment';
import { DragableComponent } from '../../dragable/dragable.component';
import { MatDialog } from '@angular/material/dialog';
import { ToastService } from 'src/app/core/services/toast.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  dataClient!: Customer;
  dataMovie: Movie[] = [];
  HideSubNav: boolean = true;
  constructor(
    private dialog: DialogService,
    private clientSer: ClientService,
    private projectSer: ProjectService,
    private route: Router,
    private orderTickSer: OrderTicketService,
    private http: HttpClient,
    public dialogMat: MatDialog,
    private toastSer: ToastService
  ) {
    this.clientSer.dataClientLogin$.subscribe((res) => (this.dataClient = res));
    this.projectSer.dataMovieActive$.subscribe((res) => (this.dataMovie = res));

    console.warn(this.clientSer.getUserIDDataFromLocalStorage());
    console.warn(this.clientSer.getUserNameDataFromLocalStorage());

    /// get movie active
  }
  ngOnInit(): void {}

  login() {
    this.dialog.openDialog();
  }
  review(movie: Movie) {
    this.projectSer.MovieReview$.next(movie);
    this.projectSer.getUserReviewFilm();
    this.route.navigate(['/review']);
    this.HideSubNav = true;
  }
  getBase64Image(byteArray: Uint8Array): string {
    return 'data:image/png;base64,' + byteArray;
  }
  navReview() {
    // const temp = this.orderTickSer.allMovieByDate$.getValue();
    // temp.day = 0;
    // this.orderTickSer.allMovieByDate$.next(temp);
    this.HideSubNav = !this.HideSubNav;
  }

  navigate(path: string) {
    this.route.navigate([path]);
  }

  logout() {
    const temp: Customer = { isLogin: false };
    this.clientSer.dataClientLogin$.next(temp);
    this.clientSer.removeUserDataFromLocalStorage();
    this.dialog.openDialog();
  }
  showAlgro() {
    if (this.clientSer.dataClientLogin$.getValue().isLogin) {
      const dialogRef = this.dialogMat.open(DragableComponent);
    } else {
      this.toastSer.showError('Thông báo', 'Chưa đăng nhập');
    }
  }
}
