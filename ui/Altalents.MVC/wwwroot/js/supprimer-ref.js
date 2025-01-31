    function actionConfirmationDeleteReference(idRef, callbackFinalize) {
        $.ajax({
            //cette constante : deleteDtUrl doit imperativement etre definit dans la page de l'appelant 
          url: deleteRefUrl,
            type: "POST",
          data: { refId: idRef },
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

function onSupprimerReferenceClick(idRef) {

      //Cette methode est defenit dans site-admin.js
        var functionOnConfirmation = function (callbackFinalize) {
          actionConfirmationDeleteReference(idRef, callbackFinalize);
        }

        //Cette methode est defenit dans site-admin.js
      openConfirmationSuppressionReferenceDialog(functionOnConfirmation, actionNonConfirmationDeleteDt);
    }
