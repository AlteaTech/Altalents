using Altalents.Entities.Extensions;

namespace Altalents.Entities.Enum
{
    public enum EnumReference
    {
        [Bdd("623A987E-F9F5-744A-BD6F-BE49708D5872")]
        [Reference("animal", "animal", EnumTypeReference.Image, 638182053590000000, 1, 1)]
        Animal = 1,
        [Bdd("6F2A1EBF-04B5-424F-B87A-758EDA1E4DF8")]
        [Reference("armoirie", "coat of arms", EnumTypeReference.Image, 638182053590000000, 1, 1)]
        Armoirie = 2,
        [Bdd("DA06A210-3153-B647-A20A-A03F4AB2DF8B")]
        [Reference("corps humain", "human body", EnumTypeReference.Image, 638182053590000000, 1, 1)]
        CorpsHumain = 3,
        [Bdd("9B168893-47FA-0040-BA31-EB0121824724")]
        [Reference("figure géométrique", "geometric figure", EnumTypeReference.Image, 638182053590000000, 1, 1)]
        FigureGeometrique = 4,
        [Bdd("1003B140-2A85-EC4C-9593-2214EAD7B7CA")]
        [Reference("objet ou représentation divers", "object or representation", EnumTypeReference.Image, 638182053590000000, 1, 1)]
        ObjetOuRepresentationDiverse = 5,
        [Bdd("C6390328-0DE8-BE45-BF77-E48B931845E3")]
        [Reference("végétal", "vegetation", EnumTypeReference.Image, 638182053590000000, 1, 1)]
        Vegetal = 6,
        [Bdd("050A2CF0-68AB-E846-BB93-BEAE8CAF2E73")]
        [Reference("marque au pochoir", "stencilled mark", EnumTypeReference.Technique, 638182053590000000, 4, 4)]
        MarquePochoir = 7,
        [Bdd("FE9FA763-F5A7-2D44-A611-837CBA4615DF")]
        [Reference("marque écrite", "written mark", EnumTypeReference.Technique, 638182053590000000, 2, 2)]
        MarqueEcrite = 8,
        [Bdd("AD901AAE-B7FF-7D44-B14A-2437B5E868AC")]
        [Reference("marque estampée", "stamped mark", EnumTypeReference.Technique, 638182053590000000, 1, 1)]
        MarqueEstampee = 9,
        [Bdd("E489D0A4-5D50-9041-A03B-F0A13952CD62")]
        [Reference("marque rapportée", "label", EnumTypeReference.Technique, 638182053590000000, 3, 3)]
        MarqueRapportee = 10,
        [Bdd("8DE86E9C-4FB8-9B41-AE58-8BE834D6B9BD")]
        [Reference("argent", "silver", EnumTypeReference.Couleur, 638182053590000000, 1, 1)]
        Argent = 11,
        [Bdd("4A109CC4-73BE-5A4A-A5D7-691B8253C23A")]
        [Reference("bleu", "blue", EnumTypeReference.Couleur, 638182053590000000, 1, 1)]
        Bleu = 12,
        [Bdd("D16E329C-98B2-E64D-8D2A-D8C3E0D2217A")]
        [Reference("brun", "brown", EnumTypeReference.Couleur, 638182053590000000, 1, 1)]
        Brun = 13,
        [Bdd("97227B33-2075-1E4F-911C-0E3A371FD512")]
        [Reference("jaune", "yellow", EnumTypeReference.Couleur, 638182053590000000, 1, 1)]
        Jaune = 14,
        [Bdd("1CCDBB6F-0DD1-334F-AC19-B682D598E684")]
        [Reference("noir", "black", EnumTypeReference.Couleur, 638182053590000000, 1, 1)]
        Noir = 15,
        [Bdd("6A5FE636-58F0-7447-8066-2C27E033F8F0")]
        [Reference("or", "gold", EnumTypeReference.Couleur, 638182053590000000, 1, 1)]
        Or = 16,
        [Bdd("5CB62F81-5F2E-4847-B384-A4CE50DD2894")]
        [Reference("orange", "orange", EnumTypeReference.Couleur, 638182053590000000, 1, 1)]
        Orange = 17,
        [Bdd("E1BF3579-E349-5645-9FAA-A7B490D9ACC6")]
        [Reference("rouge", "red", EnumTypeReference.Couleur, 638182053590000000, 1, 1)]
        Rouge = 18,
        [Bdd("2759E2F0-B831-E345-A369-616A16978FA0")]
        [Reference("vert", "green", EnumTypeReference.Couleur, 638182053590000000, 1, 1)]
        Vert = 19,
        [Bdd("37E2419F-1366-4F44-8B64-3E5AE3CEE3FE")]
        [Reference("violet", "purple", EnumTypeReference.Couleur, 638182053590000000, 1, 1)]
        Violet = 20,
        [Bdd("B06A7B0B-D3C3-CD48-A59C-13F31B30B1D2")]
        [Reference("caractère japonais", "japanese characters", EnumTypeReference.Texte, 638182053590000000, 4, 4)]
        CaractereJaponais = 21,
        [Bdd("0D02021A-1CC2-4C4F-B40E-C0FBD430264E")]
        [Reference("initiale", "initial", EnumTypeReference.Texte, 638182053590000000, 1, 1)]
        Initiale = 22,
        [Bdd("C9B48A64-7214-1745-978B-8CACEBE6097C")]
        [Reference("mot", "word", EnumTypeReference.Texte, 638182053590000000, 2, 2)]
        Mot = 23,
        [Bdd("9B50ADB6-07D6-8948-B41E-50AC82517576")]
        [Reference("numéro", "number", EnumTypeReference.Texte, 638182053590000000, 3, 3)]
        Numero = 24,
        [Bdd("CB382FD0-0139-5E4D-8018-75B8A55985B5")]
        [Reference("paraphe", "paraph", EnumTypeReference.Texte, 638182053590000000, 5, 5)]
        Paraphe = 25,
        [Bdd("7A0E83BE-E8D6-A741-8503-34E5527C055D")]
        [Reference("spécimen d'écriture", "writing sample", EnumTypeReference.Texte, 638182053590000000, 6, 6)]
        SpecimenEcriture = 26,
        [Bdd("0E3D3AC7-E706-114D-91E1-A407A37A22C4")]
        [Reference("autre", "other", EnumTypeReference.Localisation, 638182053590000000, 1, 1)]
        Autre = 27,
        [Bdd("1D98BF80-69AF-2540-9EA2-BF59C9EB6848")]
        [Reference("montage", "assembly", EnumTypeReference.Localisation, 638182053590000000, 1, 1)]
        Montage = 28,
        [Bdd("EF66F1B2-04F8-7B47-A17D-6D3DA3820167")]
        [Reference("recto", "recto", EnumTypeReference.Localisation, 638182053590000000, 1, 1)]
        Recto = 29,
        [Bdd("1A829DDE-A7A1-2142-8EF2-7C5259C1F5C0")]
        [Reference("verso", "verso", EnumTypeReference.Localisation, 638182053590000000, 1, 1)]
        Verso = 30,
        [Bdd("B74C6220-78D4-BF47-9E6B-0458D09EAE0E")]
        [Reference("Algérie", "Algeria", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Algerie = 31,
        [Bdd("1D5A2106-A203-0241-A8A1-2298137C2129")]
        [Reference("Allemagne", "Germany", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Allemagne = 32,
        [Bdd("16291A5B-C359-4C46-A0A7-E3915A6D79F2")]
        [Reference("Amérique du Sud", "South America", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        AmeriqueduSud = 33,
        [Bdd("F9DCE163-B6AB-7244-901C-97A146E87956")]
        [Reference("Argentine", "Argentina", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Argentine = 34,
        [Bdd("79BD59D1-FB0D-214E-AC1E-F9AB7C409AA1")]
        [Reference("Australie", "Australia", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Australie = 35,
        [Bdd("7AC19E77-D0FE-C84C-B58B-E27FE34C2A8B")]
        [Reference("Autriche", "Austria", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Autriche = 36,
        [Bdd("AEFC01CF-F4DB-FC43-908E-040E1C9C8041")]
        [Reference("Belgique", "Belgium", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Belgique = 37,
        [Bdd("F53B3305-97F9-7147-91E6-90C520D24CCC")]
        [Reference("Brésil", "Brazil", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Bresil = 38,
        [Bdd("4AE98B22-D56B-1847-9193-EBB732852BB4")]
        [Reference("Canada", "Canada", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Canada = 39,
        [Bdd("22AEAECD-6C67-584D-94FA-F1D87AB4A5F9")]
        [Reference("Chypre", "Cyprus", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Chypre = 40,
        [Bdd("665F0321-3716-DA45-A83C-E589E301A9CA")]
        [Reference("Danemark", "Denmark", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Danemark = 41,
        [Bdd("42869A21-C6E6-5745-9729-469D1E536618")]
        [Reference("Egypte", "Egypt", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Egypte = 42,
        [Bdd("728AE5CD-712A-7D41-9D42-D1A9691596F9")]
        [Reference("Espagne", "Spain", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Espagne = 43,
        [Bdd("504BAD24-CDCF-B849-A93D-E003BDB2B4A1")]
        [Reference("Estonie", "Estonia", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Estonie = 44,
        [Bdd("D65D993F-0B27-DF45-8C0E-9FF31F041B63")]
        [Reference("Etats-Unis", "United States", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        EtatsUnis = 45,
        [Bdd("50F53BBD-091D-4647-A57C-97CDC00FE2E6")]
        [Reference("Finlande", "Finland", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Finlande = 46,
        [Bdd("B4D86F62-46C2-4D41-A8B1-F515F2A22103")]
        [Reference("France", "France", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        France = 47,
        [Bdd("F4301C0A-8FAB-C940-AEBE-9192C43582B0")]
        [Reference("Hawaï", "Hawaii", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Hawai = 48,
        [Bdd("726BEEB0-5E15-EC44-AABB-3B8F963D6744")]
        [Reference("Hongrie", "Hungary", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Hongrie = 49,
        [Bdd("98318D36-CCC8-0340-9DAA-6B80422B44C9")]
        [Reference("Inde", "India", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Inde = 50,
        [Bdd("6E59D4D7-42C9-914E-9C32-21148735BA71")]
        [Reference("Irlande", "Ireland", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Irlande = 51,
        [Bdd("639A1DA5-2E79-FE42-9B2A-D668827C344A")]
        [Reference("Israel", "Israel", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Israel = 52,
        [Bdd("525A0B2E-5390-784D-8F7F-27F6344A0E3C")]
        [Reference("Italie", "Italy", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Italie = 53,
        [Bdd("B68E5A21-D66C-AB41-916E-400651CAE666")]
        [Reference("Japon", "Japan", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Japon = 54,
        [Bdd("7DAF94A0-5FEC-B444-BC61-5F94B455C9F2")]
        [Reference("Jersey", "Jersey", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Jersey = 55,
        [Bdd("EC790A75-4FBD-4E4B-8FCF-6FF51A77F708")]
        [Reference("Liechtenstein", "Liechtenstein", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Liechtenstein = 56,
        [Bdd("A41440D5-FA01-3F49-8041-0F89024BF1FE")]
        [Reference("Lituanie", "Lithuania", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Lituanie = 57,
        [Bdd("E575F758-2278-E346-A582-94ADE12FE933")]
        [Reference("Maroc", "Morocco", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Maroc = 58,
        [Bdd("249D2961-B052-9946-9349-14FD7F10642D")]
        [Reference("Norvège", "Norway", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Norvege = 59,
        [Bdd("7472764B-6144-0A41-9235-668533E1A190")]
        [Reference("Pays-Bas", "Netherlands", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        PaysBas = 60,
        [Bdd("F97784E0-13C4-8843-A9C1-C0A4953239B9")]
        [Reference("Pologne", "Poland", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Pologne = 61,
        [Bdd("47952CB9-F66C-7F4C-ACC0-A0F1D8753C62")]
        [Reference("Portugal", "Portugal", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Portugal = 62,
        [Bdd("4D918A28-4FBC-F943-A845-F9954D937F44")]
        [Reference("République Tchèque", "Czech Republic", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        RepubliqueTcheque = 63,
        [Bdd("CA1EF0C1-265C-254E-9036-FEB6E774F3D7")]
        [Reference("Roumanie", "Romania", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Roumanie = 64,
        [Bdd("5222535C-70EB-EE42-8A6A-957E378716DC")]
        [Reference("Royaume-Uni", "United Kingdom", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        RoyaumeUni = 65,
        [Bdd("1958866D-F7D7-4D40-A49D-B96E74D80057")]
        [Reference("Russie", "Russia", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Russie = 66,
        [Bdd("73277E87-09C2-1D49-AC87-79599A1BF91D")]
        [Reference("Slovaquie", "Slovakia", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Slovaquie = 67,
        [Bdd("D1BC641A-3D92-C84A-855D-47598DAE9F07")]
        [Reference("Suède", "Sweden", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Suede = 68,
        [Bdd("E972150D-51E0-1944-9519-A18DE1F2688A")]
        [Reference("Suisse", "Switzerland", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Suisse = 69,
        [Bdd("6F07069F-9215-E845-8930-CA0B25650F5B")]
        [Reference("Tchéquie", "Czechia", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Tchequie = 70,
        [Bdd("80457266-C806-6D40-9D5F-C169CEA93BA0")]
        [Reference("Ukraine", "Ukraine", EnumTypeReference.Pays, 638182053590000000, 1, 1)]
        Ukraine = 71,
        [Bdd("48F2CF10-21EF-2D4E-82F0-EB19075A779A")]
        [Reference("Collectionneur", "Collector", EnumTypeReference.Categorie, 638182053590000000, 1, 1)]
        Collectionneur = 72,
        [Bdd("1CCC9766-665C-E544-AC97-6690EB4A7EA7")]
        [Reference("Editeur", "Publisher", EnumTypeReference.Categorie, 638182053590000000, 1, 1)]
        Editeur = 73,
        [Bdd("EBA70E62-956D-174B-8704-4BD821367EA5")]
        [Reference("Marque d'imprimeur, éditeur ou de société", "Printer's, publisher's, or company's mark", EnumTypeReference.Categorie, 638182053590000000, 1, 1)]
        Marquedimprimeurediteuroudesociete = 74,
        [Bdd("C9036798-1132-654C-9392-466EA95460C6")]
        [Reference("Marque de bibliothèque", "Library mark", EnumTypeReference.Categorie, 638182053590000000, 1, 1)]
        Marquedebibliotheque = 75,
        [Bdd("D8AD71ED-1695-6040-BD41-A3CCA4228706")]
        [Reference("Marque de collection, d'artiste, d'atelier ou de succession", "Collection, artist's, workshop's, or estate mark", EnumTypeReference.Categorie, 638182053590000000, 1, 1)]
        Marquedecollectiondartistedatelieroudesuccession = 76,
        [Bdd("0EA93D49-C025-9D44-8063-79738942D02D")]
        [Reference("Marque de marchand", "Merchant mark", EnumTypeReference.Categorie, 638182053590000000, 1, 1)]
        Marquedemarchand = 77,
        [Bdd("E21E87B9-24E5-7E49-805D-A4F5C5479BD4")]
        [Reference("Marque de musée, d'académie, fondation ou bibliothèque", "Museum, academy, foundation, or library mark", EnumTypeReference.Categorie, 638182053590000000, 1, 1)]
        Marquedemuseedacadémiefondationoubibliotheque = 78,
        [Bdd("6234127C-CCE0-BF4C-BCE3-F4F68568F276")]
        [Reference("Autre", "Other", EnumTypeReference.Contour, 638182053590000000, 1, 1)]
        AutreContour = 79,
        [Bdd("84884424-1252-F040-9B38-66DA045FAE71")]
        [Reference("Circulaire", "Circular", EnumTypeReference.Contour, 638182053590000000, 1, 1)]
        Circulaire = 80,
        [Bdd("23B035E7-90A3-1B4B-B736-07D307EFEED7")]
        [Reference("Ovale", "Oval", EnumTypeReference.Contour, 638182053590000000, 1, 1)]
        Ovale = 81,
        [Bdd("592C4B7A-AF4F-D54F-99EC-D28788FA4888")]
        [Reference("Rectangulaire", "Rectangular", EnumTypeReference.Contour, 638182053590000000, 1, 1)]
        Rectangulaire = 82,
        [Bdd("426156E4-9BE6-9247-B94B-C312B824F5E9")]
        [Reference("Forme à pans coupés", "Octagonal shape", EnumTypeReference.Contour, 638182053590000000, 1, 1)]
        Formeapanscoupes = 83
    }
}
