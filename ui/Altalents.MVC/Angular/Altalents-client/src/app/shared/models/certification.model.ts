import { FormationCertificationDto } from "../services/generated/api/api.client";
import { DureeExperienceService } from "../services/services/calculators/duree-experience-calculator";

export class Certification {
    id!: string;
    libelle!: string;
    niveau?: string;
    organisme?: string;
    dateObtention!: Date;

    public static from(dto : FormationCertificationDto):Certification{
        var model = new Certification ();
        model.id = dto.id;

        model.dateObtention = new Date(dto.dateObtention!);
        model.libelle = dto.libelle!;
        model.niveau = dto.niveau!;
        model.organisme = dto.organisme!;

        return model;
      }

      public static fromList(dtos : FormationCertificationDto[]):Certification[]{
        var model: Certification[] = [];
        dtos.forEach(dto => {
          model.push(this.from(dto));
        });
        return model;
      }

}