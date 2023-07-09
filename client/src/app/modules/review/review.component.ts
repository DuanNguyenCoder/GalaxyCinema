import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ClientService } from 'src/app/core/services/client.service';
import { DateService } from 'src/app/core/services/date.service';
import { DialogService } from 'src/app/core/services/dialog.service';
import { ProjectService } from 'src/app/core/services/project.service';
import { ToastService } from 'src/app/core/services/toast.service';

import { Movie, Review } from 'src/app/shared/interface/project';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.scss'],
})
export class ReviewComponent implements OnInit {
  dataUserReview: Review[] = [];
  dataMovie!: Movie;
  point!: number;
  // Chuyển đổi byte[] thành định dạng base64
  base64Image: any;
  imageUrl: any;

  urlSafe?: SafeResourceUrl;
  // rating
  public ratingArr: number[] = [1, 2, 3, 4, 5];
  public rateNum: number = 1;
  //rating

  myFormControl = new FormControl();

  constructor(
    private projectSer: ProjectService,
    public sanitizer: DomSanitizer,
    public clientSer: ClientService,
    private dialogSer: DialogService,
    private dateService: DateService,
    private toastSer: ToastService
  ) {
    this.projectSer.MovieReview$.subscribe((res) => {
      this.dataMovie = res;
      this.base64Image = this.getBase64Image(this.dataMovie.image);
    });
    this.projectSer.dataUserReviewFilm$.subscribe((res) => {
      this.dataUserReview = res;
      this.calPointMovie();
    });
  }

  ngOnInit(): void {}

  getLinkReviewYtb(): any {
    const result = this.dataMovie.link?.split('watch?v=')[1];
    this.urlSafe = this.sanitizer.bypassSecurityTrustResourceUrl(
      'https://www.youtube-nocookie.com/embed/' + result
    );

    return this.urlSafe;
  }

  scrollToIframe() {
    const iframe = document.getElementById('myIframe');
    if (iframe) {
      const iframeTopOffset = iframe.getBoundingClientRect().top;
      const windowHeight = window.innerHeight;
      const scrollToPosition =
        iframeTopOffset - windowHeight / 2 + iframe.offsetHeight / 2;
      window.scrollTo({ top: scrollToPosition, behavior: 'smooth' });
    }
  }

  rating(rating: number) {
    this.rateNum = rating;
    console.warn(rating);
  }

  showIcon(rating: number) {
    if (this.rateNum > rating) {
      return 'star';
    }
    return 'star_border';
  }

  getBase64Image(byteArray: Uint8Array): string {
    return 'data:image/png;base64,' + byteArray;
  }

  writeReview() {
    this.dataUserReview.map((e) => console.warn(e));

    if (
      this.clientSer.dataClientLogin$.getValue().customerID === null ||
      this.clientSer.dataClientLogin$.getValue().customerID === undefined
    ) {
      this.dialogSer.openDialog();
      this.toastSer.showError(
        'Thông báo',
        'Vui lòng đăng nhập trước khi bình luận'
      );
    } else {
      const cusID = this.clientSer.dataClientLogin$.getValue().customerID;
      const filmID = this.projectSer.MovieReview$.getValue().filmID;
      const comment = this.myFormControl.value;
      const date = this.dateService.formatDatePostReview();
      const name = this.clientSer.dataClientLogin$.getValue().name;

      const rate = this.rateNum;
      const dataPost = new Review(cusID!, filmID, name!, date, rate, comment);

      if (this.checkUserWasReview(cusID!)) {
        console.warn('cap nhat lai binh luan');

        this.projectSer.dataUserReviewFilm$.next([
          ...this.projectSer.dataUserReviewFilm$
            .getValue()
            .filter((e) => e.customerID != cusID),
          dataPost,
        ]);
        this.projectSer.updateReview(dataPost);
      } else {
        console.warn('them moi binh luan');
        this.projectSer.dataUserReviewFilm$.next([
          ...this.projectSer.dataUserReviewFilm$.getValue(),
          dataPost,
        ]);
        this.projectSer.postReview(dataPost);
      }
      this.toastSer.showSuccess('Thông báo', 'Bình luận thành công');
      // console.warn(dataPost);
      // reset form
      this.myFormControl.setValue('');
      this.rateNum = 0;
    }
  }

  checkUserWasReview(idUserReview: number): boolean {
    return this.dataUserReview.some((e) => e.customerID === idUserReview);
  }

  calPointMovie(dataUserReview?: Review[]) {
    if (this.dataUserReview.length === 0) {
      this.point = 0;
      console.warn(this.point);
    } else {
      const totalVotes = this.dataUserReview.reduce(
        (total, vote) => total + vote.rate!,
        0
      );
      this.point = totalVotes / this.dataUserReview.length;
    }
  }
}
