import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AlgorithmService {
  public initialArray!: number[][];

  public dataInitMatrix$ = new BehaviorSubject<number[][]>(this.initialArray);
  public dataSimilarMatrix$ = new BehaviorSubject<number[][]>(
    this.initialArray
  );
  public coupleSimilar$ = new BehaviorSubject<string[]>([]);
  public dataUser$ = new BehaviorSubject<string[]>([]);
  public dataItem$ = new BehaviorSubject<string[]>([]);

  constructor() {}
}
