import { AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { of } from 'rxjs';

export function ValidateIsNumber(): AsyncValidatorFn {
  return (control: AbstractControl) => {
    if (!Number.isNaN(+control.value)) return of(null);;
    return of({ invalidField: true });
  };
}
