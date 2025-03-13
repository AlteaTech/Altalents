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


// Fonction pour récupérer un paramètre depuis l'URL
function getUrlParameter(name) {
  name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
  var regex = new RegExp("[\\?&]" + name + "=([^&#]*)");
  var results = regex.exec(location.search);
  return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}
