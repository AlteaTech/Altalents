import { FormationCertificationDto } from "../services/generated/api/api.client";
import { DureeExperienceService } from "../services/services/calculators/duree-experience-calculator";

export class Formation {
    id!: string;
    libelle!: string;
    niveau?: string;
    organisme!: string;
    dateObtention!: Date;

    // champs calculés 
    dureeExperience?: string;

    public static from(dto : FormationCertificationDto):Formation{

        var model = new Formation ();

        model.id = dto.id;
        model.dateObtention =  new Date(dto.dateObtention!);

        model.libelle = dto.libelle!;
        model.niveau = dto.niveau!;
        model.organisme = dto.organisme!;

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

