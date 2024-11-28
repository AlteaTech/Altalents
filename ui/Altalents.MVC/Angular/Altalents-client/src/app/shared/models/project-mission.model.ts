import { Constantes } from "../constantes/constantes";
import { ProjetOrMissionClientDto } from "../services/generated/api/api.client";
import { DureeExperienceService } from "../services/services/calculators/duree-experience-calculator";
import { ValidateDate } from "../services/services/validators/validate-date";
import { Reference } from "./reference.model";

export class ProjectOrMissionClient {

    NomClientOrProjet!: string;
    descriptionProjetOrMission!: string;
    taches!: string;
    lieu!: string;
    budget?: number;
    compositionEquipe!: string;
    dateDebut!: string;
    dateFin!: string;
    domaineMetier?: Reference;

    // champs calculés 
    dureeExperience?: string;

    static from(dto : ProjetOrMissionClientDto):ProjectOrMissionClient{
      var model = new ProjectOrMissionClient ();

        model.NomClientOrProjet = dto.nomClientOrProjet!;
        model.descriptionProjetOrMission = dto.descriptionProjetOrMission!;
        model.taches = dto.taches!;
        model.lieu = dto.lieu!;
        model.budget = dto.budget!;
        model.compositionEquipe = dto.compositionEquipe!;
        model.dateDebut = dto.dateDebut! ; 
        model.dateFin = dto.dateFin! ; 
        model.domaineMetier = dto.domaineMetier ? Reference.fromReferenceDto(dto.domaineMetier) : undefined; 
        model.dureeExperience = model.dateDebut ? DureeExperienceService.CalculateDureeExperience(new Date(model.dateDebut!), ValidateDate(model.dateFin)?new Date(model.dateFin):undefined) : undefined;

        
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