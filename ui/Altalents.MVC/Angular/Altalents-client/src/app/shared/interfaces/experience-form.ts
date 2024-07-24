import { FormControl } from "@angular/forms";
import { Reference } from "../models/reference.model";

export interface ExperienceForm {
    typeContrat: FormControl<Reference | undefined>,
    intitulePoste: FormControl<string | undefined>,
    entreprise: FormControl<string | undefined>,
    isClientFinal: FormControl<boolean | undefined>,
    clientFinal: FormControl<string | undefined>,
    dateDebut: FormControl<string | undefined>,
    dateFin: FormControl<string | undefined>,
    isPosteActuel: FormControl<boolean | undefined>,
    lieu: FormControl<string | undefined>,
    description: FormControl<string | undefined>,
    domaineMetier: FormControl<string | undefined>,
    compositionEquipe: FormControl<string | undefined>,
    technologies: FormControl<Reference[] | undefined>,
    competences: FormControl<Reference[] | undefined>,
    methodologies: FormControl<Reference[] | undefined>,
    isBudgetGere: FormControl<boolean | undefined>,
    budgetGere: FormControl<number | undefined>,
}