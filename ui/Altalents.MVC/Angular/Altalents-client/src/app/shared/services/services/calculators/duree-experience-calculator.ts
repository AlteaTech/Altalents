export class DureeExperienceService {
  public static CalculateDureeExperience(dateDebut: Date, dateFin?: Date): string {
    if (!dateDebut) {
      throw new Error("dateDebut est requis");
    }

    const dateFinFinal = dateFin ? new Date(dateFin) : new Date();
    const dateDebutFinal = new Date(dateDebut);
    
    // Calcul de la différence en jours
    const jours: number = Math.round(
      (Date.UTC(dateFinFinal.getFullYear(), dateFinFinal.getMonth(), dateFinFinal.getDate()) -
        Date.UTC(dateDebutFinal.getFullYear(), dateDebutFinal.getMonth(), dateDebutFinal.getDate())) /
        (1000 * 60 * 60 * 24)
    );

    if (jours <= 30) {
      return `${jours} jour${jours > 1 ? "s" : ""}`;
    } else if (jours < 365) {
      const mois = Math.round(jours / 30);
      return `${mois} mois`;
    } else {
      const ans = Math.round(jours / 365);
      return `${ans} an${ans > 1 ? "s" : ""}`;
    }
  }
}
