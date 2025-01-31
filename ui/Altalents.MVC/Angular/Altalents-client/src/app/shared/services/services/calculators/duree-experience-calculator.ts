export class DureeExperienceService {
  public static CalculateDureeExperience(dateDebut: Date, dateFin?: Date, ignoreDays: boolean = false): string {
    if (!dateDebut) {
      throw new Error("dateDebut est requis");
    }

    const dateFinFinal = dateFin ? new Date(dateFin) : new Date();
    const dateDebutFinal = new Date(dateDebut);

    // Calcul de la différence en mois et années
    let totalMois =
      (dateFinFinal.getFullYear() - dateDebutFinal.getFullYear()) * 12 +
      (dateFinFinal.getMonth() - dateDebutFinal.getMonth());

    const joursRestants =
      dateFinFinal.getDate() - dateDebutFinal.getDate();

    // Ajustement si le dernier mois n'est pas complet
    if (joursRestants < 0) {
      totalMois -= 1;
    }

    const ans = Math.floor(totalMois / 12);
    const mois = totalMois % 12;

    // Construction du résultat
    let result = "";
    if (ans > 0) {
      result += `${ans} an${ans > 1 ? "s" : ""}`;
    }
    if (mois > 0) {
      result += `${ans > 0 ? " " : ""}${mois} mois`;
    }

    // Si on ne veut pas afficher les jours
    if (ignoreDays) {
      return result.trim();
    }

    // Ajouter les jours uniquement si aucune année ni mois n'est calculé
    if (!result && joursRestants > 0) {
      result = `${joursRestants} jour${joursRestants > 1 ? "s" : ""}`;
    }

    return result.trim();
  }
}
