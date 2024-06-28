import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccueilComponent } from './components/accueil/accueil.component';
import { DonneesLegalesComponent } from './components/donnees-legales/donnees-legales.component';
import { FormationsComponent } from './components/formations/formations.component';
import { ExperiencesComponent } from './components/experiences/experiences.component';
import { CompetencesComponent } from './components/competences/competences.component';
import { QuestionsComponent } from './components/questions/questions.component';
import { RecapitulatifComponent } from './components/recapitulatif/recapitulatif.component';
import { FormContainerComponent } from './components/form-container/form-container.component';

@NgModule({
  declarations: [
    AppComponent,
    AccueilComponent,
    FormContainerComponent,
    DonneesLegalesComponent,
    FormationsComponent,
    ExperiencesComponent,
    CompetencesComponent,
    QuestionsComponent,
    RecapitulatifComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
