export class DataFormatService {

  // Fonction de formatage de devise
  public static FormatCurrencyEuro(value: string): string {
    let number = parseFloat(value.replace(/[^0-9,.]/g, '').replace(/,/g, '.'));
  
    if (isNaN(number)) return '0 €';  // Retourne 0 si la conversion échoue.
  
    // Formatage du nombre avec le séparateur de milliers et un maximum de 2 décimales
    let formattedValue = number
      .toLocaleString('fr-FR', { minimumFractionDigits: 0, maximumFractionDigits: 2 })
      .replace(/\s/g, '\u00A0'); // Remplace les espaces par des espaces insécables
  
    // Ajouter le symbole de l'euro au début
    formattedValue = formattedValue + ' €' ;
  
    return formattedValue;
  }

}