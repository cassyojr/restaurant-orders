import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GridDishesComponent } from './grid-dishes.component';

describe('GridDishesComponent', () => {
  let component: GridDishesComponent;
  let fixture: ComponentFixture<GridDishesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GridDishesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridDishesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
