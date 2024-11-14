import { CompetenceDto } from "../services/generated/api/api.client";

export class Competence {
    idLiaison!: string;
    libelle?: string | null;
    niveau!: number ;
    typeLiaisonCode!: string;
    
    public static from(dto : CompetenceDto):Competence{
        var model = new Competence ();
        model.idLiaison = dto.idLiaison;
        model.libelle = dto.libelle;
        model.niveau = dto.niveau || 0; 
        return model;
      }
    
    public static fromList(dtos : CompetenceDto[]):Competence[]{
      var model: Competence[] = [];
      dtos.forEach(dto => {
        model.push(this.from(dto));
      });
      return model;
    }

}