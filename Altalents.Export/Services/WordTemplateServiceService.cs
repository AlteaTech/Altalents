
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Altalents.Commun.Constants;
using Altalents.Export.DSO.OpenXml;
using Altalents.Export.OpenXml;

namespace Altalents.Export.Services
{
    public class WordTemplateService
    {
        public byte[] GenerateDocument(DtMainPageExportDso dt)
        {
            string outputTempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.docx");

            try
            {
                string normalizedPath = GetNormalisedFullPathWordTemplate(FilesNamesConstantes.ExportDtMainPage_WordTemplatePage_FileNameWithExt_V2);

                File.Copy(normalizedPath, outputTempPath, true);

                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputTempPath, true))
                {
                    Body mainBody = wordDoc.MainDocumentPart.Document.Body;

                    Dictionary<string, string> data = GetDataExportDictionaryForMainPage(dt);
                    ReplacePlaceholders(mainBody, data);
                    ReplacePlaceholdersInFooters(wordDoc.MainDocumentPart, data);

                    FeedCompMetierSection(dt, mainBody);
                    FeedFormationsSection(dt, mainBody);
                    FeedCertificationSection(dt, mainBody);
                    FeedLanguageSection(dt, mainBody);
                    //FeedExperiencesSectionV1(dt, mainBody);
                    FeedExperiencesSectionV2(dt, mainBody);
                    FeedQuestionSection(dt, mainBody);

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
            Paragraph paraWithKeyTABLEAU_RECURSIF_CERTIFICATION = mainBody.Descendants<Paragraph>().FirstOrDefault(p => p.InnerText.Contains(DtTemplatesReplacementKeys.SECTION_TABLEAU_RECURSIF_CERTIFICATIONS));

            if (paraWithKeyTABLEAU_RECURSIF_CERTIFICATION != null)
            {
                OpenXmlElement parent = paraWithKeyTABLEAU_RECURSIF_CERTIFICATION.Parent;

                if (dt.Candidat_Certifications == null || dt.Candidat_Certifications.Count == 0)
                {
                    RemoveSection(paraWithKeyTABLEAU_RECURSIF_CERTIFICATION);
                }
                else
                {
                    using (WordprocessingDocument docuTemplateItemTabVertical = WordprocessingDocument.Open(GetTemplateItemTabVerticalPath(), false))
                    {
                        Body bodyTemplateItemTabVerticall = docuTemplateItemTabVertical.MainDocumentPart.Document.Body;
                        Table tableauFromTemplate = bodyTemplateItemTabVerticall.Descendants<Table>().FirstOrDefault();
                        Table newTableau = (Table)tableauFromTemplate.CloneNode(true);
                        TableRow modelRow = newTableau.Elements<TableRow>().FirstOrDefault();

                        foreach (DtCertificationExportDso certifDso in dt.Candidat_Certifications)
                        {
                            TableRow newRow = GetNewRowTableauVertical(modelRow, certifDso.Annee, certifDso.LibelleComplet);
                            newTableau.Append(newRow);
                        }

                        FormatResultTableuVertical(paraWithKeyTABLEAU_RECURSIF_CERTIFICATION, parent, newTableau);
                    }
                }
            }
        }

        private static void FeedFormationsSection(DtMainPageExportDso dt, Body mainBody)
        {
            Paragraph paraWithKeyTABLEAU_RECURSIF_FORMATION = mainBody.Descendants<Paragraph>().FirstOrDefault(p => p.InnerText.Contains(DtTemplatesReplacementKeys.SECTION_TABLEAU_RECURSIF_FORMATIONS));

            if (paraWithKeyTABLEAU_RECURSIF_FORMATION != null)
            {
                OpenXmlElement parent = paraWithKeyTABLEAU_RECURSIF_FORMATION.Parent;

                if (dt.Candidat_Formations == null || dt.Candidat_Formations.Count == 0)
                {
                    RemoveSection(paraWithKeyTABLEAU_RECURSIF_FORMATION);
                }
                else
                {
                    using (WordprocessingDocument docuTemplateItemTabVertical = WordprocessingDocument.Open(GetTemplateItemTabVerticalPath(), false))
                    {
                        Body bodyTemplateItemTabVerticall = docuTemplateItemTabVertical.MainDocumentPart.Document.Body;
                        Table tableauFromTemplate = bodyTemplateItemTabVerticall.Descendants<Table>().FirstOrDefault();
                        Table newTableau = (Table)tableauFromTemplate.CloneNode(true);
                        TableRow modelRow = newTableau.Elements<TableRow>().FirstOrDefault();

                        foreach (DtFormationExportDso formationDso in dt.Candidat_Formations)
                        {
                            TableRow newRow = GetNewRowTableauVertical(modelRow, formationDso.Annee, formationDso.LibelleComplet);
                            newTableau.Append(newRow);
                        }

                        FormatResultTableuVertical(paraWithKeyTABLEAU_RECURSIF_FORMATION, parent, newTableau);
                    }
                }
            }
        }

