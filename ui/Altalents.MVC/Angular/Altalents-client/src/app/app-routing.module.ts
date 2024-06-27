import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccueilComponent } from './components/accueil/accueil.component';
import { ConstantesRoutes } from './shared/constantes/constantes-routes';

const routes: Routes = [
  { path: `${ConstantesRoutes.accueilBaseUrl}:${ConstantesRoutes.paramTokenDossierTechnique}`, component: AccueilComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
