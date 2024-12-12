
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text.RegularExpressions;
using Altalents.Report.Library.DSO.OpenXml;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Altalents.Report.Library.Services
{
    public class WordTemplateService
    {
        public byte[] GenerateDocument(DtMainPageExportDso dt)
        {

            string outputTempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.docx");

            try
            {

                string mainTemplateName = "Template_DT_Altea_2024_FirstPage.docx";
                string templateRelativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Templates", mainTemplateName);
                string normalizedPath = Path.GetFullPath(templateRelativePath);

                File.Copy(normalizedPath, outputTempPath, true);

                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputTempPath, true))
                {
                    var mainBody = wordDoc.MainDocumentPart.Document.Body;

                    FeedCompMetierSection(dt, mainBody);
                    FeedFormationsSection(dt, mainBody);
                    FeedCertificationSection(dt, mainBody);
                    FeedLanguageSection(dt, mainBody);

                    //remplacement des clés par des valeur du model dt Dans tout le document
                    Dictionary<string, string> data = GetDataExportDictionary(dt);
                    ReplacePlaceholdersInBody(mainBody, data);
                    ReplacePlaceholdersInFooters(wordDoc.MainDocumentPart, data);

                    wordDoc.MainDocumentPart.Document.Save();
                }

                return File.ReadAllBytes(outputTempPath);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Une erreur s'est produite lors de la génération du document.", ex);
            }
            finally
            {
                if (File.Exists(outputTempPath))
                {
                    try
                    {
                        File.Delete(outputTempPath);
                    }
                    catch
                    {

                    }
                }
            }
        }



        private static void FeedCertificationSection(DtMainPageExportDso dt, Body mainBody)
        {
            var paraWithKeyTABLEAU_RECURSIF_CERTIFICATION = mainBody.Descendants<Paragraph>().FirstOrDefault(p => p.InnerText.Contains(DtTemplatesReplacementKeys.SECTION_TABLEAU_RECURSIF_CERTIFICATIONS));

            if (paraWithKeyTABLEAU_RECURSIF_CERTIFICATION != null)
            {
                // Localiser le parent du paragraphe
                OpenXmlElement parent = paraWithKeyTABLEAU_RECURSIF_CERTIFICATION.Parent;

                using (WordprocessingDocument docuTemplateItemTabVertical = WordprocessingDocument.Open(GetTemplateItemTabVerticalPath(), false))
                {
                    Body bodyTemplateItemTabVerticall = docuTemplateItemTabVertical.MainDocumentPart.Document.Body;
                    Table tableauFromTemplate = bodyTemplateItemTabVerticall.Descendants<Table>().FirstOrDefault();

                    Table newTableau = (Table)tableauFromTemplate.CloneNode(true);

                    // Supprimer les lignes du modèle


                    TableRow modelRow = newTableau.Elements<TableRow>().FirstOrDefault();
                    foreach (DtCertificationExportDso certifDso in dt.Candidat_Certifications)
                    {
                        TableRow newRow = GetNewRowTableauVertical(modelRow, certifDso.Annee, certifDso.LibelleComplet);

                        // Ajouter la nouvelle ligne au tableau
                        newTableau.Append(newRow);
                    }

                    FormatResultTableuVertical(paraWithKeyTABLEAU_RECURSIF_CERTIFICATION, parent, newTableau);

                }
            }
        }


        private static void FeedFormationsSection(DtMainPageExportDso dt, Body mainBody)
        {
            var paraWithKeyTABLEAU_RECURSIF_FORMATION = mainBody.Descendants<Paragraph>().FirstOrDefault(p => p.InnerText.Contains(DtTemplatesReplacementKeys.SECTION_TABLEAU_RECURSIF_FORMATIONS));

            if (paraWithKeyTABLEAU_RECURSIF_FORMATION != null)
            {
                // Localiser le parent du paragraphe
                OpenXmlElement parent = paraWithKeyTABLEAU_RECURSIF_FORMATION.Parent;

                using (WordprocessingDocument docuTemplateItemTabVertical= WordprocessingDocument.Open(GetTemplateItemTabVerticalPath(), false))
                {
                    Body bodyTemplateItemTabVerticall = docuTemplateItemTabVertical.MainDocumentPart.Document.Body;
                    Table tableauFromTemplate = bodyTemplateItemTabVerticall.Descendants<Table>().FirstOrDefault();

                    Table newTableau = (Table)tableauFromTemplate.CloneNode(true);

                    // Supprimer les lignes du modèle


                    TableRow modelRow = newTableau.Elements<TableRow>().FirstOrDefault();
                    foreach (DtFormationExportDso formationDso in dt.Candidat_Formations)
                    {
                        TableRow newRow = GetNewRowTableauVertical(modelRow, formationDso.Annee, formationDso.LibelleComplet);

                        // Ajouter la nouvelle ligne au tableau
                        newTableau.Append(newRow);
                    }

                    FormatResultTableuVertical(paraWithKeyTABLEAU_RECURSIF_FORMATION, parent, newTableau);

                }
            }
        }


        private static void FeedCompMetierSection(DtMainPageExportDso dt, Body mainBody)
        {
            var paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS = mainBody.Descendants<Paragraph>().FirstOrDefault(p => p.InnerText.Contains(DtTemplatesReplacementKeys.SECTION_TABLEAU_RECURSIF_COMPETENCES_METIER));

            if (paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS != null)
            {
                // Localiser le parent du paragraphe
                OpenXmlElement parent = paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS.Parent;

                using (WordprocessingDocument docuTemplateItemTabHorizontal = WordprocessingDocument.Open(GetTemplateItemTabHorizontalPath(), false))
                {
                    Body bodyTemplateItemTabHorizontal = docuTemplateItemTabHorizontal.MainDocumentPart.Document.Body;
                    Table tableauFromTemplate = bodyTemplateItemTabHorizontal.Descendants<Table>().FirstOrDefault();

                    Table newTableau = (Table)tableauFromTemplate.CloneNode(true);

                    // Récupérer les 2 lignes du tableau
                    TableRow modelRowLibelle = tableauFromTemplate.Elements<TableRow>().FirstOrDefault();
                    TableRow modelRowValeur = tableauFromTemplate.Elements<TableRow>().Skip(1).FirstOrDefault();

                    // Préparer les nouvelles lignes pour les libellés et valeurs
                    TableRow newRowLibelle = (TableRow)modelRowLibelle.CloneNode(false); // Ligne pour les libellés (sans contenu initial)
                    TableRow newRowValeur = (TableRow)modelRowValeur.CloneNode(false);  // Ligne pour les valeurs (sans contenu initial)

                    foreach (DtCompetenceMetierExportDso compMetierDso in dt.Candidat_CompetencesMetiers)
                    {
                        TableCell newCellValeur = GetNewRowTableauHorizontal(modelRowLibelle, modelRowValeur, newRowLibelle, compMetierDso.Nom, compMetierDso.DureeExperience);
                        newRowValeur.Append(newCellValeur);
                    }

                    // Ajouter les lignes complétées au tableau
                    newTableau.Append(newRowLibelle);
                    newTableau.Append(newRowValeur);

                    FormatResultTableaHorizontal(paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS, parent, newTableau);

                }
            }
        }

        private static void FeedLanguageSection(DtMainPageExportDso dt, Body mainBody)
        {
            var paraWithKeyTABLEAU_RECURSIF_LANGUES = mainBody.Descendants<Paragraph>().FirstOrDefault(p => p.InnerText.Contains(DtTemplatesReplacementKeys.SECTION_TABLEAU_RECURSIF_LANGUES));

            if (paraWithKeyTABLEAU_RECURSIF_LANGUES != null)
            {
                // Localiser le parent du paragraphe
                OpenXmlElement parent = paraWithKeyTABLEAU_RECURSIF_LANGUES.Parent;

                using (WordprocessingDocument docuTemplateItemTabHorizontal = WordprocessingDocument.Open(GetTemplateItemTabHorizontalPath(), false))
                {
                    Body bodyTemplateItemTabHorizontal = docuTemplateItemTabHorizontal.MainDocumentPart.Document.Body;
                    Table tableauFromTemplate = bodyTemplateItemTabHorizontal.Descendants<Table>().FirstOrDefault();

                    Table newTableau = (Table)tableauFromTemplate.CloneNode(true);

                    // Récupérer les 2 lignes du tableau
                    TableRow modelRowLibelle = tableauFromTemplate.Elements<TableRow>().FirstOrDefault();
                    TableRow modelRowValeur = tableauFromTemplate.Elements<TableRow>().Skip(1).FirstOrDefault();

                    // Préparer les nouvelles lignes pour les libellés et valeurs
                    TableRow newRowLibelle = (TableRow)modelRowLibelle.CloneNode(false); // Ligne pour les libellés (sans contenu initial)
                    TableRow newRowValeur = (TableRow)modelRowValeur.CloneNode(false);  // Ligne pour les valeurs (sans contenu initial)

                    foreach (DtLangueExportDso LangueDso in dt.Candidat_Langues)
                    {
                        TableCell newCellValeur = GetNewRowTableauHorizontal(modelRowLibelle, modelRowValeur, newRowLibelle, LangueDso.Libelle, LangueDso.Niveau);
                        newRowValeur.Append(newCellValeur);
                    }

                    // Ajouter les lignes complétées au tableau
                    newTableau.Append(newRowLibelle);
                    newTableau.Append(newRowValeur);

                    FormatResultTableaHorizontal(paraWithKeyTABLEAU_RECURSIF_LANGUES, parent, newTableau);

                }
            }
        }


        private static void FormatResultTableaHorizontal(Paragraph paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS, OpenXmlElement parent, Table newTableau)
        {
            // Insérer le paragraphe vide entre les tableaux
            parent.InsertBefore(GetMinimalSeparator(), paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS);

            // Insérer le nouveau tableau juste avant le paragraphe à remplacer
            parent.InsertAfter(newTableau, paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS);

            // Supprimer les lignes du modèle
            var rowsToRemove = newTableau.Elements<TableRow>().Take(2).ToList(); // Les lignes à supprimer
            foreach (var row in rowsToRemove)
            {
                row.Remove();
            }

            // Supprimer l'ancien paragraphe après avoir inséré le tableau
            paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS.Remove();
        }


        private static void FormatResultTableuVertical(Paragraph paraWithKeyTABLEAU_RECURSIF, OpenXmlElement parent, Table newTableau)
        {
            // Insérer le paragraphe vide entre les tableaux
            parent.InsertBefore(GetMinimalSeparator(), paraWithKeyTABLEAU_RECURSIF);

            // Insérer le nouveau tableau juste avant le paragraphe à remplacer
            parent.InsertAfter(newTableau, paraWithKeyTABLEAU_RECURSIF);

            var rowsToRemove = newTableau.Elements<TableRow>().Take(1).ToList(); // Les lignes à supprimer
            foreach (var row in rowsToRemove)
            {
                row.Remove();
            }

            // Supprimer l'ancien paragraphe après avoir inséré le tableau
            paraWithKeyTABLEAU_RECURSIF.Remove();
        }

        private static TableRow GetNewRowTableauVertical(TableRow modelRow, string libelle, string value)
        {
            // Cloner la ligne modèle pour créer une nouvelle ligne
            TableRow newRow = (TableRow)modelRow.CloneNode(true);

            if (newRow != null)
            {
                foreach (Text text in newRow.Descendants<Text>())
                {
                    if (text.Text.Contains(DtTemplatesReplacementKeys.TABLEAU_RECURSIF_ITEM_LIBELLE))
                    {
                        text.Text = text.Text.Replace(DtTemplatesReplacementKeys.TABLEAU_RECURSIF_ITEM_LIBELLE, libelle);
                    }
                    if (text.Text.Contains(DtTemplatesReplacementKeys.TABLEAU_RECURSIF_ITEM_VALEUR))
                    {
                        text.Text = text.Text.Replace(DtTemplatesReplacementKeys.TABLEAU_RECURSIF_ITEM_VALEUR, value);
                    }
                }
            }

            return newRow;
        }

        private static TableCell GetNewRowTableauHorizontal(TableRow modelRowLibelle, TableRow modelRowValeur, TableRow newRowLibelle, string libelle, string value)
        {
            // Cloner une cellule pour le libellé et conserver son style
            var modelCellLibelle = modelRowLibelle.Elements<TableCell>().FirstOrDefault();
            var newCellLibelle = (TableCell)modelCellLibelle.CloneNode(true);
            foreach (var text in newCellLibelle.Descendants<Text>())
            {
                if (text.Text.Contains(DtTemplatesReplacementKeys.TABLEAU_RECURSIF_ITEM_LIBELLE))
                {
                    text.Text = text.Text.Replace(DtTemplatesReplacementKeys.TABLEAU_RECURSIF_ITEM_LIBELLE, libelle);
                }
            }
            newRowLibelle.Append(newCellLibelle);

            // Cloner une cellule pour la valeur et conserver son style
            var modelCellValeur = modelRowValeur.Elements<TableCell>().FirstOrDefault();
            var newCellValeur = (TableCell)modelCellValeur.CloneNode(true);
            foreach (var text in newCellValeur.Descendants<Text>())
            {
                if (text.Text.Contains(DtTemplatesReplacementKeys.TABLEAU_RECURSIF_ITEM_VALEUR))
                {
                    text.Text = text.Text.Replace(DtTemplatesReplacementKeys.TABLEAU_RECURSIF_ITEM_VALEUR, value);
                }
            }

            return newCellValeur;
        }

        private static Paragraph GetMinimalSeparator()
        {
            // Ajouter un petit paragraphe vide pour séparer les tableaux
            var separationPara = new Paragraph(new Run(new Text("")));
            separationPara.ParagraphProperties = new ParagraphProperties(
                new SpacingBetweenLines { After = "0" } // Suppression de l'espacement
            );
            return separationPara;
        }

        private static string GetTemplateItemTabHorizontalPath()
        {
            string ItemTabHorizontal = "Template_DT_Altea_2024_ItemTabHorizontal.docx";
            string ItemTabHorizontalRelativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Templates", ItemTabHorizontal);
            string ItemTabHorizontalNormalizedPath = Path.GetFullPath(ItemTabHorizontalRelativePath);
            return ItemTabHorizontalNormalizedPath;
        }

        private static string GetTemplateItemTabVerticalPath()
        {
            string ItemTabHorizontal = "Template_DT_Altea_2024_ItemTabVertical.docx";
            string ItemTabHorizontalRelativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Templates", ItemTabHorizontal);
            string ItemTabHorizontalNormalizedPath = Path.GetFullPath(ItemTabHorizontalRelativePath);
            return ItemTabHorizontalNormalizedPath;
        }

        private static Dictionary<string, string> GetDataExportDictionary(DtMainPageExportDso dt)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data.Add(DtTemplatesReplacementKeys.HEADER_CANDIDAT_TRI, dt.Candidat_Trigramme);
            data.Add(DtTemplatesReplacementKeys.HEADER_CANDIDAT_POSTE, dt.Dt_Poste);

            data.Add(DtTemplatesReplacementKeys.HEADER_COMMERCIAL_EMAIL, dt.Commercial_Email);
            data.Add(DtTemplatesReplacementKeys.HEADER_COMMERCIAL_PHONE, dt.Commercial_Phone);
            data.Add(DtTemplatesReplacementKeys.HEADER_COMMERCIAL_NOM_COMPLET, dt.Commercial_NomComplet);
            data.Add(DtTemplatesReplacementKeys.HEADER_COMMERCIAL_WEBSITE, dt.Commercial_SiteWeb);

            data.Add(DtTemplatesReplacementKeys.FOCUS_NB_YEAR_EXP, dt.Candidat_NbAnneesExperiences);
            data.Add(DtTemplatesReplacementKeys.FOCUS_KEY_COMPETENCES, dt.Candidat_CompetencesClefs);
            data.Add(DtTemplatesReplacementKeys.FOCUS_KEY_SYNTHESE, dt.Candidat_Synthese);

            data.Add(DtTemplatesReplacementKeys.COMPETENCES_SOFT_SKILLS, dt.Candidat_SoftSkill);
            data.Add(DtTemplatesReplacementKeys.COMPETENCES_DOMAINES, dt.Candidat_Domaines);
            data.Add(DtTemplatesReplacementKeys.COMPETENCES_LANGUAGES_PROG, dt.Candidat_Languages_Prog);
            data.Add(DtTemplatesReplacementKeys.COMPETENCES_BDD, dt.Candidat_Bdd);
            data.Add(DtTemplatesReplacementKeys.COMPETENCES_METHODOLOGIE, dt.Candidat_Methodologie);
            return data;
        }

        private void ReplacePlaceholdersInBody(OpenXmlElement elem, Dictionary<string, string> placeholders)
        {
            foreach (var paragraph in elem.Descendants<OpenXmlElement>())
            {
                foreach (var run in paragraph.Descendants<Run>())
                {
                    foreach (var placeholder in placeholders)
                    {
                        if (run.InnerText.Contains(placeholder.Key))
                        {
                            run.GetFirstChild<Text>().Text = run.InnerText.Replace(placeholder.Key, placeholder.Value);
                        }
                    }
                }
            }
        }

        private void ReplacePlaceholdersInFooters(MainDocumentPart mainDocumentPart, Dictionary<string, string> placeholders)
        {
            // Parcourir tous les pieds de page du document
            foreach (var footerPart in mainDocumentPart.FooterParts)
            {
                var footer = footerPart.Footer;

                // Parcourir tous les descendants du pied de page
                foreach (var element in footer.Descendants<OpenXmlElement>())
                {
                    // Vérifier et remplacer les placeholders dans les textes
                    foreach (var placeholder in placeholders)
                    {
                        if (element.InnerText.Contains(placeholder.Key))
                        {
                            var textElement = element.GetFirstChild<Text>();
                            if (textElement != null)
                            {
                                textElement.Text = element.InnerText.Replace(placeholder.Key, placeholder.Value);
                            }
                        }
                    }
                }

                footer.Save();
            }
        }

    }
}
