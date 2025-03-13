import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function ValidateDate(value: string): boolean {
    const isoFormat = /^\d{4}-\d{2}-\d{2}$/; // YYYY-MM-dd
    if (!isoFormat.test(value)) {
      return false; // La chaîne ne correspond pas au format attendu
    }
    else
    {
        return true;
    }
}

  export function dateRangeValidator(dateDebutKey: string, dateFinKey: string): ValidatorFn {
    return (group: AbstractControl): ValidationErrors | null => {
      const dateDebut = group.get(dateDebutKey)?.value;
      const dateFin = group.get(dateFinKey)?.value;
  
      // Vérifier si les dates sont valides et si la dateDebut est après la dateFin
      if (dateDebut && dateFin && new Date(dateDebut) > new Date(dateFin)) {
        return { dateRangeInvalid: true }; // Retourne une erreur
      }
  
      return null; // Pas d'erreur
    };
  }

  export function maxDateTodayValidator(): (control: AbstractControl) => ValidationErrors | null {
    return (control: AbstractControl): ValidationErrors | null => {
      const inputDate = new Date(control.value);
      const today = new Date();
      if (control.value && inputDate > today) {
        return { maxDate: { value: control.value, max: today.toISOString().split('T')[0] } };
      }
      return null;
    };
  }


export function maxDateThisMonthValidator(): (control: AbstractControl) => ValidationErrors | null {
  return (control: AbstractControl): ValidationErrors | null => {
    if (!control.value) {
      return null; // Pas d'erreur si le champ est vide
    }

    const inputDate = new Date(control.value);
    const today = new Date();

    // Vérification : l'année et le mois ne doivent pas dépasser le mois en cours
    if (inputDate.getFullYear() > today.getFullYear() || 
       (inputDate.getFullYear() === today.getFullYear() && inputDate.getMonth() > today.getMonth())) {
      return {
        maxDateThisMonth: {
          value: control.value,
          max: `${today.getFullYear()}-${(today.getMonth() + 1).toString().padStart(2, '0')}`, // Format YYYY-MM
        }
      };
    }
    
    return null;
  };
}
