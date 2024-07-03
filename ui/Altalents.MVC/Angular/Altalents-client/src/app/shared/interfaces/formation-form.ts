import { FormControl } from "@angular/forms";

export interface FormationForm {
    formation: FormControl<string | null>,
    domaine: FormControl<string | null>,
    niveau: FormControl<string | null>,
    organisme: FormControl<string | null>,
    dateDebut: FormControl<string | null>,
    dateFin: FormControl<string | null>
}