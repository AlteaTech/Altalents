import { LangueParleeDto } from "../services/generated/api/api.client";
import { Reference } from "./reference.model";

export class Langue {
    id!: string;

    idLangue?: string;
    libelleLangue?: string | null;
    idReferenceNiveau?: string;
    libelleReferenceNiveau?: string | null;

    public static from(dto : LangueParleeDto):Langue{

        var model = new Langue ();

        model.id = dto.dossierTechniqueLangueId;
        model.idLangue = dto.idLangue;
        model.libelleLangue = dto.libelleLangue;
        model.idReferenceNiveau = dto.idReferenceNiveau;
        model.libelleReferenceNiveau = dto.libelleReferenceNiveau;

        return model;
      }

      public static fromList(dtos : LangueParleeDto[]):Langue[]{
        var model: Langue[] = [];
        dtos.forEach(dto => {
          model.push(this.from(dto));
        });
        return model;
      }


}