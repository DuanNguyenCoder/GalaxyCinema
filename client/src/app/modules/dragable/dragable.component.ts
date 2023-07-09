import { Component, Inject, OnInit } from '@angular/core';
import { CdkDrag } from '@angular/cdk/drag-drop';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DialogData } from '../login/login.component';
import { AlgorithmService } from 'src/app/core/services/algorithm.service';
import { Customer } from 'src/app/shared/interface/project';
import { ClientService } from 'src/app/core/services/client.service';

@Component({
  selector: 'app-dragable',
  templateUrl: './dragable.component.html',
  styleUrls: ['./dragable.component.scss'],
})
export class DragableComponent {
  public dataCurrentUser!: Customer;
  public dataCus!: string[];
  public dataItem!: string[];
  public dataInitMatrix!: number[][];
  public dataSimilarMatrix!: number[][];
  public dataCoupleSimilar!: string[];

  constructor(
    public clienSer: ClientService,
    public algoSer: AlgorithmService,
    public dialogRef: MatDialogRef<DragableComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {
    this.algoSer.dataItem$.subscribe((res) => {
      this.dataItem = res;
    });
    this.algoSer.dataUser$.subscribe((res) => (this.dataCus = res));
    this.algoSer.dataInitMatrix$.subscribe(
      (res) => (this.dataInitMatrix = res)
    );

    this.algoSer.dataSimilarMatrix$.subscribe(
      (res) => (this.dataSimilarMatrix = res)
    );

    this.algoSer.coupleSimilar$.subscribe(
      (res) => (this.dataCoupleSimilar = res)
    );

    this.clienSer.dataClientLogin$.subscribe(
      (res) => (this.dataCurrentUser = res)
    );
  }
}
