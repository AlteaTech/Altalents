import { FormControl } from "@angular/forms";

export interface CertificationForm {
    libelle: FormControl<string | null>,
    domaine: FormControl<string | undefined>,
    niveau: FormControl<string | undefined>,
    organisme: FormControl<string | undefined>,
    dateDebut: FormControl<string | null>,
    dateFin: FormControl<string | null>,
}