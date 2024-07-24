import { Reference } from "./reference.model";

export class Experience {
    id!: number;
    typeContrat?: Reference;
    intitulePoste?: string;
    entreprise?: string;
    clientFinal?: string;
    dateDebut?: string;
    dateFin?: string;
    isPosteActuel!: boolean;
    lieu?: string;
    description?: string;
    domaineMetier?: string;
    compositionEquipe?: string;
    technologies: Reference[] = [];
    competences: Reference[] = [];
    methodologies: Reference[] = [];
    budgetGere?: number;
}