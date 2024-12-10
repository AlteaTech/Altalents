
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
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string templateRelativePath = Path.Combine(baseDirectory, @"..\..\..\Templates", mainTemplateName);
                string normalizedPath = Path.GetFullPath(templateRelativePath);

                if (!File.Exists(normalizedPath))
                {
                    throw new FileNotFoundException("Le fichier template "+ mainTemplateName + " est introuvable.", normalizedPath);
                }

                File.Copy(normalizedPath, outputTempPath, true);

                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputTempPath, true))
                {
                    string CompTechniqueTemplateName = "Template_DT_Altea_2024_CompTech.docx";
                    string templateCompetenceTechRelativePath = Path.Combine(baseDirectory, @"..\..\..\Templates", CompTechniqueTemplateName);
                    string templateCompetenceTechNormalizedPath = Path.GetFullPath(templateCompetenceTechRelativePath);

                    if (!File.Exists(templateCompetenceTechNormalizedPath))
                    {
                        throw new FileNotFoundException("Le fichier template "+ CompTechniqueTemplateName + " est introuvable.", templateCompetenceTechNormalizedPath);
                    }

                    var mainBody = wordDoc.MainDocumentPart.Document.Body;
                    using (WordprocessingDocument secondaryDoc = WordprocessingDocument.Open(templateCompetenceTechNormalizedPath, false))
                    {
                        var bodyCompTech = secondaryDoc.MainDocumentPart.Document.Body;
                        mainBody.Append(bodyCompTech.First().CloneNode(true));
                    }

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

                    ReplacePlaceholders(mainBody, data);
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

        private void ReplacePlaceholders(OpenXmlElement elem, Dictionary<string, string> placeholders)
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

                // Sauvegarder les modifications dans le pied de page
                footer.Save();
            }
        }

    }
}
