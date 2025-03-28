import { CUSTOM_ELEMENTS_SCHEMA, LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {AlteaBaseModule} from '@altea-si-tech/altea-base';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccueilComponent } from './components/accueil/accueil.component';
import { ParlonsDeVousComponent } from './components/parlons-de-vous/parlons-de-vous.component';
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
import { CommonModule, registerLocaleData } from '@angular/common';
import localeFr from '@angular/common/locales/fr';
import { QuestionnaireDialogComponent } from './components/dialogs/questionnaire-dialog/questionnaire-dialog.component';
import { PieceJointeDialogComponent } from './components/dialogs/piece-jointe-dialog/piece-jointe-dialog.component';
import { TelechargementDtComponent } from './components/telechargement-dt/telechargement-dt.component';
import { CustomLoaderComponent } from './shared/components/custom-loader/custom-loader.component';
import { ConfirmDeleteDialogComponent } from './components/dialogs/confirm-delete-dialog/confirm-delete-dialog.component';
import { AccesDtInterditComponent } from './components/acces-dt-interdit/acces-dt-interdit.component';
import { DtReadonlyMessageComponent } from './shared/components/dt-readonly-message/dt-readonly-message.component';
import { DtInexistantComponent } from './components/dt-inexistant/dt-inexistant.component';
import { MonthYearPickerComponent } from './shared/components/month-year-picker/month-year-picker.component';


registerLocaleData(localeFr);

@NgModule({
  declarations: [
    AppComponent,
    AccueilComponent,
    FormContainerComponent,
    ParlonsDeVousComponent,
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
    MultipleAutocompleteComponent,
    QuestionnaireDialogComponent,
    PieceJointeDialogComponent,
    TelechargementDtComponent,
    CustomLoaderComponent,
    ConfirmDeleteDialogComponent,
    AccesDtInterditComponent,
    DtReadonlyMessageComponent,
    DtInexistantComponent,
    MonthYearPickerComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    AlteaBaseModule
  ],
  providers: [{provide: LOCALE_ID, useValue: "fr-FR" } ],
  bootstrap: [AppComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class AppModule { }
