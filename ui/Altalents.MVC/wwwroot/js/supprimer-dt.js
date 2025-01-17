    function actionConfirmationDeleteDt(idDt, callbackFinalize) {
        $.ajax({
            //cette constante : deleteDtUrl doit imperativement etre definit dans la page de l'appelant 
            url: deleteDtUrl,
            type: "POST",
            data: { dossierTechniqueId: idDt },
            success: function (recData) {
                if (recData.Errors) {

                  //Cette methode est defenit dans site-admin.js
                    erreurFunction(recData.Errors);
                }
                else {
                  //Cette methode est defenit dans site-admin.js
                    suppressionReussie();

                    //cette methode : deleteDtUrl doit imperativement etre definit dans la page de l'appelant 
                    reloadGrid();
                }
            },
            error: erreurFunction,
            finalize: function () {
                //Cette methode est defenit dans site-admin.js
                callbackFinalize();
            }
        });
    }

    function actionNonConfirmationDeleteDt(callbackFinalize) {
      //Cette methode est defenit dans site-admin.js
        callbackFinalize();
    }

    function onSupprimerDossietTechniqueClick(idDt) {

      //Cette methode est defenit dans site-admin.js
        var functionOnConfirmation = function (callbackFinalize) {
            actionConfirmationDeleteDt(idDt, callbackFinalize);
        }

        //Cette methode est defenit dans site-admin.js
        openConfirmationSuppressionDTDialog(functionOnConfirmation, actionNonConfirmationDeleteDt);
    }
