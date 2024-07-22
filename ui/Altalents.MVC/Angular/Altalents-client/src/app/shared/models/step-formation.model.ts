import { Certification } from "./certification.model";
import { Formation } from "./formation.model";
import { Langue } from "./langue.model";

export class StepFormation {
    formations: Formation[] = [];
    certifications: Certification[] = [];
    langues: Langue[] = [];
}