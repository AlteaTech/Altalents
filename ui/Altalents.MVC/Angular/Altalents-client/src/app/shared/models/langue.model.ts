import { LangueParleeDto } from "../services/generated/api/api.client";
import { Reference } from "./reference.model";

export class Langue {
    id!: string;
    langue?: Reference;
    niveau?: Reference;

    public static from(dto : LangueParleeDto):Langue{
        var model = new Langue ();
        model.id = dto.idLangue!;

        //Code a ajuster une fois qu'on aura pris la decision concernant l'incoherance de model entre ce qui existe en back et front
        // model.niveau = dto.niveau!;
        // model.langue = dto.libelleLangue!;
        
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