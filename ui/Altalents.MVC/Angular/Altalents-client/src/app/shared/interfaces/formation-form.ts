import { FormControl } from "@angular/forms";

export interface FormationForm {
    formationLibelle: FormControl<string | undefined>,
    domaine: FormControl<string | undefined>,
    niveau: FormControl<string | undefined>,
    organisme: FormControl<string | undefined>,
    dateDebut: FormControl<string | undefined>,
    dateFin: FormControl<string | undefined>
}