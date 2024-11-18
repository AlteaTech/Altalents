export class DureeExperienceService {

public static CalculateDureeExperience(dateDebut: Date, dateFin?: Date) : string {
   
    if (dateDebut) {
      const dateFinFinal = dateFin ? new Date(dateFin) : new Date();
      const dateDebutFinal = new Date(dateDebut);
      const jours: number = Math.round((Date.UTC(dateFinFinal.getFullYear(), dateFinFinal.getMonth(), dateFinFinal.getDate())
                                          - Date.UTC(dateDebutFinal.getFullYear(), dateDebutFinal.getMonth(), dateDebutFinal.getDate()))
                                        / (1000 * 60 * 60 * 24));

      if(jours <= 30) {
        return jours + " jours";
      }
      else if(jours < 365) {
        return Math.round(jours/30) + " mois";
      }
      else {
        return Math.round(jours/365) + " ans";
      }
    }
    throw new Error("dateDebut est requis");
  }
}