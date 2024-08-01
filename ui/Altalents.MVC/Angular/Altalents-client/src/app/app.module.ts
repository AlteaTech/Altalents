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
import { FinComponent } from './components/fin/fin.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommercialCreationDtAccueilComponent } from './components/commercial-creation-dt-accueil/commercial-creation-dt-accueil.component';
import { CommercialCreationDtConfigurationComponent } from './components/commercial-creation-dt-configuration/commercial-creation-dt-configuration.component';
import { HttpClientModule } from '@angular/common/http';
import { FormationDialogComponent } from './components/dialogs/formation-dialog/formation-dialog.component';
import { CertificationDialogComponent } from './components/dialogs/certification-dialog/certification-dialog.component';
import { LangueDialogComponent } from './components/dialogs/langue-dialog/langue-dialog.component';
import { ExperienceDialogComponent } from './components/dialogs/experience-dialog/experience-dialog.component';
import { MultipleAutocompleteComponent } from './shared/components/multiple-autocomplete/multiple-autocomplete.component';

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
    RecapitulatifComponent,
    FinComponent,
    CommercialCreationDtAccueilComponent,
    CommercialCreationDtConfigurationComponent,
    FormationDialogComponent,
    CertificationDialogComponent,
    LangueDialogComponent,
    ExperienceDialogComponent,
    MultipleAutocompleteComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
