import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-order-preview',
  templateUrl: './order-preview.component.html',
  styleUrls: ['./order-preview.component.scss']
})
export class OrderPreviewComponent implements OnInit {
  @Input('order') order: string;

  constructor() { }

  ngOnInit(): void {
    this.order = this.order || 'Your last order will be shown here';
  }
}
