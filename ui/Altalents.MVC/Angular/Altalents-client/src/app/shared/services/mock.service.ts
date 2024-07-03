import { Injectable } from "@angular/core";
import { StepFormation } from "../models/step-formation.model";
import { Formation } from "../models/formation.model";

@Injectable({
    providedIn: 'root'
})
export class MockService {
    public getStepFormation(): StepFormation {
        let formation = new Formation();
        formation.formationLibelle = "Libelle de la formation";
        formation.domaine = "Codage de code";
        formation.niveau = "BAC +34";
        formation.organisme = "école nationale du codage de code";
        formation.dateDebut = "07/03/2020";
        formation.dateFin = "13/12/2022";

        let mock = new StepFormation();
        mock.formations.push(formation);
        return mock;
    }
}