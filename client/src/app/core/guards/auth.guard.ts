import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

import { TokenService } from '../services/token.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private token: TokenService, private router: Router) {}

  canActivate(): boolean {
    if (this.token.checkAuth()) {
      console.warn('da dang nhap');
      return true;
    } else {
      console.warn('chua dang nhap');
      this.router.navigate(['/login']);
      return false;
    }
  }
}
