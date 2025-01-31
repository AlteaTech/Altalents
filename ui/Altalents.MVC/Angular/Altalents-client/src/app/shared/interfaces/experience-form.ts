import { FormArray, FormControl, FormGroup } from "@angular/forms";
import { Reference } from "../models/reference.model";
import { ProjectOrMissionClient } from "../models/project-mission.model";
import { ProjectForm } from "./project-mission-form";

export interface ExperienceForm {
    
    typeContrat: FormControl<Reference | null>,
    intitulePoste: FormControl<string | null>,
    entreprise: FormControl<string | null>,
    isEntrepriseEsnOrInterim: FormControl<boolean | null>,
    dateDebut: FormControl<Date | null>,
    dateFin: FormControl<Date | null>,
    isPosteActuel: FormControl<boolean | null>,
    lieu: FormControl<string | null>,
    domaineMetier: FormControl<Reference | null>,

    projects: FormArray<FormGroup<ProjectForm>>;

}