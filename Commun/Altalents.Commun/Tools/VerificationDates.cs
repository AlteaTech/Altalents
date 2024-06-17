using AlteaTools.Api.Core.Exceptions;

namespace Altalents.Commun.Tools
{
    public static class VerificationDates
    {
        public static void VerifierDateFinPosterieureADateDebut(DateTime debut, DateTime fin, string messageErreur, bool strict = true)
        {
            if (strict && debut > fin)
            {
                throw new BusinessException(messageErreur);
            }

            if (!strict && debut >= fin)
            {
                throw new BusinessException(messageErreur);
            }
        }
    }
}
