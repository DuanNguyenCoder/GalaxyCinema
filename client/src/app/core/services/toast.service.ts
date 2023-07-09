import { Injectable } from '@angular/core';
import { NgToastService } from 'ng-angular-popup';

@Injectable({
  providedIn: 'root',
})
export class ToastService {
  constructor(private toast: NgToastService) {}

  time: number = 2500;

  title = {
    LOGIN_FAIL: 'Login failed',
    SUCCESS: 'Success',
    FAIL: 'Fail',
    INVALID: 'Invalid',
  };

  content = {
    LOGIN_FAIL: 'Invalid user name or password!',
    LOGIN_SUCCESS: 'Login success!',
    ADD_FAIL: 'Add new fail!',
    ADD_SUCCESS: 'Add new success!',
    DELETE_FAIL: 'Delete fail!',
    DELETE_SUCCESS: 'Delete success!',
    NAME_INVALID: 'Invalid name!',
    CODE_ERROR: 'Code was exsisted!',
  };

  showInfo(title?: string, content?: string) {
    this.toast.info({
      detail: title,
      summary: content,
      duration: this.time,
    });
  }
  showSuccess(title?: string, content?: string) {
    this.toast.success({
      detail: title,
      summary: content,
      duration: this.time,
    });
  }
  showError(title?: string, content?: string) {
    this.toast.error({
      detail: title,
      summary: content,
      duration: this.time,
    });
  }
}