        private static void FeedQuestionSection(DtMainPageExportDso dt, Body mainBody)
        {
            Paragraph paraWithKeyTABLEAU_QUESTION_PERSONNALISEE = mainBody.Descendants<Paragraph>().FirstOrDefault(p => p.InnerText.Contains(DtTemplatesReplacementKeys.SECTION_TABLEAU_QUESTIONS_PERSONNALISEES));

            if (paraWithKeyTABLEAU_QUESTION_PERSONNALISEE != null)
            {
                OpenXmlElement parent = paraWithKeyTABLEAU_QUESTION_PERSONNALISEE.Parent;

                if (dt.Candidat_Questions == null || dt.Candidat_Questions.Count == 0)
                {
                    RemoveSection(paraWithKeyTABLEAU_QUESTION_PERSONNALISEE);
                }
                else
                {
                    using (WordprocessingDocument docuTemplateItemQuestion = WordprocessingDocument.Open(GetTemplateItemQuestionPersonaliseePath(), false))
                    {
                        Body bodyTemplateItemQuestion = docuTemplateItemQuestion.MainDocumentPart.Document.Body;
                        Table tableauFromTemplate = bodyTemplateItemQuestion.Descendants<Table>().FirstOrDefault();
                        Table newTableau = (Table)tableauFromTemplate.CloneNode(true);
                        TableRow modelRow = newTableau.Elements<TableRow>().FirstOrDefault();

                        foreach (DtQuestionDso questionDso in dt.Candidat_Questions)
                        {
                            TableRow newRow = GetNewRowQuestionPersonnalisee(modelRow, questionDso.Question, questionDso.Reponse);
                            newTableau.Append(newRow);
                        }

                        FormatResultQuestionPersonalisee(paraWithKeyTABLEAU_QUESTION_PERSONNALISEE, parent, newTableau);
                    }
                }
            }
        }

        private static void FeedCompMetierSection(DtMainPageExportDso dt, Body mainBody)
        {
            Paragraph paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS = mainBody.Descendants<Paragraph>().FirstOrDefault(p => p.InnerText.Contains(DtTemplatesReplacementKeys.SECTION_TABLEAU_RECURSIF_COMPETENCES_METIER));

            if (paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS != null)
            {
                OpenXmlElement parent = paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS.Parent;

                if (dt.Candidat_CompetencesMetiers == null || dt.Candidat_CompetencesMetiers.Count == 0)
                {
                    RemoveSection(paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS);
                }
                else
                {
                    using (WordprocessingDocument docuTemplateItemTabHorizontal = WordprocessingDocument.Open(GetTemplateItemTabHorizontalPath(), false))
                    {
                        Body bodyTemplateItemTabHorizontal = docuTemplateItemTabHorizontal.MainDocumentPart.Document.Body;
                        Table tableauFromTemplate = bodyTemplateItemTabHorizontal.Descendants<Table>().FirstOrDefault();

                        Table newTableau = (Table)tableauFromTemplate.CloneNode(true);

                        TableRow modelRowLibelle = tableauFromTemplate.Elements<TableRow>().FirstOrDefault();
                        TableRow modelRowValeur = tableauFromTemplate.Elements<TableRow>().Skip(1).FirstOrDefault();

                        TableRow newRowLibelle = (TableRow)modelRowLibelle.CloneNode(false);
                        TableRow newRowValeur = (TableRow)modelRowValeur.CloneNode(false);

                        foreach (DtCompetenceMetierExportDso compMetierDso in dt.Candidat_CompetencesMetiers)
                        {
                            TableCell newCellValeur = GetNewRowTableauHorizontal(modelRowLibelle, modelRowValeur, newRowLibelle, compMetierDso.Nom, compMetierDso.DureeExperience);
                            newRowValeur.Append(newCellValeur);
                        }

                        newTableau.Append(newRowLibelle);
                        newTableau.Append(newRowValeur);

                        FormatResultTableaHorizontal(paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS, parent, newTableau);
                    }
                }
            }
        }

