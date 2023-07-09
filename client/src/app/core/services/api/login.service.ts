import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { ILogin } from '../../../shared/interface/login.model';
import { Injectable } from '@angular/core';

export const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private http: HttpClient) {}

  loginTimeSheet(loginData: ILogin) {
    return this.http.post(
      `${environment.BASE_URL}/TokenAuth/Authenticate`,
      loginData,
      httpOptions
    );
  }
}
