
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Altalents.Report.Library.Services
{


    public class WordTemplateService
    {


        public byte[] GenerateDocument(string templatePath, Dictionary<string, string> data)
        {
            // Valider les paramètres d'entrée
            if (string.IsNullOrEmpty(templatePath) || !File.Exists(templatePath))
                throw new FileNotFoundException("Le fichier de template est introuvable.", templatePath);

            if (data == null || data.Count == 0)
                throw new ArgumentException("Aucune donnée n'a été fournie pour remplir le document.", nameof(data));

            // Créer un chemin temporaire pour le fichier de sortie
            string outputTempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.docx");

            try
            {
                // Copier le template dans un fichier temporaire
                File.Copy(templatePath, outputTempPath, true);

                // Ouvrir et modifier le document
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(outputTempPath, true))
                {
                    // Accéder au corps du document
                    var body = wordDoc.MainDocumentPart.Document.Body;

                    // Remplacer les balises statiques
                    ReplacePlaceholders(body, data);

                    // Sauvegarder les modifications
                    wordDoc.MainDocumentPart.Document.Save();
                }

                // Lire le fichier temporaire en tant que byte array
                byte[] fileBytes = File.ReadAllBytes(outputTempPath);

                return fileBytes;
            }
            catch (Exception ex)
            {
                // Gérer les erreurs
                throw new InvalidOperationException("Une erreur s'est produite lors de la génération du document.", ex);
            }
            finally
            {
                // Supprimer le fichier temporaire
                if (File.Exists(outputTempPath))
                {
                    try
                    {
                        File.Delete(outputTempPath);
                    }
                    catch
                    {
                        // Ignorer les erreurs de suppression
                    }
                }
            }
        }

        private string reformatKeys(string input)
        {
            return Regex.Replace(input, @"{{\s*(.*?)\s*}}", match =>
            {
                // Supprime les espaces à l'intérieur des accolades
                return "{{" + match.Groups[1].Value.Replace(" ", string.Empty) + "}}";
            });
        }

        /// <summary>
        /// Remplace les balises dans le document par leurs valeurs.
        /// </summary>
        private void ReplacePlaceholders(Body body, Dictionary<string, string> placeholders)
        {
            //string fullBodyText1 = string.Join(" ", body.Descendants<Text>().Select(t => t.Text));

            foreach (var text in body.Descendants<Text>())
            {
                // Remplacer les placeholders dans le texte
                foreach (var placeholder in placeholders)
                {
                    if (text.Text.Contains(placeholder.Key))
                    {
                        text.Text = text.Text.Replace(placeholder.Key, placeholder.Value);
                    }
                }
            }
        }

        /// <summary>
        /// Insère dynamiquement des expériences professionnelles à un emplacement spécifique.
        /// </summary>
        private void InsertExperiences(Body body, string placeholderTag, List<ExperienceEto> experiences)
        {
            // Trouver le paragraphe contenant la balise {{EXPERIENCES}}
            Paragraph placeholderParagraph = FindParagraph(body, placeholderTag);
            if (placeholderParagraph == null)
                return;

            foreach (var experience in experiences)
            {
                // Ajouter un bloc d'expérience
                var experienceBlock = CreateExperienceBlock(experience);
                foreach (var paragraph in experienceBlock)
                {
                    body.InsertAfter(paragraph, placeholderParagraph);
                }
            }

            // Supprimer le paragraphe contenant la balise
            body.RemoveChild(placeholderParagraph);
        }

        /// <summary>
        /// Trouve un paragraphe contenant une balise spécifique.
        /// </summary>
        private Paragraph FindParagraph(Body body, string tag)
        {
            foreach (var paragraph in body.Descendants<Paragraph>())
            {
                if (paragraph.InnerText.Contains(tag))
                {
                    return paragraph;
                }
            }
            return null;
        }

        /// <summary>
        /// Crée un bloc de paragraphes pour une expérience professionnelle.
        /// </summary>
        private List<Paragraph> CreateExperienceBlock(ExperienceEto experience)
        {
            var paragraphs = new List<Paragraph>
        {
            CreateParagraph($"Poste : {experience.Poste}", isBold: true),
            CreateParagraph($"Durée : {experience.Duree}"),
            CreateParagraph($"Contexte : {experience.Contexte}"),
            CreateParagraph($"Tâches : {experience.Taches}"),
            CreateParagraph($"Environnement Technique : {experience.Environnement}")
        };

            // Ajouter une ligne vide pour séparer les expériences
            paragraphs.Add(new Paragraph(new Run(new Text(""))));
            return paragraphs;
        }

        /// <summary>
        /// Crée un paragraphe formaté.
        /// </summary>
        private Paragraph CreateParagraph(string text, bool isBold = false)
        {
            var paragraph = new Paragraph();
            var run = new Run(new Text(text));

            if (isBold)
            {
                var runProperties = new RunProperties();
                runProperties.Append(new Bold());
                run.PrependChild(runProperties);
            }

            paragraph.Append(run);
            return paragraph;
        }
    }

    /// <summary>
    /// Classe représentant une expérience professionnelle.
    /// </summary>
    public class ExperienceEto
    {
        public string Poste { get; set; }
        public string Duree { get; set; }
        public string Contexte { get; set; }
        public string Taches { get; set; }
        public string Environnement { get; set; }
    }



}
