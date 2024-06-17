using Altalents.Entities.Extensions;

namespace Altalents.Entities.Enum
{
    public enum EnumSousReference
    {
        [Bdd("259803DA-1AC0-0B4A-AB11-13E32E73501F")]
        [SousReference("mammifère", "mammal", EnumReference.Animal, 638182053590000000, 1, 1)]
        Mammifere = 1,
        [Bdd("D4E3E1C4-072F-C646-9594-E8DF33080034")]
        [SousReference("reptile", "reptile", EnumReference.Animal, 638182053590000000, 1, 1)]
        Reptile = 2,
        [Bdd("457C805F-F913-4E47-8635-66B504FA4DF0")]
        [SousReference("oiseau", "bird", EnumReference.Animal, 638182053590000000, 1, 1)]
        Oiseau = 3,
        [Bdd("392AD8E5-F8B8-9448-9184-9404EE53A959")]
        [SousReference("animal fabuleux", "mythical animal", EnumReference.Animal, 638182053590000000, 1, 1)]
        AnimalFabuleux = 4,
        [Bdd("83D082D5-D49B-9F48-B1BA-ED2B0756A264")]
        [SousReference("insecte", "insect", EnumReference.Animal, 638182053590000000, 1, 1)]
        Insecte = 5,
        [Bdd("F40B13C7-E943-6347-B27B-87EA625F3D1A")]
        [SousReference("scorpion", "scorpion", EnumReference.Animal, 638182053590000000, 1, 1)]
        Scorpion = 6,
        [Bdd("8F2DDC8C-FD20-8849-A58C-CCE4B799F8B2")]
        [SousReference("poisson", "fish", EnumReference.Animal, 638182053590000000, 1, 1)]
        Poisson = 7,
        [Bdd("7D96EC62-77E1-D04B-9752-B1CB1B78506F")]
        [SousReference("oeil", "eye", EnumReference.CorpsHumain, 638182053590000000, 1, 1)]
        Oeil = 8,
        [Bdd("08ACFEA5-72AC-4F4C-93E9-CBA55799E723")]
        [SousReference("figure", "figure", EnumReference.CorpsHumain, 638182053590000000, 1, 1)]
        Figure = 9,
        [Bdd("C47B1EA4-5058-D944-86CD-E598081E23CB")]
        [SousReference("coeur", "heart", EnumReference.CorpsHumain, 638182053590000000, 1, 1)]
        Coeur = 10,
        [Bdd("7FE5269A-47C4-2C49-ACB7-C4FFF7F2273C")]
        [SousReference("main", "hand", EnumReference.CorpsHumain, 638182053590000000, 1, 1)]
        Main = 11,
        [Bdd("361B286E-27CC-6D41-B67C-16542886CAB8")]
        [SousReference("tete", "head", EnumReference.CorpsHumain, 638182053590000000, 1, 1)]
        Tete = 12,
        [Bdd("8DEB1CC6-3FE3-FD45-B5FD-8AE8DFE5CD7B")]
        [SousReference("oreille", "ear", EnumReference.CorpsHumain, 638182053590000000, 1, 1)]
        Oreille = 13,
        [Bdd("4BB053EB-478A-7842-9FE1-EB7AE7813C85")]
        [SousReference("ovale", "oval", EnumReference.FigureGeometrique, 638182053590000000, 1, 1)]
        Ovale = 14,
        [Bdd("06A274FF-DBD4-E749-BE08-83CC32442EE3")]
        [SousReference("cercle", "circle", EnumReference.FigureGeometrique, 638182053590000000, 1, 1)]
        Cercle = 15,
        [Bdd("EDB58EB0-558C-3747-AA37-3FD0260661FC")]
        [SousReference("rectangle", "rectangle", EnumReference.FigureGeometrique, 638182053590000000, 1, 1)]
        Rectangle = 16,
        [Bdd("6D17BA93-6687-A644-8E7E-70C90C7B5090")]
        [SousReference("carré", "square", EnumReference.FigureGeometrique, 638182053590000000, 1, 1)]
        Carre = 17,
        [Bdd("FC4F97AD-DBC4-2047-8E2E-4C8D7359F882")]
        [SousReference("polylobe", "polylobed form", EnumReference.FigureGeometrique, 638182053590000000, 1, 1)]
        Polylobe = 18,
        [Bdd("9995727D-916C-1242-A3A3-B64620FCE6C3")]
        [SousReference("triangle", "triangle", EnumReference.FigureGeometrique, 638182053590000000, 1, 1)]
        Triangle = 19,
        [Bdd("41EA6667-B4F1-E845-B5BA-BB2E7054BB67")]
        [SousReference("polygone", "polygon", EnumReference.FigureGeometrique, 638182053590000000, 1, 1)]
        Polygone = 20,
        [Bdd("A948AB74-B803-C84D-A966-8ADD2836F498")]
        [SousReference("losange", "rhomb", EnumReference.FigureGeometrique, 638182053590000000, 1, 1)]
        Losange = 21,
        [Bdd("8A1961BA-B6AB-3948-8F74-A325ABF0F9F1")]
        [SousReference("coquille", "shell", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Coquille = 22,
        [Bdd("2EA3854F-35B4-5240-8984-CC3CB7F6D690")]
        [SousReference("ancre", "anchor", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Ancre = 23,
        [Bdd("C72F2CDF-1A62-8549-A4D3-898BEFCD3637")]
        [SousReference("armure", "armour", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Armure = 24,
        [Bdd("DAC0C43C-DDB6-B545-BE93-722ADC06A2E4")]
        [SousReference("objet ou signe indéterminé", "unidentified object or sign", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        ObjetOuSigneIndetermine = 25,
        [Bdd("942CBD7F-B283-CE48-8DCF-44AA1BE4D2A4")]
        [SousReference("cartouche", "cartouche", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Cartouche = 26,
        [Bdd("72FFD073-3E52-E14E-853E-C46270E9797B")]
        [SousReference("chapeau", "hat", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Chapeau = 27,
        [Bdd("039B3ECA-1F74-4F4C-8D85-4104C4C49E4B")]
        [SousReference("flèche", "arrow", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Fleche = 28,
        [Bdd("553D8108-9344-0542-A2CF-28424311AAE8")]
        [SousReference("tablette", "tablet", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Tablette = 29,
        [Bdd("2310EE58-8D48-2A47-B826-FB35EF41973E")]
        [SousReference("bâtiment ou partie de bâtiment", "building or part of a building", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Batiment = 30,
        [Bdd("21CD363A-46D7-BE4D-9348-08D133D86D7B")]
        [SousReference("hache", "axe", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Hache = 31,
        [Bdd("396E2F21-6802-4347-9204-6534953F2DDB")]
        [SousReference("plume ou pinceau", "pen or brush", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        PlumePinceau = 32,
        [Bdd("91F01004-7C16-F74F-B896-D978E76E84BA")]
        [SousReference("compas", "compass", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Compas = 33,
        [Bdd("EE10E897-5BE7-1C4E-A016-E676454583BE")]
        [SousReference("ruche", "hive", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Ruche = 34,
        [Bdd("40474FFA-569E-AB41-9EC6-6C96833955D1")]
        [SousReference("ceinture", "belt", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Ceinture = 35,
        [Bdd("CD6D4EB5-80FC-ED4B-8BF1-665A5516A78E")]
        [SousReference("bateau", "ship", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Bateau = 36,
        [Bdd("22417E31-676F-7E46-A86A-4A263E3AE9AC")]
        [SousReference("aviron", "oar", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Aviron = 37,
        [Bdd("A9F9C217-3B44-3D40-8E5B-3B0212333AF3")]
        [SousReference("lune", "moon", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Lune = 38,
        [Bdd("6508B51D-75D7-DD45-9A86-FD0619831400")]
        [SousReference("fusil", "rifle", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Fusil = 39,
        [Bdd("55C49DE5-0652-F942-8420-8124364969C8")]
        [SousReference("récipient", "container", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Recipient = 40,
        [Bdd("05177BA2-2151-F642-9E05-B556EA699EAD")]
        [SousReference("presse à taille douce", "intaglio press", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Presse = 41,
        [Bdd("E6E543D5-1E47-9446-83A5-0F9A034BF88C")]
        [SousReference("montage", "mount", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Montage = 42,
        [Bdd("D90BF99E-1619-CC4E-8CDB-C97F90ACBF1C")]
        [SousReference("palette", "palet", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Palette = 43,
        [Bdd("CABC48CB-A25D-A848-8060-CF62D4CF0887")]
        [SousReference("botte", "boot", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Botte = 44,
        [Bdd("33817284-080C-DE45-A514-9002ECAA1F98")]
        [SousReference("épée", "sword", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Epee = 45,
        [Bdd("3BCCBE5E-3A14-F749-9612-261888F932D3")]
        [SousReference("clefs", "keys", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Clefs = 46,
        [Bdd("398AA5D3-C9B7-3E4B-B42C-F5CB537012EF")]
        [SousReference("marteau", "hammer", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Marteau = 47,
        [Bdd("AC23BE9C-05A2-9941-81C1-15D541E572FE")]
        [SousReference("raquette", "racket", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Raquette = 48,
        [Bdd("E181D954-A31B-554A-9BE2-282967DB5611")]
        [SousReference("étoile ou soleil", "star or sun", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        EtoileSoleil = 49,
        [Bdd("37F06B55-3144-5B4C-973B-C45FDE1E0C8C")]
        [SousReference("livre", "book", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Livre = 50,
        [Bdd("C25FAF0D-2C01-834F-8C9C-406498AD532A")]
        [SousReference("écu", "escutcheon", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Ecu = 51,
        [Bdd("6221937D-29B0-D940-BD13-C8EF5D40BE50")]
        [SousReference("caducée", "caduceus", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Caducee = 52,
        [Bdd("B791FD55-4514-924C-958C-CC0EDB71EFCA")]
        [SousReference("croix", "cross", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Croix = 53,
        [Bdd("FDFE60A6-A459-AC4C-A8BA-D7876902BC55")]
        [SousReference("musique et instruments", "music and intruments", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        MusiqueIntruments = 54,
        [Bdd("E7636DF4-F328-F34E-965F-1FF0F7692CEE")]
        [SousReference("couronne", "crown", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Couronne = 55,
        [Bdd("5E4D3E84-FA92-6040-9902-1BBF76D72BD7")]
        [SousReference("présentoir", "stand", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Presentoir = 56,
        [Bdd("041A1940-28F0-234C-9814-3E801BBDAFF7")]
        [SousReference("faisceau", "fasces", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Faisceau = 57,
        [Bdd("026F9A84-4F43-B749-AFE8-24DA03006067")]
        [SousReference("drapeau ou banderole", "flag or banner", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        DrapeauBanderole = 58,
        [Bdd("25A80FF9-9F30-7E4B-8FB5-60EA4B573DE3")]
        [SousReference("bijou", "jewelry", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Bijou = 59,
        [Bdd("95349A5D-6DBC-E548-9809-EB061A85ACB5")]
        [SousReference("carte", "map", EnumReference.ObjetOuRepresentationDiverse, 638182053590000000, 1, 1)]
        Carte = 60,
        [Bdd("92BBA411-1634-A143-A557-4F7631559C40")]
        [SousReference("fleur", "flower", EnumReference.Vegetal, 638182053590000000, 1, 1)]
        Fleur = 61,
        [Bdd("82E058C4-BA5A-2B4C-B307-D3AB607EC131")]
        [SousReference("fruit", "fruit", EnumReference.Vegetal, 638182053590000000, 1, 1)]
        Fruit = 62,
        [Bdd("BCFF4E80-A63D-8540-AD34-548A4C026AC8")]
        [SousReference("arbre", "tree", EnumReference.Vegetal, 638182053590000000, 1, 1)]
        Arbre = 63,
        [Bdd("3D5AA4FA-6EB7-1A4E-A98E-6254E74BC5A5")]
        [SousReference("plante", "plant", EnumReference.Vegetal, 638182053590000000, 1, 1)]
        Plante = 64,
        [Bdd("6D398E46-590C-C645-B6BF-AD02ABC962A2")]
        [SousReference("encre", "ink", EnumReference.MarquePochoir, 638182053590000000, 1, 1)]
        EncrePochoir = 65,
        [Bdd("730E9A0A-DAB6-C74B-890B-05DA367EEF1D")]
        [SousReference("crayon", "pencil", EnumReference.MarqueEcrite, 638182053590000000, 1, 1)]
        Crayon = 66,
        [Bdd("EF1D6022-FE2D-F145-82DE-F007628E4706")]
        [SousReference("encre", "ink", EnumReference.MarqueEcrite, 638182053590000000, 1, 1)]
        EncreEcrite = 67,
        [Bdd("4D721AF6-F1CE-FA4B-8CE5-06B46F431272")]
        [SousReference("cachet sec", "blind stamp", EnumReference.MarqueEstampee, 638182053590000000, 1, 1)]
        CachetSec = 68,
        [Bdd("D7AE399F-8C1C-1A4C-82C8-36B3E21A4CCE")]
        [SousReference("cachet de cire", "wax stamp", EnumReference.MarqueEstampee, 638182053590000000, 1, 1)]
        CachetCire = 69,
        [Bdd("F6DE36EC-B0E8-7045-B0AD-F2B9F77910EC")]
        [SousReference("encre", "ink", EnumReference.MarqueEstampee, 638182053590000000, 1, 1)]
        EncreEstampee = 70,
        [Bdd("E6C9B6AF-C673-D94D-9533-0F7DBC7C0FD8")]
        [SousReference("initiale (alphabet latin)", "initial (latin alphabet)", EnumReference.Initiale, 638182053590000000, 1, 1)]
        InitialeLatin = 71,
        [Bdd("D0EE7E7B-4B4A-1248-9D08-54966D1EFC56")]
        [SousReference("initiale (alphabet non latin)", "initial (non latin alphabet)", EnumReference.Initiale, 638182053590000000, 1, 1)]
        InitialeNonLatin = 72,
        [Bdd("457CDB12-0E60-3C40-B9BA-B4AEF284265A")]
        [SousReference("mot (alphabet latin)", "word (latin alphabet)", EnumReference.Mot, 638182053590000000, 2, 2)]
        MotLatin = 73,
        [Bdd("78A9C25A-AD60-F140-96E0-16BA5C868D57")]
        [SousReference("mot (alphabet non latin)", "word (non latin alphabet)", EnumReference.Mot, 638182053590000000, 2, 2)]
        MotNonLatin = 74,
        [Bdd("3C501704-E84A-6E48-938D-1FB439F0361F")]
        [SousReference("date", "date", EnumReference.Numero, 638182053590000000, 3, 3)]
        Date = 75,
        [Bdd("B7F42A65-8C1E-094D-84D6-F3C0682F816D")]
        [SousReference("numéro", "number", EnumReference.Numero, 638182053590000000, 3, 3)]
        Numero = 76,
        [Bdd("65B1F923-D544-8847-B7EA-B0EDCE0A8AE2")]
        [SousReference("adresse", "adress", EnumReference.Numero, 638182053590000000, 3, 3)]
        Adresse = 77,
        [Bdd("65D9B98E-4048-DF4B-A32F-AEB31E2E9084")]
        [SousReference("prix", "price", EnumReference.Numero, 638182053590000000, 3, 3)]
        Prix = 78,
        [Bdd("DBA02A1C-B120-4E4A-8DE0-D3368EDA69AC")]
        [SousReference("Aalen-Fachsenfeld", "Aalen-Fachsenfeld", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        AalenFachsenfeld = 79,
        [Bdd("697BFB6A-1CE1-834F-9464-0E8A425D21C8")]
        [SousReference("Aix-la-Chapelle", "Aix-la-Chapelle", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        AixlaChapelle = 80,
        [Bdd("CC898EED-D671-D74C-B176-61490A21EF41")]
        [SousReference("Albstadt", "Albstadt", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Albstadt = 81,
        [Bdd("9881AA6F-2128-1249-89A4-A0001114EA56")]
        [SousReference("Altena", "Altena", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Altena = 82,
        [Bdd("1D031F0E-C206-FE4B-B0A3-F8C4A4966A2A")]
        [SousReference("Altenburg", "Altenburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Altenburg = 83,
        [Bdd("0F0F7EFF-5DA8-3846-84EF-7E2D8591B488")]
        [SousReference("Alveslohe", "Alveslohe", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Alveslohe = 84,
        [Bdd("105EC988-0F0B-7247-9039-E4BBD5252CE9")]
        [SousReference("Ansbach", "Ansbach", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Ansbach = 85,
        [Bdd("D888344D-DC62-E847-92B6-0614F8066E76")]
        [SousReference("Aschaffenburg", "Aschaffenburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Aschaffenburg = 86,
        [Bdd("3079530A-6176-D847-979F-B749D3F1B3B0")]
        [SousReference("Aufsess", "Aufsess", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Aufsess = 87,
        [Bdd("E250A82C-6421-5842-991F-B268643318A9")]
        [SousReference("Augsbourg", "Augsburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Augsbourg = 88,
        [Bdd("3ACB5B1F-C50E-744D-942B-AEF43C45D41F")]
        [SousReference("Aussig", "Aussig", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Aussig = 89,
        [Bdd("7AD63FA8-2BD0-1A47-ADAA-9A03A10EB9DA")]
        [SousReference("Bad Tölz", "Bad Tölz", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        BadTolz = 90,
        [Bdd("B939A52F-B043-024F-BAA3-37D5CCB60734")]
        [SousReference("Baden-Baden", "Baden-Baden", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        BadenBaden = 91,
        [Bdd("A480829E-6EBB-8641-81DE-152C3E30E75F")]
        [SousReference("Bamberg", "Bamberg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Bamberg = 92,
        [Bdd("E168649B-4C2D-FF43-AC72-FC8EF7054685")]
        [SousReference("Bayreuth", "Bayreuth", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Bayreuth = 93,
        [Bdd("7495C767-E956-4449-ACE3-3CD6C5B4DC0E")]
        [SousReference("Bedburg", "Bedburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Bedburg = 94,
        [Bdd("4F14AB6D-635C-AB44-BC03-983B915FC061")]
        [SousReference("Berlin", "Berlin", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Berlin = 95,
        [Bdd("7ADD4516-CC8D-EF46-8A97-D68B157B5667")]
        [SousReference("Bonn", "Bonn", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Bonn = 96,
        [Bdd("F909D85A-25EB-7644-9975-BBE71051D663")]
        [SousReference("Braunschweig", "Braunschweig", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Braunschweig = 97,
        [Bdd("D1E7D789-EE83-2C4D-B9F4-8C46B099EB63")]
        [SousReference("Brême", "Bremen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Breme = 98,
        [Bdd("489BEDBE-E24B-0545-8251-B7651DA5A333")]
        [SousReference("Breslau", "Breslau", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Breslau = 99,
        [Bdd("9497B519-0FE2-DB42-92FC-20CA489BA5B8")]
        [SousReference("Brunswick", "Brunswick", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Brunswick = 100,
        [Bdd("672159F5-434D-6C4C-9E40-3DB7C7803C1E")]
        [SousReference("Cassel", "Kassel", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Cassel = 101,
        [Bdd("4506F3E5-3F97-434A-B0A0-68D9C7091E85")]
        [SousReference("Celle", "Celle", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Celle = 102,
        [Bdd("EBCF3A86-CECA-2E4C-9F51-71FBC9FE1D85")]
        [SousReference("Charlottenburg", "Charlottenburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Charlottenburg = 103,
        [Bdd("F5827CB0-0C82-5D4D-B161-70CC991DCC9F")]
        [SousReference("Château Rattelsdorf", "Château Rattelsdorf", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        ChateauRattelsdorf = 104,
        [Bdd("E74B1677-7669-6347-832B-FC0EEFC0AEDD")]
        [SousReference("Chemnitz", "Chemnitz", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Chemnitz = 105,
        [Bdd("F84F0D44-C887-E449-B9D4-6FC3C1326DC1")]
        [SousReference("Cobourg", "Coburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Cobourg = 106,
        [Bdd("3A849356-6E96-F248-AC3C-15BB5619FDDA")]
        [SousReference("Cologne", "Cologne", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Cologne = 107,
        [Bdd("B1BD42EB-C119-3945-AFB6-314CB27EB753")]
        [SousReference("Constance", "Constance", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Constance = 108,
        [Bdd("A9EA8F01-B2B2-214A-97E7-54AE7D4B9F98")]
        [SousReference("Crefeld", "Krefeld", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Crefeld = 109,
        [Bdd("189FE094-E8C9-B049-9065-932CA392332E")]
        [SousReference("Cronberg", "Cronberg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Cronberg = 110,
        [Bdd("2A7D90F4-3A0A-564D-BF3D-D7F2227FF4E7")]
        [SousReference("Dachau", "Dachau", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Dachau = 111,
        [Bdd("CD4D3610-BD6B-AB42-8C44-13433DC78E14")]
        [SousReference("Darmstadt", "Darmstadt", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Darmstadt = 112,
        [Bdd("A461F51C-D3C2-D747-8413-0131BD310954")]
        [SousReference("Dessau", "Dessau", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Dessau = 113,
        [Bdd("49525B62-2E31-EF43-8FF0-91A9A7999483")]
        [SousReference("Detmold", "Detmold", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Detmold = 114,
        [Bdd("32DFAA51-4ACA-5545-82B6-788A70CF0A85")]
        [SousReference("Dillingen", "Dillingen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Dillingen = 115,
        [Bdd("AF9F6339-4D0E-BF4A-8DB7-8680D1540054")]
        [SousReference("Dohna", "Dohna", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Dohna = 116,
        [Bdd("6509EF31-C46F-A94C-982D-43A153599A52")]
        [SousReference("Donaueschingen", "Donaueschingen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Donaueschingen = 117,
        [Bdd("7174BFBD-D735-334F-A0E6-7D76FBDF7AA6")]
        [SousReference("Dornburg", "Dornburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Dornburg = 118,
        [Bdd("3F8895F2-F29B-C146-BB82-BB5D33B7DA5B")]
        [SousReference("Dortmund", "Dortmund", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Dortmund = 119,
        [Bdd("FF21D27D-AC72-3B4E-BD7B-2F74F027C35F")]
        [SousReference("Dreieich", "Dreieich", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Dreieich = 120,
        [Bdd("33080AA4-5C3F-4F46-B89E-2903613E0093")]
        [SousReference("Dresde", "Dresden", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Dresde = 121,
        [Bdd("3AE7120A-8371-104F-AC51-CFF161E5F996")]
        [SousReference("Düsseldorf", "Düsseldorf", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Dusseldorf = 122,
        [Bdd("F0203FFD-FC20-A04B-B1E5-FE5B64475704")]
        [SousReference("Eberswalde", "Eberswalde", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Eberswalde = 123,
        [Bdd("1BEE23E3-8961-314A-967F-D668ADC7AA82")]
        [SousReference("Elberfeld", "Elberfeld", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Elberfeld = 124,
        [Bdd("8739ACC0-E27F-FD43-B1E3-EFBAD36CF704")]
        [SousReference("Erfurt", "Erfurt", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Erfurt = 125,
        [Bdd("8F4076BC-B920-6542-850D-147C542755CD")]
        [SousReference("Erlangen", "Erlangen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Erlangen = 126,
        [Bdd("0D666A3B-0080-6043-98C6-B5FEFC40EF6C")]
        [SousReference("Ermlitz", "Ermlitz", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Ermlitz = 127,
        [Bdd("07E9D83E-174E-3C45-AC53-1EF792E7D83B")]
        [SousReference("Essen", "Essen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Essen = 128,
        [Bdd("27C72068-06BB-B245-B82A-C9C72D66E361")]
        [SousReference("Eutin", "Eutin", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Eutin = 129,
        [Bdd("A79822FF-5F07-AE4E-95EF-DBA609660692")]
        [SousReference("Francfort s/l'Oder", "Frankfurt an der Oder", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        FrancfortslOder = 130,
        [Bdd("44DF1036-3AD9-344B-A688-E283A9432315")]
        [SousReference("Francfort s/le Main", "Frankfurt am Main", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        FrancfortsleMain = 131,
        [Bdd("7A2CD747-CAB8-7740-95EB-D75D88FB1587")]
        [SousReference("Fribourg-en-Brisgau", "Freiburg im Breisgau", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        FribourgenBrisgau = 132,
        [Bdd("BE620B53-3CC4-BE47-8B40-0DE34FD550E4")]
        [SousReference("Gelsenkirchen", "Gelsenkirchen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Gelsenkirchen = 133,
        [Bdd("C2150EB5-C015-E048-A55B-01F88440C9B9")]
        [SousReference("Gera", "Gera", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Gera = 134,
        [Bdd("18C7C5CC-8164-9644-9F2F-BDA2792E30EB")]
        [SousReference("Giessen", "Giessen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Giessen = 135,
        [Bdd("3A581158-91BB-AF4D-8692-11706B2797E2")]
        [SousReference("Glauburg", "Glauburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Glauburg = 136,
        [Bdd("5A59F99E-F041-2A4A-9AA2-A2FF4B59AD5A")]
        [SousReference("Goslar", "Goslar", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Goslar = 137,
        [Bdd("1E1055F0-1729-8448-AF86-1C2463004F53")]
        [SousReference("Gotha", "Gotha", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Gotha = 138,
        [Bdd("0CCEBE5F-C343-8A44-A6BC-7339261C84FE")]
        [SousReference("Göttingen", "Göttingen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Gottingen = 139,
        [Bdd("986B2409-B68C-5A44-BC03-F22BB30EB1AE")]
        [SousReference("Greiz", "Greiz", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Greiz = 140,
        [Bdd("664F0BA4-C416-D14B-A8EB-7427BBC981D5")]
        [SousReference("Gusborn", "Gusborn", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Gusborn = 141,
        [Bdd("D16C0217-222E-F645-86F2-F2B58ECCDEC7")]
        [SousReference("Hagen", "Hagen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Hagen = 142,
        [Bdd("2265EACF-843A-4D44-AB4F-AD0FAB008B02")]
        [SousReference("Halberstadt", "Halberstadt", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Halberstadt = 143,
        [Bdd("F5A41991-1F9C-7D4F-9A54-3FCFFA0E7527")]
        [SousReference("Hambourg", "Hamburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Hambourg = 144,
        [Bdd("EF8D3CCF-6DE1-BA41-9F4C-31FA235D90C0")]
        [SousReference("Hannoversch Münden", "Hannoversch Münden", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        HannoverschMunden = 145,
        [Bdd("7AE06D73-9F75-8841-9D72-236B56EA8F75")]
        [SousReference("Hanovre", "Hanover", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Hanovre = 146,
        [Bdd("477CA4BD-65F3-864D-8108-D9F8FBED4406")]
        [SousReference("Heidelberg", "Heidelberg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Heidelberg = 147,
        [Bdd("FAD6B0DB-1857-0644-BFD9-BDB1BDE0E8DC")]
        [SousReference("Heilbronn", "Heilbronn", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Heilbronn = 148,
        [Bdd("2A80C82E-6D98-9142-9FBE-D94BA09856FA")]
        [SousReference("Helgoland", "Heligoland", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Helgoland = 149,
        [Bdd("4DFF1977-F039-B04A-B595-CEB4BC33E526")]
        [SousReference("Herford", "Herford", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Herford = 150,
        [Bdd("3D3CA710-21F3-F54C-827F-A717F161197A")]
        [SousReference("Jena", "Jena", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Jena = 151,
        [Bdd("78E1C756-7365-384F-A50F-80CF30E79206")]
        [SousReference("Jerxheim", "Jerxheim", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Jerxheim = 152,
        [Bdd("74902EDC-83F5-7C4A-9EB4-FACBE537C9A5")]
        [SousReference("Karlsruhe", "Karlsruhe", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Karlsruhe = 153,
        [Bdd("AE124D63-6A90-624A-8FF2-6BCD768FED82")]
        [SousReference("Kassel", "Kassel", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Kassel = 154,
        [Bdd("EF934880-22B1-F241-A6BD-DED5017C7ADD")]
        [SousReference("Kiel", "Kiel", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Kiel = 155,
        [Bdd("AA5578D0-2401-BB42-8CF2-FB823459CB48")]
        [SousReference("Klingenmünster", "Klingenmünster", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Klingenmunster = 156,
        [Bdd("69CB3946-9ADC-9E40-986E-483230E91258")]
        [SousReference("Langelsheim", "Langelsheim", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Langelsheim = 157,
        [Bdd("0018F941-9BEE-5D4D-B00B-364DE5667DC3")]
        [SousReference("Leipzig", "Leipzig", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Leipzig = 158,
        [Bdd("C8D78226-4FE5-EA45-8098-9B7E9A3E97FA")]
        [SousReference("Lindau", "Lindau", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Lindau = 159,
        [Bdd("E0859853-B316-E84A-84CD-259BC93B8594")]
        [SousReference("Lübeck", "Lübeck", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Lubeck = 160,
        [Bdd("E6EE3F34-FE6A-A34E-9D6D-45C4854D6928")]
        [SousReference("Lützschena", "Lützschena", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Lutzschena = 161,
        [Bdd("D9D210C7-980E-224F-A60A-8008A6E8ED70")]
        [SousReference("Maihingen", "Maihingen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Maihingen = 162,
        [Bdd("BE673E28-0DD6-844A-A159-ACD1D59F31D0")]
        [SousReference("Mainz", "Mainz", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Mainz = 163,
        [Bdd("B6D64F69-7929-6145-A2E3-E0B57FBBC0C2")]
        [SousReference("Mannheim", "Mannheim", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Mannheim = 164,
        [Bdd("72DBFE02-77EE-204A-9DBB-AA15ACEE3DE4")]
        [SousReference("Marbourg", "Marburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Marbourg = 165,
        [Bdd("5603B8E1-FF8A-0941-B717-D46009B5279E")]
        [SousReference("Mariental", "Mariental", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Mariental = 166,
        [Bdd("43EBF88A-9E97-BD42-8C41-45BE83C4A3CD")]
        [SousReference("Marienthal", "Marienthal", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Marienthal = 167,
        [Bdd("65F61ADA-C21C-F441-A359-892EF0DAA216")]
        [SousReference("Mayence", "Mainz", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Mayence = 168,
        [Bdd("F076EF66-5F6A-C349-A2E4-B1A9E045C1C3")]
        [SousReference("Meiningen", "Meiningen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Meiningen = 169,
        [Bdd("F629AD70-C853-ED44-8D2E-1C4FF2AAD5E2")]
        [SousReference("Meissen", "Meissen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Meissen = 170,
        [Bdd("027C4FBC-4352-EC4A-85CA-AFB2261F683E")]
        [SousReference("Munich", "Munich", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Munich = 171,
        [Bdd("57C808E5-5B16-9448-9058-753AF64355A9")]
        [SousReference("Naunhof", "Naunhof", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Naunhof = 172,
        [Bdd("487F0425-EF52-3747-BFCA-BD95D01AF12C")]
        [SousReference("Neuburg", "Neuburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Neuburg = 173,
        [Bdd("FCF554B0-AAF1-B74E-BABC-8BF083BAD9AC")]
        [SousReference("Neuses", "Neuses", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Neuses = 174,
        [Bdd("71390C0B-E51D-EB47-85EF-4295546AD5DC")]
        [SousReference("Nordkirchen", "Nordkirchen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Nordkirchen = 175,
        [Bdd("81CD429E-94D0-1B41-A8A3-84E059D8955C")]
        [SousReference("Nuremberg", "Nuremberg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Nuremberg = 176,
        [Bdd("5EF731F3-2D06-7541-9C38-3D6A6C90ACEC")]
        [SousReference("Oettingen", "Oettingen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Oettingen = 177,
        [Bdd("ABDA5E2E-F7C2-8641-BA75-0BCA0A573DCE")]
        [SousReference("Oldenbourg", "Oldenburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Oldenbourg = 178,
        [Bdd("0E23D5F5-4585-7D4C-BC10-A8AF35A8A962")]
        [SousReference("Potsdam", "Potsdam", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Potsdam = 179,
        [Bdd("507B8F7E-051A-0A44-8C34-FF00E8BA0267")]
        [SousReference("Quedlinbourg", "Quedlinburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Quedlinbourg = 180,
        [Bdd("591B4233-B4F1-1545-9E6F-7D0806B78A15")]
        [SousReference("Raitzhain", "Raitzhain", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Raitzhain = 181,
        [Bdd("BF7F9F15-7850-E645-8BC6-1BDFD5C30FE2")]
        [SousReference("Ratisbonne", "Regensburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Ratisbonne = 182,
        [Bdd("BE7AFBEC-168F-5448-B705-9ABA87D89ABD")]
        [SousReference("Recklinghausen", "Recklinghausen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Recklinghausen = 183,
        [Bdd("7C419110-5AE3-F54C-A17A-BAB78E76B5E8")]
        [SousReference("Rheinhausen-Oestrum", "Rheinhausen-Oestrum", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        RheinhausenOestrum = 184,
        [Bdd("0E798CFF-E5A1-0B43-B9ED-6005D293E5F4")]
        [SousReference("Saint Ingbert", "Saint Ingbert", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        SaintIngbert = 185,
        [Bdd("8BB52514-42F1-3640-94D7-5DFE0EB37BB0")]
        [SousReference("Sanssouci", "Sanssouci", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Sanssouci = 186,
        [Bdd("D59E878C-0F28-1F4C-9531-2C121E906726")]
        [SousReference("Schleißheim", "Schleissheim", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Schleiheim = 187,
        [Bdd("D0508800-F2C4-C24D-9512-A5361ACC6279")]
        [SousReference("Schleiz", "Schleiz", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Schleiz = 188,
        [Bdd("71D61904-2032-C749-B2EA-6A7EA441F867")]
        [SousReference("Schweinfurt", "Schweinfurt", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Schweinfurt = 189,
        [Bdd("5D50209A-83CE-A24A-9231-1A2E9E226368")]
        [SousReference("Schwerin", "Schwerin", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Schwerin = 190,
        [Bdd("378730FF-7997-7F48-8842-D5D04C087B2B")]
        [SousReference("Sierksdorf", "Sierksdorf", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Sierksdorf = 191,
        [Bdd("2023C512-4FBA-D049-AF63-294CD61BA285")]
        [SousReference("Sigmaringen", "Sigmaringen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Sigmaringen = 192,
        [Bdd("1CBE1BA0-510C-874E-9862-93D3687F51AB")]
        [SousReference("Staßfurt", "Staßfurt", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Stafurt = 193,
        [Bdd("81C97740-9DD2-4142-92A1-C236F1033046")]
        [SousReference("Stuttgart", "Stuttgart", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Stuttgart = 194,
        [Bdd("478D0160-636E-7740-BE7F-505ECA76830B")]
        [SousReference("Tatschen", "Tatschen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Tatschen = 195,
        [Bdd("A948E0A0-0B00-1F43-A35F-4CE7400E4EE7")]
        [SousReference("Tornow", "Tornow", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Tornow = 196,
        [Bdd("E30DA585-19D1-094C-A3CE-4EE8000EF38C")]
        [SousReference("Tübingen", "Tübingen", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Tubingen = 197,
        [Bdd("CE4AC310-625B-3848-858C-51B9340F0C0B")]
        [SousReference("Unna", "Unna", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Unna = 198,
        [Bdd("5342698A-6946-0049-A5F4-9BF5A46A0874")]
        [SousReference("Weimar", "Weimar", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Weimar = 199,
        [Bdd("BFF9ED8E-276B-F045-BD08-EAE324B847F2")]
        [SousReference("Wiesbaden", "Wiesbaden", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Wiesbaden = 200,
        [Bdd("6B843F59-C577-C74F-92D6-6538E1FAB8B3")]
        [SousReference("Wolfegg", "Wolfegg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Wolfegg = 201,
        [Bdd("5E253354-5D33-1149-A70B-6F20D8DE69E1")]
        [SousReference("Wuppertal", "Wuppertal", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Wuppertal = 202,
        [Bdd("72E51ACE-350D-B643-BE0D-DBE7B028B7C9")]
        [SousReference("Wurtzbourg", "Würzburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Wurtzbourg = 203,
        [Bdd("5D898319-5CBB-FD4E-9079-D182BF71771A")]
        [SousReference("Würzburg", "Würzburg", EnumReference.Allemagne, 638182053590000000, 1, 1)]
        Wurzburg = 204,
        [Bdd("E74CDA5F-8392-5C41-9F83-805395BF81FD")]
        [SousReference("Buenos-Aires", "Buenos Aires", EnumReference.Argentine, 638182053590000000, 1, 1)]
        BuenosAires = 205,
        [Bdd("9ADE9609-3573-714D-A833-589E9F1212D5")]
        [SousReference("Melbourne", "Melbourne", EnumReference.Australie, 638182053590000000, 1, 1)]
        Melbourne = 206,
        [Bdd("AAD7C6D9-3477-6948-9ADE-FAC294FA1FAC")]
        [SousReference("Brixlegg", "Brixlegg", EnumReference.Autriche, 638182053590000000, 1, 1)]
        Brixlegg = 207,
        [Bdd("EDFFAF50-10F8-944A-8F82-40D1901C60CD")]
        [SousReference("Eisenstadt", "Eisenstadt", EnumReference.Autriche, 638182053590000000, 1, 1)]
        Eisenstadt = 208,
        [Bdd("A6AE67A1-06F0-E648-8668-867FB82528BF")]
        [SousReference("Graz", "Graz", EnumReference.Autriche, 638182053590000000, 1, 1)]
        Graz = 209,
        [Bdd("1B69A31E-35EE-954A-BC7C-D03F7FB94AEA")]
        [SousReference("Innsbruck", "Innsbruck", EnumReference.Autriche, 638182053590000000, 1, 1)]
        Innsbruck = 210,
        [Bdd("36F923E7-B5EA-F240-8A5E-A9523C9E8DC5")]
        [SousReference("Königgratz", "Königgrätz", EnumReference.Autriche, 638182053590000000, 1, 1)]
        Koniggratz = 211,
        [Bdd("1ED71985-C8BE-5F4D-93FB-4C163545E072")]
        [SousReference("Laas", "Laas", EnumReference.Autriche, 638182053590000000, 1, 1)]
        Laas = 212,
        [Bdd("C75E1350-3331-F945-9466-A6B18A7D813C")]
        [SousReference("Linz", "Linz", EnumReference.Autriche, 638182053590000000, 1, 1)]
        Linz = 213,
        [Bdd("A2F6AE0F-5333-A44F-9F43-F36ECF941B81")]
        [SousReference("Mendel", "Mendel", EnumReference.Autriche, 638182053590000000, 1, 1)]
        Mendel = 214,
        [Bdd("E7866C03-02B8-3E49-8664-3587D7778825")]
        [SousReference("Perchtoldsdorf", "Perchtoldsdorf", EnumReference.Autriche, 638182053590000000, 1, 1)]
        Perchtoldsdorf = 215,
        [Bdd("AF5DE8BF-3A16-774E-80F3-762AC3BFC5D3")]
        [SousReference("Raigern", "Raigern", EnumReference.Autriche, 638182053590000000, 1, 1)]
        Raigern = 216,
        [Bdd("7097FAFF-D523-4B4B-9C3E-18329F153E8C")]
        [SousReference("Vienne", "Vienna", EnumReference.Autriche, 638182053590000000, 1, 1)]
        Vienne = 217,
        [Bdd("943C8167-42C8-A048-8F63-B8AF349BE4D6")]
        [SousReference("Volary", "Volary", EnumReference.Autriche, 638182053590000000, 1, 1)]
        Volary = 218,
        [Bdd("3FF120DE-0ADE-584F-AE59-E5083B26C3C2")]
        [SousReference("Anvers", "Antwerp", EnumReference.Belgique, 638182053590000000, 1, 1)]
        Anvers = 219,
        [Bdd("3960F978-B5C9-E84D-B51E-A2409B37A17E")]
        [SousReference("Bruges", "Bruges", EnumReference.Belgique, 638182053590000000, 1, 1)]
        Bruges = 220,
        [Bdd("9D88E49D-5501-FC48-B718-CE651EF666E6")]
        [SousReference("Bruxelles", "Brussels", EnumReference.Belgique, 638182053590000000, 1, 1)]
        Bruxelles = 221,
        [Bdd("EECC72EA-817A-4544-885A-2072EB9A0C83")]
        [SousReference("Essen", "Essen", EnumReference.Belgique, 638182053590000000, 1, 1)]
        Essen_Belgique = 222,
        [Bdd("6BDA8AFE-A6C6-514E-A4AF-0B323BFD89F6")]
        [SousReference("Gand", "Ghent", EnumReference.Belgique, 638182053590000000, 1, 1)]
        Gand = 223,
        [Bdd("855E00CD-D66D-5D4D-ABA8-825F32087378")]
        [SousReference("Liège", "Liège", EnumReference.Belgique, 638182053590000000, 1, 1)]
        Liege = 224,
        [Bdd("BC506565-3EC1-2A43-998F-55A0898249C0")]
        [SousReference("Louvain-la-Neuve", "Louvain-la-Neuve", EnumReference.Belgique, 638182053590000000, 1, 1)]
        LouvainlaNeuve = 225,
        [Bdd("066315A9-7C36-2C4A-8751-2E302DD62EED")]
        [SousReference("Malines", "Mechelen", EnumReference.Belgique, 638182053590000000, 1, 1)]
        Malines = 226,
        [Bdd("F9C301AE-42CA-7943-9BFD-B12AF948B4F1")]
        [SousReference("Marcinelle", "Marcinelle", EnumReference.Belgique, 638182053590000000, 1, 1)]
        Marcinelle = 227,
        [Bdd("7CE74E4E-F190-0942-928D-EB792515788B")]
        [SousReference("Morlanweltz", "Morlanwelz", EnumReference.Belgique, 638182053590000000, 1, 1)]
        Morlanweltz = 228,
        [Bdd("C23A9963-19E2-9F49-85A0-86E450429542")]
        [SousReference("Namur", "Namur", EnumReference.Belgique, 638182053590000000, 1, 1)]
        Namur = 229,
        [Bdd("C95DE49B-39B6-A747-AD1D-C0E1D5FF8EDA")]
        [SousReference("Tongres", "Tongeren", EnumReference.Belgique, 638182053590000000, 1, 1)]
        Tongres = 230,
        [Bdd("732AC822-5B81-B240-94D8-17B0EB0AA1D8")]
        [SousReference("Tournai", "Tournai", EnumReference.Belgique, 638182053590000000, 1, 1)]
        Tournai = 231,
        [Bdd("EA6AE6BE-ED83-A542-9CC7-9A247ABE9232")]
        [SousReference("Verviers", "Verviers", EnumReference.Belgique, 638182053590000000, 1, 1)]
        Verviers = 232,
        [Bdd("386BC669-3B15-2A49-A0A2-AD421045E3BE")]
        [SousReference("Ottawa", "Ottawa", EnumReference.Canada, 638182053590000000, 1, 1)]
        Ottawa = 233,
        [Bdd("B8B96323-CBD3-AD41-8C21-26FFCB2264FB")]
        [SousReference("Toronto", "Toronto", EnumReference.Canada, 638182053590000000, 1, 1)]
        Toronto = 234,
        [Bdd("32C69CB5-7C54-8E49-8C32-86492C82CF1F")]
        [SousReference("Ammendrup", "Ammendrup", EnumReference.Danemark, 638182053590000000, 1, 1)]
        Ammendrup = 235,
        [Bdd("68193629-EC86-B14B-B502-D725B4595A32")]
        [SousReference("Aröstjöbing", "Aröstjöbing", EnumReference.Danemark, 638182053590000000, 1, 1)]
        Arostjobing = 236,
        [Bdd("00370B34-8C3B-8246-A417-3882204E0DF5")]
        [SousReference("Copenhague", "Copenhagen", EnumReference.Danemark, 638182053590000000, 1, 1)]
        Copenhague = 237,
        [Bdd("74598BB9-3BDE-B646-9D14-D22734C9E161")]
        [SousReference("Klampenborg", "Klampenborg", EnumReference.Danemark, 638182053590000000, 1, 1)]
        Klampenborg = 238,
        [Bdd("4A2EC7BA-4241-DF4B-87CA-40A8C550C0D5")]
        [SousReference("Barcelone", "Barcelona", EnumReference.Espagne, 638182053590000000, 1, 1)]
        Barcelone = 239,
        [Bdd("FE08A2F7-334B-4143-BD93-EE9DBE2E1B7C")]
        [SousReference("Madrid", "Madrid", EnumReference.Espagne, 638182053590000000, 1, 1)]
        Madrid = 240,
        [Bdd("DD0B7A5D-7D85-6E4C-BD30-35F32835FF31")]
        [SousReference("Saint-Sébastien", "San Sebastian", EnumReference.Espagne, 638182053590000000, 1, 1)]
        SaintSebastien = 241,
        [Bdd("2CCAE0FE-A90A-5047-AEAB-15522989555B")]
        [SousReference("Séville", "Seville", EnumReference.Espagne, 638182053590000000, 1, 1)]
        Seville = 242,
        [Bdd("F07080FA-2497-EB4F-8B10-7C2162CCDAEF")]
        [SousReference("Tartu (anc. Dorpat)", "Tartu (formerly Dorpat)", EnumReference.Estonie, 638182053590000000, 1, 1)]
        TartuancDorpat = 243,
        [Bdd("2EA7A60B-3142-994A-9485-FEC70BA4CD60")]
        [SousReference("Athens", "Athens", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Athens = 244,
        [Bdd("2073262B-DF4D-374E-9290-0568CFC69C2E")]
        [SousReference("Atlanta", "Atlanta", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Atlanta = 245,
        [Bdd("383AEDB9-4A17-1947-A609-359551E82B4F")]
        [SousReference("Baltimore", "Baltimore", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Baltimore = 246,
        [Bdd("6CAFBA80-CEAC-994E-A4B2-638DA270CE08")]
        [SousReference("Beverly Hills", "Beverly Hills", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        BeverlyHills = 247,
        [Bdd("D8AAEF46-D37E-DB47-96D8-3B1DC0612DBD")]
        [SousReference("Boston", "Boston", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Boston = 248,
        [Bdd("A7927CED-6983-DB45-BFCA-4E2BC2FFC6F9")]
        [SousReference("Brookline", "Brookline", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Brookline = 249,
        [Bdd("D2B892B1-98DF-2F45-A3F1-9F6BE5282F4B")]
        [SousReference("Brooklyn", "Brooklyn", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Brooklyn = 250,
        [Bdd("3F34A53C-058B-D84B-8BCA-20FC387F069F")]
        [SousReference("Cambridge", "Cambridge", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Cambridge = 251,
        [Bdd("3A297CF1-8557-E641-A0E7-3DEEDD40A1A4")]
        [SousReference("Chapel Hill", "Chapel Hill", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        ChapelHill = 252,
        [Bdd("AAF7A792-8F50-6741-BD78-05BF42E44386")]
        [SousReference("Chicago", "Chicago", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Chicago = 253,
        [Bdd("8C7C0DE7-D284-314C-8B6B-F97B73C18D81")]
        [SousReference("Cincinnati", "Cincinnati", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Cincinnati = 254,
        [Bdd("65539E92-6C9C-3245-A514-0EFA09871E54")]
        [SousReference("Cleveland", "Cleveland", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Cleveland = 255,
        [Bdd("B0FDD12A-D9F1-864F-8A0D-49AD5DFE157F")]
        [SousReference("Clinton", "Clinton", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Clinton = 256,
        [Bdd("9EA5993E-8033-244B-9C5B-9F9A15CE656C")]
        [SousReference("Dayton", "Dayton", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Dayton = 257,
        [Bdd("43288336-B26E-DE4E-B0E7-20F86537EB06")]
        [SousReference("Denver", "Denver", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Denver = 258,
        [Bdd("602E4839-053F-7846-8763-918703FA37E7")]
        [SousReference("Detroit", "Detroit", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Detroit = 259,
        [Bdd("F5D4B168-D678-6D4D-ADBF-CDE9AE6EE951")]
        [SousReference("Dumbarton Oaks", "Dumbarton Oaks", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        DumbartonOaks = 260,
        [Bdd("D60B5104-3F42-EB4A-9FE1-FA8DADC9EBA1")]
        [SousReference("Ellenville", "Ellenville", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Ellenville = 261,
        [Bdd("C44A073A-933F-874B-933D-938F54CDE1BF")]
        [SousReference("Ellwood City", "Ellwood City", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        EllwoodCity = 262,
        [Bdd("3036D838-23FB-3649-8353-1DCB6D800855")]
        [SousReference("Englewood", "Englewood", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Englewood = 263,
        [Bdd("69E10407-4E19-5D4A-8CE2-710F5BA7B72D")]
        [SousReference("Fairfax County", "Fairfax County", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        FairfaxCounty = 264,
        [Bdd("40E14824-342E-9E47-BF79-CD5B398B04B8")]
        [SousReference("Fitchburg", "Fitchburg", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Fitchburg = 265,
        [Bdd("3099096A-0F86-9241-A0C2-5A75EC4E49DF")]
        [SousReference("Geneseo", "Geneseo", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Geneseo = 266,
        [Bdd("353FAC66-C0EB-7D43-B906-247FBCA39F0A")]
        [SousReference("Hawaï", "Hawaii", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Hawai = 267,
        [Bdd("0BA6EF0F-5E59-B44A-8217-7B0DE67218BF")]
        [SousReference("Hilo Farm", "Hilo Farm", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        HiloFarm = 268,
        [Bdd("EA608D86-97A6-C149-ABCF-50DB5236040E")]
        [SousReference("Houston", "Houston", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Houston = 269,
        [Bdd("5C908ADC-E155-CB44-8A4C-8B5BF07C9850")]
        [SousReference("Kansas City", "Kansas City", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        KansasCity = 270,
        [Bdd("EE26E916-4EEE-6A47-9496-FCDC9CC93C06")]
        [SousReference("Leeds", "Leeds", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Leeds = 271,
        [Bdd("51221EDF-7E65-0E42-BB12-52080203EC46")]
        [SousReference("Lenox", "Lenox", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Lenox = 272,
        [Bdd("4C9D67C6-1CA2-EB4B-AD2A-F164C20714AE")]
        [SousReference("Los Angeles", "Los Angeles", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        LosAngeles = 273,
        [Bdd("E6321616-E374-304B-8821-A55D2E4C5874")]
        [SousReference("Merchantville (New Jersey)", "Merchantville (New Jersey)", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        MerchantvilleNewJersey = 274,
        [Bdd("99D9B9CD-195C-7545-938D-AFA36A69D29C")]
        [SousReference("Miami", "Miami", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Miami = 275,
        [Bdd("3F4096F6-4800-4E45-A44A-93034A0EA433")]
        [SousReference("Middletown", "Middletown", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Middletown = 276,
        [Bdd("E39BAF79-674D-8B47-BD9D-25D0CC26E86B")]
        [SousReference("Mystic", "Mystic", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Mystic = 277,
        [Bdd("41330A4E-3CA7-4D41-ABF2-FA0E35E30C97")]
        [SousReference("Naugatuck", "Naugatuck", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Naugatuck = 278,
        [Bdd("6C1B2767-2EC4-A848-820E-879584934823")]
        [SousReference("New England", "New England", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        NewEngland = 279,
        [Bdd("1CAA93DD-765D-9E4D-85F0-0A2E3FF487C3")]
        [SousReference("New Haven", "New Haven", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        NewHaven = 280,
        [Bdd("E618A8D1-A933-3C45-83C0-2B06FD4E76E2")]
        [SousReference("New Hope", "New Hope", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        NewHope = 281,
        [Bdd("5F2C40CF-7A2E-6342-A5EB-91DC7795AB63")]
        [SousReference("New London", "New London", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        NewLondon = 282,
        [Bdd("ADE7C7B9-9D80-6B40-891F-6CCD6E192384")]
        [SousReference("New York", "New York", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        NewYork = 283,
        [Bdd("93009E89-FF9C-4445-BBC2-874B319DB191")]
        [SousReference("Newark", "Newark", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Newark = 284,
        [Bdd("DD8F0FC9-18DD-9C42-96FF-49E544B80E43")]
        [SousReference("Newport", "Newport", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Newport = 285,
        [Bdd("6195FC15-4A28-8C45-8D0A-83FEAB5D0263")]
        [SousReference("Norfolk", "Norfolk", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Norfolk = 286,
        [Bdd("9D31F722-BFDA-3F42-A096-5E7DE46DAA9A")]
        [SousReference("Nouvelle-Orléans", "New Orleans", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        NouvelleOrleans = 287,
        [Bdd("EA93D741-0C9F-6443-AE5A-734763F0EDEE")]
        [SousReference("Oswego", "Oswego", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Oswego = 288,
        [Bdd("AFB581E1-F703-494D-9277-489054FDCAC0")]
        [SousReference("Palm Beach", "Palm Beach", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        PalmBeach = 289,
        [Bdd("72E17F61-7E90-3441-95FE-521FCEDB1B71")]
        [SousReference("Paterson", "Paterson", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Paterson = 290,
        [Bdd("66583681-7CE9-7545-8D79-1A832AFADF76")]
        [SousReference("Philadelphie", "Philadelphia", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Philadelphie = 291,
        [Bdd("FB520B35-1319-2E4B-A5C1-C09997EEC1C2")]
        [SousReference("Pittsburg", "Pittsburgh", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Pittsburg = 292,
        [Bdd("02277430-8A16-3046-8FB9-1D1EA5B49906")]
        [SousReference("Portland", "Portland", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Portland = 293,
        [Bdd("9FBCA522-253A-5B4B-8DD6-91077B76A705")]
        [SousReference("Princeton", "Princeton", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Princeton = 294,
        [Bdd("D842992A-1052-BF4F-B3B2-0F4A535EC038")]
        [SousReference("Providence", "Providence", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Providence = 295,
        [Bdd("17F0B228-C5F1-774E-8FD5-3070B861EEF9")]
        [SousReference("Rancho Palos Verdes", "Rancho Palos Verdes", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        RanchoPalosVerdes = 296,
        [Bdd("C3B49164-6017-EC4E-A778-6915F730BEB6")]
        [SousReference("Rockport", "Rockport", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Rockport = 297,
        [Bdd("2E1CB163-2941-C54F-8636-05984DE32EAE")]
        [SousReference("Sacramento", "Sacramento", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Sacramento = 298,
        [Bdd("98BF14B5-E3AA-2E4A-ABBE-38A57E66C1DD")]
        [SousReference("Saint Louis", "Saint Louis", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        SaintLouis = 299,
        [Bdd("BA6F1329-7B10-8647-B1B3-BE344E895DF1")]
        [SousReference("San Diego", "San Diego", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        SanDiego = 300,
        [Bdd("5073F543-2114-C540-BB5F-563AD88028DD")]
        [SousReference("San Francisco", "San Francisco", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        SanFrancisco = 301,
        [Bdd("9BB7DE6C-FD9E-7B4B-9351-8E5D04240499")]
        [SousReference("San Marino", "San Marino", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        SanMarino = 302,
        [Bdd("EA1321AE-B355-9E45-8616-7E5CB2BFF4FB")]
        [SousReference("Saratoga Springs", "Saratoga Springs", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        SaratogaSprings = 303,
        [Bdd("34925696-7433-4840-8B4F-4FAA4814A3B9")]
        [SousReference("Seattle", "Seattle", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Seattle = 304,
        [Bdd("C3AC4016-B8E8-3D49-822A-6154511D9C0A")]
        [SousReference("Short Hills", "Short Hills", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        ShortHills = 305,
        [Bdd("CF1DC293-20D2-5144-9937-2A37E558F706")]
        [SousReference("Southampton (N.Y.)", "Southampton (N.Y.)", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        SouthamptonNY = 306,
        [Bdd("8C1C85A0-D126-6C4B-ABF6-EE73586B9833")]
        [SousReference("Springfield", "Springfield", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Springfield = 307,
        [Bdd("2704642A-FDCF-E344-9214-6F6A7047A96B")]
        [SousReference("Toledo", "Toledo", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Toledo = 308,
        [Bdd("5937D9D9-1E14-1D4E-B758-DD642841365A")]
        [SousReference("Washington", "Washington", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Washington = 309,
        [Bdd("AAB26CD6-85E3-CC4E-902F-4C0AE4FAC20E")]
        [SousReference("Waterbury", "Waterbury", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Waterbury = 310,
        [Bdd("BC1BAC4B-C522-E24F-973B-45E6F9A2E4AE")]
        [SousReference("Watertown", "Watertown", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Watertown = 311,
        [Bdd("B5F239DD-3344-DE4A-A843-79028A748D52")]
        [SousReference("Wilmington", "Wilmington", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Wilmington = 312,
        [Bdd("5D0E83E4-2C8A-6945-B66C-79EF088130E4")]
        [SousReference("Winona", "Winona", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Winona = 313,
        [Bdd("87DFB5BD-551C-E440-8D99-D7657DDA666F")]
        [SousReference("Woodbury", "Woodbury", EnumReference.EtatsUnis, 638182053590000000, 1, 1)]
        Woodbury = 314,
        [Bdd("C32EB23A-E517-184C-A33C-956DCEADF474")]
        [SousReference("Aix-en-Provence", "Aix-en-Provence", EnumReference.France, 638182053590000000, 1, 1)]
        AixenProvence = 315,
        [Bdd("F51C1640-F518-DD40-81E6-8CDCFA798E0C")]
        [SousReference("Ajaccio", "Ajaccio", EnumReference.France, 638182053590000000, 1, 1)]
        Ajaccio = 316,
        [Bdd("B5A5BE88-991E-A744-94E8-65403C96D77D")]
        [SousReference("Albi", "Albi", EnumReference.France, 638182053590000000, 1, 1)]
        Albi = 317,
        [Bdd("A8694CF9-28A2-0347-9D95-F631296C0E93")]
        [SousReference("Alençon", "Alençon", EnumReference.France, 638182053590000000, 1, 1)]
        Alenon = 318,
        [Bdd("D6B2DB58-6E53-4B44-811A-1FD57715A7AC")]
        [SousReference("Amiens", "Amiens", EnumReference.France, 638182053590000000, 1, 1)]
        Amiens = 319,
        [Bdd("9A7D930E-D869-AD47-8BD7-AA94D9E14E98")]
        [SousReference("Angers", "Angers", EnumReference.France, 638182053590000000, 1, 1)]
        Angers = 320,
        [Bdd("2A9CBCFA-7926-0D4A-89F6-97FA40BA0076")]
        [SousReference("Angoulême", "Angoulême", EnumReference.France, 638182053590000000, 1, 1)]
        Angouleme = 321,
        [Bdd("9D2C6B93-106B-1045-AE67-03A68C60EA3F")]
        [SousReference("Arras", "Arras", EnumReference.France, 638182053590000000, 1, 1)]
        Arras = 322,
        [Bdd("71437E48-AB2E-1644-970F-FF926800C87C")]
        [SousReference("Auch", "Auch", EnumReference.France, 638182053590000000, 1, 1)]
        Auch = 323,
        [Bdd("72696503-C37C-7D4A-995F-202D37B58EED")]
        [SousReference("Auteuil", "Auteuil", EnumReference.France, 638182053590000000, 1, 1)]
        Auteuil = 324,
        [Bdd("E0F15E6F-0882-064B-B902-BE5571EA915C")]
        [SousReference("Auvers-sur-Oise", "Auvers-sur-Oise", EnumReference.France, 638182053590000000, 1, 1)]
        AuverssurOise = 325,
        [Bdd("4BCEECDA-7454-4F45-82BD-1721169CFD82")]
        [SousReference("Azay-le-Rideau", "Azay-le-Rideau", EnumReference.France, 638182053590000000, 1, 1)]
        AzayleRideau = 326,
        [Bdd("7010F876-7237-0B40-96CD-A746C69A15E0")]
        [SousReference("Banyuls-sur-Mer", "Banyuls-sur-Mer", EnumReference.France, 638182053590000000, 1, 1)]
        BanyulssurMer = 327,
        [Bdd("6AABF284-E4B6-6D46-A880-282F9D18E5FA")]
        [SousReference("Bar-le-Duc", "Bar-le-Duc", EnumReference.France, 638182053590000000, 1, 1)]
        BarleDuc = 328,
        [Bdd("70A1FBE0-491B-DE46-81BA-B693623E02FB")]
        [SousReference("Barbizon", "Barbizon", EnumReference.France, 638182053590000000, 1, 1)]
        Barbizon = 329,
        [Bdd("13E42627-7B5C-D346-B2E7-A5C7E2D63C27")]
        [SousReference("Bayonne", "Bayonne", EnumReference.France, 638182053590000000, 1, 1)]
        Bayonne = 330,
        [Bdd("28C0047C-E14B-7847-A94E-83ED933E883F")]
        [SousReference("Beaumesnil", "Beaumesnil", EnumReference.France, 638182053590000000, 1, 1)]
        Beaumesnil = 331,
        [Bdd("F2D583BF-A037-B44E-B1A9-56107A45F0A1")]
        [SousReference("Bécon-les-Bruyères", "Bécon-les-Bruyères", EnumReference.France, 638182053590000000, 1, 1)]
        BeconlesBruyeres = 332,
        [Bdd("6EA7F3A1-8637-224B-A78A-FDC2B1C4024C")]
        [SousReference("Bédarieux", "Bédarieux", EnumReference.France, 638182053590000000, 1, 1)]
        Bedarieux = 333,
        [Bdd("B6556807-CD78-6247-A5E3-0766E8BF8CC8")]
        [SousReference("Bellesme", "Bellesme", EnumReference.France, 638182053590000000, 1, 1)]
        Bellesme = 334,
        [Bdd("11E523DD-DB5D-3845-8018-50C55AC4D656")]
        [SousReference("Berck-sur-Mer", "Berck-sur-Mer", EnumReference.France, 638182053590000000, 1, 1)]
        BercksurMer = 335,
        [Bdd("8B71FE33-DC66-C941-A71C-28E8D9600EDF")]
        [SousReference("Bergues", "Bergues", EnumReference.France, 638182053590000000, 1, 1)]
        Bergues = 336,
        [Bdd("F4BCE987-6F07-7A40-9A18-DE94DB6CAE3B")]
        [SousReference("Besançon", "Besançon", EnumReference.France, 638182053590000000, 1, 1)]
        Besanon = 337,
        [Bdd("FE5A17C9-287B-2140-BD4E-537476EFED54")]
        [SousReference("Besse-sur-Issole", "Besse-sur-Issole", EnumReference.France, 638182053590000000, 1, 1)]
        BessesurIssole = 338,
        [Bdd("CBA47EFE-0F00-F94A-BAB6-6E6D34306E64")]
        [SousReference("Béziers", "Béziers", EnumReference.France, 638182053590000000, 1, 1)]
        Beziers = 339,
        [Bdd("FE9A7E9A-B92D-9E41-AE35-6C6D28DC9D61")]
        [SousReference("Bezolles", "Bezolles", EnumReference.France, 638182053590000000, 1, 1)]
        Bezolles = 340,
        [Bdd("64DAF971-8C0E-9749-B4CC-787343D28DC3")]
        [SousReference("Biarritz", "Biarritz", EnumReference.France, 638182053590000000, 1, 1)]
        Biarritz = 341,
        [Bdd("7EF15B80-67E9-0145-B125-2CFDFDC04FFF")]
        [SousReference("Bièvres", "Bièvres", EnumReference.France, 638182053590000000, 1, 1)]
        Bievres = 342,
        [Bdd("4D126D4F-9046-274A-80FE-F619CD096B11")]
        [SousReference("Blérancourt", "Blérancourt", EnumReference.France, 638182053590000000, 1, 1)]
        Blerancourt = 343,
        [Bdd("7DA73FC7-4E1D-0548-BEE9-7B667F7FD7F3")]
        [SousReference("Bordeaux", "Bordeaux", EnumReference.France, 638182053590000000, 1, 1)]
        Bordeaux = 344,
        [Bdd("3FEEA2B0-E57F-6F45-BEDD-C8B5CEC441AA")]
        [SousReference("Boulogne-Billancourt", "Boulogne-Billancourt", EnumReference.France, 638182053590000000, 1, 1)]
        BoulogneBillancourt = 345,
        [Bdd("CD8CF761-BB42-2040-866E-09B16F223F6E")]
        [SousReference("Bourg-en-Bresse", "Bourg-en-Bresse", EnumReference.France, 638182053590000000, 1, 1)]
        BourgenBresse = 346,
        [Bdd("229F4C23-52B8-6543-8C6E-A787BAD89366")]
        [SousReference("Bourron-Marlotte", "Bourron-Marlotte", EnumReference.France, 638182053590000000, 1, 1)]
        BourronMarlotte = 347,
        [Bdd("A178BC55-839F-C748-B22D-8EC88C90A609")]
        [SousReference("Bressuire", "Bressuire", EnumReference.France, 638182053590000000, 1, 1)]
        Bressuire = 348,
        [Bdd("B9F665D4-B5C8-8A48-BB6B-8EEDF4F65862")]
        [SousReference("Caen", "Caen", EnumReference.France, 638182053590000000, 1, 1)]
        Caen = 349,
        [Bdd("1A4BB102-54F5-7745-9A52-B8B0872E016A")]
        [SousReference("Cagnes-sur-Mer", "Cagnes-sur-Mer", EnumReference.France, 638182053590000000, 1, 1)]
        CagnessurMer = 350,
        [Bdd("C83E3A32-7134-6F43-BBDE-A02EA3705084")]
        [SousReference("Cannes", "Cannes", EnumReference.France, 638182053590000000, 1, 1)]
        Cannes = 351,
        [Bdd("C317E97B-9A56-9E41-8847-406757BB53A1")]
        [SousReference("Carbonne", "Carbonne", EnumReference.France, 638182053590000000, 1, 1)]
        Carbonne = 352,
        [Bdd("DE0093F2-01FB-BA41-8DFF-E835B7F53920")]
        [SousReference("Carcassonne", "Carcassonne", EnumReference.France, 638182053590000000, 1, 1)]
        Carcassonne = 353,
        [Bdd("1102D32C-29E8-DA49-B83E-E7C56C624527")]
        [SousReference("Carpentras", "Carpentras", EnumReference.France, 638182053590000000, 1, 1)]
        Carpentras = 354,
        [Bdd("0990AE74-F213-A54D-B317-8787BC765B65")]
        [SousReference("Cernay-la-Ville", "Cernay-la-Ville", EnumReference.France, 638182053590000000, 1, 1)]
        CernaylaVille = 355,
        [Bdd("18C96252-EC85-104E-B389-964B7D25A98A")]
        [SousReference("Chambourcy", "Chambourcy", EnumReference.France, 638182053590000000, 1, 1)]
        Chambourcy = 356,
        [Bdd("97395848-1128-D245-86ED-4254414AD4C9")]
        [SousReference("Chamerolles", "Chamerolles", EnumReference.France, 638182053590000000, 1, 1)]
        Chamerolles = 357,
        [Bdd("A2DE9A47-D16D-BC4F-9721-8D77F06D94D4")]
        [SousReference("Champaissant", "Champaissant", EnumReference.France, 638182053590000000, 1, 1)]
        Champaissant = 358,
        [Bdd("CE483CD4-C97D-F048-A672-09A51700F02D")]
        [SousReference("Chantilly", "Chantilly", EnumReference.France, 638182053590000000, 1, 1)]
        Chantilly = 359,
        [Bdd("B8A648D7-6E3C-1444-81E9-7E6FC2ED376D")]
        [SousReference("Charenton", "Charenton", EnumReference.France, 638182053590000000, 1, 1)]
        Charenton = 360,
        [Bdd("9F7FF40E-8790-A14D-9D6D-763DB0B8E41B")]
        [SousReference("Charleville", "Charleville", EnumReference.France, 638182053590000000, 1, 1)]
        Charleville = 361,
        [Bdd("5E19FF1C-7F6F-414D-A516-1E794E99F988")]
        [SousReference("Chars", "Chars", EnumReference.France, 638182053590000000, 1, 1)]
        Chars = 362,
        [Bdd("FD1BF783-8E06-7145-BA7D-613C152D439F")]
        [SousReference("Chartres", "Chartres", EnumReference.France, 638182053590000000, 1, 1)]
        Chartres = 363,
        [Bdd("FF5765ED-41E1-FF4C-8EF6-9F629073D84C")]
        [SousReference("Château de Terre-Neuve", "Château de Terre-Neuve", EnumReference.France, 638182053590000000, 1, 1)]
        ChateaudeTerreNeuve = 364,
        [Bdd("16C4668B-1EAD-E74D-80D2-234B0EF07F40")]
        [SousReference("Chateauvieux", "Chateauvieux", EnumReference.France, 638182053590000000, 1, 1)]
        Chateauvieux = 365,
        [Bdd("EAB65EEF-C236-6748-A303-12EA9A829ADE")]
        [SousReference("Chauvigny", "Chauvigny", EnumReference.France, 638182053590000000, 1, 1)]
        Chauvigny = 366,
        [Bdd("D4415EF0-C0D9-4341-90BC-85683987507A")]
        [SousReference("Cherbourg", "Cherbourg", EnumReference.France, 638182053590000000, 1, 1)]
        Cherbourg = 367,
        [Bdd("A2566A64-33EC-4B4D-9ACD-A095CF509CA8")]
        [SousReference("Clamecy", "Clamecy", EnumReference.France, 638182053590000000, 1, 1)]
        Clamecy = 368,
        [Bdd("90AA347D-DFF1-ED4D-B476-A97322B7854D")]
        [SousReference("Clermont-l'Hérault", "Clermont-l'Hérault", EnumReference.France, 638182053590000000, 1, 1)]
        ClermontlHerault = 369,
        [Bdd("E6FA02C8-A574-6B4F-8AE6-8DC5141E7159")]
        [SousReference("Cléry-Saint-André", "Cléry-Saint-André", EnumReference.France, 638182053590000000, 1, 1)]
        ClerySaintAndre = 370,
        [Bdd("E43D6779-2D41-4C41-8130-3836EF616E6C")]
        [SousReference("Colmar", "Colmar", EnumReference.France, 638182053590000000, 1, 1)]
        Colmar = 371,
        [Bdd("B707CE78-3580-BF45-BDD2-7355037E0FFE")]
        [SousReference("Commercy", "Commercy", EnumReference.France, 638182053590000000, 1, 1)]
        Commercy = 372,
        [Bdd("B202196E-BF5B-A842-922E-BA1EAB7D4120")]
        [SousReference("Compiègne", "Compiègne", EnumReference.France, 638182053590000000, 1, 1)]
        Compiegne = 373,
        [Bdd("48348052-AA3F-264E-AFCC-F4F8EB0D21C5")]
        [SousReference("Courbevoie", "Courbevoie", EnumReference.France, 638182053590000000, 1, 1)]
        Courbevoie = 374,
        [Bdd("91D66F2F-E057-F342-AF02-00128E75950E")]
        [SousReference("Dieppe", "Dieppe", EnumReference.France, 638182053590000000, 1, 1)]
        Dieppe = 375,
        [Bdd("15D3D62A-F86E-044C-8ADD-78A71AB8092A")]
        [SousReference("Dijon", "Dijon", EnumReference.France, 638182053590000000, 1, 1)]
        Dijon = 376,
        [Bdd("78AA4FC1-9C27-4B4D-A123-BAF7F6E21321")]
        [SousReference("Doëlan", "Doëlan", EnumReference.France, 638182053590000000, 1, 1)]
        Doelan = 377,
        [Bdd("3B10D258-56D2-C34E-9544-FC4564164A2E")]
        [SousReference("Douai", "Douai", EnumReference.France, 638182053590000000, 1, 1)]
        Douai = 378,
        [Bdd("EDE08E29-94F3-2B44-A121-69D09190F4BE")]
        [SousReference("Enghien", "Enghien", EnumReference.France, 638182053590000000, 1, 1)]
        Enghien = 379,
        [Bdd("E7EC195B-034A-324F-9D3E-32DFB6092B33")]
        [SousReference("Epernay", "Epernay", EnumReference.France, 638182053590000000, 1, 1)]
        Epernay = 380,
        [Bdd("C2F673A1-DE80-AD43-A4E3-C8D94D5F7510")]
        [SousReference("Etretat", "Etretat", EnumReference.France, 638182053590000000, 1, 1)]
        Etretat = 381,
        [Bdd("461BB399-4AC5-2445-8864-C0FBE197D9C7")]
        [SousReference("Fécamp", "Fécamp", EnumReference.France, 638182053590000000, 1, 1)]
        Fecamp = 382,
        [Bdd("7FB7F297-401D-1B41-A066-5FDEF62FCC59")]
        [SousReference("Fontainebleau", "Fontainebleau", EnumReference.France, 638182053590000000, 1, 1)]
        Fontainebleau = 383,
        [Bdd("FECB6DEA-A733-DC48-839A-E2508131C2DE")]
        [SousReference("Fontenay-aux-Roses", "Fontenay-aux-Roses", EnumReference.France, 638182053590000000, 1, 1)]
        FontenayauxRoses = 384,
        [Bdd("61DCC07A-BD71-7B4D-803C-9BF42F2AD5AF")]
        [SousReference("Frapesle", "Frapesle", EnumReference.France, 638182053590000000, 1, 1)]
        Frapesle = 385,
        [Bdd("23E66B03-78D3-3040-85E7-8064C546A0D8")]
        [SousReference("Fresnay", "Fresnay", EnumReference.France, 638182053590000000, 1, 1)]
        Fresnay = 386,
        [Bdd("91A7105B-19CD-6641-9E5B-E6410C2D5FDD")]
        [SousReference("Giverny", "Giverny", EnumReference.France, 638182053590000000, 1, 1)]
        Giverny = 387,
        [Bdd("60C310FF-EB03-934F-88B1-7694F344A178")]
        [SousReference("Granville", "Granville", EnumReference.France, 638182053590000000, 1, 1)]
        Granville = 388,
        [Bdd("403C93C6-B4E0-B74A-9335-D75D4F1C404A")]
        [SousReference("Grasse", "Grasse", EnumReference.France, 638182053590000000, 1, 1)]
        Grasse = 389,
        [Bdd("F4954913-2B3D-324D-84B0-5876CF9D8B24")]
        [SousReference("Gravelines", "Gravelines", EnumReference.France, 638182053590000000, 1, 1)]
        Gravelines = 390,
        [Bdd("AA53462B-B084-734C-BA51-04D7D4629598")]
        [SousReference("Grenoble", "Grenoble", EnumReference.France, 638182053590000000, 1, 1)]
        Grenoble = 391,
        [Bdd("86CF0533-A7AA-934A-8367-DF417184F42D")]
        [SousReference("Honfleur", "Honfleur", EnumReference.France, 638182053590000000, 1, 1)]
        Honfleur = 392,
        [Bdd("504D1A0D-4E45-E14A-9ABB-2992EAD0598B")]
        [SousReference("Jouy-en-Josas", "Jouy-en-Josas", EnumReference.France, 638182053590000000, 1, 1)]
        JouyenJosas = 393,
        [Bdd("C9EA0DC2-8140-5848-A74D-F659C21C1D82")]
        [SousReference("L'Isle-Adam", "L'Isle-Adam", EnumReference.France, 638182053590000000, 1, 1)]
        LIsleAdam = 394,
        [Bdd("B05D1CFA-A59B-B743-B906-E17F46EBFD6A")]
        [SousReference("La Frette-sur-Seine", "La Frette-sur-Seine", EnumReference.France, 638182053590000000, 1, 1)]
        LaFrettesurSeine = 395,
        [Bdd("3851F9EB-6CEC-0E45-9B7C-F0E7AEA4DA8B")]
        [SousReference("La Rochelle", "La Rochelle", EnumReference.France, 638182053590000000, 1, 1)]
        LaRochelle = 396,
        [Bdd("18ABEEE2-C226-BB44-8968-D40EC33F0293")]
        [SousReference("Laon", "Laon", EnumReference.France, 638182053590000000, 1, 1)]
        Laon = 397,
        [Bdd("9D74C225-68DE-1344-B55F-16D5FB81CAEA")]
        [SousReference("Le Blanc", "Le Blanc", EnumReference.France, 638182053590000000, 1, 1)]
        LeBlanc = 398,
        [Bdd("4017080A-3036-B645-9E62-40F42FA34A33")]
        [SousReference("Le Cannet", "Le Cannet", EnumReference.France, 638182053590000000, 1, 1)]
        LeCannet = 399,
        [Bdd("AC622E5F-FE56-5A4A-88CC-EF2375742E3C")]
        [SousReference("Le Havre", "Le Havre", EnumReference.France, 638182053590000000, 1, 1)]
        LeHavre = 400,
        [Bdd("01302A58-F496-FD4D-B66E-840A6138D9CD")]
        [SousReference("Le Pouldu", "Le Pouldu", EnumReference.France, 638182053590000000, 1, 1)]
        LePouldu = 401,
        [Bdd("6FBBDA55-B89E-EF42-B9F9-D94F3DB57C6C")]
        [SousReference("Lille", "Lille", EnumReference.France, 638182053590000000, 1, 1)]
        Lille = 402,
        [Bdd("DE1EFB73-C39B-5E40-85C9-A10F26491861")]
        [SousReference("Limoges", "Limoges", EnumReference.France, 638182053590000000, 1, 1)]
        Limoges = 403,
        [Bdd("51CFE50B-938E-8C48-8D63-5F68E18AECE8")]
        [SousReference("Lisle-sur-Tarn", "Lisle-sur-Tarn", EnumReference.France, 638182053590000000, 1, 1)]
        LislesurTarn = 404,
        [Bdd("96158FB0-A547-4945-BFAA-A32FD219F6CF")]
        [SousReference("Lorient", "Lorient", EnumReference.France, 638182053590000000, 1, 1)]
        Lorient = 405,
        [Bdd("7BDAE586-52BD-D742-9C2F-8072C30606D8")]
        [SousReference("Louviers", "Louviers", EnumReference.France, 638182053590000000, 1, 1)]
        Louviers = 406,
        [Bdd("37ED3C30-D723-6441-A58C-95C3455F4B7E")]
        [SousReference("Lozère sur Yvette", "Lozère sur Yvette", EnumReference.France, 638182053590000000, 1, 1)]
        LozeresurYvette = 407,
        [Bdd("A9F2023C-D4B4-E944-8F19-5C716BBC9997")]
        [SousReference("Luçay-le-Mâle", "Luçay-le-Mâle", EnumReference.France, 638182053590000000, 1, 1)]
        LuayleMale = 408,
        [Bdd("AED19BED-F7AF-6341-95F7-DE5C360928C3")]
        [SousReference("Lunéville", "Lunéville", EnumReference.France, 638182053590000000, 1, 1)]
        Luneville = 409,
        [Bdd("378A7913-B463-1043-9F57-086D704194E7")]
        [SousReference("Lyon", "Lyon", EnumReference.France, 638182053590000000, 1, 1)]
        Lyon = 410,
        [Bdd("24229654-0D1B-AB4E-8FFC-B8CB1AF1DC22")]
        [SousReference("Maisons-Laffitte", "Maisons-Laffitte", EnumReference.France, 638182053590000000, 1, 1)]
        MaisonsLaffitte = 411,
        [Bdd("C3D266FE-1BA8-584F-AA1B-C9805ED46864")]
        [SousReference("Marly-le-Roi", "Marly-le-Roi", EnumReference.France, 638182053590000000, 1, 1)]
        MarlyleRoi = 412,
        [Bdd("3AF0D924-F1A9-6A46-85F7-A1DCBFC7549D")]
        [SousReference("Marseille", "Marseille", EnumReference.France, 638182053590000000, 1, 1)]
        Marseille = 413,
        [Bdd("CEF3827B-B164-7049-B41D-41C8147615B7")]
        [SousReference("Maubeuge", "Maubeuge", EnumReference.France, 638182053590000000, 1, 1)]
        Maubeuge = 414,
        [Bdd("C103CC80-33F8-9646-A605-27AB4ACFF9B7")]
        [SousReference("Mée-sur-Seine", "Mée-sur-Seine", EnumReference.France, 638182053590000000, 1, 1)]
        MeesurSeine = 415,
        [Bdd("81B2A3C2-2F7F-3549-93AC-134E0F16472A")]
        [SousReference("Melun", "Melun", EnumReference.France, 638182053590000000, 1, 1)]
        Melun = 416,
        [Bdd("97D8EED8-73F8-7A47-8F93-08B6D2A48420")]
        [SousReference("Menton", "Menton", EnumReference.France, 638182053590000000, 1, 1)]
        Menton = 417,
        [Bdd("AC502523-C90F-ED42-BDA0-3C7810A6AAAB")]
        [SousReference("Metz", "Metz", EnumReference.France, 638182053590000000, 1, 1)]
        Metz = 418,
        [Bdd("567793D9-850B-8746-A47E-074559F445BE")]
        [SousReference("Meudon", "Meudon", EnumReference.France, 638182053590000000, 1, 1)]
        Meudon = 419,
        [Bdd("890F6E1C-C4AA-5F4C-A8DB-9AE92F018528")]
        [SousReference("Montauban", "Montauban", EnumReference.France, 638182053590000000, 1, 1)]
        Montauban = 420,
        [Bdd("DB808FCC-8742-4E4D-8877-351B4C14775D")]
        [SousReference("Montpellier", "Montpellier", EnumReference.France, 638182053590000000, 1, 1)]
        Montpellier = 421,
        [Bdd("C6228884-C902-2C4A-B1EE-FED3541B9125")]
        [SousReference("Morestel", "Morestel", EnumReference.France, 638182053590000000, 1, 1)]
        Morestel = 422,
        [Bdd("F8900ED3-4AC6-D346-ABAD-79E2D07CCFC3")]
        [SousReference("Mormant", "Mormant", EnumReference.France, 638182053590000000, 1, 1)]
        Mormant = 423,
        [Bdd("9BB863A7-EE2B-DF46-AB54-3356C5788A56")]
        [SousReference("Moulins", "Moulins", EnumReference.France, 638182053590000000, 1, 1)]
        Moulins = 424,
        [Bdd("C8EEF786-9A96-914F-AD15-854C1844D8CE")]
        [SousReference("Mulhouse", "Mulhouse", EnumReference.France, 638182053590000000, 1, 1)]
        Mulhouse = 425,
        [Bdd("0A48F6FB-0469-7048-8A2D-57C024C0F15E")]
        [SousReference("Nancy", "Nancy", EnumReference.France, 638182053590000000, 1, 1)]
        Nancy = 426,
        [Bdd("F82D410D-C898-C94C-B505-63AD3D53CBCC")]
        [SousReference("Nanterre", "Nanterre", EnumReference.France, 638182053590000000, 1, 1)]
        Nanterre = 427,
        [Bdd("A478CEE8-7BEF-D240-992A-9E1AD6AFA7F8")]
        [SousReference("Nantes", "Nantes", EnumReference.France, 638182053590000000, 1, 1)]
        Nantes = 428,
        [Bdd("16E4FDB4-604E-9B4F-8068-BE1D82E2093C")]
        [SousReference("Nemours", "Nemours", EnumReference.France, 638182053590000000, 1, 1)]
        Nemours = 429,
        [Bdd("4B60FCD4-752D-5647-9242-F378DE0306A8")]
        [SousReference("Neuilly-sur-Seine", "Neuilly-sur-Seine", EnumReference.France, 638182053590000000, 1, 1)]
        NeuillysurSeine = 430,
        [Bdd("7E83ABC2-AB9B-8D47-B1B2-3FF971F737F3")]
        [SousReference("Nice", "Nice", EnumReference.France, 638182053590000000, 1, 1)]
        Nice = 431,
        [Bdd("5B122C62-ED7D-AA4E-BCD3-AD8E87DD2F19")]
        [SousReference("Nîmes", "Nîmes", EnumReference.France, 638182053590000000, 1, 1)]
        Nimes = 432,
        [Bdd("B324F470-7D0F-CB4F-BF36-2C61BCD1F90F")]
        [SousReference("Nogent-sur-Marne", "Nogent-sur-Marne", EnumReference.France, 638182053590000000, 1, 1)]
        NogentsurMarne = 433,
        [Bdd("0261D20E-2548-4A45-A1C2-E49F1ADC294F")]
        [SousReference("Orléans", "Orléans", EnumReference.France, 638182053590000000, 1, 1)]
        Orleans = 434,
        [Bdd("CE1C09AF-851D-E74A-ACF8-C026EB42BE8A")]
        [SousReference("Ornans", "Ornans", EnumReference.France, 638182053590000000, 1, 1)]
        Ornans = 435,
        [Bdd("02685361-DD6C-1640-AA00-C81231A353FD")]
        [SousReference("Orrouy", "Orrouy", EnumReference.France, 638182053590000000, 1, 1)]
        Orrouy = 436,
        [Bdd("9BD5F757-59CE-9247-81BE-BE063C195499")]
        [SousReference("Paris", "Paris", EnumReference.France, 638182053590000000, 1, 1)]
        Paris = 437,
        [Bdd("F2AC93B7-C90B-C941-9211-4E0124733E19")]
        [SousReference("Perpignan", "Perpignan", EnumReference.France, 638182053590000000, 1, 1)]
        Perpignan = 438,
        [Bdd("3BBFE104-F3A4-9B41-BD34-B636A7CDAA1E")]
        [SousReference("Pithiviers", "Pithiviers", EnumReference.France, 638182053590000000, 1, 1)]
        Pithiviers = 439,
        [Bdd("AC2BD1C5-DB65-2D4C-8044-2770DAE18448")]
        [SousReference("Plombières-les-Bains", "Plombières-les-Bains", EnumReference.France, 638182053590000000, 1, 1)]
        PlombiereslesBains = 440,
        [Bdd("C1F8B52E-B74B-794F-AD5F-1BACD03762A0")]
        [SousReference("Poncey-sur-l’Ignon", "Poncey-sur-l’Ignon", EnumReference.France, 638182053590000000, 1, 1)]
        PonceysurlIgnon = 441,
        [Bdd("8C024657-7877-D242-89E2-22CE48478FC1")]
        [SousReference("Poncins", "Poncins", EnumReference.France, 638182053590000000, 1, 1)]
        Poncins = 442,
        [Bdd("6383CD3A-9AD6-5D4A-9632-665951D306E3")]
        [SousReference("Pont-Aven", "Pont-Aven", EnumReference.France, 638182053590000000, 1, 1)]
        PontAven = 443,
        [Bdd("5ADB43F5-995F-3A4C-A8AE-8EE64118E991")]
        [SousReference("Pont-de-l'Arche", "Pont-de-l'Arche", EnumReference.France, 638182053590000000, 1, 1)]
        PontdelArche = 444,
        [Bdd("18227856-338B-2E4A-A660-A4472B912657")]
        [SousReference("Quimper", "Quimper", EnumReference.France, 638182053590000000, 1, 1)]
        Quimper = 445,
        [Bdd("2ABF45D1-F3A5-5E47-BE21-47735F4A243A")]
        [SousReference("Reims", "Reims", EnumReference.France, 638182053590000000, 1, 1)]
        Reims = 446,
        [Bdd("9EA6B158-EB4E-9641-9383-ABA25D1A367F")]
        [SousReference("Rennes", "Rennes", EnumReference.France, 638182053590000000, 1, 1)]
        Rennes = 447,
        [Bdd("E33F0658-598E-6E44-8682-B3F0A6B27ADB")]
        [SousReference("Rochefort-sur-Mer", "Rochefort-sur-Mer", EnumReference.France, 638182053590000000, 1, 1)]
        RochefortsurMer = 448,
        [Bdd("D988729C-59CA-1948-BDB1-AA33D6CECFEC")]
        [SousReference("Romorantin", "Romorantin", EnumReference.France, 638182053590000000, 1, 1)]
        Romorantin = 449,
        [Bdd("D9963420-BA80-F24F-8DA3-C40A96CBFBE1")]
        [SousReference("Rouen", "Rouen", EnumReference.France, 638182053590000000, 1, 1)]
        Rouen = 450,
        [Bdd("180DE05E-26D5-C247-B805-2E7936A763E3")]
        [SousReference("Rueil-Malmaison", "Rueil-Malmaison", EnumReference.France, 638182053590000000, 1, 1)]
        RueilMalmaison = 451,
        [Bdd("37A97949-FADD-6949-967B-32C0EA4EEEED")]
        [SousReference("Saint-Amand-en-Puisaye", "Saint-Amand-en-Puisaye", EnumReference.France, 638182053590000000, 1, 1)]
        SaintAmandenPuisaye = 452,
        [Bdd("FA724B0C-C5EC-234E-A3FC-4354484AA1A2")]
        [SousReference("Saint-Amour", "Saint-Amour", EnumReference.France, 638182053590000000, 1, 1)]
        SaintAmour = 453,
        [Bdd("AEB27361-2B26-7F44-A059-77371A593275")]
        [SousReference("Saint-Briac", "Saint-Briac", EnumReference.France, 638182053590000000, 1, 1)]
        SaintBriac = 454,
        [Bdd("445D9E40-268E-F44B-98C2-A55AF13C99DB")]
        [SousReference("Saint-Cyr-en-Talmondais", "Saint-Cyr-en-Talmondais", EnumReference.France, 638182053590000000, 1, 1)]
        SaintCyrenTalmondais = 455,
        [Bdd("68406A81-2BD2-424A-BC48-866109B86E99")]
        [SousReference("Saint-Denis", "Saint-Denis", EnumReference.France, 638182053590000000, 1, 1)]
        SaintDenis = 456,
        [Bdd("D91E8D63-C24F-C647-B5D3-18A197822973")]
        [SousReference("Saint-Etienne", "Saint-Etienne", EnumReference.France, 638182053590000000, 1, 1)]
        SaintEtienne = 457,
        [Bdd("A0BEBD95-CF6C-F74C-8D2A-FE962C3258FD")]
        [SousReference("Saint-Marcel", "Saint-Marcel", EnumReference.France, 638182053590000000, 1, 1)]
        SaintMarcel = 458,
        [Bdd("82E8826D-AA7C-3B40-AE2B-A881235B73F6")]
        [SousReference("Saint-Maximin-la-Sainte-Baume", "Saint-Maximin-la-Sainte-Baume", EnumReference.France, 638182053590000000, 1, 1)]
        SaintMaximinlaSainteBaume = 459,
        [Bdd("9548D53A-C053-3A42-80E7-71201C95C5A6")]
        [SousReference("Saint-Omer", "Saint-Omer", EnumReference.France, 638182053590000000, 1, 1)]
        SaintOmer = 460,
        [Bdd("EE2A0856-EBEB-334B-AC4D-943C0F695CFD")]
        [SousReference("Saint-Paul-de-Vence", "Saint-Paul-de-Vence", EnumReference.France, 638182053590000000, 1, 1)]
        SaintPauldeVence = 461,
        [Bdd("971D3F0C-D972-7042-A8F8-6D3B8C3BFD41")]
        [SousReference("Saint-Tropez", "Saint-Tropez", EnumReference.France, 638182053590000000, 1, 1)]
        SaintTropez = 462,
        [Bdd("3A09A7A7-95FE-2C4B-9663-673094EC6CB7")]
        [SousReference("Salles-Curan", "Salles-Curan", EnumReference.France, 638182053590000000, 1, 1)]
        SallesCuran = 463,
        [Bdd("A15E4E71-3F28-AF43-AC6D-67B9CA2CD41C")]
        [SousReference("Senlis", "Senlis", EnumReference.France, 638182053590000000, 1, 1)]
        Senlis = 464,
        [Bdd("40085D7D-D4F1-A443-BD36-745948FD84E8")]
        [SousReference("Sèvres", "Sèvres", EnumReference.France, 638182053590000000, 1, 1)]
        Sevres = 465,
        [Bdd("7009C0C0-A43B-2642-8372-D862284E0710")]
        [SousReference("Soissons", "Soissons", EnumReference.France, 638182053590000000, 1, 1)]
        Soissons = 466,
        [Bdd("1D08C0CC-4066-C84E-8F7A-2BCA863903D1")]
        [SousReference("Strasbourg", "Strasbourg", EnumReference.France, 638182053590000000, 1, 1)]
        Strasbourg = 467,
        [Bdd("49373F9F-8B5B-7C4B-A421-2A23C24F0BA0")]
        [SousReference("Talloires", "Talloires", EnumReference.France, 638182053590000000, 1, 1)]
        Talloires = 468,
        [Bdd("FE172C60-C8A5-714F-A5C8-E025C033CCB1")]
        [SousReference("Toul", "Toul", EnumReference.France, 638182053590000000, 1, 1)]
        Toul = 469,
        [Bdd("1C5F72C7-358C-2E4E-AC04-2E6D99FB3766")]
        [SousReference("Toulon", "Toulon", EnumReference.France, 638182053590000000, 1, 1)]
        Toulon = 470,
        [Bdd("39979287-E681-EF46-A638-C8F0AEE368A7")]
        [SousReference("Toulouse", "Toulouse", EnumReference.France, 638182053590000000, 1, 1)]
        Toulouse = 471,
        [Bdd("BB9B9AA0-93C4-6B49-9127-A86414ACE62E")]
        [SousReference("Tours", "Tours", EnumReference.France, 638182053590000000, 1, 1)]
        Tours = 472,
        [Bdd("5AFFA48A-541B-B04F-A8D6-9802427EE17E")]
        [SousReference("Trouville", "Trouville", EnumReference.France, 638182053590000000, 1, 1)]
        Trouville = 473,
        [Bdd("42DAB4C7-797D-BE4B-AE4A-1C0997FCA2A6")]
        [SousReference("Troyes", "Troyes", EnumReference.France, 638182053590000000, 1, 1)]
        Troyes = 474,
        [Bdd("6DCAEA28-8D0D-494E-9DAF-4BA2C507C390")]
        [SousReference("Uzès", "Uzès", EnumReference.France, 638182053590000000, 1, 1)]
        Uzes = 475,
        [Bdd("CF980D00-B0CA-444D-99A0-D805FBF0E4C6")]
        [SousReference("Valenciennes", "Valenciennes", EnumReference.France, 638182053590000000, 1, 1)]
        Valenciennes = 476,
        [Bdd("C9347309-C0CC-FA44-B6CF-738BB240BF04")]
        [SousReference("Valleraugue", "Valleraugue", EnumReference.France, 638182053590000000, 1, 1)]
        Valleraugue = 477,
        [Bdd("E6AFAD17-D7EF-154D-8970-CA9D9B4CC470")]
        [SousReference("Vanves", "Vanves", EnumReference.France, 638182053590000000, 1, 1)]
        Vanves = 478,
        [Bdd("D001DE88-A411-0B4B-98C2-AF971A6793A3")]
        [SousReference("Varengeville-sur-Mer", "Varengeville-sur-Mer", EnumReference.France, 638182053590000000, 1, 1)]
        VarengevillesurMer = 479,
        [Bdd("C69566E2-C2FE-0342-B115-D0CF5B2935BF")]
        [SousReference("Versailles", "Versailles", EnumReference.France, 638182053590000000, 1, 1)]
        Versailles = 480,
        [Bdd("A3C90EF6-7BC5-254F-9DD0-D083E5165492")]
        [SousReference("Ville d'Avray", "Ville d'Avray", EnumReference.France, 638182053590000000, 1, 1)]
        VilledAvray = 481,
        [Bdd("46E8C237-5F57-A341-8E22-A0EA1A51077F")]
        [SousReference("Villejuif", "Villejuif", EnumReference.France, 638182053590000000, 1, 1)]
        Villejuif = 482,
        [Bdd("C426F11B-47BB-0D48-AD3D-4980D2108A1F")]
        [SousReference("Vincennes", "Vincennes", EnumReference.France, 638182053590000000, 1, 1)]
        Vincennes = 483,
        [Bdd("2E09622A-5A27-E548-9618-9160A7C19DF3")]
        [SousReference("Viroflay", "Viroflay", EnumReference.France, 638182053590000000, 1, 1)]
        Viroflay = 484,
        [Bdd("C7EC7C5E-A6C5-8E46-9506-6DAE0E94E2E5")]
        [SousReference("Vorges", "Vorges", EnumReference.France, 638182053590000000, 1, 1)]
        Vorges = 485,
        [Bdd("A13A63E8-509D-E14B-9F88-24C4DF7375B5")]
        [SousReference("Honolulu", "Honolulu", EnumReference.Hawai, 638182053590000000, 1, 1)]
        Honolulu = 486,
        [Bdd("9F05387A-358D-D441-B738-49AE9B9DC4A0")]
        [SousReference("Budapest", "Budapest", EnumReference.Hongrie, 638182053590000000, 1, 1)]
        Budapest = 487,
        [Bdd("F61F1F7B-0973-9941-8BD5-5CCED71544F0")]
        [SousReference("Dublin", "Dublin", EnumReference.Irlande, 638182053590000000, 1, 1)]
        Dublin = 488,
        [Bdd("A608BDFA-D4C2-8642-A92E-F11C7267C02E")]
        [SousReference("Ennis", "Ennis", EnumReference.Irlande, 638182053590000000, 1, 1)]
        Ennis = 489,
        [Bdd("3E23BA74-C81C-1B43-8590-63125B391EA0")]
        [SousReference("Kilkenny", "Kilkenny", EnumReference.Irlande, 638182053590000000, 1, 1)]
        Kilkenny = 490,
        [Bdd("5BBC44FF-05CF-244E-8BB4-4663E7E3ECB6")]
        [SousReference("Jérusalem", "Jerusalem", EnumReference.Israel, 638182053590000000, 1, 1)]
        Jerusalem = 491,
        [Bdd("9EB2689E-EC16-844F-BF6C-41F1B8BBB24C")]
        [SousReference("Andria", "Andria", EnumReference.Italie, 638182053590000000, 1, 1)]
        Andria = 492,
        [Bdd("F995B3C8-C353-0B4C-81DF-5C34702FDA51")]
        [SousReference("Arezzo", "Arezzo", EnumReference.Italie, 638182053590000000, 1, 1)]
        Arezzo = 493,
        [Bdd("3C174878-389D-5445-AD58-A2772B9D7474")]
        [SousReference("Bassano del Grappa", "Bassano del Grappa", EnumReference.Italie, 638182053590000000, 1, 1)]
        BassanodelGrappa = 494,
        [Bdd("26619270-295E-8A48-BAF3-097405DD54E9")]
        [SousReference("Bergame", "Bergamo", EnumReference.Italie, 638182053590000000, 1, 1)]
        Bergame = 495,
        [Bdd("A3A84465-BD75-9348-9670-FC48FCADB063")]
        [SousReference("Bologne", "Bologna", EnumReference.Italie, 638182053590000000, 1, 1)]
        Bologne = 496,
        [Bdd("C190F1D8-43D1-0446-99CF-9EE11ED1C755")]
        [SousReference("Brescia", "Brescia", EnumReference.Italie, 638182053590000000, 1, 1)]
        Brescia = 497,
        [Bdd("9C6A6E7D-2A27-0F4C-A525-584E0393718C")]
        [SousReference("Casalpusterlengo", "Casalpusterlengo", EnumReference.Italie, 638182053590000000, 1, 1)]
        Casalpusterlengo = 498,
        [Bdd("2740EA67-D862-7E45-8C67-EB8E93600DD7")]
        [SousReference("Crocetta", "Crocetta", EnumReference.Italie, 638182053590000000, 1, 1)]
        Crocetta = 499,
        [Bdd("9956EC7A-D560-FA4D-9293-36166A14EFAF")]
        [SousReference("Cureglia", "Cureglia", EnumReference.Italie, 638182053590000000, 1, 1)]
        Cureglia = 500,
        [Bdd("43E89DB9-913C-0548-AFE2-C209CBDB4F43")]
        [SousReference("Faenza", "Faenza", EnumReference.Italie, 638182053590000000, 1, 1)]
        Faenza = 501,
        [Bdd("75F8F63C-752B-4947-AA85-C1837FEF0FF1")]
        [SousReference("Ferrare", "Ferrara", EnumReference.Italie, 638182053590000000, 1, 1)]
        Ferrare = 502,
        [Bdd("6958BE5C-98B5-0140-B084-5D3D1D31C650")]
        [SousReference("Florence", "Florence", EnumReference.Italie, 638182053590000000, 1, 1)]
        Florence = 503,
        [Bdd("59E202AB-7F7B-1B4B-9925-A21E2D5924D6")]
        [SousReference("Forli", "Forli", EnumReference.Italie, 638182053590000000, 1, 1)]
        Forli = 504,
        [Bdd("B1FC4A52-D1D6-F245-A419-AC49992DE1AB")]
        [SousReference("Gênes", "Genoa", EnumReference.Italie, 638182053590000000, 1, 1)]
        Genes = 505,
        [Bdd("A1AAE9A3-AD9F-A04E-8FEF-8DACAD815F80")]
        [SousReference("Lerici", "Lerici", EnumReference.Italie, 638182053590000000, 1, 1)]
        Lerici = 506,
        [Bdd("7F41ACF7-4426-904B-8120-4E93DC75D35E")]
        [SousReference("Mantoue", "Mantua", EnumReference.Italie, 638182053590000000, 1, 1)]
        Mantoue = 507,
        [Bdd("387F7EED-4929-2045-A15C-59561355924B")]
        [SousReference("Milan", "Milan", EnumReference.Italie, 638182053590000000, 1, 1)]
        Milan = 508,
        [Bdd("1F2A208B-733A-D34E-802C-1741C8B4F899")]
        [SousReference("Modène", "Modena", EnumReference.Italie, 638182053590000000, 1, 1)]
        Modene = 509,
        [Bdd("625E28D1-D99D-9C46-A0EC-620262C3A3BB")]
        [SousReference("Naples", "Naples", EnumReference.Italie, 638182053590000000, 1, 1)]
        Naples = 510,
        [Bdd("896F82A3-E221-6549-9943-84ADF16DFC21")]
        [SousReference("Ortona", "Ortona", EnumReference.Italie, 638182053590000000, 1, 1)]
        Ortona = 511,
        [Bdd("70262C61-24E9-C14D-A731-BFCF55379646")]
        [SousReference("Padoue", "Padua", EnumReference.Italie, 638182053590000000, 1, 1)]
        Padoue = 512,
        [Bdd("78341CFD-5F1C-8642-B680-A3FF1A32CEBF")]
        [SousReference("Parme", "Parma", EnumReference.Italie, 638182053590000000, 1, 1)]
        Parme = 513,
        [Bdd("C0545C27-F6D8-7048-A511-F22439D9F5E2")]
        [SousReference("Pavie", "Pavia", EnumReference.Italie, 638182053590000000, 1, 1)]
        Pavie = 514,
        [Bdd("6D15A4E2-D3B6-984C-A665-E216BC3818B6")]
        [SousReference("Pesaro", "Pesaro", EnumReference.Italie, 638182053590000000, 1, 1)]
        Pesaro = 515,
        [Bdd("BD9FE2A8-6E78-084B-A063-3A4BEF45B79A")]
        [SousReference("Ravenne", "Ravenna", EnumReference.Italie, 638182053590000000, 1, 1)]
        Ravenne = 516,
        [Bdd("D6B0E5CE-7EB6-454A-9716-70DD8630D156")]
        [SousReference("Reggio d'Emilie", "Reggio Emilia", EnumReference.Italie, 638182053590000000, 1, 1)]
        ReggiodEmilie = 517,
        [Bdd("C8996A42-8C8B-1541-B6F6-1FE87CD81381")]
        [SousReference("Rome", "Rome", EnumReference.Italie, 638182053590000000, 1, 1)]
        Rome = 518,
        [Bdd("4457515B-66AC-804A-8AEB-9827182F33D6")]
        [SousReference("San Donato", "San Donato", EnumReference.Italie, 638182053590000000, 1, 1)]
        SanDonato = 519,
        [Bdd("CC82F357-4320-7E4E-9A6A-3273628D612B")]
        [SousReference("Santa Maria Maggiore", "Santa Maria Maggiore", EnumReference.Italie, 638182053590000000, 1, 1)]
        SantaMariaMaggiore = 520,
        [Bdd("F6A85B37-C785-3C47-99E7-C1FBBE335397")]
        [SousReference("Spolète", "Spoleto", EnumReference.Italie, 638182053590000000, 1, 1)]
        Spolete = 521,
        [Bdd("8194EC19-9CC4-7747-992D-6B732364184D")]
        [SousReference("Trieste", "Trieste", EnumReference.Italie, 638182053590000000, 1, 1)]
        Trieste = 522,
        [Bdd("AF9057CC-333C-5045-8858-3F20E4174BC8")]
        [SousReference("Turin", "Turin", EnumReference.Italie, 638182053590000000, 1, 1)]
        Turin = 523,
        [Bdd("4F1EA79F-15B6-0043-8E16-1584CF42E0A0")]
        [SousReference("Udine", "Udine", EnumReference.Italie, 638182053590000000, 1, 1)]
        Udine = 524,
        [Bdd("D49A666D-759A-C249-B579-3ADE6268ADA5")]
        [SousReference("Urbania", "Urbania", EnumReference.Italie, 638182053590000000, 1, 1)]
        Urbania = 525,
        [Bdd("256BCBC3-1DE0-A04C-8347-383D394E20C2")]
        [SousReference("Urbino", "Urbino", EnumReference.Italie, 638182053590000000, 1, 1)]
        Urbino = 526,
        [Bdd("1F6CE775-FB2E-A147-8C93-094B304BA9B5")]
        [SousReference("Venise", "Venice", EnumReference.Italie, 638182053590000000, 1, 1)]
        Venise = 527,
        [Bdd("1F7894AE-847F-D741-91E4-17DCB2C24A09")]
        [SousReference("Vérone", "Verona", EnumReference.Italie, 638182053590000000, 1, 1)]
        Verone = 528,
        [Bdd("AA59F14F-01E0-4146-8993-791D147B1214")]
        [SousReference("Tokyo", "Tokyo", EnumReference.Japon, 638182053590000000, 1, 1)]
        Tokyo = 529,
        [Bdd("9655E122-828D-484A-8891-FCE67C51E49D")]
        [SousReference("Vaduz", "Vaduz", EnumReference.Liechtenstein, 638182053590000000, 1, 1)]
        Vaduz = 530,
        [Bdd("B0C9C1D9-CE7B-B94E-8285-426ED368AB9A")]
        [SousReference("Baranowicz", "Baranowicz", EnumReference.Lituanie, 638182053590000000, 1, 1)]
        Baranowicz = 531,
        [Bdd("EE26541D-95D6-9D42-A023-B557128B058C")]
        [SousReference("Oslo", "Oslo", EnumReference.Norvege, 638182053590000000, 1, 1)]
        Oslo = 532,
        [Bdd("0714FE23-6EB5-2C4B-B8B9-E29448E4787C")]
        [SousReference("Abbenbroek", "Abbenbroek", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Abbenbroek = 533,
        [Bdd("7D63411E-A431-A541-83C5-3B7796E2B157")]
        [SousReference("Aerdenhout", "Aerdenhout", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Aerdenhout = 534,
        [Bdd("4662DDA9-12C5-944D-8408-54F0F240EC1F")]
        [SousReference("Almelo", "Almelo", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Almelo = 535,
        [Bdd("8C0D3621-858B-7246-B7D1-E13B918BF2FA")]
        [SousReference("Amsterdam", "Amsterdam", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Amsterdam = 536,
        [Bdd("38DF442D-19F2-9942-996A-80D190C21209")]
        [SousReference("Arnhem", "Arnhem", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Arnhem = 537,
        [Bdd("0D3F902A-0CDD-3948-8318-8E684260233E")]
        [SousReference("Baarn", "Baarn", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Baarn = 538,
        [Bdd("2893B62D-FF69-7645-976B-A28853E218B5")]
        [SousReference("Berg en Dal", "Berg en Dal", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        BergenDal = 539,
        [Bdd("95D1D2F9-D203-354B-8C7C-AF62EC3A9900")]
        [SousReference("Bilthoven", "Bilthoven", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Bilthoven = 540,
        [Bdd("E6EE111E-43CF-DB4F-8FE4-5E1526C6FFD2")]
        [SousReference("Blaricum", "Blaricum", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Blaricum = 541,
        [Bdd("DA746C90-475E-8544-BABC-26B5F59E056A")]
        [SousReference("Bodegraven", "Bodegraven", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Bodegraven = 542,
        [Bdd("1ED1BB1A-59A1-3648-9235-B923963A26B9")]
        [SousReference("Bois-le-Duc", "'s-Hertogenbosch", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        BoisleDuc = 543,
        [Bdd("2B428BF5-EBB1-344F-83BD-F0047B41FC31")]
        [SousReference("Bolsward", "Bolsward", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Bolsward = 544,
        [Bdd("B33106C2-0F86-414A-96B0-4FC314CBE202")]
        [SousReference("Borkel & Schaft", "Borkel & Schaft", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        BorkelSchaft = 545,
        [Bdd("F285B519-379D-284D-9A19-441A30F2C23A")]
        [SousReference("Breda", "Breda", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Breda = 546,
        [Bdd("D055DD47-ED53-E749-9B99-C8971FCFE986")]
        [SousReference("Crailo", "Crailo", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Crailo = 547,
        [Bdd("8CC8B63A-D865-4A4A-99AA-4E2B6DD9CB5C")]
        [SousReference("De Meern", "De Meern", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        DeMeern = 548,
        [Bdd("8F64CEF0-3A12-D247-9D5B-1B413342880E")]
        [SousReference("Delft", "Delft", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Delft = 549,
        [Bdd("3489BED1-0E19-BE49-909E-76CD2A581E74")]
        [SousReference("Deventer", "Deventer", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Deventer = 550,
        [Bdd("798D74F2-99B0-E54F-B448-27405B2E5982")]
        [SousReference("Dordrecht", "Dordrecht", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Dordrecht = 551,
        [Bdd("F8C6007A-3135-CA4E-9A31-D01365F560D1")]
        [SousReference("Dronrijp", "Dronrijp", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Dronrijp = 552,
        [Bdd("0DC4EB0B-165E-D842-81D2-E01DE150E9A5")]
        [SousReference("Edam", "Edam", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Edam = 553,
        [Bdd("6608F0A1-F591-9942-8484-B3FF4AE10828")]
        [SousReference("Gorinchem", "Gorinchem", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Gorinchem = 554,
        [Bdd("51FE4D9F-379D-6640-B644-3E3D58FEB314")]
        [SousReference("Groningue", "Groningen", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Groningue = 555,
        [Bdd("4B715A50-8682-5643-A090-7EBA1CD27F91")]
        [SousReference("Haarlem", "Haarlem", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Haarlem = 556,
        [Bdd("74FDB24D-07F2-274C-B2EA-0EB40BA40D79")]
        [SousReference("Heemstede", "Heemstede", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Heemstede = 557,
        [Bdd("EED3CFDD-EA30-5247-9BCF-084FD8E465CC")]
        [SousReference("Hillegom", "Hillegom", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Hillegom = 558,
        [Bdd("CDB16383-DD32-E347-AC06-1962B104E24E")]
        [SousReference("Hilversum", "Hilversum", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Hilversum = 559,
        [Bdd("CC027648-4C47-2D42-890C-752EDC3AC5BC")]
        [SousReference("Katwijk", "Katwijk", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Katwijk = 560,
        [Bdd("560AA432-1333-3641-BB19-AFAC70F5737B")]
        [SousReference("La Haye", "The Hague", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        LaHaye = 561,
        [Bdd("F91B9E23-507B-BC4C-808E-24FFC3804FCC")]
        [SousReference("Laren", "Laren", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Laren = 562,
        [Bdd("6BBCCF07-5BBA-5F48-BA94-04E971A05624")]
        [SousReference("Leeuwarden", "Leeuwarden", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Leeuwarden = 563,
        [Bdd("17F5246E-139E-864F-BE96-43EDB2EE950E")]
        [SousReference("Leyde", "Leiden", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Leyde = 564,
        [Bdd("34284E87-2D4F-8244-94EE-BC148D99EE55")]
        [SousReference("Maartensdijk", "Maartensdijk", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Maartensdijk = 565,
        [Bdd("567EDA7C-5EC1-214B-A610-9603824D45FA")]
        [SousReference("Middelburg", "Middelburg", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Middelburg = 566,
        [Bdd("D96D16A1-D61F-9C49-BA04-B2CA55EAA06E")]
        [SousReference("Nimègue", "Nijmegen", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Nimegue = 567,
        [Bdd("138895AE-9CB5-3E4A-AD4D-D894D68D1657")]
        [SousReference("Oosterbeek", "Oosterbeek", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Oosterbeek = 568,
        [Bdd("FCA4E992-B0E9-174F-801C-ED9B06DF9539")]
        [SousReference("Otterlo", "Otterlo", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Otterlo = 569,
        [Bdd("2235A4BF-A8F2-894E-92BC-7F6112DD1485")]
        [SousReference("Overveen", "Overveen", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Overveen = 570,
        [Bdd("774149C4-09E0-7B44-BA4D-FCFB075E18F6")]
        [SousReference("Putten", "Putten", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Putten = 571,
        [Bdd("0268EE25-FC4D-414B-AAFE-8B53510B45EF")]
        [SousReference("Rhoon", "Rhoon", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Rhoon = 572,
        [Bdd("D4AA5608-2CD0-E243-8655-7250B713D72F")]
        [SousReference("Roosendaal", "Roosendaal", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Roosendaal = 573,
        [Bdd("F3E784D0-E1C1-0E4A-856B-D534F89C31BD")]
        [SousReference("Rotterdam", "Rotterdam", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Rotterdam = 574,
        [Bdd("103D59D9-CBA5-2F40-BE2A-C1193B6ABF8F")]
        [SousReference("Schiedam", "Schiedam", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Schiedam = 575,
        [Bdd("0D22FA8B-13AA-5D41-B558-817E1290A550")]
        [SousReference("Soelen", "Soelen", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Soelen = 576,
        [Bdd("A53D7D8D-284B-4344-9A09-AC4EC09110F9")]
        [SousReference("Utrecht", "Utrecht", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Utrecht = 577,
        [Bdd("A9D539A7-3F2D-8B43-8216-708F6643881D")]
        [SousReference("Vaassen", "Vaassen", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Vaassen = 578,
        [Bdd("9244D52F-FC57-8940-8309-FF78715147DD")]
        [SousReference("Vreeland", "Vreeland", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Vreeland = 579,
        [Bdd("D4810029-BBA1-9943-948D-60F9B60C641C")]
        [SousReference("Warmond", "Warmond", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Warmond = 580,
        [Bdd("D514E3AA-80A7-6A4B-9BA9-41C6AC0750C0")]
        [SousReference("Wassenaar", "Wassenaar", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Wassenaar = 581,
        [Bdd("56FA65C1-9DD6-354D-B31A-5A4B704B99A0")]
        [SousReference("Worpswede", "Worpswede", EnumReference.PaysBas, 638182053590000000, 1, 1)]
        Worpswede = 582,
        [Bdd("AE1C3BD6-463E-0F47-9561-A763195AA134")]
        [SousReference("Brzeg", "Brzeg", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Brzeg = 583,
        [Bdd("EC6871AA-6E54-5C44-BBDB-5FC34897B6DB")]
        [SousReference("Cracovie", "Krakow", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Cracovie = 584,
        [Bdd("75F9F677-B78B-2343-BAB5-9BB30D1C969C")]
        [SousReference("Dabrowa Górnicza", "Dabrowa Gornicza", EnumReference.Pologne, 638182053590000000, 1, 1)]
        DabrowaGornicza = 585,
        [Bdd("79F3ABA0-1F59-3040-93B8-73B5AFDAB2D5")]
        [SousReference("Dantzig", "Gdansk", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Dantzig = 586,
        [Bdd("10585D48-B75B-C046-A9DC-83D59B62BA5C")]
        [SousReference("Dolsk", "Dolsk", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Dolsk = 587,
        [Bdd("9322810E-3953-6C48-853F-8EAA031B1B1B")]
        [SousReference("Goluchów", "Goluchów", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Goluchow = 588,
        [Bdd("A815FB21-861A-2340-B890-3F8ACEC32A14")]
        [SousReference("Goscieszyn", "Goscieszyn", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Goscieszyn = 589,
        [Bdd("D266E7C9-3754-EB46-B0C5-1A7C339B0C07")]
        [SousReference("Kalisz", "Kalisz", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Kalisz = 590,
        [Bdd("0B69DFD0-1F71-E04B-8969-CC7A7430031D")]
        [SousReference("Kiev", "Kiev", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Kiev = 591,
        [Bdd("DAD5CFEF-55F6-7A43-BE8D-2BCA98C74D7A")]
        [SousReference("Lodz", "Lodz", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Lodz = 592,
        [Bdd("BAF4049A-2184-6E47-AB14-AE3C80A919E4")]
        [SousReference("Militsch", "Milicz", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Militsch = 593,
        [Bdd("027DE199-51AB-9E42-A268-F6A6C83ED4AC")]
        [SousReference("Olesnica Mala", "Olesnica Mala", EnumReference.Pologne, 638182053590000000, 1, 1)]
        OlesnicaMala = 594,
        [Bdd("903F17C9-C775-A741-8E18-D4034522B645")]
        [SousReference("Ozarów", "Ozarów", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Ozarow = 595,
        [Bdd("F3729962-6122-7243-AAAF-D5F75B7B34FF")]
        [SousReference("Poznan", "Poznan", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Poznan = 596,
        [Bdd("9F05DA18-834E-6946-B837-DCA8EF69CB4E")]
        [SousReference("Pustyn", "Pustyn", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Pustyn = 597,
        [Bdd("3336029C-AD39-5948-AED3-01F70EC91ED3")]
        [SousReference("Radachów", "Radachów", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Radachow = 598,
        [Bdd("3B935984-0638-3A48-BC02-554581FAB603")]
        [SousReference("Szczecin (anc. Stettin)", "Szczecin", EnumReference.Pologne, 638182053590000000, 1, 1)]
        SzczecinancStettin = 599,
        [Bdd("BB0E68AA-2E35-7541-8EB5-2A47A4FEB767")]
        [SousReference("Varsovie", "Warsaw", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Varsovie = 600,
        [Bdd("DD588BA4-7EFF-4942-BB9A-A68499C70DFA")]
        [SousReference("Vilnius", "Vilnius", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Vilnius = 601,
        [Bdd("097649B3-8DD3-9843-A8D4-4ABE014156A5")]
        [SousReference("Wroclaw (anc. Breslau)", "Wroclaw", EnumReference.Pologne, 638182053590000000, 1, 1)]
        WroclawancBreslau = 602,
        [Bdd("DF1906DE-CBD2-DA4A-9C35-DC41234F6356")]
        [SousReference("Zamosc", "Zamosc", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Zamosc = 604,
        [Bdd("CA900245-5F0D-CD4F-8F34-1068683616AE")]
        [SousReference("Zolkiewka", "Zolkiewka", EnumReference.Pologne, 638182053590000000, 1, 1)]
        Zolkiewka = 605,
        [Bdd("FAB0EECA-6ED5-F84A-B0BB-6E3174DB06C7")]
        [SousReference("Zloty Stok", "Zloty Stok", EnumReference.Pologne, 638182053590000000, 1, 1)]
        ZlotyStok = 606,
        [Bdd("0983A3D2-E920-9A4D-B71A-BAB0E589589D")]
        [SousReference("Alcobaça", "Alcobaça", EnumReference.Portugal, 638182053590000000, 1, 1)]
        Alcobaa = 607,
        [Bdd("1F082A1B-105F-1648-B19F-7DF85A04E8E4")]
        [SousReference("Lisbonne", "Lisbon", EnumReference.Portugal, 638182053590000000, 1, 1)]
        Lisbonne = 608,
        [Bdd("41DB7527-EB7F-C144-A2CC-B98DC7882098")]
        [SousReference("Brno (anc. Brunn)", "Brno", EnumReference.RepubliqueTcheque, 638182053590000000, 1, 1)]
        BrnoancBrunn = 609,
        [Bdd("7B847C9F-08D8-2847-94C6-E6B0DE45F793")]
        [SousReference("Karlovy Vary (anc. Karlsbad)", "Karlovy Vary", EnumReference.RepubliqueTcheque, 638182053590000000, 1, 1)]
        KarlovyVaryancKarlsbad = 610,
        [Bdd("76FE0936-A157-694E-A1C7-4060AE1ABEFF")]
        [SousReference("Prague", "Prague", EnumReference.RepubliqueTcheque, 638182053590000000, 1, 1)]
        Prague = 611,
        [Bdd("355E8CC8-EDC3-8240-8979-77A58F626338")]
        [SousReference("Turnau", "Turnov", EnumReference.RepubliqueTcheque, 638182053590000000, 1, 1)]
        Turnau = 612,
        [Bdd("1606E01E-FD5D-A247-8737-BBE1E98EFF49")]
        [SousReference("Bucarest", "Bucharest", EnumReference.Roumanie, 638182053590000000, 1, 1)]
        Bucarest = 613,
        [Bdd("563656D6-43C8-C547-83BD-C2AF68BD567F")]
        [SousReference("Aberdeen", "Aberdeen", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Aberdeen = 614,
        [Bdd("21E26C9D-6017-E041-9DD7-00E58134AC37")]
        [SousReference("Abergavenny", "Abergavenny", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Abergavenny = 615,
        [Bdd("E5537B95-0239-344F-B54F-85647F1DD9CB")]
        [SousReference("Alkrington", "Alkrington", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Alkrington = 616,
        [Bdd("F34529FB-A9B1-074B-B1BA-77E845350731")]
        [SousReference("Allesley", "Allesley", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Allesley = 617,
        [Bdd("91789378-1D89-4E4D-8241-2F0B7CC76E0D")]
        [SousReference("Alresford", "Alresford", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Alresford = 618,
        [Bdd("EB94ED8D-3C4A-F648-B0E5-544BD585B50E")]
        [SousReference("Althorp", "Althorp", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Althorp = 619,
        [Bdd("1A88B193-0A9E-194A-9F42-DE61025D73E7")]
        [SousReference("Alton", "Alton", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Alton = 620,
        [Bdd("A9F7E2E9-BBFD-664E-BBBB-7EBA9362B16B")]
        [SousReference("Amersham", "Amersham", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Amersham = 621,
        [Bdd("879EAA9B-F7E6-124D-B58D-0C633C758D23")]
        [SousReference("Ayr", "Ayr", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Ayr = 622,
        [Bdd("C19B14BE-FF8F-F944-9528-D2AF4F6349E7")]
        [SousReference("Badger", "Badger", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Badger = 623,
        [Bdd("48F51A20-F4EF-B649-A325-5942A5240313")]
        [SousReference("Ballskelly", "Ballskelly", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Ballskelly = 624,
        [Bdd("8B7797BF-CEE5-B749-9831-62FC33DF48F8")]
        [SousReference("Banbury", "Banbury", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Banbury = 625,
        [Bdd("1A7A59DE-12A4-C141-914A-BBE309AB80F3")]
        [SousReference("Bath", "Bath", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Bath = 626,
        [Bdd("5C111E91-9729-3747-BF74-D6A8DBAC0D0D")]
        [SousReference("Beaulieu", "Beaulieu", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Beaulieu = 627,
        [Bdd("5A027F8F-08F7-F847-BEB3-1E7679B34753")]
        [SousReference("Bignor Park", "Bignor Park", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        BignorPark = 628,
        [Bdd("69D562B1-70B2-DE44-B356-A6CF3C3559BF")]
        [SousReference("Birkenhead", "Birkenhead", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Birkenhead = 629,
        [Bdd("6320AD9F-5FF1-9240-85EA-79DCF5FEE387")]
        [SousReference("Birmingham", "Birmingham", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Birmingham = 630,
        [Bdd("934FC362-BBC4-B449-91C9-F7E4D7571D20")]
        [SousReference("Boldre", "Boldre", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Boldre = 631,
        [Bdd("BDAD28C6-A028-CD4C-A8D1-ED0D87D767FB")]
        [SousReference("Bradford", "Bradford", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Bradford = 632,
        [Bdd("C2223FE7-3723-9D48-856B-1E85EDC41097")]
        [SousReference("Bridgwater", "Bridgwater", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Bridgwater = 633,
        [Bdd("2F323847-0311-634B-8FB1-927CE715D560")]
        [SousReference("Brighton", "Brighton", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Brighton = 634,
        [Bdd("9C2CB6EE-3F3E-A84C-A1FE-32A580CEA1CD")]
        [SousReference("Bristol", "Bristol", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Bristol = 635,
        [Bdd("E19D448F-F9A7-C549-9F3A-15C7AB1734A4")]
        [SousReference("Bromley", "Bromley", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Bromley = 636,
        [Bdd("910C82F1-038C-6841-800C-86D7EFFE9A67")]
        [SousReference("Bryn y Gwin", "Bryn y Gwin", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        BrynyGwin = 637,
        [Bdd("0BED756B-5EE7-DB4E-B0D5-50487F0D447A")]
        [SousReference("Bude", "Bude", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Bude = 638,
        [Bdd("63652D33-1C99-7A44-95E2-431988DDD1C7")]
        [SousReference("Burford", "Burford", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Burford = 639,
        [Bdd("D25BE29F-F692-1E43-AEA8-299184D3842E")]
        [SousReference("Bushey", "Bushey", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Bushey = 640,
        [Bdd("6ECFEB30-B9E0-774D-A2BC-E72776747001")]
        [SousReference("Bushy", "Bushy", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Bushy = 641,
        [Bdd("EFBC717C-1360-2C46-A978-DEDA4ABEA6A1")]
        [SousReference("Butterwick", "Butterwick", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Butterwick = 642,
        [Bdd("B6A8E064-53F5-0849-A2B8-A266CB6E9B40")]
        [SousReference("Cambridge", "Cambridge", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Cambridge_RoyaumeUni = 643,
        [Bdd("61A5DFBE-F0E6-3649-B61E-AF4394B96E3E")]
        [SousReference("Carlish", "Carlish", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Carlish = 644,
        [Bdd("70E50E3A-DEB9-B548-9931-0423E711F20A")]
        [SousReference("Catsfield", "Catsfield", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Catsfield = 645,
        [Bdd("F8CB53C2-FB10-B042-BD30-BB560A2DE28B")]
        [SousReference("Chatsworth", "Chatsworth", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Chatsworth = 646,
        [Bdd("62DD1FAA-691F-644B-BECC-22834599E536")]
        [SousReference("Cheltenham", "Cheltenham", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Cheltenham = 647,
        [Bdd("B351C432-6DFF-4441-825E-5263B9E496A3")]
        [SousReference("Chesham", "Chesham", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Chesham = 648,
        [Bdd("89E660FB-419D-454E-8F15-B93B7FAC7C7D")]
        [SousReference("Chislehurst", "Chislehurst", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Chislehurst = 649,
        [Bdd("D3D2780D-3CD2-2640-A2F8-C037AEFF23F3")]
        [SousReference("Clapham Rise", "Clapham Rise", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        ClaphamRise = 650,
        [Bdd("487ACABF-86B9-C84B-A199-847B64E266FD")]
        [SousReference("Cleckheaton", "Cleckheaton", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Cleckheaton = 651,
        [Bdd("8B313226-CABA-424E-9176-99431F2B035D")]
        [SousReference("Cobham", "Cobham", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Cobham = 652,
        [Bdd("8D2F50FF-EE2B-794E-BABE-7F9D4A451B01")]
        [SousReference("Compton Hall", "Compton Hall", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        ComptonHall = 653,
        [Bdd("BCEF6D89-3492-ED4F-B1EA-8EDC2421B401")]
        [SousReference("Cuckfield", "Cuckfield", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Cuckfield = 654,
        [Bdd("E28BAB8A-992E-F348-886B-6BCCE382D66A")]
        [SousReference("Dalkeith", "Dalkeith", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Dalkeith = 655,
        [Bdd("E5AD5B9C-4FFA-564B-8844-B7B3F911972B")]
        [SousReference("Delgany", "Delgany", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Delgany = 656,
        [Bdd("0386D6EC-0A41-0E47-9EE6-BEC46C161978")]
        [SousReference("Devonport", "Devonport", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Devonport = 657,
        [Bdd("CA22F2EA-74B3-0340-88EE-2BB03E6FD03C")]
        [SousReference("Ditchling", "Ditchling", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Ditchling = 658,
        [Bdd("04C7D840-537B-E246-B462-804696875915")]
        [SousReference("Dumbarton", "Dumbarton", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Dumbarton = 659,
        [Bdd("8E7D22D4-2FFA-E947-91C7-67E93A5A41B8")]
        [SousReference("Ealing Grove", "Ealing Grove", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        EalingGrove = 660,
        [Bdd("B1867CA7-0261-3444-BCC0-38784E8459BF")]
        [SousReference("Eastbourne", "Eastbourne", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Eastbourne = 661,
        [Bdd("18796728-080D-F649-8545-E7B60AEB9BFC")]
        [SousReference("Easton Court", "Easton Court", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        EastonCourt = 662,
        [Bdd("F59FEE22-1E88-3642-A0FF-5D5922F9276C")]
        [SousReference("Edimbourg", "Edinburgh", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Edimbourg = 663,
        [Bdd("DC06E0FC-B3D1-804C-8480-F901F0E9BB0C")]
        [SousReference("Eltham", "Eltham", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Eltham = 664,
        [Bdd("AFC94125-B379-094E-81D1-8C8DDBE8257D")]
        [SousReference("Ennis", "Ennis", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Ennis_RoyaumeUni = 665,
        [Bdd("1AC6A785-6EF1-9441-8948-DCCEEC4EE640")]
        [SousReference("Epping", "Epping", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Epping = 666,
        [Bdd("949C4E19-C1AC-B942-AF8E-71D20D4671F4")]
        [SousReference("Ethie Castle", "Ethie Castle", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        EthieCastle = 667,
        [Bdd("0C2D1DD6-3366-0044-A157-5084A49D61A9")]
        [SousReference("Evesham", "Evesham", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Evesham = 668,
        [Bdd("AD1012F6-786F-4046-AB73-5B3BF3C8F1F2")]
        [SousReference("Falmouth", "Falmouth", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Falmouth = 669,
        [Bdd("CE243569-76ED-F244-AF69-68BECD457EEE")]
        [SousReference("Finchley", "Finchley", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Finchley = 670,
        [Bdd("9A195598-2CAE-0A46-AD03-22E34CF97D4A")]
        [SousReference("Fonthill", "Fonthill", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Fonthill = 671,
        [Bdd("ABAD0A18-5724-2E4F-A0FD-1071989E6E9D")]
        [SousReference("Foxley", "Foxley", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Foxley = 672,
        [Bdd("092781CA-CAC0-D84C-8B77-69510272073D")]
        [SousReference("Glasgow", "Glasgow", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Glasgow = 673,
        [Bdd("A1648D79-BCEC-434F-99C8-E042DFB8216C")]
        [SousReference("Gloucester", "Gloucester", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Gloucester = 674,
        [Bdd("C794CF5A-6251-8446-B410-9E8201AD2B10")]
        [SousReference("Glynde Place", "Glynde Place", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        GlyndePlace = 675,
        [Bdd("78EE9AAA-9941-0E43-966C-F77CF7E48DA6")]
        [SousReference("Great Barton", "Great Barton", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        GreatBarton = 676,
        [Bdd("36C06043-ACBE-2449-BAF7-097BF53B5D6C")]
        [SousReference("Great Packington", "Great Packington", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        GreatPackington = 677,
        [Bdd("E73B80AA-FBF8-D440-A1B1-CAC1E5BA4337")]
        [SousReference("Great Waltham", "Great Waltham", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        GreatWaltham = 678,
        [Bdd("43A726E2-BC10-3C45-90AF-84D72E09A98C")]
        [SousReference("Grendon", "Grendon", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Grendon = 679,
        [Bdd("948E486C-2DAA-6849-B889-5CB0BDF20000")]
        [SousReference("Guildford", "Guildford", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Guildford = 680,
        [Bdd("5B47F729-88C6-AA4D-9DB3-83F23CE242DF")]
        [SousReference("Hale", "Hale", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Hale = 681,
        [Bdd("6325280A-FA4D-C143-8D95-BA93A9C5BEFF")]
        [SousReference("Hampstead", "Hampstead", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Hampstead = 682,
        [Bdd("E01BC4EF-9D80-7042-8F1F-7A893B2AB2EA")]
        [SousReference("Hampton Hill", "Hampton Hill", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        HamptonHill = 683,
        [Bdd("6FE735E8-66EE-C44B-ACB8-C6660732A14C")]
        [SousReference("Heavitree", "Heavitree", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Heavitree = 684,
        [Bdd("3F2AAEEE-EB4D-504B-AFE1-051B8D653A63")]
        [SousReference("High Beech", "High Beech", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        HighBeech = 685,
        [Bdd("E271F26C-80BE-F843-838B-56A8C4C2FF3B")]
        [SousReference("Hill Top", "Hill Top", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        HillTop = 686,
        [Bdd("CA5FC4C0-A0BB-5446-A87A-63543F6FA478")]
        [SousReference("Hinxworth", "Hinxworth", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Hinxworth = 687,
        [Bdd("EA5AF7F5-430D-3547-8D68-6B4304F6C776")]
        [SousReference("Hitchin", "Hitchin", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Hitchin = 688,
        [Bdd("1FE25935-45E8-7143-88B7-6A40DE54BE19")]
        [SousReference("Honiton", "Honiton", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Honiton = 689,
        [Bdd("D53F8FC3-436E-7449-9253-7F5176A55A11")]
        [SousReference("Hove", "Hove", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Hove = 690,
        [Bdd("42B14AB9-2533-7943-80B1-BD501056F510")]
        [SousReference("Humbie", "Humbie", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Humbie = 691,
        [Bdd("CA6BD088-83E2-8945-94EB-EEB4714ABF7A")]
        [SousReference("Inverness", "Inverness", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Inverness = 692,
        [Bdd("2E5B9ECD-6BBD-854A-A48A-210C151C13C7")]
        [SousReference("Kincardine-on-Forth", "Kincardine-on-Forth", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        KincardineonForth = 693,
        [Bdd("964F9CF7-6446-B941-8BD8-6BE2AF043025")]
        [SousReference("Knowbury", "Knowbury", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Knowbury = 694,
        [Bdd("64579277-6DB6-6842-8126-95B07C37F54D")]
        [SousReference("Leeds", "Leeds", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Leeds_RoyaumeUni = 695,
        [Bdd("773DBC83-23DB-704A-B400-1427E71E8018")]
        [SousReference("Leicester", "Leicester", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Leicester = 696,
        [Bdd("18C51840-E273-B24D-9431-0996FC2A7BCF")]
        [SousReference("Liverpool", "Liverpool", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Liverpool = 697,
        [Bdd("709586F1-61A5-3946-BCED-9CC21D912E14")]
        [SousReference("Londres", "London", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Londres = 698,
        [Bdd("7ECA01F2-952A-7F47-9A8F-364C5CF3ACFE")]
        [SousReference("Lurley", "Lurley", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Lurley = 699,
        [Bdd("1058FF07-3DA9-034F-94F4-C4E67EC84B67")]
        [SousReference("Manchester", "Manchester", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Manchester = 700,
        [Bdd("6B1FF677-14F0-D84E-915F-3D2017A63E62")]
        [SousReference("Mansfield", "Mansfield", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Mansfield = 701,
        [Bdd("7FE9E6D3-3DDD-CA4D-ADA1-9113298EE3E4")]
        [SousReference("Meopham", "Meopham", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Meopham = 702,
        [Bdd("12462FA6-3F03-A842-B9F8-68840E928B3F")]
        [SousReference("Mildenhall", "Mildenhall", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Mildenhall = 703,
        [Bdd("F70BF61F-F0FC-B04F-899E-CA895A57FF29")]
        [SousReference("Milton (Hampshire)", "Milton (Hampshire)", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        MiltonHampshire = 704,
        [Bdd("F8F1DFF9-080A-5F49-86A2-837EAA964EE7")]
        [SousReference("Mold", "Mold", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Mold = 705,
        [Bdd("F13DD628-4B62-DB4E-ACA6-98A4D13FCCFC")]
        [SousReference("Morpeth", "Morpeth", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Morpeth = 706,
        [Bdd("DF703C55-7746-104D-8E08-01C9998CE611")]
        [SousReference("Mount Clare", "Mount Clare", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        MountClare = 707,
        [Bdd("B0ACA196-57A6-954C-8931-01BB3920A8D9")]
        [SousReference("Newcastle upon Tyne", "Newcastle upon Tyne", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        NewcastleuponTyne = 708,
        [Bdd("3C76005B-5B4E-D14A-A3E1-45B77F797580")]
        [SousReference("Northgate", "Northgate", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Northgate = 709,
        [Bdd("D369F4CD-90DA-C246-A4C7-157A716589D9")]
        [SousReference("Northwick Park", "Northwick Park", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        NorthwickPark = 710,
        [Bdd("38C6532E-6CAC-0242-9B42-C1980448F990")]
        [SousReference("Norwich", "Norwich", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Norwich = 711,
        [Bdd("D7F7AB47-81A3-B741-B05F-73B6A6180E06")]
        [SousReference("Nottingham", "Nottingham", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Nottingham = 712,
        [Bdd("B2322CB2-11F7-604D-91D5-AC60AECD3AC0")]
        [SousReference("Nunnington", "Nunnington", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Nunnington = 713,
        [Bdd("E44765AD-B056-2043-9176-B1F18AF8E52B")]
        [SousReference("Ongar", "Ongar", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Ongar = 714,
        [Bdd("70BE61A8-FFC8-4B42-937A-987E5A3FFFB6")]
        [SousReference("Oxford", "Oxford", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Oxford = 715,
        [Bdd("B020EA59-6A59-EC4D-BD35-8CA93925CA7E")]
        [SousReference("Palmer's Green", "Palmer's Green", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        PalmersGreen = 716,
        [Bdd("75A1E3FC-C996-2746-877E-AC206C69ED83")]
        [SousReference("Pennyffordd", "Pennyffordd", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Pennyffordd = 717,
        [Bdd("F9114A6A-79F6-DD45-A62B-F0D82833D989")]
        [SousReference("Petersham Castle", "Petersham Castle", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        PetershamCastle = 718,
        [Bdd("88705C10-B8A5-C34D-A9DA-79D6B4A24E3B")]
        [SousReference("Picton Castle", "Picton Castle", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        PictonCastle = 719,
        [Bdd("6499A4C1-E03E-B144-977E-7B37F67E4C92")]
        [SousReference("Poltalloch", "Poltalloch", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Poltalloch = 720,
        [Bdd("B036BF57-C7C2-8A44-AB1A-9B068FB3F0A7")]
        [SousReference("Portinscale", "Portinscale", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Portinscale = 721,
        [Bdd("BEDAFAD9-6205-F94A-AD0A-2F9E2A16A23D")]
        [SousReference("Potterne Manor", "Potterne Manor", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        PotterneManor = 722,
        [Bdd("40458F37-1876-344C-83E6-253C62A96A1E")]
        [SousReference("Purley Park", "Purley Park", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        PurleyPark = 723,
        [Bdd("792AD773-1EBE-3C4B-884D-BCBA1207504C")]
        [SousReference("Richmond", "Richmond", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Richmond = 724,
        [Bdd("EB013247-D866-FD47-BAA1-5135A0C4B979")]
        [SousReference("Ripley", "Ripley", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Ripley = 725,
        [Bdd("DA84AF1F-B504-A648-90A2-C5B47BB85B3C")]
        [SousReference("Rowfant", "Rowfant", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Rowfant = 726,
        [Bdd("A1F33BE4-AF5E-B640-87D5-8546B847CBCC")]
        [SousReference("Salford", "Salford", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Salford = 727,
        [Bdd("C16A3E60-E67A-6544-A306-C50424DBBBBD")]
        [SousReference("Salisbury", "Salisbury", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Salisbury = 728,
        [Bdd("96A895CF-FC9B-2A49-9FA6-980860784665")]
        [SousReference("Settrington", "Settrington", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Settrington = 729,
        [Bdd("B13422F1-B758-1147-98E7-6468B39E892D")]
        [SousReference("Sevenoaks", "Sevenoaks", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Sevenoaks = 730,
        [Bdd("062EF8A7-0A77-EC42-89A1-CC16A4E5BC9C")]
        [SousReference("Shenley", "Shenley", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Shenley = 731,
        [Bdd("523415EB-3788-7D41-B1EA-1879F0B21945")]
        [SousReference("Sherborne", "Sherborne", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Sherborne = 732,
        [Bdd("BCCBCF0C-8434-C540-BEFF-EAC2AFDF22F9")]
        [SousReference("Shiplake", "Shiplake", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Shiplake = 733,
        [Bdd("A0DA24F2-E880-B748-AC70-231604932EFE")]
        [SousReference("Sledmere", "Sledmere", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Sledmere = 734,
        [Bdd("5AA9F4F1-D93E-F645-A997-5DD00602C2EC")]
        [SousReference("Southampton", "Southampton", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Southampton = 735,
        [Bdd("04B044C5-5324-0E49-9143-6F69FE0FC26A")]
        [SousReference("Stafford", "Stafford", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Stafford = 736,
        [Bdd("CE430648-8101-A147-9689-B9A350826C64")]
        [SousReference("Sutton Courtenay", "Sutton Courtenay", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        SuttonCourtenay = 737,
        [Bdd("3FDF493B-E3BE-124A-9D18-A117ACA8763D")]
        [SousReference("Swanage", "Swanage", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Swanage = 738,
        [Bdd("D7937CE5-4A0E-4F49-B609-3A186E3E2F56")]
        [SousReference("Swansea", "Swansea", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Swansea = 739,
        [Bdd("49ED264A-6488-2E44-8F5C-09A52AE23B35")]
        [SousReference("Teddington", "Teddington", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Teddington = 740,
        [Bdd("408896E8-6905-3E4A-9A11-CF5615759DB9")]
        [SousReference("Thirsk", "Thirsk", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Thirsk = 741,
        [Bdd("19CC8E64-2AD7-7F45-BFF1-DF807471A325")]
        [SousReference("Thornton-le-Street", "Thornton-le-Street", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        ThorntonleStreet = 742,
        [Bdd("A06D7BBE-95F6-BF43-97D0-3ABE4E07B1AA")]
        [SousReference("Totnes", "Totnes", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Totnes = 743,
        [Bdd("CE99BD5F-1A72-EB47-8510-3685F4338424")]
        [SousReference("Truro", "Truro", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Truro = 744,
        [Bdd("2F953150-1437-674D-9DC8-CDEB3B881B29")]
        [SousReference("Tunbridge Wells", "Tunbridge Wells", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        TunbridgeWells = 745,
        [Bdd("669496E1-E799-AA48-973B-224FF1042971")]
        [SousReference("Twickenham", "Twickenham", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Twickenham = 746,
        [Bdd("CF1A3763-1E60-4D4E-9F7F-7EBCB9117E0C")]
        [SousReference("Warfield", "Warfield", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Warfield = 747,
        [Bdd("7DABD7C5-45D8-9D4D-A210-8493A912F0F3")]
        [SousReference("Warnford Park", "Warnford Park", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        WarnfordPark = 748,
        [Bdd("AACACA27-88BD-9B48-8379-C60129EC8275")]
        [SousReference("Warrington", "Warrington", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Warrington = 749,
        [Bdd("BADFA5A7-226B-324D-A8AC-C0D078A5EC53")]
        [SousReference("Warwick", "Warwick", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Warwick = 750,
        [Bdd("9F5196B3-154A-BF40-A1E3-6B8BE1864D70")]
        [SousReference("Westonbirt", "Westonbirt", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Westonbirt = 751,
        [Bdd("FCF78861-F31A-9D44-97A3-870CE9F7E5CD")]
        [SousReference("Weybridge", "Weybridge", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Weybridge = 752,
        [Bdd("E86CAF41-4D67-3C43-8C7E-EA9D373BC434")]
        [SousReference("Whalley", "Whalley", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Whalley = 753,
        [Bdd("D4682DE2-A40C-1043-A6AC-D0202A0AA9C5")]
        [SousReference("Wigan", "Wigan", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Wigan = 754,
        [Bdd("A2C00FF9-47C4-D444-BCA8-97112E5E2502")]
        [SousReference("Wilton", "Wilton", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Wilton = 755,
        [Bdd("A6C39977-AC7B-2541-B256-5C9259EE97A4")]
        [SousReference("Wimbledon", "Wimbledon", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Wimbledon = 756,
        [Bdd("D0BDD7ED-53E3-4A48-94D1-5DD4BACFA281")]
        [SousReference("Winchester", "Winchester", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Winchester = 757,
        [Bdd("C0E914D9-19F2-D447-A6B8-7B30AFED5ECF")]
        [SousReference("Windsor", "Windsor", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Windsor = 758,
        [Bdd("7790C5A6-83AE-DC41-B7EB-3EBD43D3664B")]
        [SousReference("Wokingham", "Wokingham", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Wokingham = 759,
        [Bdd("A939153D-1867-FF43-A7C3-9E0A5B42E614")]
        [SousReference("Worthing", "Worthing", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        Worthing = 760,
        [Bdd("FEAAFBE3-545F-B743-B584-DB9C17419C99")]
        [SousReference("Wrest Park", "Wrest Park", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        WrestPark = 761,
        [Bdd("C4413348-0E35-EE46-8B0D-9EB0EAE04A67")]
        [SousReference("Wykeham Abbey", "Wykeham Abbey", EnumReference.RoyaumeUni, 638182053590000000, 1, 1)]
        WykehamAbbey = 762,
        [Bdd("91B3E62F-8DBF-B340-B7C4-ECE885C552FF")]
        [SousReference("Borodino", "Borodino", EnumReference.Russie, 638182053590000000, 1, 1)]
        Borodino = 763,
        [Bdd("39A584E2-CA6E-704B-BDE2-46B558BE1BF8")]
        [SousReference("Kaliningrad (anc. Königsberg)", "Kaliningrad", EnumReference.Russie, 638182053590000000, 1, 1)]
        KaliningradancKonigsberg = 764,
        [Bdd("232ACC93-F0E4-2C45-AEE7-62EFC2AC59CA")]
        [SousReference("Kazan", "Kazan", EnumReference.Russie, 638182053590000000, 1, 1)]
        Kazan = 765,
        [Bdd("FBAB7C84-3B24-B249-AAEB-151F79D7B05D")]
        [SousReference("Kondratovko", "Kondratovko", EnumReference.Russie, 638182053590000000, 1, 1)]
        Kondratovko = 766,
        [Bdd("C3837834-5047-A04C-B35B-FBBCEC878796")]
        [SousReference("Moscou", "Moscow", EnumReference.Russie, 638182053590000000, 1, 1)]
        Moscou = 767,
        [Bdd("37DA1E19-5222-C34F-9519-A3DD1DB3ABDA")]
        [SousReference("Pavlovsk", "Pavlovsk", EnumReference.Russie, 638182053590000000, 1, 1)]
        Pavlovsk = 768,
        [Bdd("79F6F081-3C63-704D-8AD6-5D95378FD472")]
        [SousReference("Penza", "Penza", EnumReference.Russie, 638182053590000000, 1, 1)]
        Penza = 769,
        [Bdd("807901FA-4AAA-CA4E-9A05-78964A2251DB")]
        [SousReference("Rostov", "Rostov", EnumReference.Russie, 638182053590000000, 1, 1)]
        Rostov = 770,
        [Bdd("5E25AECD-633F-6342-9AA7-F02B63EB3AA8")]
        [SousReference("Saint-Pétersbourg", "Saint Petersburg", EnumReference.Russie, 638182053590000000, 1, 1)]
        SaintPetersbourg = 771,
        [Bdd("D5E0CA85-6617-254F-A35B-421D1D662AF1")]
        [SousReference("Usman", "Usman", EnumReference.Russie, 638182053590000000, 1, 1)]
        Usman = 772,
        [Bdd("43FB668F-38E7-CD4C-8A00-1253BF318914")]
        [SousReference("Voronej", "Voronezh", EnumReference.Russie, 638182053590000000, 1, 1)]
        Voronej = 773,
        [Bdd("90A03300-E6DD-4041-9960-3A15BD3B7767")]
        [SousReference("Bratislava (anc. Presbourg)", "Bratislava", EnumReference.Slovaquie, 638182053590000000, 1, 1)]
        BratislavaancPresbourg = 774,
        [Bdd("D60FAAED-E032-A849-8500-8E51BF4D3C40")]
        [SousReference("Eskilstuna", "Eskilstuna", EnumReference.Suede, 638182053590000000, 1, 1)]
        Eskilstuna = 775,
        [Bdd("2258045E-F94E-214F-A96C-6BD55AECE876")]
        [SousReference("Finspång", "Finspång", EnumReference.Suede, 638182053590000000, 1, 1)]
        Finspng = 776,
        [Bdd("343EEDBD-B34F-FD46-ADD3-6AD56F9F77C0")]
        [SousReference("Fullerö", "Fullerö", EnumReference.Suede, 638182053590000000, 1, 1)]
        Fullero = 777,
        [Bdd("A4FC7C15-ADB2-8B48-96B2-7BCCDF53B56A")]
        [SousReference("Göteborg", "Gothenburg", EnumReference.Suede, 638182053590000000, 1, 1)]
        Goteborg = 778,
        [Bdd("8239C8B9-3A49-F74D-8D53-DD14CE825BA3")]
        [SousReference("Kulla-Gunnarstorp", "Kulla-Gunnarstorp", EnumReference.Suede, 638182053590000000, 1, 1)]
        KullaGunnarstorp = 779,
        [Bdd("07B62772-F871-2B4B-9E48-D6129535D73F")]
        [SousReference("Löberöd", "Löberöd", EnumReference.Suede, 638182053590000000, 1, 1)]
        Loberod = 780,
        [Bdd("A1413948-E7A4-364F-9438-8C405C965D14")]
        [SousReference("Norrköping", "Norrköping", EnumReference.Suede, 638182053590000000, 1, 1)]
        Norrkoping = 781,
        [Bdd("A8C4A4BF-59BB-F24A-84B4-DF131E022199")]
        [SousReference("Stockholm", "Stockholm", EnumReference.Suede, 638182053590000000, 1, 1)]
        Stockholm = 782,
        [Bdd("3CC5FBD6-5C9E-6F4A-9A6C-34C95997BAFC")]
        [SousReference("Sundsvall", "Sundsvall", EnumReference.Suede, 638182053590000000, 1, 1)]
        Sundsvall = 783,
        [Bdd("C9BCA039-2BE9-C74B-9781-91D337CA4340")]
        [SousReference("Uppsala", "Uppsala", EnumReference.Suede, 638182053590000000, 1, 1)]
        Uppsala = 784,
        [Bdd("CEBD433F-0C9F-3A4D-9D4D-647FD008EA92")]
        [SousReference("Ascona", "Ascona", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Ascona = 785,
        [Bdd("C0D49FE7-5A07-3049-8609-966A55C17FC2")]
        [SousReference("Bâle", "Basel", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Bale = 786,
        [Bdd("342E82C3-3380-3144-B506-4872D80A9C58")]
        [SousReference("Berne", "Bern", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Berne = 787,
        [Bdd("CAA3741D-DE0D-C642-92A7-004A2E6DD12C")]
        [SousReference("Chêne-Bougeries", "Chêne-Bougeries", EnumReference.Suisse, 638182053590000000, 1, 1)]
        CheneBougeries = 788,
        [Bdd("EB7DB324-99A4-0C42-B18F-06034968114B")]
        [SousReference("Coire", "Chur", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Coire = 789,
        [Bdd("D3C9445E-7FEF-F04E-9FDA-D1342102FB23")]
        [SousReference("Crans-sur-Sierre", "Crans-sur-Sierre", EnumReference.Suisse, 638182053590000000, 1, 1)]
        CranssurSierre = 790,
        [Bdd("8E11AD17-DBA1-8A4E-ABC8-CDC6009CB40A")]
        [SousReference("Davos", "Davos", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Davos = 791,
        [Bdd("F89F8FD7-A12B-6444-A979-C64EB7C11E07")]
        [SousReference("Davos-Frauenkirch", "Davos-Frauenkirch", EnumReference.Suisse, 638182053590000000, 1, 1)]
        DavosFrauenkirch = 792,
        [Bdd("0BD564DF-F841-C04C-A941-D706F891390B")]
        [SousReference("Genève", "Geneva", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Geneve = 793,
        [Bdd("D5984C32-BF73-6D40-9084-F2D64024DD6A")]
        [SousReference("Goldbach-Küssnacht", "Goldbach-Küssnacht", EnumReference.Suisse, 638182053590000000, 1, 1)]
        GoldbachKussnacht = 794,
        [Bdd("506536C9-2B81-294F-A76D-4584E450BEBC")]
        [SousReference("Ins", "Ins", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Ins = 795,
        [Bdd("15DE249B-4A64-0345-A3DC-799BCCD85A98")]
        [SousReference("Lausanne", "Lausanne", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Lausanne = 796,
        [Bdd("967AE8A6-B737-B74B-8A44-73A2F92516BE")]
        [SousReference("Lugano", "Lugano", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Lugano = 797,
        [Bdd("486FD431-39D1-534B-B1FF-2209073FEF29")]
        [SousReference("Morges", "Morges", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Morges = 798,
        [Bdd("3E58D95F-8C65-1C47-B174-45293E45E0FD")]
        [SousReference("Neuchâtel", "Neuchâtel", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Neuchatel = 799,
        [Bdd("E3F9EF9D-1A94-7046-AC36-95C979407143")]
        [SousReference("Rapperswil", "Rapperswil", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Rapperswil = 800,
        [Bdd("2107A901-2D41-8D48-8381-778F70A196D2")]
        [SousReference("Riehen", "Riehen", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Riehen = 801,
        [Bdd("9A43190A-80EB-1E43-904F-3EA928DF833F")]
        [SousReference("Saint-Gall", "St. Gallen", EnumReference.Suisse, 638182053590000000, 1, 1)]
        SaintGall = 802,
        [Bdd("0AF22C8B-CB26-1F45-8931-BFB98974002B")]
        [SousReference("Schaffhouse", "Schaffhausen", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Schaffhouse = 803,
        [Bdd("6728C4E1-A8AF-734D-BAEF-EE814CD062C5")]
        [SousReference("Vevey", "Vevey", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Vevey = 804,
        [Bdd("D4FB526C-70C3-7F4E-B351-F3F0646C7568")]
        [SousReference("Veyras", "Veyras", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Veyras = 805,
        [Bdd("4126436E-858D-5748-AD12-334ACF2C2113")]
        [SousReference("Villard-sous-Blonay", "Villard-sous-Blonay", EnumReference.Suisse, 638182053590000000, 1, 1)]
        VillardsousBlonay = 806,
        [Bdd("337056D8-4762-754C-BF85-B3ED6B220F95")]
        [SousReference("Winterthur", "Winterthur", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Winterthur = 807,
        [Bdd("63B66BBE-6167-594B-A96D-36B53FB66D1F")]
        [SousReference("Zurich", "Zurich", EnumReference.Suisse, 638182053590000000, 1, 1)]
        Zurich = 808,
        [Bdd("A26BA3BF-D96D-4E4D-BA55-BBCC1D53D755")]
        [SousReference("Aussig", "Aussig", EnumReference.Tchequie, 638182053590000000, 1, 1)]
        Aussig_Tchequie = 809,
        [Bdd("A5381B17-ADE1-2947-9FC7-767E385226C0")]
        [SousReference("Prepych", "Prepych", EnumReference.Tchequie, 638182053590000000, 1, 1)]
        Prepych = 810,
        [Bdd("F6DFE7C3-1AEA-084D-8624-E351992AE1F0")]
        [SousReference("Ústí nad Labem", "Ústí nad Labem", EnumReference.Tchequie, 638182053590000000, 1, 1)]
        ustinadLabem = 811,
        [Bdd("B67018E7-012E-5E4B-8705-8106A14506E6")]
        [SousReference("Odessa", "Odessa", EnumReference.Ukraine, 638182053590000000, 1, 1)]
        Odessa = 812,

    }
}
