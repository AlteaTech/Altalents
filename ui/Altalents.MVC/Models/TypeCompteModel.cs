using Altalents.Commun.Enums;

using AlteaTools.Api.Core.Extensions;

namespace Altalents.MVC.Models
{
    public class TypeCompteModel
    {
        public string Text => Value.GetDisplayName(false);
        public TypeUtilisateurEnum Value { get; set; }
    }
}
