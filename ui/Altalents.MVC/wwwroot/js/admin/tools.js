function formatDate(date) {
  if (date) {
    var d = new Date(date), // Conversion en objet Date
      day = String(d.getDate()).padStart(2, '0'),
      month = String(d.getMonth() + 1).padStart(2, '0'),
      year = d.getFullYear(),
      hours = String(d.getHours()).padStart(2, '0'),
      minutes = String(d.getMinutes()).padStart(2, '0');

    return `${day}/${month}/${year} ${hours}:${minutes}`;
  }
  return "-";
}
