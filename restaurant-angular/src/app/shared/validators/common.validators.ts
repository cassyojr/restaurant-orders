import { AbstractControl, ValidationErrors } from '@angular/forms';
import { ORDER_TIME_REGEXP, ORDER_REGEXP, MORNING_REGEXP, NIGHT_REGEXP } from '../common.regex';

export class OrderValidator {
    static hasValidOrderTime(control: AbstractControl): ValidationErrors | null {
        if (ORDER_TIME_REGEXP.test(control.value)) return null;
        return { hasValidOrderTime: true };
    }

    static isValidOrder(control: AbstractControl): ValidationErrors | null {
        if (!control.value) return null;

        const replacedValue = control.value.replace(MORNING_REGEXP, '').replace(NIGHT_REGEXP, '');

        if (!ORDER_REGEXP.test(replacedValue)) return null;
        return { isValidOrder: true };
    }
}
