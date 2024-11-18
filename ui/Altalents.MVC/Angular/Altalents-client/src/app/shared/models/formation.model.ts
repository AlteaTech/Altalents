import { FormationCertificationDto } from "../services/generated/api/api.client";
import { DureeExperienceService } from "../services/services/calculators/duree-experience-calculator";

export class Formation {
    id!: string;
    libelle!: string;
    domaine?: string;
    niveau?: string;
    organisme?: string;
    dateDebut!: Date;
    dateFin?: Date;

    // champs calculés 
    dureeExperience?: string;

    public static from(dto : FormationCertificationDto):Formation{

        var model = new Formation ();

        model.id = dto.id;
        model.dateDebut =  new Date(dto.dateDebut!);
        model.dateFin = dto.dateFin ? new Date(dto.dateFin) : undefined;
        model.domaine = dto.domaine!;
        model.libelle = dto.libelle!;
        model.niveau = dto.niveau!;
        model.organisme = dto.organisme!;
        model.dureeExperience = DureeExperienceService.CalculateDureeExperience(model.dateDebut, model.dateFin);

        return model;
        
      }

      public static fromList(dtos : FormationCertificationDto[]):Formation[]{
        var model: Formation[] = [];
        dtos.forEach(dto => {
          model.push(this.from(dto));
        });
        return model;
      }

}

