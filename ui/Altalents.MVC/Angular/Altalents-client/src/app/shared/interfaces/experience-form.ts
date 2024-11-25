import { FormControl } from "@angular/forms";
import { Reference } from "../models/reference.model";

export interface ExperienceForm {
    
    typeContrat: FormControl<Reference | null>,
    intitulePoste: FormControl<string | null>,
    entreprise: FormControl<string | null>,
    isClientFinal: FormControl<boolean | null>,
    clientFinal: FormControl<string | null>,
    dateDebut: FormControl<string | null>,
    dateFin: FormControl<string | null>,
    isPosteActuel: FormControl<boolean | null>,
    lieu: FormControl<string | null>,
    description: FormControl<string | null>,
    domaineMetier: FormControl<Reference | null>,
    compositionEquipe: FormControl<string | null>,
    technologies: FormControl<Reference[] | null>,
    competences: FormControl<Reference[] | null>,
    methodologies: FormControl<Reference[] | null>,
    outils: FormControl<Reference[] | null>,
    isBudgetGere: FormControl<boolean | null>,
    budgetGere: FormControl<number | null>,
}