        private void FeedExperiencesSectionV1(DtMainPageExportDso dt, Body mainBody)
        {
            Paragraph paraWithKeyEXPERIENCES_RECURSIF = mainBody.Descendants<Paragraph>().FirstOrDefault(p => p.InnerText.Contains(DtTemplatesReplacementKeys.SECTION_EXPERIENCES_PRO_RECURSIF));

            if (paraWithKeyEXPERIENCES_RECURSIF != null)
            {
                OpenXmlElement parent = paraWithKeyEXPERIENCES_RECURSIF.Parent;

                if (dt.Candidat_ExperiencesProV1 == null || dt.Candidat_ExperiencesProV1.Count == 0)
                {
                    RemoveSection(paraWithKeyEXPERIENCES_RECURSIF);
                    return;
                }

                string templatePath = GetTemplateExperiencelPath();
                using (WordprocessingDocument docuTemplateExperience = WordprocessingDocument.Open(templatePath, false))
                {
                    Body bodyTemplateItemExperience = docuTemplateExperience.MainDocumentPart.Document.Body;
                    Table tableauFromTemplate = bodyTemplateItemExperience.Descendants<Table>().FirstOrDefault();

                    foreach (DtExperienceProExportDso expDso in dt.Candidat_ExperiencesProV1)
                    {
                        Table newTableau = (Table)tableauFromTemplate.CloneNode(true);
                        Dictionary<string, string> data = GetDataExportDictionaryForOneExperienceV1(expDso);

                        ReplacePlaceholders(newTableau, data);
                        parent.InsertAfter(newTableau, paraWithKeyEXPERIENCES_RECURSIF);

                        Paragraph emptyParagraph = new Paragraph(new Run(new Break()));
                        parent.InsertAfter(emptyParagraph, newTableau);
                    }
                }
                paraWithKeyEXPERIENCES_RECURSIF.Remove();
            }
        }

        private void FeedExperiencesSectionV2(DtMainPageExportDso dt, Body mainBody)
        {
            Paragraph paraWithKeyEXPERIENCES_RECURSIF = mainBody.Descendants<Paragraph>().FirstOrDefault(p => p.InnerText.Contains(DtTemplatesReplacementKeys.SECTION_EXPERIENCES_PRO_RECURSIF));

            if (paraWithKeyEXPERIENCES_RECURSIF != null)
            {
                OpenXmlElement parent = paraWithKeyEXPERIENCES_RECURSIF.Parent;

                if (dt.Candidat_ExperiencesProV2 == null || dt.Candidat_ExperiencesProV2.Count == 0)
                {
                    RemoveSection(paraWithKeyEXPERIENCES_RECURSIF);
                    return;
                }

                string templatePath = GetTemplateExperiencelPath();
                using (WordprocessingDocument docuTemplateExperience = WordprocessingDocument.Open(templatePath, false))
                {
                    Body bodyTemplateItemExperience = docuTemplateExperience.MainDocumentPart.Document.Body;
                    Table tableauFromTemplate = bodyTemplateItemExperience.Descendants<Table>().FirstOrDefault();


                    int index = 0;
                    foreach (DtExperienceProExportDsoV2 expDso in dt.Candidat_ExperiencesProV2)
                    {
                        index = index + 1;
                        Table newTableau = (Table)tableauFromTemplate.CloneNode(true);
                        Dictionary<string, string> data = GetDataExportDictionaryForOneExperienceV2(expDso);

                        ReplacePlaceholders(newTableau, data);
                        parent.InsertAfter(newTableau, paraWithKeyEXPERIENCES_RECURSIF);

                        if (dt.Candidat_ExperiencesProV2.Count != index)
                        {
                            Paragraph emptyParagraph = new Paragraph(new Run(new Break()));
                            parent.InsertAfter(emptyParagraph, newTableau);
                        }

                        
                    }
                }
                paraWithKeyEXPERIENCES_RECURSIF.Remove();
            }
        }

