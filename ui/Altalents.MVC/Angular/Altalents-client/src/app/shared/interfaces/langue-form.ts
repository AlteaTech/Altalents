import { FormControl } from "@angular/forms";
import { CodeLibelle } from "../models/code-libelle.model";

export interface LangueForm {
    libelle: FormControl<string | undefined>,
    niveau: FormControl<CodeLibelle | undefined>
}