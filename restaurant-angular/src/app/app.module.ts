import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';


import { AppComponent } from './app.component';
import { GridOrdersComponent } from './components/grid-orders/grid-orders.component';
import { IndexComponent } from './components/index/index.component';
import { GridDishesComponent } from './components/grid-dishes/grid-dishes.component';
import { OrderPreviewComponent } from './components/order-preview/order-preview.component';
import { CreateOrderComponent } from './components/create-order/create-order.component';
import { RequestInterceptor } from './shared/interceptor/request.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    GridOrdersComponent,
    IndexComponent,
    GridDishesComponent,
    OrderPreviewComponent,
    CreateOrderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    RouterModule,
    HttpClientModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: RequestInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