        private static void FeedLanguageSection(DtMainPageExportDso dt, Body mainBody)
        {
            Paragraph paraWithKeyTABLEAU_RECURSIF_LANGUES = mainBody.Descendants<Paragraph>().FirstOrDefault(p => p.InnerText.Contains(DtTemplatesReplacementKeys.SECTION_TABLEAU_RECURSIF_LANGUES));

            if (paraWithKeyTABLEAU_RECURSIF_LANGUES != null)
            {
                OpenXmlElement parent = paraWithKeyTABLEAU_RECURSIF_LANGUES.Parent;

                if (dt.Candidat_Langues == null || dt.Candidat_Langues.Count == 0)
                {
                    RemoveSection(paraWithKeyTABLEAU_RECURSIF_LANGUES);
                }
                else
                {
                    using (WordprocessingDocument docuTemplateItemTabHorizontal = WordprocessingDocument.Open(GetTemplateItemTabHorizontalPath(), false))
                    {
                        Body bodyTemplateItemTabHorizontal = docuTemplateItemTabHorizontal.MainDocumentPart.Document.Body;
                        Table tableauFromTemplate = bodyTemplateItemTabHorizontal.Descendants<Table>().FirstOrDefault();

                        Table newTableau = (Table)tableauFromTemplate.CloneNode(true);

                        TableRow modelRowLibelle = tableauFromTemplate.Elements<TableRow>().FirstOrDefault();
                        TableRow modelRowValeur = tableauFromTemplate.Elements<TableRow>().Skip(1).FirstOrDefault();

                        TableRow newRowLibelle = (TableRow)modelRowLibelle.CloneNode(false); 
                        TableRow newRowValeur = (TableRow)modelRowValeur.CloneNode(false);

                        foreach (DtLangueExportDso LangueDso in dt.Candidat_Langues)
                        {
                            TableCell newCellValeur = GetNewRowTableauHorizontal(modelRowLibelle, modelRowValeur, newRowLibelle, LangueDso.Libelle, LangueDso.Niveau);
                            newRowValeur.Append(newCellValeur);
                        }

                        newTableau.Append(newRowLibelle);
                        newTableau.Append(newRowValeur);

                        FormatResultTableaHorizontal(paraWithKeyTABLEAU_RECURSIF_LANGUES, parent, newTableau);
                    }
                }
            }
        }

        private static void RemoveSection(Paragraph paraWithKeyTABLEAU_RECURSIF_CERTIFICATION)
        {
            OpenXmlElement previousElement = paraWithKeyTABLEAU_RECURSIF_CERTIFICATION.PreviousSibling();
            List<OpenXmlElement> elementsToRemove = new List<OpenXmlElement>();

            // Collecter tous les éléments avant le tableau et entre le tableau et le paragraphe
            while (previousElement != null && !(previousElement is Table))
            {
                elementsToRemove.Add(previousElement);
                previousElement = previousElement.PreviousSibling();
            }

            // Si un tableau est trouvé, le supprimer
            if (previousElement is Table tableauToRemove)
            {
                elementsToRemove.Add(tableauToRemove);
            }

            // Supprimer tous les éléments collectés
            foreach (OpenXmlElement element in elementsToRemove)
            {
                element.Remove();
            }

            // Supprimer le paragraphe après avoir supprimé tout ce qui est entre
            paraWithKeyTABLEAU_RECURSIF_CERTIFICATION.Remove();
        }


        private static void FormatResultTableaHorizontal(Paragraph paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS, OpenXmlElement parent, Table newTableau)
        {
            // Insérer le nouveau tableau juste avant le paragraphe à remplacer
            parent.InsertAfter(newTableau, paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS);

            // Supprimer les lignes du modèle
            var rowsToRemove = newTableau.Elements<TableRow>().Take(2).ToList();
            foreach (TableRow row in rowsToRemove)
            {
                row.Remove();
            }

            // Supprimer l'ancien paragraphe après avoir inséré le tableau
            paraWithKeyTABLEAU_RECURSIF_COMPETENCES_METIERS.Remove();
        }

