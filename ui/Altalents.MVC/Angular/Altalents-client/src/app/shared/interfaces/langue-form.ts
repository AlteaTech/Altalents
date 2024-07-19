import { FormControl } from "@angular/forms";
import { Reference } from "../models/reference.model";

export interface LangueForm {
    langue: FormControl<Reference | undefined>,
    niveau: FormControl<Reference | undefined>
}