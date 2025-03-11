var privateDataDtWindow;

$(document).ready(function () {
  // Initialisation de la modal Kendo
  referenceWindow = $("#PrivateDataDtWindow").kendoWindow({
    title: "Modifier les données privées",
    modal: true,
    visible: false,
    resizable: false,
    actions: ["Close"]
  }).data("kendoWindow");

  // Sauvegarder le statut via AJAX
  $('#SavePrivateDataDtBtn').on('click', function () {

    const dtId = $('#DtId').val();
    const email = $('#Email').val();
    const trigram = $('#Trigram').val();
    const poste = $('#Poste').val();
    const tarif = $('#Tarif').val();
    const newDispoGuid = $('#DispoDropdown option:selected').data('guid');

    // Appel AJAX pour sauvegarder le nouveau statut
    $.ajax({
      url: savePrivateDataUrl, // Définir cette variable dans chaque page qui appel ce service
      type: 'POST',
      data: { DtId: dtId, Email: email, Trigramme: trigram, Poste: poste, TarifJournalier: tarif, DisponibiliteId: newDispoGuid },
      success: function (recData) {
        if (recData.Errors) {
          alert(recData.Errors.join('\n')); // Afficher les erreurs
        } else {
          closeKendoPrivateDataWindow();

          // Recharger les grilles (recharger via des fonctions spécifiques à la page)
          if (typeof reloadGrid === 'function') {
            reloadGrid();
          }
        }
      },
      error: function () {
        alert('Une erreur est survenue lors de la mise à jour de la référence.');
      }
    });


  });
});

function openKendoPrivateDatatDteWindow(dtId) {
  // Remplir les données dans la modal


  // Appel AJAX pour charger les donnee a partir de l ID de DT
  $.ajax({
    url: getPrivateDataUrl + '?id=' + dtId, // Définir cette variable dans chaque page qui appel ce service
    type: 'GET',
    success: function (recData) {
      if (recData.Errors) {
        alert(recData.Errors.join('\n')); // Afficher les erreurs
      } else {

        $('#DtId').val(recData.DtId);
        $('#Email').val(recData.Email != 'null' ? recData.Email : "");
        $('#Trigram').val(recData.Trigramme != 'null' ? recData.Trigramme : "");
        $('#Poste').val(recData.Poste != 'null' ? recData.Poste : "");
        $('#Tarif').val(recData.TarifJournalier != 'null' ? recData.TarifJournalier : "");

        $('#DispoDropdown').val(recData.DisponibiliteId);

        // Ouvrir la modal
        referenceWindow.center().open();
      }
    },
    error: function () {
      alert('Une erreur est survenue lors de la mise à jour de la référence.');
    }
  });

}

function closeKendoPrivateDataWindow() {
  referenceWindow.close();
}