        private static void FormatResultTableuVertical(Paragraph paraWithKeyTABLEAU_RECURSIF, OpenXmlElement parent, Table newTableau)
        {

            // Insérer le nouveau tableau juste avant le paragraphe à remplacer
            parent.InsertAfter(newTableau, paraWithKeyTABLEAU_RECURSIF);

            List<TableRow> rowsToRemove = newTableau.Elements<TableRow>().Take(1).ToList();
            foreach (TableRow row in rowsToRemove)
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

        private static void FormatResultQuestionPersonalisee(Paragraph paraWithKeyQUESTION_PERSONNALISEE, OpenXmlElement parent, Table newTableau)
        {

            // Insérer le nouveau tableau juste avant le paragraphe à remplacer
            parent.InsertAfter(newTableau, paraWithKeyQUESTION_PERSONNALISEE);

            List<TableRow> rowsToRemove = newTableau.Elements<TableRow>().Take(1).ToList();
            foreach (TableRow row in rowsToRemove)
            {
                row.Remove();
            }

            // Supprimer l'ancien paragraphe après avoir inséré le tableau
            paraWithKeyQUESTION_PERSONNALISEE.Remove();
        }

        private static TableRow GetNewRowQuestionPersonnalisee(TableRow modelRow, string libelle, string value)
        {
            // Cloner la ligne modèle pour créer une nouvelle ligne
            TableRow newRow = (TableRow)modelRow.CloneNode(true);

            if (newRow != null)
            {
                foreach (Text text in newRow.Descendants<Text>())
                {
                    if (text.Text.Contains(DtTemplatesReplacementKeys.QUESTION_PERSONNALISEE_ITEM_QUESTION))
                    {
                        text.Text = text.Text.Replace(DtTemplatesReplacementKeys.QUESTION_PERSONNALISEE_ITEM_QUESTION, libelle);
                    }
                    if (text.Text.Contains(DtTemplatesReplacementKeys.QUESTION_PERSONNALISEE_ITEM_RESPONSE))
                    {
                        text.Text = text.Text.Replace(DtTemplatesReplacementKeys.QUESTION_PERSONNALISEE_ITEM_RESPONSE, value);
                    }
                }
            }
            return newRow;
        }






        private static TableCell GetNewRowTableauHorizontal(TableRow modelRowLibelle, TableRow modelRowValeur, TableRow newRowLibelle, string libelle, string value)
        {

            TableCell modelCellLibelle = modelRowLibelle.Elements<TableCell>().FirstOrDefault();
            TableCell newCellLibelle = (TableCell)modelCellLibelle.CloneNode(true);

            foreach (Text text in newCellLibelle.Descendants<Text>())
            {
                if (text.Text.Contains(DtTemplatesReplacementKeys.TABLEAU_RECURSIF_ITEM_LIBELLE))
                {
                    text.Text = text.Text.Replace(DtTemplatesReplacementKeys.TABLEAU_RECURSIF_ITEM_LIBELLE, libelle);
                }
            }
            newRowLibelle.Append(newCellLibelle);

            TableCell modelCellValeur = modelRowValeur.Elements<TableCell>().FirstOrDefault();
            TableCell newCellValeur = (TableCell)modelCellValeur.CloneNode(true);

            foreach (Text text in newCellValeur.Descendants<Text>())
            {
                if (text.Text.Contains(DtTemplatesReplacementKeys.TABLEAU_RECURSIF_ITEM_VALEUR))
                {
                    text.Text = text.Text.Replace(DtTemplatesReplacementKeys.TABLEAU_RECURSIF_ITEM_VALEUR, value);
                }
            }
            return newCellValeur;
        }



        private static string GetTemplateItemTabHorizontalPath()
        {
            string templateDocName = FilesNamesConstantes.ItemTabHorizontal_WordTemplateItem_FileNameWithExt;
            return GetNormalisedFullPathWordTemplate(templateDocName);
        }

        private static string GetTemplateExperiencelPath()
        {
            string templateDocName = FilesNamesConstantes.ItemExperience_WordTemplateItem_FileNameWithExt_V2;
            return GetNormalisedFullPathWordTemplate(templateDocName);
        }

        private static string GetTemplateItemTabVerticalPath()
        {
            string templateDocName = FilesNamesConstantes.ItemTabVertical_WordTemplateItem_FileNameWithExt;
            return GetNormalisedFullPathWordTemplate(templateDocName);
        }

        private static string GetTemplateItemQuestionPersonaliseePath()
        {
            string templateDocName = FilesNamesConstantes.ItemQuestion_WordTemplateItem_FileNameWithExt;
            return GetNormalisedFullPathWordTemplate(templateDocName);
        }

        private static string GetNormalisedFullPathWordTemplate(string fileName)
        {
            string FileRelativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "Templates", "Word", fileName);
            string FileNormalizedPath = Path.GetFullPath(FileRelativePath);
            return FileNormalizedPath;
        }

