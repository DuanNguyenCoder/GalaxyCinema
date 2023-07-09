import { NgModule } from '@angular/core';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// import { AuthInterceptorService } from '../../src/app/core/interceptors/auth-interceptor.service';

///// Mat-angular

import { MatSliderModule } from '@angular/material/slider';
import { BrowserModule } from '@angular/platform-browser';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatMenuModule } from '@angular/material/menu';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTabsModule } from '@angular/material/tabs';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

///// alert Toast
import { NgToastModule } from 'ng-angular-popup';

//// helper

///// component
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './modules/login/login.component';
import { NotFoundComponent } from './modules/not-found/not-found.component';
import { MainComponent } from './modules/main/main.component';
import { BreadcrumbComponent } from './modules/breadcrumb/breadcrumb.component';
import { OrderTicketComponent } from './modules/order-ticket/order-ticket.component';
import { TicketComponent } from './modules/order-ticket/select-ticket/ticket.component';
import { SeatComponent } from './modules/order-ticket/select-seat/seat.component';
import { BillComponent } from './modules/order-ticket/bill/bill.component';
import { ShowTimeComponent } from './modules/show-time/show-time.component';
import { TicketItemComponent } from './modules/main/ticket-item/ticket-item.component';

import { HeaderComponent } from './modules/layout/header/header.component';
import { FooterComponent } from './modules/layout/footer/footer.component';
import { EventComponent } from './modules/layout/event/event.component';
import { ReviewComponent } from './modules/review/review.component';
import { FoodComponent } from './modules/order-ticket/select-food/food.component';
import { ConfirmComponent } from './modules/order-ticket/confirm/confirm.component';
import { OrderSuccessComponent } from './modules/order-ticket/order-success/order-success.component';
import { TicketShowtimeComponent } from './modules/main/ticket-showtime/ticket-showtime.component';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { DragableComponent } from './modules/dragable/dragable.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DragableComponent,

    NotFoundComponent,

    MainComponent,
    BreadcrumbComponent,
    OrderTicketComponent,
    TicketComponent,
    SeatComponent,
    BillComponent,
    ShowTimeComponent,
    TicketItemComponent,
    HeaderComponent,
    FooterComponent,
    EventComponent,
    ReviewComponent,
    FoodComponent,
    ConfirmComponent,
    OrderSuccessComponent,
    TicketShowtimeComponent,
  ],
  imports: [
    DragDropModule,
    MatSliderModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    AppRoutingModule,
    MatProgressSpinnerModule,
    FormsModule,
    MatInputModule,
    MatToolbarModule,
    MatButtonToggleModule,
    MatIconModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatPaginatorModule,
    HttpClientModule,
    NgToastModule,
    MatSelectModule,
    MatDialogModule,
    MatSidenavModule,
    MatTabsModule,
    MatMenuModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatExpansionModule,
  ],
  providers: [
    // {
    //   provide: HTTP_INTERCEPTORS,
    //   useClass: AuthInterceptorService,
    //   multi: true,
    // },
    { provide: LocationStrategy, useClass: HashLocationStrategy },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
