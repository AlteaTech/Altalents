import { FormControl } from "@angular/forms";
import { Reference } from "../models/reference.model";

export interface ProjectForm {
    
    NomClientOrProjet: FormControl<string | null>,
    descriptionProjetOrMission: FormControl<string | null>,
    taches: FormControl<string | null>,
    lieu: FormControl<string | null>,
    budget: FormControl<number | null>,
    compositionEquipe: FormControl<string | null>,
    dateDebut: FormControl<string | null>,
    dateFin: FormControl<string | null>,
    domaineMetier: FormControl<Reference | null>
}