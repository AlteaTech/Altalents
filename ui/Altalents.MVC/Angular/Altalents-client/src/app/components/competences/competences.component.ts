import { Component, Input, OnInit } from '@angular/core';
import { Competence } from 'src/app/shared/models/competence.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { CompetenceDto, LiaisonExperienceUpdateNiveauDto } from 'src/app/shared/services/generated/api/api.client';
import { merge, tap } from 'rxjs';
import { ConstantesTypesLiaisons } from 'src/app/shared/constantes/constantes-types-liaisons';

@Component({
  selector: 'app-competences',
  templateUrl: './competences.component.html',
  styleUrls: ['./competences.component.scss']
})

export class CompetencesComponent extends BaseComponentCallHttpComponent implements OnInit {

  @Input() public tokenDossierTechnique: string = "";

  public compCompetences: Competence[] = [];
  public compMethodologies: Competence[] = [];
  public compOutils: Competence[] = [];
  public compTechnologie: Competence[] = [];
  public arrayNbEtoiles: number[] = [1,2,3,4,5];
  public constantesTypesLiaisons = ConstantesTypesLiaisons;
  
  constructor(private modalService: NgbModal,
    private service: ApiServiceAgent
  ) {
    super()
  }
  
  public ngOnInit(): void {
    this.populateData();
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
        this.isLoading = false; // Dès qu'une requête répond, le loader s'arrête
      },
      error: () => {
        this.isLoading = false; // En cas d'erreur, arrêt du loader
        // Vous pouvez également gérer les erreurs ici
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
