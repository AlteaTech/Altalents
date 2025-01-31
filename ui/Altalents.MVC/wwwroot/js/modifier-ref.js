var referenceWindow;

$(document).ready(function () {
  // Initialisation de la modal Kendo
  referenceWindow = $("#ReferenceWindow").kendoWindow({
    title: "Modifier la référence",
    modal: true,
    visible: false,
    resizable: false,
    actions: ["Close"]
  }).data("kendoWindow");

  // Sauvegarder le statut via AJAX
  $('#saveReferenceBtn').on('click', function () {

    const referenceId = $('#ReferenceId').val();
    const isValidatedCheckBox = $('#IsValidatedCheckBox').val();
    const libelle = $('#Libelle').val();
    const commentaire = $('#Commentaire').val();


    // Appel AJAX pour sauvegarder le nouveau statut
    $.ajax({
      url: updateRefUrl, // Définir cette variable dans chaque page
      type: 'POST',
      data: { id: referenceId, validated: isValidatedCheckBox, libelle: libelle, commentaire: commentaire },
      success: function (recData) {
        if (recData.Errors) {
          alert(recData.Errors.join('\n')); // Afficher les erreurs
        } else {
          closeKendoReferenceWindow();

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

function openKendoReferenceWindow(id, validated, libelle, commentaire) {
  // Remplir les données dans la modal


  $('#ReferenceId').val(id);
  $('#IsValidatedCheckBox').val(validated);
  $('#Libelle').val(libelle);
  $('#Commentaire').val(commentaire);

;

  // Ouvrir la modal
  referenceWindow.center().open();
}

function closeKendoReferenceWindow() {
  referenceWindow.close();
}
