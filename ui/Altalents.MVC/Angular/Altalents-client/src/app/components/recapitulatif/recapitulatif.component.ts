import { Component, Input, OnInit, EventEmitter, Output, ElementRef, Renderer2 } from '@angular/core';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { RecapitulatifDtDto } from 'src/app/shared/services/generated/api/api.client';
import { Certification } from 'src/app/shared/models/certification.model';
import { Formation } from 'src/app/shared/models/formation.model';
import { Experience } from 'src/app/shared/models/experience.model';
import { Langue } from 'src/app/shared/models/langue.model';
import { Question } from 'src/app/shared/models/question.model';
import { Competence } from 'src/app/shared/models/competence.model';
import { DossierTechniqueEnum } from 'src/app/shared/enums/dossier-technique-step.enum';
import { FormContainerComponent } from '../form-container/form-container.component';
import { ParlonsDeVous } from 'src/app/shared/models/parlons-de-vous.model';
import { firstValueFrom } from 'rxjs';
import { PermissionDT } from 'src/app/shared/models/permissionDT.model';
import { PermissionService } from 'src/app/shared/services/services/security/permission-service';

@Component({
  selector: 'app-recapitulatif',
  templateUrl: './recapitulatif.component.html',
  styleUrls: ['./recapitulatif.component.scss']
})

export class RecapitulatifComponent extends BaseComponentCallHttpComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @Output() stepChange = new EventEmitter<DossierTechniqueEnum>();
  @Input() public permissionDT: PermissionDT = new PermissionDT();
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();

  public dossierTechniqueEnum = DossierTechniqueEnum; 
  public formContainer = FormContainerComponent;
  public confirmation: boolean = false;

  public parlonsDeVous: ParlonsDeVous = new ParlonsDeVous();
  public arrayNbEtoiles: number[] = [1,2,3,4,5];

  public formations: Formation[] = [];
  public certifications: Certification[] = [];
  public experiences: Experience[] = [];
  public langues: Langue[] = [];
  public questions: Question[] = [];
  
  public compCompetences: Competence[] = [];
  public compMethodologies: Competence[] = [];
  public compOutils: Competence[] = [];
  public compTechnologie: Competence[] = [];

  constructor(private modalService: NgbModal,
    private service: ApiServiceAgent,
                private permissionService: PermissionService, 
                private el: ElementRef,
                private renderer: Renderer2
  ) {
    super()
  }

  public ngOnInit(): void {
    if (this.permissionDT.isDtAccessible) {
      this.validationCallback.emit(() => this.submit());
      this.populateData();
    }
  }

  public ngAfterViewInit(): void {
    //L observer est necessaire pour les champs qui ont *ngIf ou *ngFor (car il sont generer plus tard et donc ne sont pas dans le DOM au moment de l'entré dans ngAfterViewInit)
    if (this.permissionDT.isDtReadOnly) {
      const observer = new MutationObserver(() => {
        this.permissionService.disableAllFields(this.el, this.renderer);
      });
      observer.observe(this.el.nativeElement, {
        childList: true,
        subtree: true,
      });
    }
  }

  goToStep(step: DossierTechniqueEnum) {
    this.stepChange.emit(step);
  }

  public downloadPj()
  {
    var link = document.createElement("a"); //Create <a>
    link.href = "data:" + this.parlonsDeVous.pieceJointe?.mimeType + ";base64," + this.parlonsDeVous.pieceJointe?.data; //Image Base64 Goes here
    link.download = this.parlonsDeVous.pieceJointe?.nomFichier!; //File name Here
    link.click(); //Downloaded file
  }

  private async submit(): Promise<boolean> {
    let isValid: boolean = false;
    if (this.confirmation) {

      this.isLoading = true;
      // TODO APPEL DE LA METHODE QUI VALIDE LE Dt 

      await firstValueFrom(this.service.validationDtCompletByCandidat(this.tokenDossierTechnique)).then(() => {
        isValid = true;
        this.isLoading = false;
      });

    }
    else
    {
      isValid = false;
    }
    return new Promise<boolean>(resolve => resolve(isValid));
  }

  public populateData(): void {

    this.isLoading = true;

    this.callRequest(ConstantesRequest.getRecapitulatif, this.service.getRecapitulatif(this.tokenDossierTechnique)
    .subscribe((response: RecapitulatifDtDto) => {

      this.parlonsDeVous =  ParlonsDeVous.from(response.parlonsDeVous!);

      this.formations = Formation.fromList(response.formations!);
      this.certifications = Certification.fromList(response.certifications!);
      this.experiences = Experience.fromList(response.experiences!);
      this.langues = Langue.fromList(response.langues!);
      this.questions = Question.fromList(response.questionnaires!);

      this.compCompetences= Competence.fromList(response.competences?.competences!);
      this.compMethodologies= Competence.fromList(response.competences?.methodologies!);
      this.compOutils= Competence.fromList(response.competences?.outils!);
      this.compTechnologie= Competence.fromList(response.competences?.technologie!);

      this.isLoading = false;

    }));
  }
}
