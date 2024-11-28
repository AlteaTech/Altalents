export function ValidateDate(value: string): boolean {
    const isoFormat = /^\d{4}-\d{2}-\d{2}$/; // YYYY-MM-dd
    if (!isoFormat.test(value)) {
      return false; // La chaîne ne correspond pas au format attendu
    }
    else
    {
        return true;
    }
  

  }