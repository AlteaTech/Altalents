import { FormArray, FormControl, FormGroup } from "@angular/forms";
import { Reference } from "../models/reference.model";
import { ProjectOrMissionClient } from "../models/project-mission.model";
import { ProjectForm } from "./project-mission-form";

export interface ExperienceForm {
    
    typeContrat: FormControl<Reference | null>,
    intitulePoste: FormControl<string | null>,
    entreprise: FormControl<string | null>,
    isEntrepriseEsnOrInterim: FormControl<boolean | null>,
    dateDebut: FormControl<string | null>,
    dateFin: FormControl<string | null>,
    isPosteActuel: FormControl<boolean | null>,
    lieu: FormControl<string | null>,
    domaineMetier: FormControl<Reference | null>,
    technologies: FormControl<Reference[] | null>,
    competences: FormControl<Reference[] | null>,
    methodologies: FormControl<Reference[] | null>,
    outils: FormControl<Reference[] | null>,
    projects: FormArray<FormGroup<ProjectForm>>;

}