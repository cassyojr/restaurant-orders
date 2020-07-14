import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderPreviewComponent } from './order-preview.component';

describe('OrderPreviewComponent', () => {
  let component: OrderPreviewComponent;
  let fixture: ComponentFixture<OrderPreviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrderPreviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderPreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