        private static Dictionary<string, string> GetDataExportDictionaryForOneExperienceV1(DtExperienceProExportDso exp)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            string ESN = "";
            if (exp.IsEsn)
            {
                ESN = " (ESN)";
            }

            data.Add(DtTemplatesReplacementKeys.EXP_ENTREPRISE, exp.NomEntreprise + ESN);
            data.Add(DtTemplatesReplacementKeys.EXP_POSTE, exp.IntitulePoste);
            data.Add(DtTemplatesReplacementKeys.EXP_CONTEXT, exp.Context);
            data.Add(DtTemplatesReplacementKeys.EXP_DATES, exp.DateDebutEtDateFin);
            data.Add(DtTemplatesReplacementKeys.EXP_EQUIPE, exp.Equipe);
            data.Add(DtTemplatesReplacementKeys.EXP_ENV_TECH, exp.EnvironnementsTechnique);

            string textToAddInTachesPLaceholder = "Projet(s)";
            if (exp.IsEsn)
            {
                textToAddInTachesPLaceholder = "Mission(s)";
            }

            string textToAddInProjectsPlaceholder = "";
            string textToAddInTachesPlaceholder = "";

            foreach (DtExpProMission missionOrProject in exp.MissionsOrProjects)
            {
                string projet = "";

                if (exp.IsEsn)
                {
                    projet += "<b>" + missionOrProject.NomClient  ;

                    if (!string.IsNullOrEmpty(missionOrProject.DomaineMetier) || !string.IsNullOrEmpty(missionOrProject.Lieu) || !string.IsNullOrEmpty(missionOrProject.DateDebutDateFin))
                    {
                        if (!string.IsNullOrWhiteSpace(missionOrProject.DomaineMetier))
                            projet += " [" + missionOrProject.DomaineMetier + "] ";

                        if (!string.IsNullOrWhiteSpace(missionOrProject.Lieu))
                            projet += "| " + missionOrProject.Lieu + " ";

                        if (!string.IsNullOrWhiteSpace(missionOrProject.DateDebutDateFin))
                            projet += "| " + missionOrProject.DateDebutDateFin + " ";
                    }

                    projet += "</b>";

                    if (!string.IsNullOrEmpty(missionOrProject.DomaineMetier) || !string.IsNullOrEmpty(missionOrProject.Lieu) || !string.IsNullOrEmpty(missionOrProject.DateDebutDateFin))
                    {
                        projet += "\n\n";
                    }
                }

                projet += missionOrProject.DescriptionProjet += "\n\n";

                if (!string.IsNullOrWhiteSpace(missionOrProject.Budget))
                {
                    projet += "Budget : " + missionOrProject.Budget;

                    if (!string.IsNullOrWhiteSpace(missionOrProject.CompoEquipe))
                    {
                        projet +=  " | ";
                    } 
                }

                if (!string.IsNullOrWhiteSpace(missionOrProject.CompoEquipe))
                    projet += "Equipe : " + missionOrProject.CompoEquipe;

                textToAddInProjectsPlaceholder += projet+ "\n\n\n";
                textToAddInTachesPlaceholder += missionOrProject.Taches+ "\n\n\n";
            }

            //on retire les 3 retour a la ligne si c'est le dernier element
            textToAddInProjectsPlaceholder = textToAddInProjectsPlaceholder.Remove(textToAddInProjectsPlaceholder.Count() - 3, 3);
            textToAddInTachesPlaceholder = textToAddInTachesPlaceholder.Remove(textToAddInTachesPlaceholder.Count() - 3, 3);

            data.Add(DtTemplatesReplacementKeys.EXP_TACHES, textToAddInTachesPlaceholder);
            data.Add(DtTemplatesReplacementKeys.EXP_PROJ_OR_MISSION_LIBELLE, textToAddInTachesPLaceholder);
            data.Add(DtTemplatesReplacementKeys.EXP_PROJ_OR_MISSION_VALUES, textToAddInProjectsPlaceholder);

