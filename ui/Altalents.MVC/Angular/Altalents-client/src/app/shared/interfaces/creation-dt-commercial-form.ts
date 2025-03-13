import { FormControl } from "@angular/forms";

export interface CreationDtCommercialForm {
    prenom: FormControl<string | null>,
    nom: FormControl<string | null>,
    trigram: FormControl<string | null>,
    numeroTelephone1: FormControl<string | null>,
    adresseMail: FormControl<string | null>,
    poste: FormControl<string | null>,
    isPrixJourEnable: FormControl<boolean | null>,
    prixJour: FormControl<number | null>,
    disponibilite: FormControl<string | null>,
    idBoond: FormControl<string | null>,
}