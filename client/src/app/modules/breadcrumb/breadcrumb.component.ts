import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HelperService } from 'src/app/core/services/helper.service';
import { OrderTicketService } from 'src/app/core/services/order-ticket.service';
import { ToastService } from 'src/app/core/services/toast.service';
import { Breadcrumb } from 'src/app/shared/interface/project';

@Component({
  selector: 'app-breadcrumb',
  templateUrl: './breadcrumb.component.html',
  styleUrls: ['./breadcrumb.component.scss'],
})
export class BreadcrumbComponent {
  public dataBread: Breadcrumb[];
  public currentStep!: number;

  constructor(
    private toastSer: ToastService,
    private router: Router,
    private helperSer: HelperService,
    private orderSer: OrderTicketService
  ) {
    this.dataBread = helperSer.getBreadcrumbs();
    this.orderSer.stepBread$.subscribe((res) => (this.currentStep = res));
  }

  stepBread(itemIndex: number, url: string) {
    if (url == '/ticket/selectTicket') {
      this.orderSer.stepBread$.next(1);
      this.router.navigate([url]);
    }
    if (url == '/ticket/selectSeat') {
      if (this.orderSer.userSelectSeat$.getValue().length == 0) {
        this.toastSer.showError(
          'Thông báo',
          'Bạn chưa xác nhận chọn số lượng vé'
        );
      } else {
        this.orderSer.stepBread$.next(2);
        this.router.navigate([url]);
      }
    }
    if (url == '/ticket/selectFood') {
      if (this.orderSer.userSelectSeat$.getValue().length == 0) {
        this.toastSer.showError('Thông báo', 'Bạn chưa xác nhận chọn chỗ ngồi');
      } else {
        this.orderSer.stepBread$.next(3);
        this.router.navigate([url]);
      }
    }
    if (url == '/ticket/confirm') {
      if (
        this.orderSer.userSelectSeat$.getValue().length == 0 ||
        this.orderSer.currentMovie$.getValue().filmID == 0
      ) {
        this.toastSer.showError(
          'Thông báo',
          'Bạn chưa xác nhận chọn vé hoặc chỗ ngồi'
        );
      } else {
        this.orderSer.stepBread$.next(4);
        this.router.navigate([url]);
      }
    }
    console.warn(this.currentStep);
  }
}
