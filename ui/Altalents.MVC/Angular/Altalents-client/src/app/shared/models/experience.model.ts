import { ExperienceDto } from "../services/generated/api/api.client";
import { Reference } from "./reference.model";

export class Experience {
    id!:string;
    typeContrat!: Reference;
    intitulePoste!: string;
    nomEntreprise!: string;
    IsEntrepriseEsnOrInterim!: boolean;
    dateDebut!: Date;
    dateFin?: Date;
    lieu!: string;
    description!: string;
    domaineMetier!: Reference;
    compositionEquipe?: string;
    technologies?: Reference[];
    competences?: Reference[];
    methodologies?: Reference[];
    outils?: Reference[];
    budgetGere?: number;

    // champs calculés 
    dureeExperience?: string;

    static from(dto : ExperienceDto):Experience{
      var model = new Experience ();
      model.id = dto.id;
      model.typeContrat = Reference.fromReferenceDto(dto.typeContrat);
      model.intitulePoste = dto.intitulePoste;
      model.nomEntreprise = dto.nomEntreprise;
      
      model.IsEntrepriseEsnOrInterim = dto.isEntrepriseEsnOrInterim!;
      model.dateDebut = new Date(dto.dateDebut);
      model.dateFin = dto.dateFin ? new Date(dto.dateFin) : undefined;
      model.lieu = dto.lieuEntreprise;
      model.description = dto.description;
      model.domaineMetier = Reference.fromReferenceDto(dto.domaineMetier);
      model.technologies = dto.technologies ? Reference.fromListReferenceDto(dto.technologies) : undefined;
      model.competences = dto.competences ? Reference.fromListReferenceDto(dto.competences) : undefined;
      model.methodologies = dto.methodologies ? Reference.fromListReferenceDto(dto.methodologies) : undefined;
      model.outils = dto.outils ? Reference.fromListReferenceDto(dto.outils) : undefined;
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