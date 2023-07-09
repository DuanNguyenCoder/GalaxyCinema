import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LoadingService {
  public loadingProject = new BehaviorSubject<boolean>(true);
  public loadingFilterProject = new BehaviorSubject<boolean>(false);

  constructor() {}
}
