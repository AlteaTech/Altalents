import { ParlonsDeVousDto } from "../services/generated/api/api.client";
import { Adresse } from "./adresse.model";

export class ParlonsDeVous {
    prenom?: string | null;
    nom?: string | null;
    telephone1?: string | null;
    telephone2?: string | null;
    email?: string | null;
    adresse?: Adresse;

    public static from(dto: ParlonsDeVousDto): ParlonsDeVous {
        let model = new ParlonsDeVous();
        model.prenom = dto.prenom;
        model.nom = dto.nom;
        model.telephone1 = dto.telephone1;
        model.telephone2 = dto.telephone2;
        model.email = dto.email;
        if(dto.adresse) {
            model.adresse = Adresse.from(dto.adresse);
        }
        return model;
    }
}