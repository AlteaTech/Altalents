import { AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { catchError, map } from 'rxjs/operators';
import { of } from 'rxjs';
import { ApiServiceAgent } from '../../services-agents/api.service-agent';

export function ValidateTelephoneWithApi(apiService: ApiServiceAgent, isOptionnale: boolean): AsyncValidatorFn {
  return (control: AbstractControl) => {
    if(isOptionnale && ( control.value == null || control.value == '' || control.value == undefined)){
      return of(null);
    }
    if(control.value.length <= 1){
      return of({ invalidField: true });
    }
    return apiService.isTelephoneValid(control.value, isOptionnale).pipe(
      map(response => {
        return response ? null : { invalidField: true };
      }),
      catchError((response_: any) =>{
        return of({ invalidField: true })
  })
    );
  };
}
