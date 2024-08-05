import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';
import { ConstantesTitresSteps } from 'src/app/shared/constantes/constantes-titres-steps';
import { DossierTechniqueEnum } from 'src/app/shared/enums/dossier-technique-step.enum';

@Component({
  selector: 'app-form-container',
  templateUrl: './form-container.component.html',
  styleUrls: ['form-container.component.scss','../../app.component.css']
})
export class FormContainerComponent implements OnInit {
  public tokenDossierTechnique: string = "";
  public dossierTechniqueEnum = DossierTechniqueEnum;
  public currentStep: DossierTechniqueEnum = DossierTechniqueEnum.ParlonsDeVous;
  public titreStep: string = ConstantesTitresSteps.parlonsDeVous;
  public steps: number[] = [];
  public validationCallBack: (() => Promise<boolean>) | undefined;

  constructor(private route: ActivatedRoute) {

  }

  public ngOnInit(): void {
    this.tokenDossierTechnique = this.route.snapshot.paramMap.get(ConstantesRoutes.paramTokenDossierTechnique) ?? "";

    // Les enums sont gérés bizarrement en Angular, on ne peut pas simplement boucler dessus (valeurs en double).
    // On récupère les keys de chaque valeur de l'enum pour pouvoir boucler dessus pour afficher le stepper dynamiquement.
    this.steps = Object.keys(this.dossierTechniqueEnum).filter(f => !isNaN(Number(f))).map(k => parseInt(k));
  }

  public onStepClick(stepSelected: DossierTechniqueEnum): void {
    this.currentStep = stepSelected;
    this.changeStep();
  }

  public onRetourClick(): void {
    if(this.currentStep == 0){
      document.location.href = `${ConstantesRoutes.accueilBaseUrl}${this.tokenDossierTechnique}`
    } else {
      this.currentStep -= 1;
      this.changeStep();
    }
  }

  public onSuivantClick(): void {
    if(this.validationCallBack){
      this.validationCallBack().then((isValid: boolean) => {
        if(!isValid){
          return;
        }

        this.validationCallBack = undefined;
        if(this.currentStep == this.steps.length - 1){
          document.location.href = `${ConstantesRoutes.finBaseUrl}${this.tokenDossierTechnique}`
        } else {
          this.currentStep += 1;
          this.changeStep();
        }
      })
    }
  }

  public onValidationCallbackChange(callback: () => Promise<boolean>): void {
    this.validationCallBack = callback;
  }

  private changeStep(): void {
    switch (this.currentStep) {
      case DossierTechniqueEnum.ParlonsDeVous:
        this.titreStep = ConstantesTitresSteps.parlonsDeVous;
        break;
      case DossierTechniqueEnum.Formations:
        this.titreStep = ConstantesTitresSteps.formations;
        break;
      case DossierTechniqueEnum.Experiences:
        this.titreStep = ConstantesTitresSteps.experiences;
        break;
      case DossierTechniqueEnum.Competences:
        this.titreStep = ConstantesTitresSteps.competences;
        break;
      case DossierTechniqueEnum.Questions:
        this.titreStep = ConstantesTitresSteps.questions;
        break;
      case DossierTechniqueEnum.Recapitulatif:
        this.titreStep = ConstantesTitresSteps.recapitulatif;
        break;
    }
  }
}
