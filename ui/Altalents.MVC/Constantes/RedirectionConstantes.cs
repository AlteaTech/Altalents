namespace Altalents.MVC.Constantes
{
    public static class RedirectionConstantes
    {
        public static string Home => "~/";
        public static string LoggedHome => "~/"+RoutesNamesConstantes.MvcAreaAdmin+"/"+ RoutesNamesConstantes.MvcControllerTableauDeBord ;
        public static string LoginPage => "~/"+RoutesNamesConstantes.MvcAreaAdmin+ "/"+RoutesNamesConstantes.MvcControllerAccount + "/" + RoutesNamesConstantes.MvcControllerAccount_MethodeLogin;
        public static string ReLogin => "/"+RoutesNamesConstantes.MvcAreaAdmin+"/"+ RoutesNamesConstantes.MvcControllerAutoLogout;
        public static string ForceLogout => "~/"+RoutesNamesConstantes.MvcAreaAdmin+"/"+ RoutesNamesConstantes.MvcControllerAutoLogout+ "/"+ RoutesNamesConstantes.MvcControllerAutoLogout_MethodeRedirect;
    }
}
