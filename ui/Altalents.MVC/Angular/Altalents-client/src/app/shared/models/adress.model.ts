import { AdresseDto} from "../services/generated/api/api.client";

export class Adress {

    adresse1?: string | null;
    adresse2?: string | null;
    codePostal?: string | null;
    ville?: string | null;
    pays?: string | null;

    public get getFormatedAdress():string{
      const addressParts = [
        this.adresse1,
        this.adresse2,
        this.codePostal,
        this.ville,
        this.pays
      ];
      return addressParts.filter(part => part).join(', ');

    }

    public static from(dto : AdresseDto):Adress{

        var model = new Adress ();

        model.adresse1 = dto.adresse1;
        model.adresse2 = dto.adresse2;
        model.codePostal = dto.codePostal;
        model.ville = dto.ville;
        model.pays = dto.pays;

        return model;
      }

      public static fromList(dtos : AdresseDto[]):Adress[]{
        var model: Adress[] = [];
        dtos.forEach(dto => {
          model.push(this.from(dto));
        });
        return model;
      }
}