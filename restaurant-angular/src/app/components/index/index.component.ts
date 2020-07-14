import { Component, OnInit } from '@angular/core';
import { Order } from 'app/shared/models/order';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {
  public order: string = '';

  constructor() { }

  ngOnInit(): void {
  }

  public onOrderCreated($event: string) {
    this.order = $event;
  }
}
