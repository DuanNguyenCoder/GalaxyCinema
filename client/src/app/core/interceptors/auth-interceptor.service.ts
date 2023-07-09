// import {
//   HttpHandler,
//   HttpInterceptor,
//   HttpRequest,
// } from '@angular/common/http';
// import { Injectable } from '@angular/core';
// import { TokenService } from '../services/token.service';
// @Injectable({
//   providedIn: 'root',
// })
// export class AuthInterceptorService implements HttpInterceptor {
//   constructor(public token: TokenService) {}

//   intercept(req: HttpRequest<any>, next: HttpHandler) {
//     const authToken = this.token.getToken();
//     req = req.clone({
//       setHeaders: {
//         'Content-Type': 'application/json',
//         Authorization: 'Bearer ' + authToken,
//       },
//     });
//     return next.handle(req);
//   }
// }
