import { ProjetOrMissionClientDto } from "../services/generated/api/api.client";
import { Reference } from "./reference.model";

export class ProjectOrMissionClient {

    NomClientOrProjet?: string;
    descriptionProjetOrMission!: string;
    taches!: string;
    lieu!: string;
    budget?: number;
    compositionEquipe?: string;
    dateDebut?: Date;
    dateFin?: Date;
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
        model.compositionEquipe = dto.descriptionProjetOrMission!;
        model.dateDebut = dto.dateDebut ? new Date(dto.dateDebut) : undefined; 
        model.dateFin = dto.dateFin ? new Date(dto.dateFin) : undefined; 
        model.domaineMetier = dto.domaineMetier ? Reference.fromReferenceDto(dto.domaineMetier) : undefined; 
      
    //   model.typeContrat = Reference.fromReferenceDto(dto.typeContrat);
    //   model.intitulePoste = dto.intitulePoste;
    //   model.nomEntreprise = dto.nomEntreprise;
      
    //   model.IsEntrepriseEsnOrInterim = dto.isEntrepriseEsnOrInterim;
    //   model.dateDebut = new Date(dto.dateDebut);
    //   model.dateFin = dto.dateFin ? new Date(dto.dateFin) : undefined;
    //   model.lieu = dto.lieuEntreprise;
    //   model.description = dto.description;
    //   model.domaineMetier = Reference.fromReferenceDto(dto.domaineMetier);
    //   model.technologies = dto.technologies ? Reference.fromListReferenceDto(dto.technologies) : undefined;
    //   model.competences = dto.competences ? Reference.fromListReferenceDto(dto.competences) : undefined;
    //   model.methodologies = dto.methodologies ? Reference.fromListReferenceDto(dto.methodologies) : undefined;
    //   model.outils = dto.outils ? Reference.fromListReferenceDto(dto.outils) : undefined;
    //   model.budgetGere = dto.budget ?? undefined;

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