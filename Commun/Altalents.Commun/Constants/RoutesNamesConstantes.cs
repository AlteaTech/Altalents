using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.Commun.Constants
{
    public class RoutesNamesConstantes
    {
  

        //MVC ADMIN AREAS NAMES
        public const string MvcAreaAdmin = "Admin";

        //MVC ADMIN CONTROLERS & METHODES NAMES
        public const string MvcControllerTableauDeBord = "TableauDeBord";
        public const string MvcControllerTableauDeBord_MethodeIndex = "Index";
        public const string MvcControllerTableauDeBord_MethodeUpdateStatut = "UpdateStatut";
        public const string MvcControllerTableauDeBord_MethodeGetDtsCreesLimitedReal = "GetDtsCreesLimitedReal";
        public const string MvcControllerTableauDeBord_MethodeGetDtsAValiderLimitedReal = "GetDtsAValiderLimitedReal";
        public const string MvcControllerTableauDeBord_MethodeGetDtsTermineesLimitedReal = "GetDtsTermineesLimitedReal";

        public const string MvcControllerHome = "Home";
        public const string MvcControllerHome_MethodeIndex = "Index";

        public const string MvcControllerAccount = "Account";
        public const string MvcControllerAccount_MethodeIndex = "Index";
        public const string MvcControllerAccount_MethodeLogin = "Login";

        public const string MvcControllerBiblioDt = "BiblioDt";
        public const string MvcControllerBiblioDt_MethodeIndex = "Index";
        public const string MvcControllerBiblioDt_MethodeUpdateStatut = "UpdateStatut";
        public const string MvcControllerBiblioDt_MethodeGetBiblioDts = "GetBiblioDts";
        
        public const string MvcControllerAutoLogout = "AutoLogout";
        public const string MvcControllerAutoLogout_MethodeRedirect = "Redirect";

        public const string MvcControllerDataControle = "DataControle";
        public const string MvcControllerDataControle_MethodeIndex = "Index";
        public const string MvcControllerDataControle_MethodeGetReferences = "GetReferences";
        public const string MvcControllerDataControle_MethodeUpdateReference = "UpdateReference";

        public const string MvcControllerHomeAdmin = "HomeAdmin";
        public const string MvcControllerHomeAdmin_MethodeError = "Error";

        public const string MvcControllerIndicateurExtract = "IndicateurExtract";
        public const string MvcControllerIndicateurExtract_MethodeIndex = "Index";

        public const string MvcControllerUpdateCandidat = "UpdateCandidat";
        public const string MvcControllerUpdateCandidat_MethodeIndex = "Index";

        public const string MvcControllerUtilisateur = "Utilisateur";
        public const string MvcControllerUtilisateur_MethodeIndex = "Index";
        public const string MvcControllerUtilisateur_MethodeGetUtilisateurs = "GetUtilisateurs";
        public const string MvcControllerUtilisateur_MethodeCreateUtilisateur = "CreateUtilisateur";
        public const string MvcControllerUtilisateur_MethodeUpdateUtilisateur = "UpdateUtilisateur";
        public const string MvcControllerUtilisateur_MethodeDeleteUtilisateur = "DeleteUtilisateur";
        public const string MvcControllerUtilisateur_MethodeTypeCompte = "TypeCompte";




        //API AREAS NAMES

        //API SWAGGER ENDPOINT
        public const string ApiSwaggerEndpointName = "AltalentsApi";

        //API HANGFIRE ENDPOINT
        public const string HangfireEndpointName = "hangfire";

        //API HANGFIRE ENDPOINT
        public const string ApiSupervisionEndpointName = "state";
        public const string ApiSupervisionreadinessEndpointName = "readiness";
        

        //API CONTROLERS NAMES
        public const string ApiControllerDossiersTechniques = "DossiersTechniques";

        //API METHODE NAMES
        public const string ApiControllerDossierTechnique_MethodeDownloadDt = "download-dt";





        //ANGULAR APP
        public const string AngularApp_DossierTechnique = "dossier-technique";
    }
}
