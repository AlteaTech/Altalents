using Altalents.Entities.Extensions;

namespace Altalents.Entities.Enum
{
    public enum EnumTypeReference
    {
        [Display(Name = "Image")]
        [TypeReference(638182053590000000, 1, true, true)]
        [Bdd("FABF8050-8255-44A0-BF03-D9A8C3A5D84C")]
        Image = 1,
        [Display(Name = "Technique")]
        [TypeReference(638182053590000000, 1, true, true)]
        [Bdd("EBC5DDEE-B5BC-463D-8729-62317735C7A5")]
        Technique = 2,
        [Display(Name = "Nom")]
        [TypeReference(638182053590000000, 1, false, false)]
        [Bdd("541B3D32-1DFD-4034-BD01-A182F41B7223")]
        Nom = 3,
        [Display(Name = "Pays")]
        [TypeReference(638182053590000000, 1, true, true)]
        [Bdd("1489AFD9-58EB-4A05-B52F-6C2F268512C8")]
        Pays = 4,
        [Display(Name = "Texte")]
        [TypeReference(638182053590000000, 1, true, true)]
        [Bdd("407E711D-183C-4395-9C65-A1CF0ADC4198")]
        Texte = 5,
        [Display(Name = "Couleur")]
        [TypeReference(638182053590000000, 1, true, false)]
        [Bdd("0335D175-3378-43F4-8683-E9D7BAD3CDC4")]
        Couleur = 6,
        [Display(Name = "Localisation")]
        [TypeReference(638182053590000000, 1, true, false)]
        [Bdd("A84D4874-3577-46B8-853B-25910A0F67C8")]
        Localisation = 7,
        [Display(Name = "Catégorie")]
        [TypeReference(638182053590000000, 1, true, true)]
        [Bdd("0C829CB7-C123-40D2-B542-DE6C30B4ABD3")]
        Categorie = 8,
        [Display(Name = "Contour")]
        [TypeReference(638182053590000000, 1, true, true)]
        [Bdd("428179BA-98F9-4010-9626-6B6F7B69011F")]
        Contour = 9,
    }
}
