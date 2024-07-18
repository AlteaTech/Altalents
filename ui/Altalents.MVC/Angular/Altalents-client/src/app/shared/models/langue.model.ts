import { CodeLibelle } from "./code-libelle.model";

export class Langue {
    id!: number;
    libelle?: string;
    niveau?: CodeLibelle;
}