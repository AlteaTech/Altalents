import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccueilComponent } from './components/accueil/accueil.component';
import { ConstantesRoutes } from './shared/constantes/constantes-routes';
import { FormContainerComponent } from './components/form-container/form-container.component';
import { FinComponent } from './components/fin/fin.component';

const routes: Routes = [
  { path: `${ConstantesRoutes.accueilBaseUrl}:${ConstantesRoutes.paramTokenDossierTechnique}`, component: AccueilComponent },
  { path: `${ConstantesRoutes.dossierTechniqueBaseUrl}:${ConstantesRoutes.paramTokenDossierTechnique}`, component: FormContainerComponent },
  { path: `${ConstantesRoutes.finBaseUrl}:${ConstantesRoutes.paramTokenDossierTechnique}`, component: FinComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
