using System.ComponentModel.DataAnnotations;

namespace Altalents.Commun.Enums
{
    public enum CodeReferenceEnum
    {
        Anglais = 1,
        Arabe = 2,
        Chinois = 3,
        Espagnol = 4,
        Francais = 5,
        Russe = 6,
        Albanais = 7,
        Allemand = 8,
        Amazigh = 9,
        Armenien = 10,
        Aymara = 11,
        Bengali = 12,
        Catalan = 13,
        Coreen = 14,
        Croate = 15,
        Danois = 16,
        Ewe = 17,
        Guarani = 18,
        Grec = 19,
        Hongrois = 20,
        Italien = 21,
        Japonais = 22,
        Kikongo = 23,
        Kiswahili = 24,
        Lingala = 25,
        Malgache = 26,
        Malais = 27,
        Mongol = 28,
        Neerlandais = 29,
        Occitan = 30,
        Ourdou = 31,
        Persan = 32,
        Portugais = 33,
        Quechua = 34,
        Roumain = 35,
        Samoan = 36,
        Serbe = 37,
        Sesotho = 38,
        Slovaque = 39,
        Slovene = 40,
        Suedois = 41,
        Tamoul = 42,
        Turc = 43,

        [Display(Name = "Immédiate")]
        Immediate = 44,
        [Display(Name = "1 mois")]
        SousUnMois = 45,
        [Display(Name = "3 mois")]
        SousTroisMois = 46,

        Telephone = 47,
        Cv = 48,
        Dt = 49,

        Cdi = 50,
        Cdd = 51,
        Freelance = 102,
        Alternance = 103,
        Stage = 104,

        //ATTENTION SI VOUS MODIFER OU SUPPRIMER le code d'un des statut, l'app front angular en contient de ref a ces code : VOIR StatutDtFromCodeReferenceEnumInBackend dans l'app angular
        [Display(Name = "Créé")]
        Cree = 52,
        [Display(Name = "À Valider")]
        AValider = 53,
        [Display(Name = "Terminé")]
        Termine = 54,

        Candidat = 58,
        Basique = 59,
        Intermediaire = 60,
        Avance = 61,
        Bilingue = 62,
        GestionProjet = 63,
        RedactionSpecifications = 64,
        AnalyseDonnees = 65,
        MarketingDigital = 66,
        ResponsabiliteEquipes = 67,
        Design = 68,
        GestionEquipe = 69,
        DeveloppementLogiciels = 70,
        MicrosoftOffice365 = 71,
        MicrosoftOffice = 72,
        Linux = 73,
        Windows = 74,
        Csharp = 75,
        Java = 76,
        Jee = 77,
        InVision = 78,
        Notion = 79,
        SCRUM = 80,
        KANBAN = 81,
        CycleV = 82,
        PERT = 83,
        Lean = 84,

   
        SanteMedical = 85,
        Education = 86,
        BanqueAssurance = 87,
        Energie = 88,
        Services = 89,
        GestionComptabilite = 90,
        TransportsLogistique = 91,
        CommerceDistribution = 92,
        TelecomInformatique = 93,
        Industrie = 94,
        TourismeLoisirs = 95,
        Environnement = 96,
        Immobilier = 97,
        Social = 98,
        Recherche = 99,
        Administration=100,
        AutreDomaines=101




    }
}
