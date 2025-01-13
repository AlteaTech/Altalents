import { ParlonsDeVousDto } from "../services/generated/api/api.client";
import { Adress } from "./adress.model";
import { PieceJointe } from "./piece-jointe.model";

export class ParlonsDeVous {

    prenom?: string | null;
    nom?: string | null;
    telephone1?: string | null;
    email?: string | null;
    adresse?: Adress;
    synthese?: string | null;
    softSKills?: string | null;
    zoneGeo?: string | null;
    pieceJointe?: PieceJointe;

    // Propriété calculée pour le nom formaté
    get formattedName(): string {
      const formattedPrenom = this.prenom 
          ? this.prenom.charAt(0).toUpperCase() + this.prenom.slice(1).toLowerCase() 
          : '';
      const upperNom = this.nom ? this.nom.toUpperCase() : '';
      return `${formattedPrenom} ${upperNom}`.trim();
  }

    public static from(dto : ParlonsDeVousDto):ParlonsDeVous{

        var model = new ParlonsDeVous ();

        model.prenom = dto.prenom;
        model.nom = dto.nom;
        model.telephone1 = dto.telephone1;
        model.email = dto.email;
        model.synthese = dto.synthese;
        model.zoneGeo = dto.zoneGeo;
        model.softSKills = dto.softSkills;

            // Transformation de AdresseDto en Adress
          if (dto.adresse) {
            model.adresse = new Adress();
            model.adresse.adresse1 = dto.adresse.adresse1;
            model.adresse.codePostal = dto.adresse.codePostal;
            model.adresse.ville = dto.adresse.ville;
            model.adresse.pays = dto.adresse.pays;
          }

        if(dto.documents && dto.documents[0])
        {
          model.pieceJointe = PieceJointe.from(dto.documents[0]);
        }

        return model;
      }
}