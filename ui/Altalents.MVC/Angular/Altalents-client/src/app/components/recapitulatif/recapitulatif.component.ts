import { Component, Input, OnInit, EventEmitter, Output } from '@angular/core';
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

@Component({
  selector: 'app-recapitulatif',
  templateUrl: './recapitulatif.component.html',
  styleUrls: ['./recapitulatif.component.scss']
})

export class RecapitulatifComponent extends BaseComponentCallHttpComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @Output() stepChange = new EventEmitter<DossierTechniqueEnum>();
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();

  public dossierTechniqueEnum = DossierTechniqueEnum; 
  public formContainer = FormContainerComponent;
  public confirmation: boolean = false;
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
    private service: ApiServiceAgent
  ) {
    super()
  }

  public ngOnInit(): void {
    this.validationCallback.emit(() => this.submit());
    this.populateData();
  }

  goToStep(step: DossierTechniqueEnum) {
    this.stepChange.emit(step);
  }

  private async submit(): Promise<boolean> {
    let isValid: boolean = false;
    if (this.confirmation) {
        isValid = true;
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
