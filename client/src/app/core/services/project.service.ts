import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Movie, Review } from 'src/app/shared/interface/project';
import { environment } from 'src/environments/environment';
import { AlgorithmService } from './algorithm.service';

@Injectable({
  providedIn: 'root',
})
export class ProjectService {
  private movieRecommend: Movie[] = [];
  public dataMovieActive$ = new BehaviorSubject<Movie[]>([]);
  public dataMovieRecommend$ = new BehaviorSubject<Movie[]>([]);
  public reLog$ = new BehaviorSubject<boolean>(false);
  public dataUserReviewFilm$ = new BehaviorSubject<Review[]>([]);
  public MovieReview$ = new BehaviorSubject<Movie>({
    filmID: 0,
    name: '',
    ageLimited: 0,
    image: '',
    time: '',
  });

  public ticketShowTime$ = new BehaviorSubject<Movie>({
    filmID: 0,
    name: '',
    ageLimited: 0,
    image: '',
    time: '',
  });
  public itemCarousel$ = new BehaviorSubject<Object[]>([]);

  constructor(private http: HttpClient, private algoSer: AlgorithmService) {}

  getUserReviewFilm() {
    this.http
      .get<any>(
        environment.BASE_URL + 'review/' + this.MovieReview$.getValue().filmID
      )
      .subscribe((res) => {
        this.dataUserReviewFilm$.next(res);
      });
  }

  postReview(userReview: Review) {
    this.http
      .post<any>(environment.BASE_URL + 'review/addNew', userReview)
      .subscribe();
  }

  updateReview(userReview: Review) {
    this.http
      .post<any>(environment.BASE_URL + 'review/update', userReview)
      .subscribe();
  }
  recommendForUser(idUser: number) {
    const movieActive = this.dataMovieActive$.getValue();

    this.http
      .get<any>(environment.BASE_URL + 'recommend/' + idUser)
      .subscribe((res: Movie[]) => {
        //
        const intersected = res.filter((obj1) => {
          const matchedObj = movieActive.find(
            (obj2) => obj2.filmID === obj1.filmID
          );
          return matchedObj !== undefined;
        });

        const nonIntersected = movieActive.filter((obj2) => {
          const matchedObj = res.find((obj1) => obj1.filmID === obj2.filmID);
          return matchedObj === undefined;
        });

        const result = intersected.concat(nonIntersected);
        this.dataMovieRecommend$.next(result);
        console.log(result);

        //
      });
  }

  recommendForUserAndAlgorithm(idUser: number) {
    const movieActive = this.dataMovieActive$.getValue();

    this.http
      .get<any>(environment.BASE_URL + 'recommend/a/' + idUser)
      .subscribe((res) => {
        console.log(res);
        this.algoSer.coupleSimilar$.next(res.coupleSimilar);
        this.algoSer.dataInitMatrix$.next(res.initMatrix);
        this.algoSer.dataSimilarMatrix$.next(res.similarMatrix);
        this.algoSer.dataUser$.next(res.nameCus);
        this.algoSer.dataItem$.next(res.nameItem);

        // sap xep phim
        console.warn(res.dataFilm);
        const intersected = res.dataFilm.filter((obj1: any) => {
          const matchedObj = movieActive.find(
            (obj2) => obj2.filmID === obj1.filmID
          );
          return matchedObj !== undefined;
        });

        const nonIntersected = movieActive.filter((obj2) => {
          const matchedObj = res.dataFilm.find(
            (obj1: any) => obj1.filmID === obj2.filmID
          );
          return matchedObj === undefined;
        });

        const result = intersected.concat(nonIntersected);
        this.dataMovieRecommend$.next(result);
        console.log(result);
      });
  }
  recommendNoneLogin() {}
}
