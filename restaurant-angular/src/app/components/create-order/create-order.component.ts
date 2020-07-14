import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { OrderValidator } from 'app/shared/validators/common.validators';
import { MORNING_REGEXP, NIGHT_REGEXP, DISHES_REGEXP } from 'app/shared/common.regex';
import { DISH_GROUPS } from 'app/shared/dish-groups';
import { DishGroup } from 'app/shared/models/dish-group';
import { Dish } from 'app/shared/models/dish';
import { EDishTime } from 'app/shared/enums/EDishTime';
import { EDishType } from 'app/shared/enums/EDishType';
import { RestaurantService } from 'app/shared/services/restaurant.service';
import { CreatedOrder } from 'app/shared/models/created-order';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.scss']
})
export class CreateOrderComponent implements OnInit {
  @Output() orderCreated = new EventEmitter<string>();

  public isFormSubmited: boolean = false;
  public form = new FormGroup({
    order: new FormControl(null, [
      Validators.required,
      OrderValidator.hasValidOrderTime,
      OrderValidator.isValidOrder
    ]),
  });

  constructor(private restaurantService: RestaurantService) { }

  ngOnInit(): void {
  }

  async onSubmit(): Promise<void> {
    this.isFormSubmited = true;

    if (this.form.invalid) return;

    const createdOrder = this.createrOrder();

    if (!createdOrder.hasError)
      await this.restaurantService.createOrder(createdOrder.dishes);

    this.onOrderCreated(createdOrder.dishes);
  }

  public onOrderCreated(order: string): void {
    this.orderCreated.emit(order);
  }

  private createrOrder(): CreatedOrder {
    const isMorning = MORNING_REGEXP.test(this.order.value);
    const isNight = NIGHT_REGEXP.test(this.order.value);
    const onlyDishes = this.order.value.trim().match(DISHES_REGEXP);
    const dishes = onlyDishes[0]
      .split(',')
      .map((d: any) => d.trim())
      .filter((d: any) => d != null && d != '');

    if (isMorning) {
      return this.getDishes(EDishTime.Morning, dishes);
    } else if (isNight) {
      return this.getDishes(EDishTime.Night, dishes);
    } else
      return new CreatedOrder(true);
  }

  private getDishes(dishTime: EDishTime, dishes: string[]): CreatedOrder {
    const order: any[] = [];
    let hasError = false;

    if (dishes.length == 0) return new CreatedOrder();

    const validDishes = this.getFilteredDishes(dishTime, dishes);

    for (const dish of dishes) {
      const currentGroup = validDishes.find(dg => dg.id == +dish);

      if (!currentGroup) {
        hasError = true;
        break;
      }

      const isDishAdded = order.find(a => a == currentGroup);

      if (isDishAdded) {
        if (currentGroup.dish.repeatable) {
          order.push(currentGroup);
        } else {
          hasError = true;
          break;
        }
      } else {
        order.push(currentGroup);
      }
    }

    const sortedDishes = this.sortDishes(order);
    let groupedDishes = this.groupDishes(sortedDishes);

    if (hasError) groupedDishes += ' error';

    const createdOrder = new CreatedOrder();
    createdOrder.dishes = this.replaceUnusedCommas(groupedDishes);
    createdOrder.hasError = hasError;

    return createdOrder;
  }

  private sortDishes(dishes: any[]): Dish[] {
    const sortOrder = [EDishType.Entree, EDishType.Side, EDishType.Drink, EDishType.Dessert];

    return dishes
      .sort((a, b) => sortOrder.indexOf(a.type) - sortOrder.indexOf(b.type))
      .map(a => a.dish);
  }

  private getFilteredDishes(time: EDishTime, dishes: string[]): any[] {
    let validDishes = [];

    if (time == EDishTime.Morning) {
      validDishes = DISH_GROUPS
        .filter(dg => dishes.includes(dg.id.toString()))
        .map((dg: DishGroup) => {
          return { id: dg.id, type: dg.type, dish: dg.morning };
        })
        .filter(dg => dg.dish);
    }
    else if (time == EDishTime.Night) {
      validDishes = DISH_GROUPS
        .filter(dg => dishes.includes(dg.id.toString()))
        .map((dg: DishGroup) => {
          return { id: dg.id, type: dg.type, dish: dg.night };
        })
        .filter(dg => dg.dish);
    }

    return validDishes;
  }

  private replaceUnusedCommas(order: string): string {
    return order.replace(/(,),*(,|$)/, '');
  }

  private groupDishes(order: Dish[]): string {
    const groupedDishes = order
      .reduce((result, currentValue) => {
        (result[currentValue.name] = result[currentValue.name] || []).push(currentValue);
        return result;
      }, []);

    let groupedOrder = '';

    for (const key in groupedDishes) {
      if (groupedDishes[key].length == 1) {
        groupedOrder += `${key}, `;
      } else {
        groupedOrder += `${key}(x${groupedDishes[key].length}), `;
      }
    }

    return groupedOrder.trim();
  }

  get hasErrors(): boolean {
    return this.isFormSubmited && this.form.invalid;
  }

  get order(): AbstractControl {
    return this.form.controls.order;
  }
}
