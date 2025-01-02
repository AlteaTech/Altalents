using System;
using Altalents.Export.OpenXml;

namespace Altalents.Export.DSO.OpenXml
{
    public class DtMainPageExportDso
    {

        //Header
        public string Dt_Numero { get; set; }
        public string Dt_TokenAccesRapide { get; set; }
        public string Dt_Poste { get; set; }
        public string Candidat_Trigramme { get; set; }

        //Section Focus
        public string Candidat_NbAnneesExperiences { get; set; }
        public string Candidat_CompetencesClefs { get; set; }
        public string Candidat_Synthese { get; set; }

        //Section commercial
        public string Commercial_NomComplet { get; set; }
        public string Commercial_Email { get; set; }
        public string Commercial_Phone { get; set; }
        public string Commercial_SiteWeb { get; set; }

        //Section Ccompetences techniques
        public string Candidat_SoftSkill { get; set; }
        public string Candidat_Domaines { get; set; }
        public string Candidat_Languages_Prog { get; set; }
        public string Candidat_Bdd { get; set; }
        public string Candidat_Methodologie { get; set; }
        public string Candidat_Outils { get; set; }
        public string Candidat_IDE { get; set; }
        public string Candidat_Framework { get; set; }
        public string Candidat_Virtualisation { get; set; }
        public string Candidat_Versionning { get; set; }

        public List<DtCompetenceMetierExportDso> Candidat_CompetencesMetiers { get; set; }
        public List<DtFormationExportDso> Candidat_Formations { get; set; }
        public List<DtCertificationExportDso> Candidat_Certifications{ get; set; }
        public List<DtLangueExportDso> Candidat_Langues { get; set; }
        public  List<DtExperienceProExportDso> Candidat_ExperiencesPro { get; set; }
        public List<DtQuestionDso> Candidat_Questions { get; set; }

    }
}
