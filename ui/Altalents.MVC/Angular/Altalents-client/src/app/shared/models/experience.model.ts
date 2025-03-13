import { ExperienceDto } from "../services/generated/api/api.client";
import { ProjectOrMissionClient } from "./project-mission.model";
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
    domaineMetier!: Reference;
    compositionEquipe?: string;
    projetOrMission?: ProjectOrMissionClient[];
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
      model.domaineMetier = Reference.fromReferenceDto(dto.domaineMetier);

      model.projetOrMission = dto.projetsOrMissionsClient ? ProjectOrMissionClient.fromList(dto.projetsOrMissionsClient) : undefined;

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