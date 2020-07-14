import { Component, OnInit } from '@angular/core';
import { DishGroup } from 'app/shared/models/dish-group';
import { DISH_GROUPS } from 'app/shared/dish-groups';
import { EDishType } from 'app/shared/enums/EDishType';

@Component({
  selector: 'app-grid-dishes',
  templateUrl: './grid-dishes.component.html',
  styleUrls: ['./grid-dishes.component.scss']
})
export class GridDishesComponent implements OnInit {
  public dishGroups: DishGroup[] = DISH_GROUPS;

  constructor() { }

  ngOnInit(): void {
  }
}
