import { Component, Input, OnInit, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-month-year-picker',
  templateUrl: './month-year-picker.component.html',
  styleUrls: ['./month-year-picker.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => MonthYearPickerComponent),
      multi: true
    }
  ]
})
export class MonthYearPickerComponent implements OnInit, ControlValueAccessor {

  @Input() idPrefix: string = '';  // Ajout d'un input pour l'ID dynamique

  public moisList = [
    { value: '01', label: 'Janvier' },
    { value: '02', label: 'Février' },
    { value: '03', label: 'Mars' },
    { value: '04', label: 'Avril' },
    { value: '05', label: 'Mai' },
    { value: '06', label: 'Juin' },
    { value: '07', label: 'Juillet' },
    { value: '08', label: 'Août' },
    { value: '09', label: 'Septembre' },
    { value: '10', label: 'Octobre' },
    { value: '11', label: 'Novembre' },
    { value: '12', label: 'Décembre' }
  ];
  
  public anneesList: number[] = [];
  public moisSelectionne: string = '';
  public anneeSelectionnee: string = '';
  public isDisabled: boolean = false;  // Variable pour gérer la désactivation

  private onChange: (value: Date | null) => void = () => {};
  private onTouched: () => void = () => {};

  constructor() {}

  ngOnInit(): void {
    const currentYear = new Date().getFullYear();
    for (let i = currentYear; i >= 1950; i--) {
      this.anneesList.push(i);
    }
  }

  writeValue(value: Date | null): void {
    if (value) {
      this.moisSelectionne = String(value.getMonth() + 1).padStart(2, '0');
      this.anneeSelectionnee = String(value.getFullYear());
    } else {
      this.moisSelectionne = '';
      this.anneeSelectionnee = '';
    }
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
  }

  updateValue(): void {
    if (this.moisSelectionne && this.anneeSelectionnee) {
      const selectedDate = new Date(`${this.anneeSelectionnee}-${this.moisSelectionne}-01`);
      this.onChange(selectedDate);
    } else {
      this.onChange(null);
    }
    this.onTouched();
  }
}
