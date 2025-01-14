var statusWindow;

$(document).ready(function () {
  // Initialisation de la modal Kendo
  statusWindow = $("#statusWindow").kendoWindow({
    title: "Modifier le statut",
    modal: true,
    visible: false,
    resizable: false,
    actions: ["Close"]
  }).data("kendoWindow");

  // Sauvegarder le statut via AJAX
  $('#saveStatusBtn').on('click', function () {
    const dtId = $('#dtId').val();
    const newStatus = $('#statusDropdown').val();

    // Appel AJAX pour sauvegarder le nouveau statut
    $.ajax({
      url: saveStatusUrl, // Définir cette variable dans chaque page
      type: 'POST',
      data: { id: dtId, statutId: newStatus },
      success: function (recData) {
        if (recData.Errors) {
          alert(recData.Errors.join('\n')); // Afficher les erreurs
        } else {
          closeKendoStatusWindow();

          // Recharger les grilles (recharger via des fonctions spécifiques à la page)
          if (typeof reloadGrids === 'function') {
            reloadGrids();
          }
        }
      },
      error: function () {
        alert('Une erreur est survenue lors de la mise à jour du statut.');
      }
    });
  });
});

function openKendoStatusWindow(id, currentStatus) {
  // Remplir les données dans la modal
  $('#dtId').val(id);
  $('#statusDropdown').val(currentStatus);

  // Ouvrir la modal
  statusWindow.center().open();
}

function closeKendoStatusWindow() {
  statusWindow.close();
}