            return data;
        }


        private static Dictionary<string, string> GetDataExportDictionaryForOneExperienceV2(DtExperienceProExportDsoV2 exp)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            string ESN = "";
            if (exp.IsEsn)
            {
                ESN = " (ESN ou Intérim)";
            }

            data.Add(DtTemplatesReplacementKeys.EXP_ENTREPRISE, exp.NomEntreprise + ESN);
            data.Add(DtTemplatesReplacementKeys.EXP_POSTE, exp.IntitulePoste);
            data.Add(DtTemplatesReplacementKeys.EXP_DATES, exp.DateDebutEtDateFin);

            string textToAddInProjectsPlaceholder = "";

            int numProj = 0;

            foreach (DtExpProProjetOrMissionV2 missionOrProject in exp.MissionsOrProjects)
            {

                string projet = "\n";
                numProj = numProj + 1;

                projet += "<b>";
                if (exp.IsEsn)
                {
                    projet += $"MISSION {numProj} : ";
                    projet += missionOrProject.NomClient;
                    if (!string.IsNullOrWhiteSpace(missionOrProject.DomaineMetierClient))
                        projet += " [" + missionOrProject.DomaineMetierClient + "] ";
                        projet += "| " + missionOrProject.Lieu + " ";
                }
                else
                {
                    projet += $"PROJET {numProj} : ";
                }

                if (!string.IsNullOrWhiteSpace(missionOrProject.DateDebutDateFin))
                    projet += "| " + missionOrProject.DateDebutDateFin + " ";

                projet += "</b>";
                projet += "\n\n";

                projet += "<b>Contexte</b> : " + missionOrProject.Context + "\n\n";

                projet += "<b>Tâches</b> : " + missionOrProject.Taches + "\n\n";

                if (!string.IsNullOrWhiteSpace(missionOrProject.CompoEquipe))
                    projet += "<b>Equipe</b> : " + missionOrProject.CompoEquipe + "\n\n";

                if (!string.IsNullOrWhiteSpace(missionOrProject.Competences))
                    projet += "<b>Compétence(s)</b> : " + missionOrProject.Competences + "\n\n";

                if (!string.IsNullOrWhiteSpace(missionOrProject.Methodologies))
                    projet += "<b>Méthodologie(s)</b> : " + missionOrProject.CompoEquipe + "\n\n";

                if (!string.IsNullOrWhiteSpace(missionOrProject.EnvironnementsTechnique))
                    projet += "<b>Environnement(s) Technique</b> : " + missionOrProject.EnvironnementsTechnique + "\n";

                textToAddInProjectsPlaceholder += projet + "\n";
            }

            //on retire les 1 retour a la ligne si c'est le dernier element
            textToAddInProjectsPlaceholder = textToAddInProjectsPlaceholder.Remove(textToAddInProjectsPlaceholder.Count() - 1, 1);

            data.Add(DtTemplatesReplacementKeys.EXP_PROJ_OR_MISSION_VALUES, textToAddInProjectsPlaceholder);

