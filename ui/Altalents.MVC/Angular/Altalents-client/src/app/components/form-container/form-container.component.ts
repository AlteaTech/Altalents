import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';
import { ConstantesTitresSteps } from 'src/app/shared/constantes/constantes-titres-steps';
import { DossierTechniqueEnum } from 'src/app/shared/enums/dossier-technique-step.enum';
import { PermissionDT } from 'src/app/shared/models/permissionDT.model';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { PermissionService } from 'src/app/shared/services/services/security/permission-service';

@Component({
  selector: 'app-form-container',
  templateUrl: './form-container.component.html',
  styleUrls: ['form-container.component.scss']
})
export class FormContainerComponent extends BaseComponentCallHttpComponent implements OnInit {


  public static instance: FormContainerComponent;

  public permissionDT: PermissionDT = new PermissionDT();
  public tokenDossierTechnique: string = "";
  public dossierTechniqueEnum = DossierTechniqueEnum;
  public currentStep: DossierTechniqueEnum = DossierTechniqueEnum.ParlonsDeVous;
  public titreStep: string = ConstantesTitresSteps.parlonsDeVous;
  public steps: number[] = [];
  public validationCallBack: (() => Promise<boolean>) | undefined;

  constructor(private route: ActivatedRoute, private readonly service: ApiServiceAgent,private permissionService: PermissionService) {

    super();
    FormContainerComponent.instance = this;
    
     
  }

  public async  ngOnInit(): Promise<void>  {
    this.isLoading = true;
    this.tokenDossierTechnique = this.route.snapshot.paramMap.get(ConstantesRoutes.paramTokenDossierTechnique) ?? "";
    this.permissionDT = await this.permissionService.getRefreshedDTPermissionAndRedirectIfNecessary(this.tokenDossierTechnique);


  // Récupérer les permissions et définir l'état readOnly
  //  this.permissionDT = await this.permissionService.getLastPermissionDT();

    // Les enums sont gérés bizarrement en Angular, on ne peut pas simplement boucler dessus (valeurs en double).
    // On récupère les keys de chaque valeur de l'enum pour pouvoir boucler dessus pour afficher le stepper dynamiquement.
    this.steps = Object.keys(this.dossierTechniqueEnum).filter(f => !isNaN(Number(f))).map(k => parseInt(k));
    this.isLoading = false;
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

        let numEtape : number = this.currentStep+1;
          this.callRequest(ConstantesRequest.setLastValidatedEtape, this.service.setLastValidatedEtape(this.tokenDossierTechnique, numEtape)
            .subscribe(() => {

              this.validationCallBack = undefined;
            if(this.currentStep == this.steps.length - 1){
              document.location.href = `${ConstantesRoutes.finBaseUrl}${this.tokenDossierTechnique}`
            } else {
              this.currentStep += 1;
              this.changeStep();
            }

        
        }));
        


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
