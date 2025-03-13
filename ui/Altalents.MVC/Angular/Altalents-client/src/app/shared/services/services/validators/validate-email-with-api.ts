import { AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { catchError, map } from 'rxjs/operators';
import { of } from 'rxjs';
import { ApiServiceAgent } from '../../services-agents/api.service-agent';

export function ValidateEmailWithApi(apiService: ApiServiceAgent, token: string | undefined): AsyncValidatorFn {
  return (control: AbstractControl) => {
    if(control.value.length <= 1){
      return of({ invalidField: true });
    }
    return apiService.isEmailValid(control.value, token).pipe(
      map(response => {
        return response ? null : { invalidField: true };
      }),
      catchError(() => of({ invalidField: true }))
    );
  };
}
