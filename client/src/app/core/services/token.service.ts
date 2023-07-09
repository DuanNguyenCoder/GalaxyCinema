import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  privateAccessToken?: string;
  constructor(private cookie: CookieService) {}

  getToken() {
    return this.cookie.get('accessToken');
  }

  setToken(accessToken: string) {
    this.cookie.set('accessToken', accessToken);
  }

  deleteToken() {
    this.cookie.delete('accessToken');
  }

  checkAuth() {
    return (
      this.cookie.get('accessToken') &&
      this.cookie.get('accessToken').length > 20
    );
  }
}
