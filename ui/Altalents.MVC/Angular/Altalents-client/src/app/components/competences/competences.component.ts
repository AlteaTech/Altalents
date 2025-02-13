import { Component, ElementRef, EventEmitter, Input, OnInit, Output, Renderer2 } from '@angular/core';
import { Competence } from 'src/app/shared/models/competence.model';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { CompetenceDto, LiaisonExperienceUpdateNiveauDto } from 'src/app/shared/services/generated/api/api.client';
import { merge, tap } from 'rxjs';
import { ConstantesTypesLiaisons } from 'src/app/shared/constantes/constantes-types-liaisons';
import { PermissionDT } from 'src/app/shared/models/permissionDT.model';
import { PermissionService } from 'src/app/shared/services/services/security/permission-service';

@Component({
  selector: 'app-competences',
  templateUrl: './competences.component.html',
  styleUrls: ['./competences.component.scss']
})

export class CompetencesComponent extends BaseComponentCallHttpComponent implements OnInit {

  @Input() public tokenDossierTechnique: string = "";
  @Input() public permissionDT: PermissionDT = new PermissionDT();
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();
  @Output() public stepperUpdate: EventEmitter<void> = new EventEmitter<void>();

  public compCompetences: Competence[] = [];
  public compMethodologies: Competence[] = [];
  public compOutils: Competence[] = [];
  public compTechnologie: Competence[] = [];
  public arrayNbEtoiles: number[] = [1,2,3,4,5];
  public constantesTypesLiaisons = ConstantesTypesLiaisons;
  
  constructor(private service: ApiServiceAgent, private permissionService: PermissionService, private el: ElementRef, private renderer: Renderer2 ) {
    super()
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

 private async submit(): Promise<boolean> {
   return new Promise<boolean>(resolve => resolve(true))
 }

  public populateData(): void {
    this.isLoading = true;

    merge(
      this.service.getCompetences(this.tokenDossierTechnique, ConstantesTypesLiaisons.competence).pipe(
        tap((response: CompetenceDto[]) => {
          this.compCompetences = Competence.fromList(response);
        })
      ),
      this.service.getCompetences(this.tokenDossierTechnique, ConstantesTypesLiaisons.methodologie).pipe(
        tap((response: CompetenceDto[]) => {
          this.compMethodologies = Competence.fromList(response);
        })
      ),
      this.service.getCompetences(this.tokenDossierTechnique, ConstantesTypesLiaisons.outil).pipe(
        tap((response: CompetenceDto[]) => {
          this.compOutils = Competence.fromList(response);
        })
      ),
      this.service.getCompetences(this.tokenDossierTechnique, ConstantesTypesLiaisons.technologie).pipe(
        tap((response: CompetenceDto[]) => {
          this.compTechnologie = Competence.fromList(response);
        })
      )
    ).subscribe({
      next: () => {
        this.isLoading = false;
      },
      error: () => {
        this.isLoading = false; 
      }
    });
  }

  public onEtoileCompetenceClick(competence: Competence, codeTypeLiaison : string, niveau: number): void {
    
    competence.niveau = niveau;
    this.isLoading = true;
    
    this.service.putNote(this.populateRequestDto(competence, codeTypeLiaison)).subscribe({
      next: () => {
        this.isLoading = false; 
      },
      error: (err) => {
        this.isLoading = false; 
        console.error('Erreur lors de la mise à jour de la note', err);
      }
    });
  }

  private populateRequestDto(competence: Competence, codeTypeLiaison : string): LiaisonExperienceUpdateNiveauDto {

    let dto = new LiaisonExperienceUpdateNiveauDto();

    dto.liaisonId = competence.idLiaison;
    dto.typeLiaisonCode = codeTypeLiaison;
    dto.note = competence.niveau;

    return dto;
  }
}
