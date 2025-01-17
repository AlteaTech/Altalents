// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function suppressionReussie() {
  showNotification('Suppression réussie.', 'success');
}

function enregistrementReussi() {
  showNotification('Enregistrement réussi.', 'success');
}

function publicationReussie() {
  showNotification('Publication réussie.', 'success');
}

function openDialog(dialogId, titre, recData) {
  let modal = $(dialogId).data("kendoDialog");
  modal.open().title(titre);
  $(dialogId).html(recData);
  displayWindowCenteredOnYAxis(modal);
}

function closeDialog(dialogId) {
  let modal = $(dialogId).data("kendoDialog");
  modal.close();
}

function erreurFunctionInEvents(e) {
  erreurFunction(e.errors);
}

function erreurFunction(e) {
  if (e.status == 404) {
    showBusinessMessage("Elément non trouvé");
  }
  else if (e["Business Error"] && e["Business Error"].errors[0]) {
    showBusinessMessage(e["Business Error"].errors[0]);
  }
  else if (e.status == 400 && e.responseJSON.messsageError !== null) {
    showBusinessMessage(e.responseJSON.messsageError);
  }
  else {
    alert('A error');
  }
}

function onDataBoundGloblalEdit(e, editSuffixe) {
  var allBtns = $('[editBtn="' + editSuffixe + '"]', e.sender.element);
  allBtns.each(function (index) {
    var current = $(this);
    var data = e.sender.dataItems()[index];
    if (!data.IsModifiable) {
      current.attr("disabled", "true");
    }
  });
}

function onDataBoundGloblalDelete(e, editSuffixe) {
  var allBtns = $('[deleteBtn="' + editSuffixe + '"]', e.sender.element);
  allBtns.each(function (index) {
    var current = $(this);
    var data = e.sender.dataItems()[index];
    if (!data.IsSupprimable) {
      current.attr("disabled", "true");
    }
  });
}

function displayWindowCenteredOnYAxis(kendoWindow) {
  var windowOptions = kendoWindow.options;
  var pos = kendoWindow.wrapper.position();
  var viewPortWidth = $(window).width();
  var wndWidth = windowOptions.width;
  pos.left = viewPortWidth / 2 - wndWidth / 2;
  kendoWindow.wrapper.css({
    left: pos.left
  });
  kendoWindow.open();
}

function SyncGridHandler(e) {
  this.read();
}

function showBusinessMessage(message) {
  showNotification(message, "warning");
}

function showNotification(message, typeNotification) {
  var popupNotification = $("#popupNotification").data("kendoNotification");
  popupNotification.show(message, typeNotification);
}

function openConfirmationDialog(actionSiConfirmation, actionSiNonConfirmation, idDialog, titre, texte) {
  openDialog(idDialog, titre, texte);
  modelModaleDialog.actionSiConfirmation = actionSiConfirmation
  modelModaleDialog.actionSiNonConfirmation = actionSiNonConfirmation
}

function openConfirmationSuppressionUtilisateurDialog(actionSiConfirmation, actionSiNonConfirmation) {
  debugger;
  openConfirmationSuppressionDialog(actionSiConfirmation, actionSiNonConfirmation, 'Supprimer un compte d’utilisateur', 'Etes-vous sûr(e) de vouloir supprimer le compte d’utilisateur');
}

function openConfirmationSuppressionDTDialog(actionSiConfirmation, actionSiNonConfirmation) {
  debugger;
  openConfirmationSuppressionDialog(actionSiConfirmation, actionSiNonConfirmation, 'Supprimer un dossier Technique', 'Etes-vous sûr(e) de vouloir supprimer ce dossier Technique');
}

function openConfirmationSuppressionDialog(actionSiConfirmation, actionSiNonConfirmation, deleteHeaderMessage, deleteQuestionMessage) {
  if (!deleteHeaderMessage) {
    deleteHeaderMessage = 'Suppression d\'un élément';
  }
  if (!deleteQuestionMessage) {
    deleteQuestionMessage = 'Etes-vous sûr(e) de vouloir supprimer cet élément ?';
  }
  openConfirmationDialog(actionSiConfirmation, actionSiNonConfirmation, '#confirmationDialog', deleteHeaderMessage, deleteQuestionMessage)
}

function openConfirmationExportDialog(actionSiConfirmation, actionSiNonConfirmation) {
  openConfirmationDialog(actionSiConfirmation, actionSiNonConfirmation, '#confirmationDialog', 'Export des marques',"Etes-vous sûr(e) de vouloir exporter les marques ?")
}

function openConfirmationPublicationDialog(actionSiConfirmation, actionSiNonConfirmation) {
  openConfirmationDialog(actionSiConfirmation, actionSiNonConfirmation, '#confirmationDialog', 'Publier les marques',"Etes-vous sûr(e) de vouloir publier les marques ?")
}

function openConfirmationEnregistrementMarquePublieeDialog(actionSiConfirmation, actionSiNonConfirmation, texte) {
  openConfirmationDialog(actionSiConfirmation, actionSiNonConfirmation, '#confirmationDialog', 'Enregistrement de la marque', texte)
}

function openConfirmationSuppressionDTDialog(actionSiConfirmation, actionSiNonConfirmation, texte) {
  openConfirmationSuppressionDialog(
    actionSiConfirmation,
    actionSiNonConfirmation,
    'Supprimer un dossier technique',
    texte || 'Êtes-vous sûr(e) de vouloir supprimer ce dossier technique ?'
  );
}

function onConfirmationDialogClick() {
  if (typeof (modelModaleDialog.actionSiConfirmation) === "function") {
    modelModaleDialog.actionSiConfirmation(ResetModelModaleDialog);
  }
}

function onNonConfirmationDialogClick() {
  if (typeof (modelModaleDialog.actionSiNonConfirmation) === "function") {
    modelModaleDialog.actionSiNonConfirmation(ResetModelModaleDialog);
  }
}

function ResetModelModaleDialog() {
  modelModaleDialog = {
    actionSiConfirmation: null,
    actionSiNonConfirmation: null,
  };
}

let modelModaleDialog = {
  actionSiConfirmation : null,
  actionSiNonConfirmation : null,
};
