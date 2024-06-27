import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccueilComponent } from './components/accueil/accueil.component';
import { ConstantesRoutes } from './shared/constantes/constantes-routes';
import { DonneesLegalesComponent } from './components/donnees-legales/donnees-legales.component';
import { FormationsComponent } from './components/formations/formations.component';
import { ExperiencesComponent } from './components/experiences/experiences.component';
import { CompetencesComponent } from './components/competences/competences.component';
import { QuestionsComponent } from './components/questions/questions.component';
import { RecapitulatifComponent } from './components/recapitulatif/recapitulatif.component';

const routes: Routes = [
  { path: `${ConstantesRoutes.accueilBaseUrl}:${ConstantesRoutes.paramTokenDossierTechnique}`, component: AccueilComponent },
  { path: `${ConstantesRoutes.donneesLegalesBaseUrl}:${ConstantesRoutes.paramTokenDossierTechnique}`, component: DonneesLegalesComponent },
  { path: `${ConstantesRoutes.formationsBaseUrl}:${ConstantesRoutes.paramTokenDossierTechnique}`, component: FormationsComponent },
  { path: `${ConstantesRoutes.experiencesBaseUrl}:${ConstantesRoutes.paramTokenDossierTechnique}`, component: ExperiencesComponent },
  { path: `${ConstantesRoutes.competencesBaseUrl}:${ConstantesRoutes.paramTokenDossierTechnique}`, component: CompetencesComponent },
  { path: `${ConstantesRoutes.questionsBaseUrl}:${ConstantesRoutes.paramTokenDossierTechnique}`, component: QuestionsComponent },
  { path: `${ConstantesRoutes.recapitulatifBaseUrl}:${ConstantesRoutes.paramTokenDossierTechnique}`, component: RecapitulatifComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
