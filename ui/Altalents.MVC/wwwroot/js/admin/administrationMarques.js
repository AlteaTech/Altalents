function onSelectMarque(e) {
  reloadPartialViewUpdateMarque(e.dataItem.IdMarque);
}

function successFilesUploadFileMarque(item) {
  if (item != undefined && item.response != undefined && item.response.HasErreur) {
    showBusinessMessage(item.response.Message);
  } else {
    resetImages();
  }
}

function callBackHasSousReference(idDivSousReference, idDivReference, hasSousReferences, sousReferenceMultiSelectId, callbackWithSousRef) {
  if (hasSousReferences) {
    $(idDivSousReference).show();
    if (typeof (callbackWithSousRef) === 'function') {
      $(idDivReference).addClass("col-5");
      $(idDivReference).removeClass("col-10");
      callbackWithSousRef();
    }
  } else {
    $(idDivReference).removeClass("col-5");
    $(idDivReference).addClass("col-10");
    $(idDivSousReference).hide();
    selectedSousRef[sousReferenceMultiSelectId] = [];
  }
}

function onChangeSousRef(sousReferenceMultiSelectId) {
  selectedSousRef[sousReferenceMultiSelectId] = [];
  if (!$(sousReferenceMultiSelectId)) {
    return;
  }
  var sousReferenceIds = $(sousReferenceMultiSelectId).data("kendoMultiSelect");
  if (!sousReferenceIds) {
    return;
  }
  selectedSousRef[sousReferenceMultiSelectId] = sousReferenceIds.value();
}

function getSelectedReferencesIds(multiSelectId) {
  if (selectedSousRef[multiSelectId]) {
    return selectedSousRef[multiSelectId];
  }
  return getSelectedMultiSelect(multiSelectId);
}

function getSelectedMultiSelect(multiSelectId) {
  if (!$(multiSelectId)) {
    return [];
  }
  var referenceIds = $(multiSelectId).data("kendoMultiSelect");
  if (!referenceIds) {
    return [];
  }
  return referenceIds.value();
}

function onChangeSousPays() {
  onChangeSousRef("#SousReferencePaysIdsMultiSelect");
}

function onChangeSousTextes() {
  var sousReferenceMultiSelectId = "#SousReferenceTextesIdsMultiSelect";
  onChangeSousRef(sousReferenceMultiSelectId);
  reloadAffichageBtnNiveau3(sousReferenceMultiSelectId, "#ReferenceTextesIds");
}

function onChangeSousImages() {
  onChangeSousRef("#SousReferenceImagesIdsMultiSelect");
}

function onChangeSousCouleurs() {
  onChangeSousRef("#SousReferenceCouleursIdsMultiSelect");
}

function onChangeSousTechniques() {
  onChangeSousRef("#SousReferenceTechniquesIdsMultiSelect");
}

function onChangeSousLocalisations() {
  onChangeSousRef("#SousReferenceLocalisationsIdsMultiSelect");
}

function onChangeSousCategories() {
  onChangeSousRef("#SousReferenceCategoriesIdsMultiSelect");
}

function onChangeSousContours() {
  onChangeSousRef("#SousReferenceContoursIdsMultiSelect");
}

function reloadPartialSousReferencePays() {
  reloadPartialViewSousReference("ReferencePaysIds", "SousReferencePaysIdsMultiSelect", "PartialViewSousReferencesPays", "onChangeSousPays");
}

function reloadPartialSousReferenceTextes() {
  reloadPartialViewSousReference("ReferenceTextesIds", "SousReferenceTextesIdsMultiSelect", "PartialViewSousReferencesTextes", "onChangeSousTextes");
  reloadAffichageBtnNiveau3("#SousReferenceTextesIdsMultiSelect", "#ReferenceTextesIds");
}

function reloadPartialSousReferenceImages() {
  reloadPartialViewSousReference("ReferenceImagesIds", "SousReferenceImagesIdsMultiSelect", "PartialViewSousReferencesImages", "onChangeSousImages");
}

function reloadPartialSousReferenceCouleurs() {
  reloadPartialViewSousReference("ReferenceCouleursIds", "SousReferenceCouleursIdsMultiSelect", "PartialViewSousReferencesCouleurs", "onChangeSousCouleurs");
}

function reloadPartialSousReferenceTechniques() {
  reloadPartialViewSousReference("ReferenceTechniquesIds", "SousReferenceTechniquesIdsMultiSelect", "PartialViewSousReferencesTechniques", "onChangeSousTechniques");
}

function reloadPartialSousReferenceLocalisations() {
  reloadPartialViewSousReference("ReferenceLocalisationsIds", "SousReferenceLocalisationsIdsMultiSelect", "PartialViewSousReferencesLocalisations", "onChangeSousLocalisations");
}

function reloadPartialSousReferenceCategories() {
  reloadPartialViewSousReference("ReferenceCategoriesIds", "SousReferenceCategoriesIdsMultiSelect", "PartialViewSousReferencesCategories", "onChangeSousCategories");
}

function reloadPartialSousReferenceContours() {
  reloadPartialViewSousReference("ReferenceContoursIds", "SousReferenceContoursIdsMultiSelect", "PartialViewSousReferencesContours", "onChangeSousContours");
}

function onChangeReferencePaysMultiselect() {
  onChangeMultiselect('#divSousReferencePays', "#ReferencePaysIds", "#divReferencePays", "#SousReferencePaysIdsMultiSelect", reloadPartialSousReferencePays);
}

function onChangeReferenceTextesMultiselect() {
  onChangeMultiselect('#divSousReferenceTextes', "#ReferenceTextesIds", "#divReferenceTextes", "#SousReferenceTextesIdsMultiSelect", reloadPartialSousReferenceTextes);
  reloadAffichageBtnNiveau3("#SousReferenceTextesIdsMultiSelect", "#ReferenceTextesIds");
}

function onChangeReferenceImagesMultiselect() {
  onChangeMultiselect('#divSousReferenceImages', "#ReferenceImagesIds", "#divReferenceImages", "#SousReferenceImagesIdsMultiSelect", reloadPartialSousReferenceImages);
}

function onChangeReferenceCouleursMultiselect() {
  onChangeMultiselect('#divSousReferenceCouleurs', "#ReferenceCouleursIds", "#divReferenceCouleurs", "#SousReferenceCouleursIdsMultiSelect", reloadPartialSousReferenceCouleurs);
}

function onChangeReferenceTechniquesMultiselect() {
  onChangeMultiselect('#divSousReferenceTechniques', "#ReferenceTechniquesIds", "#divReferenceTechniques", "#SousReferenceTechniquesIdsMultiSelect", reloadPartialSousReferenceTechniques);
}

function onChangeReferenceLocalisationsMultiselect() {
  onChangeMultiselect('#divSousReferenceLocalisations', "#ReferenceLocalisationsIds", "#divReferenceLocalisations", "#SousReferenceLocalisationsIdsMultiSelect", reloadPartialSousReferenceLocalisations);
}

function onChangeReferenceCategoriesMultiselect() {
  onChangeMultiselect('#divSousReferenceCategories', "#ReferenceCategoriesIds", "#divReferenceCategories", "#SousReferenceCategoriesIdsMultiSelect", reloadPartialSousReferenceCategories);
}

function onChangeReferenceContoursMultiselect() {
  onChangeMultiselect('#divSousReferenceContours', "#ReferenceContoursIds", "#divReferenceContours", "#SousReferenceContoursIdsMultiSelect", reloadPartialSousReferenceContours);
}
