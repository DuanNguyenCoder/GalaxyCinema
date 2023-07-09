import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { LoginComponent } from 'src/app/modules/login/login.component';

@Injectable({
  providedIn: 'root',
})
export class DialogService {
  dialogRef!: MatDialogRef<any>; // Tham chiếu đến dialog hiện tại

  constructor(private dialog: MatDialog) {}

  openDialog() {
    this.dialogRef = this.dialog.open(LoginComponent);
  }

  closeDialog() {
    if (this.dialogRef) {
      this.dialogRef.close();
    }
  }
}