            return data;
        }

        private static Dictionary<string, string> GetDataExportDictionaryForMainPage(DtMainPageExportDso dt)
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
            data.Add(DtTemplatesReplacementKeys.COMPETENCES_OUTILS, dt.Candidat_Outils);
            data.Add(DtTemplatesReplacementKeys.COMPETENCES_IDE, dt.Candidat_IDE);
            data.Add(DtTemplatesReplacementKeys.COMPETENCES_FRAMEWORK, dt.Candidat_Framework);
            data.Add(DtTemplatesReplacementKeys.COMPETENCES_VIRTUALISATION, dt.Candidat_Virtualisation);
            data.Add(DtTemplatesReplacementKeys.COMPETENCES_VERSIONNING, dt.Candidat_Versionning);

            return data;
        }

        private void ReplacePlaceholders(OpenXmlElement elem, Dictionary<string, string> placeholders)
        {
            foreach (OpenXmlElement paragraph in elem.Descendants<OpenXmlElement>())
            {
                foreach (Run run in paragraph.Descendants<Run>())
                {
                    foreach (var placeholder in placeholders)
                    {
                        if (run.InnerText.Contains(placeholder.Key))
                        {
                            // Récupérer et vérifier la valeur du placeholder
                            string replacement = placeholder.Value ?? string.Empty;

                            // Diviser en lignes à partir de "\n"
                            string[] lines = replacement.Split(new[] { '\n' }, StringSplitOptions.None);

                            // Récupérer le parent pour insérer de nouveaux éléments
                            OpenXmlElement parent = run.Parent;

                            // Déterminer si le placeholder correspond aux tâches
                            bool isTaskPlaceholder = placeholder.Key == DtTemplatesReplacementKeys.EXP_TACHES;

                            for (int i = 0; i < lines.Length; i++)
                            {
                                string line = lines[i];

                                if (isTaskPlaceholder)
                                {
                                    // Ignorer les lignes vides
                                    if (string.IsNullOrWhiteSpace(line.Trim()))
                                        continue;

                                    // Cloner le Run d'origine pour conserver le style
                                    Run clonedRun = (Run)run.CloneNode(true);

                                    // Modifier uniquement le texte du clone
                                    Text textElement = clonedRun.GetFirstChild<Text>();
                                    if (textElement != null)
                                    {
                                        textElement.Text = "• "+line;
                                    }

                                    // Ajouter le Run cloné après la puce
                                    parent.InsertBefore(clonedRun, run);
                                }
                                else
                                {
                                    // Vérifier s'il y a du texte en gras entouré par <b></b>
                                    int startIndex = 0;
                                    while ((startIndex = line.IndexOf("<b>", startIndex)) != -1)
                                    {
                                        int endIndex = line.IndexOf("</b>", startIndex);
                                        if (endIndex == -1)
                                            break; // Si on ne trouve pas la fin de la balise, sortir

                                        // Extraire le texte à mettre en gras sans perdre les espaces
                                        string boldText = line.Substring(startIndex + 3, endIndex - (startIndex + 3));

                                        // Cloner le Run d'origine pour conserver le style
                                        Run clonedRun = (Run)run.CloneNode(true);

                                        // Ajouter la balise en gras à ce texte
                                        Text textElement = clonedRun.GetFirstChild<Text>();
                                        if (textElement != null)
                                        {
                                            textElement.Text = boldText;
                                        }

                                        // Ajouter la propriété Bold
                                        RunProperties runProperties = clonedRun.GetFirstChild<RunProperties>();
                                        if (runProperties == null)
                                        {
                                            runProperties = new RunProperties();
                                            clonedRun.PrependChild(runProperties);
                                        }

                                        Bold bold = new Bold();
                                        runProperties.AppendChild(bold);

                                        // Insérer le texte en gras dans le document
                                        parent.InsertBefore(clonedRun, run);

                                        // Supprimer la balise <b> et </b> du texte original
                                        line = line.Remove(startIndex, endIndex - startIndex + 4);

                                        startIndex = 0; // Rechercher à nouveau si une autre balise <b> existe
                                    }

                                    // Ajouter le reste du texte qui n'était pas en gras
                                    if (!string.IsNullOrWhiteSpace(line))
                                    {
                                        Run clonedRun = (Run)run.CloneNode(true);
                                        Text textElement = clonedRun.GetFirstChild<Text>();
                                        if (textElement != null)
                                        {
                                            textElement.Text = line;
                                        }

                                        parent.InsertBefore(clonedRun, run);
                                    }
                                }

                                // Ajouter un saut de ligne après chaque ligne, sauf la dernière
                                if (i < lines.Length - 1)
                                {
                                    parent.InsertBefore(new Run(new Break()), run);
                                }
                            }
                            
                            run.Remove();
                        }
                    }
                }
            }
        }




        private void ReplacePlaceholdersInFooters(MainDocumentPart mainDocumentPart, Dictionary<string, string> placeholders)
        {
            // Parcourir tous les pieds de page du document
            foreach (FooterPart footerPart in mainDocumentPart.FooterParts)
            {
                Footer footer = footerPart.Footer;

                // Parcourir tous les descendants du pied de page
                foreach (OpenXmlElement element in footer.Descendants<OpenXmlElement>())
                {
                    // Vérifier et remplacer les placeholders dans les textes
                    foreach (var placeholder in placeholders)
                    {
                        if (element.InnerText.Contains(placeholder.Key))
                        {
                            Text textElement = element.GetFirstChild<Text>();
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
