import { FormationCertificationDto } from "../services/generated/api/api.client";

export class Certification {
    id!: string;
    libelle?: string;
    domaine?: string;
    niveau?: string;
    organisme?: string;
    dateDebut!: Date;
    dateFin?: Date;

    public static from(dto : FormationCertificationDto):Certification{
        var model = new Certification ();
        model.id = dto.id;
        model.dateDebut =  new Date(dto.dateDebut!);
        model.dateFin = dto.dateFin ? new Date(dto.dateFin) : undefined;
        model.domaine = dto.domaine!;
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