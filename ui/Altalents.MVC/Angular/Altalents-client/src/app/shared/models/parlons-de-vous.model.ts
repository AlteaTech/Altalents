import { ParlonsDeVousDto } from "../services/generated/api/api.client";
import { Adress } from "./adress.model";
import { PieceJointe } from "./piece-jointe.model";

export class ParlonsDeVous {

    prenom?: string | null;
    nom?: string | null;
    telephone1?: string | null;
    telephone2?: string | null;
    email?: string | null;
    adresse?: Adress;
    synthese?: string | null;
    zoneGeo?: string | null;
    pieceJointe?: PieceJointe;

    public static from(dto : ParlonsDeVousDto):ParlonsDeVous{

        var model = new ParlonsDeVous ();

        model.prenom = dto.prenom;
        model.nom = dto.nom;
        model.telephone1 = dto.telephone1;
        model.telephone2 = dto.telephone2;
        model.email = dto.email;
        model.adresse = dto.adresse;
        model.synthese = dto.synthese;
        
        if(dto.documents && dto.documents[0])
        {
          model.pieceJointe = PieceJointe.from(dto.documents[0]);
        }

        return model;
      }
}