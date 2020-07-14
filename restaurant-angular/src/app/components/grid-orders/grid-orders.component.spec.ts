import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GridOrdersComponent } from './grid-orders.component';

describe('GridOrdersComponent', () => {
  let component: GridOrdersComponent;
  let fixture: ComponentFixture<GridOrdersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GridOrdersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
