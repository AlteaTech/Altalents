namespace Altalents.Business.Services
{
    internal class CustomSignInResult : Microsoft.AspNetCore.Identity.SignInResult
    {
        public CustomSignInResult(bool isNotAllowed, bool isLockedOut, bool requiresTwoFactor, bool succeeded)
        {
            IsNotAllowed = isNotAllowed;
            IsLockedOut = isLockedOut;
            RequiresTwoFactor = requiresTwoFactor;
            Succeeded = succeeded;
        }
    }
}
