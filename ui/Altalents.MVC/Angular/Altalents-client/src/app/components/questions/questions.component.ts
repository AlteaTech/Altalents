import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { Question } from 'src/app/shared/models/question.model';
import { QuestionnaireDto, QuestionnaireUpdateDto } from 'src/app/shared/services/generated/api/api.client';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['../../app.component.css']
})
export class QuestionsComponent extends BaseComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();

  public questions: Question[] = [];
  public showErreurs: boolean = false;

  constructor(private readonly service: ApiServiceAgent) {
    super();
  }
 
  public ngOnInit(): void {
    this.validationCallback.emit(() => this.submit());
    this.populateData();
  }

  public override populateData(): void {
    this.isLoading = true;
    this.callRequest(ConstantesRequest.getQuestionnaires, this.service.getQuestionnaires(this.tokenDossierTechnique)
        .subscribe((response: QuestionnaireDto[]) => {
          this.questions = Question.fromList(response);
          this.isLoading = false;
        }));
  }

  private async submit(): Promise<boolean> {
    let isValid: boolean = true;

    this.questions.forEach(x => {
      if(x.isObligatoire && !x.reponse) {
        isValid = false;
      }
    })
    
    if (isValid) {
      this.isLoading = true;
      // On n'utilise pas callRequest ici pour pouvoir await l'appel au back.
      await firstValueFrom(this.service.putQuestionnaires(this.populateRequestDto())).then(() => {
        isValid = true;
        this.isLoading = false;
      });
    } else {
      this.showErreurs = true;
    }

    return new Promise<boolean>(resolve => resolve(isValid));
  }

  private populateRequestDto(): QuestionnaireUpdateDto[] {
    let dtos: QuestionnaireUpdateDto[] = [];
    this.questions.forEach((question: Question) => {
      let dto = new QuestionnaireUpdateDto();
      dto.id = question.id ?? "";
      dto.reponse = question.reponse;
      dtos.push(dto);
    })
    return dtos;
  }
}
