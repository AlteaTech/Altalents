import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccueilComponent } from './components/accueil/accueil.component';
import { ConstantesRoutes } from './shared/constantes/constantes-routes';
import { FormContainerComponent } from './components/form-container/form-container.component';
import { FinComponent } from './components/fin/fin.component';
import { CommercialCreationDtAccueilComponent } from './components/commercial-creation-dt-accueil/commercial-creation-dt-accueil.component';
import { CommercialCreationDtConfigurationComponent } from './components/commercial-creation-dt-configuration/commercial-creation-dt-configuration.component';
import { TelechargementDtComponent } from './components/telechargement-dt/telechargement-dt.component';

const routes: Routes = [
  { path: `${ConstantesRoutes.accueilBaseUrl}:${ConstantesRoutes.paramTokenDossierTechnique}`, component: AccueilComponent },
  { path: `${ConstantesRoutes.dossierTechniqueBaseUrl}:${ConstantesRoutes.paramTokenDossierTechnique}`, component: FormContainerComponent },
  { path: `${ConstantesRoutes.finBaseUrl}:${ConstantesRoutes.paramTokenDossierTechnique}`, component: FinComponent },
  { path: `${ConstantesRoutes.telechargementDt}:${ConstantesRoutes.paramTokenDossierTechnique}`, component: TelechargementDtComponent },
  { path: `${ConstantesRoutes.commercialAccueilCreateDt}`, component: CommercialCreationDtAccueilComponent },
  { path: `${ConstantesRoutes.commercialAccueilCreateDt}/${ConstantesRoutes.commercialAccueilConfigurationDt}`, component: CommercialCreationDtConfigurationComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
