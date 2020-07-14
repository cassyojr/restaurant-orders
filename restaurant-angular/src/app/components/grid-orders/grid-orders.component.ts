import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { Order } from 'app/shared/models/order';
import { RestaurantService } from 'app/shared/services/restaurant.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-grid-orders',
  templateUrl: './grid-orders.component.html',
  styleUrls: ['./grid-orders.component.scss']
})
export class GridOrdersComponent implements OnInit, OnDestroy {
  private subscription: Subscription;

  public orders: Order[] = [];
  public page: number = 1;
  public pageSize: number = 5;
  public collectionSize: number = this.orders.length;

  constructor(private restaurantService: RestaurantService) { }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  ngOnInit(): void {
    this.subscription = this.restaurantService.orderCreatedSubject$
      .subscribe(() => this.refreshPage());

    this.getOrders().then(() => this.refreshPage());
  }

  async getOrders(): Promise<void> {
    this.orders = await this.restaurantService.getAll();
    this.collectionSize = this.orders.length;
  }

  async refreshPage(): Promise<void> {
    const tempOrders = await this.restaurantService.getAll();
    this.orders = tempOrders.slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }

  get hasTableData(): boolean {
    return this.orders.length > 0;
  }
}
