import { Injectable } from '@angular/core';
import { DateInfo } from 'src/app/shared/interface/project';

@Injectable({
  providedIn: 'root',
})
export class DateService {
  futureDates: DateInfo[] = [];

  constructor() {
    this.getFutureDates();
  }

  getFutureDates(): void {
    const currentDate = new Date();

    for (let i = 0; i < 15; i++) {
      const date = new Date();
      date.setDate(currentDate.getDate() + i);
      const dateInfo: DateInfo = {
        dayOfWeek: this.getDayOfWeek(date),
        month: this.getMonthName(date),
        day: date.getDate(),
      };

      this.futureDates.push(dateInfo);
    }
  }

  getDayOfWeek(day: Date): string {
    const daysOfWeek = [
      'Chủ nhật',
      'Thứ 2',
      'Thứ 3',
      'Thứ 4',
      'Thứ 5',
      'Thứ 6',
      'Thứ 7',
    ];
    return daysOfWeek[day.getDay()];
  }

  getMonthName(month: Date): string {
    const months = [
      '1',
      '2',
      '3',
      '4',
      '5',
      '6',
      '7',
      '8',
      '9',
      '10',
      '11',
      '12',
    ];
    return months[month.getMonth()];
  }

  formatDatePostReview(): string {
    const today = new Date();
    const year = today.getFullYear();
    const month = String(today.getMonth() + 1).padStart(2, '0');
    const day = String(today.getDate()).padStart(2, '0');

    return `${year}-${month}-${day}`;
  }
}
