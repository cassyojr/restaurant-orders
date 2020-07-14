import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from '../models/order';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {
  private orderSubject = new Subject<any>();
  public orderCreatedSubject$ = this.orderSubject.asObservable();

  constructor(private httpClient: HttpClient) { }

  async createOrder(dishes: string): Promise<Order> {
    const createdOrder = await this.httpClient.post<Order>('/api/v1/Restaurant', JSON.stringify(dishes)).toPromise();
    this.orderSubject.next(createdOrder);

    return createdOrder;
  }

  async getAll(): Promise<Order[]> {
    return await this.httpClient.get<Order[]>(`/api/v1/Restaurant`).toPromise();
  }
}
