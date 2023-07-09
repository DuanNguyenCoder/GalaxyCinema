import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from 'src/app/shared/interface/project';
import { environment } from 'src/environments/environment';
import { ToastService } from './toast.service';
import { DialogService } from './dialog.service';
import { BehaviorSubject } from 'rxjs';
import { ProjectService } from './project.service';

@Injectable({
  providedIn: 'root',
})
export class ClientService {
  public dataClientLogin$ = new BehaviorSubject<Customer>({ isLogin: false });

  constructor(
    private http: HttpClient,
    private toast: ToastService,
    private dialog: DialogService,
    private projectSer: ProjectService
  ) {}

  getLogin(e: string, p: string) {
    this.http
      .post<any>(environment.BASE_URL + 'customer/login', {
        email: e,
        passwords: p,
      })
      .subscribe((res) => {
        if (res !== null) {
          this.saveUserDataToLocalStorage(res);
          this.projectSer.recommendForUserAndAlgorithm(res.customerID);

          let temp: Customer = res;
          temp.isLogin = true;
          this.dataClientLogin$.next(temp);
          console.warn(this.dataClientLogin$.getValue());

          this.toast.showSuccess(
            this.toast.title.SUCCESS,
            this.toast.content.LOGIN_SUCCESS
          );
          this.dialog.closeDialog();
        } else {
          this.toast.showError(
            this.toast.title.LOGIN_FAIL,
            this.toast.content.LOGIN_FAIL
          );
        }
      });
  }

  createCustomer(dataRegis: Customer) {
    this.http
      .post<any>(environment.BASE_URL + 'customer/create', dataRegis)
      .subscribe();
    this.toast.showSuccess(
      this.toast.title.SUCCESS,
      'Tạo tài khoản thành công!!'
    );
  }

  saveUserDataToLocalStorage(user: Customer) {
    localStorage.setItem('userId', JSON.stringify(user.customerID));
    localStorage.setItem('userName', JSON.stringify(user.name));
  }
  getUserIDDataFromLocalStorage() {
    const userData = JSON.parse(localStorage.getItem('userId')!);
    return userData;
  }

  getUserNameDataFromLocalStorage() {
    const userData = JSON.parse(localStorage.getItem('userName')!);
    return userData;
  }

  removeUserDataFromLocalStorage() {
    localStorage.removeItem('userId');
    localStorage.removeItem('userName');
  }
}
