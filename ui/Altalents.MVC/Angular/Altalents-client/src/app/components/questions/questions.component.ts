import { Component, ElementRef, EventEmitter, Input, OnInit, Output, Renderer2 } from '@angular/core';
import { firstValueFrom, merge, tap } from 'rxjs';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { Question } from 'src/app/shared/models/question.model';
import { QuestionnaireDto, QuestionnaireUpdateDto } from 'src/app/shared/services/generated/api/api.client';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { DocumentDt } from 'src/app/shared/models/document.model';
import { PermissionDT } from 'src/app/shared/models/permissionDT.model';
import { PermissionService } from 'src/app/shared/services/services/security/permission-service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.scss']
})
export class QuestionsComponent extends BaseComponentCallHttpComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @Input() public permissionDT: PermissionDT = new PermissionDT();
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();
  @Output() public stepperUpdate: EventEmitter<void> = new EventEmitter<void>();

  public questions: Question[] = [];
  public documents: DocumentDt[] = [];
  public showErreurs: boolean = false;

  constructor(private readonly service: ApiServiceAgent, private permissionService: PermissionService, private el: ElementRef, private renderer: Renderer2) {
    super();
  }
 
  public ngOnInit(): void {
    this.stepperUpdate.emit(); 
    
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
  
  public downloadPj(i: number): void {
    const pieceJointe = this.documents[i];
    if (pieceJointe) {
      const a = document.createElement("a");
      a.href = "data:" + pieceJointe.mimeType + ";base64," + pieceJointe.data; 
      a.download = pieceJointe.nomFichier; 
      a.click(); 
    } else {
      alert("Erreur : la pièce jointe est introuvable.");
    }
  }


  public populateData(): void {
    this.isLoading = true;

    merge(
      this.service.getQuestionnaires(this.tokenDossierTechnique).pipe(
        tap((response: QuestionnaireDto[]) => {
          this.questions = Question.fromList(response);
        })
      ),

    ).subscribe({
      next: () => {
        this.isLoading = false;
      },
      error: () => {
        this.isLoading = false; 
      }
    });


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
