import { FormControl } from "@angular/forms";
import { Reference } from "../models/reference.model";

export interface ProjectForm {
    
    id: FormControl<string | null>,
    nomClientOrProjet: FormControl<string | null>,
    descriptionProjetOrMission: FormControl<string | null>,
    taches: FormControl<string | null>,
    lieu: FormControl<string | null>,
    budget: FormControl<number | null>,
    compositionEquipe: FormControl<string | null>,
    dateDebut: FormControl<Date | null>,
    dateFin: FormControl<Date | null>,
    isEnCours: FormControl<boolean | null>,
    domaineMetier: FormControl<Reference | null>,

    technologies: FormControl<Reference[] | null>,
    competences: FormControl<Reference[] | null>,
    methodologies: FormControl<Reference[] | null>,
    outils: FormControl<Reference[] | null>
}