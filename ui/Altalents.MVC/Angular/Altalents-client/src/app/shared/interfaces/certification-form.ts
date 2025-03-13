import { FormControl } from "@angular/forms";

export interface CertificationForm {
    libelle: FormControl<string | null>,
    niveau: FormControl<string | undefined>,
    organisme: FormControl<string | null>,
    dateObtention: FormControl<Date | null>,
}