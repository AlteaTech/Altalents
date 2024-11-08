import { CompetenceDto } from "../services/generated/api/api.client";

export class Competence {
    ldLiaison!: string;
    libelle?: string | null;
    niveau!: number ;
    typeLiaisonCode!: string;
    
    static from(dto : CompetenceDto):Competence{
        var model = new Competence ();
        model.ldLiaison = dto.idLiaison;
        model.libelle = dto.libelle;
        model.niveau = dto.niveau || 0; // Assurez-vous que 'niveau' est initialisé

        return model;
      }
    
      static fromList(dtos : CompetenceDto[]):Competence[]{
        var model: Competence[] = [];
        dtos.forEach(dto => {
          model.push(this.from(dto));
        });
        return model;
      }

}