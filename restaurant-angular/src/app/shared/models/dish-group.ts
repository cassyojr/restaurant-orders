import { Dish } from './dish';
import { EDishType } from '../enums/EDishType';

export interface DishGroup {
    id: number;
    type: EDishType;
    morning: Dish;
    night: Dish;
}
