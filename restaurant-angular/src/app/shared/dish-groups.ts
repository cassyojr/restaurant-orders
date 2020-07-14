import { DishGroup } from './models/dish-group';
import { EDishType } from './enums/EDishType';
import { Dish } from './models/dish';
import { EDishTime } from './enums/EDishTime';

export const DISH_GROUPS: DishGroup[] = [
    {
        id: 1,
        type: EDishType.Entree,
        morning: {
            name: 'Eggs',
            time: EDishTime.Morning,
            repeatable: false
        } as Dish,
        night: {
            name: 'Steak',
            time: EDishTime.Night,
            repeatable: false
        } as Dish
    } as DishGroup,
    {
        id: 2,
        type: EDishType.Side,
        morning: {
            name: 'Toast',
            time: EDishTime.Morning,
            repeatable: false
        } as Dish,
        night: {
            name: 'Potato',
            time: EDishTime.Night,
            repeatable: true
        } as Dish,
    } as DishGroup,
    {
        id: 3,
        type: EDishType.Drink,
        morning: {
            name: 'Coffee',
            time: EDishTime.Morning,
            repeatable: true
        } as Dish,
        night: {
            name: 'Wine',
            time: EDishTime.Night,
            repeatable: false
        } as Dish
    } as DishGroup,
    {
        id: 4,
        type: EDishType.Dessert,
        night: {
            name: 'Cake',
            time: EDishTime.Night,
            repeatable: false
        } as Dish
    } as DishGroup
];