import { ExperienceDto } from "../services/generated/api/api.client";
import { Reference } from "./reference.model";

export class Experience {
    id!:string;
    typeContrat!: Reference;
    intitulePoste!: string;
    entreprise!: string;
    clientFinal?: string;
    dateDebut!: Date;
    dateFin?: Date;
    lieu!: string;
    description!: string;
    domaineMetier!: string;
    compositionEquipe?: string;
    technologies?: Reference[];
    competences?: Reference[];
    methodologies?: Reference[];
    budgetGere?: number;

    // champs calculés 
    dureeExperience?: string;

    static from(dto : ExperienceDto):Experience{
      var model = new Experience ();
      model.id = dto.id;
      model.typeContrat = Reference.fromReferenceDto(dto.typeContrat);
      model.intitulePoste = dto.intitulePoste;
      model.entreprise = dto.entreprise;
      model.clientFinal = dto.clientFinal ?? undefined;
      model.dateDebut = new Date(dto.dateDebut);
      model.dateFin = dto.dateFin ? new Date(dto.dateFin) : undefined;
      model.lieu = dto.lieu;
      model.description = dto.description;
      model.domaineMetier = dto.domaineMetier;
      //model.compositionEquipe = dto.compositionEquipe;
      model.technologies = dto.technologies ? Reference.fromListReferenceDto(dto.technologies) : undefined;
      model.competences = dto.competences ? Reference.fromListReferenceDto(dto.competences) : undefined;
      model.methodologies = dto.methodologies ? Reference.fromListReferenceDto(dto.methodologies) : undefined;
      model.budgetGere = dto.budget ?? undefined;
      return model;
    }
  
    static fromList(dtos : ExperienceDto[]):Experience[]{
      var model: Experience[] = [];
      dtos.forEach(dto => {
        model.push(this.from(dto));
      });
      return model;
    }
}