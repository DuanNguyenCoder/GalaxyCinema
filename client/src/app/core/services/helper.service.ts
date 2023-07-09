import { Injectable } from '@angular/core';
import { Breadcrumb } from 'src/app/shared/interface/project';

@Injectable({
  providedIn: 'root',
})
export class HelperService {
  private breadcrumbs: Breadcrumb[] = [];

  constructor() {
    this.addBreadcrumb('Chọn vé', '/ticket/selectTicket');
    this.addBreadcrumb('Chọn ghế', '/ticket/selectSeat');
    this.addBreadcrumb('Chọn đồ ăn', '/ticket/selectFood');
    this.addBreadcrumb('Xác nhận', '/ticket/confirm');
    this.addBreadcrumb('Đặt vé thành công', '/ticket/payment_infor');
  }

  getBreadcrumbs(): Breadcrumb[] {
    return this.breadcrumbs;
  }

  addBreadcrumb(label: string, url: string): void {
    const breadcrumb: Breadcrumb = { label, url };
    this.breadcrumbs.push(breadcrumb);
  }

  removeLastBreadcrumb(): void {
    this.breadcrumbs.pop();
  }

  resetBreadcrumbs(): void {
    this.breadcrumbs = [];
  }
}
