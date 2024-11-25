import { FormControl } from "@angular/forms";

export interface ParlonsDeVousForm {
    prenom: FormControl<string | null>,
    nom: FormControl<string | null>,
    numeroTelephone1: FormControl<string | null>,
    numeroTelephone2: FormControl<string | null>,
    adresseMail: FormControl<string | null>,
    adresse1: FormControl<string | null>,
    adresse2: FormControl<string | null>,
    codePostal: FormControl<string | null>,
    ville: FormControl<string | null>,
    pays: FormControl<string | null>,
    synthese: FormControl<string | null>
}