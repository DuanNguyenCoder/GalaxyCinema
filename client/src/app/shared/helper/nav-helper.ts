import { Injectable } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class NavHelper {
  constructor(private router: Router) {}

  onTabChange(event: MatTabChangeEvent) {
    console.warn('Tab clicked:', event.index);
    switch (event.index) {
      case 0:
        this.router.navigate(['project/create/general']);
        break;
      case 1:
        this.router.navigate(['project/create/team']);
        break;
      case 2:
        this.router.navigate(['project/create/tasks']);
        break;
      case 3:
        this.router.navigate(['project/create/notification']);
        break;
      default:
        break;
    }
  }
}
