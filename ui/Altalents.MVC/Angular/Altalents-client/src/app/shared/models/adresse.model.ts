import { AdresseDto } from "../services/generated/api/api.client";

export class Adresse {
    adresse1?: string | null;
    adresse2?: string | null;
    codePostal?: string | null;
    ville?: string | null;
    pays?: string | null;

    public static from(dto: AdresseDto): Adresse {
        let model = new Adresse();
        model.adresse1 = dto.adresse1;
        model.adresse2 = dto.adresse2;
        model.codePostal = dto.codePostal;
        model.ville = dto.ville;
        model.pays = dto.pays;
        return model;
    }
}