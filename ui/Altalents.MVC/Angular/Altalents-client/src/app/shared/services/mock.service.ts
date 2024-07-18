import { Injectable } from "@angular/core";
import { StepFormation } from "../models/step-formation.model";
import { Formation } from "../models/formation.model";
import { CodeLibelle } from "../models/code-libelle.model";

@Injectable({
    providedIn: 'root'
})
export class MockService {
    public getNiveauxLangues(): CodeLibelle[] {
        let basique = new CodeLibelle();
        basique.libelle = "Basique";
        basique.code = "Basique";

        let intermediaire = new CodeLibelle();
        intermediaire.libelle = "Intermédiaire";
        intermediaire.code = "Intermediaire";
        
        let avance = new CodeLibelle();
        avance.libelle = "Avancé";
        avance.code = "Avance";
        
        let bilingue = new CodeLibelle();
        bilingue.libelle = "Bilingue";
        bilingue.code = "Bilingue";

        let niveauLangues: CodeLibelle[] = [];
        niveauLangues.push(basique);
        niveauLangues.push(intermediaire);
        niveauLangues.push(avance);
        niveauLangues.push(bilingue);
        return niveauLangues;
    }
}