import { Constantes } from "../constantes/constantes";
import { ProjetOrMissionClientDto } from "../services/generated/api/api.client";
import { DureeExperienceService } from "../services/services/calculators/duree-experience-calculator";
import { ValidateDate } from "../services/services/validators/validate-date";
import { Reference } from "./reference.model";

export class ProjectOrMissionClient {

    id!: string;
    nomClientOrProjet!: string;
    descriptionProjetOrMission!: string;
    taches!: string;
    lieu!: string;
    budget?: number;
    compositionEquipe!: string;
    dateDebut?: Date;
    dateFin?: Date;
    domaineMetier?: Reference;

    technologies?: Reference[];
    competences?: Reference[];
    methodologies?: Reference[];
    outils?: Reference[];

    // champs calculés 
    dureeExperience?: string;

    static from(dto : ProjetOrMissionClientDto):ProjectOrMissionClient{
      var model = new ProjectOrMissionClient ();

        model.id = dto.id;
        model.nomClientOrProjet = dto.nomClientOrProjet!;
        model.descriptionProjetOrMission = dto.descriptionProjetOrMission!;
        model.taches = dto.taches!;
        model.lieu = dto.lieu!;
        model.budget = dto.budget!;
        model.compositionEquipe = dto.compositionEquipe!;
        model.dateDebut = dto.dateDebut ? new Date(dto.dateDebut) : undefined; 
        model.dateFin = dto.dateFin ? new Date(dto.dateFin!): undefined;  
        model.domaineMetier = dto.domaineMetier ? Reference.fromReferenceDto(dto.domaineMetier) : undefined; 
        model.dureeExperience = model.dateDebut ? DureeExperienceService.CalculateDureeExperience(new Date(model.dateDebut!), model.dateFin ? new Date(model.dateFin):undefined, true) : undefined;

        model.technologies = dto.technologies ? Reference.fromListReferenceDto(dto.technologies) : undefined;
        model.competences = dto.competences ? Reference.fromListReferenceDto(dto.competences) : undefined;
        model.methodologies = dto.methodologies ? Reference.fromListReferenceDto(dto.methodologies) : undefined;
        model.outils = dto.outils ? Reference.fromListReferenceDto(dto.outils) : undefined;

      return model;

    }
  
    static fromList(dtos : ProjetOrMissionClientDto[]):ProjectOrMissionClient[]{
      var model: ProjectOrMissionClient[] = [];
      dtos.forEach(dto => {
        model.push(this.from(dto));
      });
      return model;
    }
}