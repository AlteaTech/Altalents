import { FormControl } from "@angular/forms";

export interface FormationForm {
    libelle: FormControl<string | null>,
    niveau: FormControl<string | undefined>,
    organisme: FormControl<string | null>,
    dateDebut: FormControl<string | null>,
    dateFin: FormControl<string | null>,
}