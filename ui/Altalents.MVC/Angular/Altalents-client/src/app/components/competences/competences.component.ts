import { Component, Input, OnInit } from '@angular/core';
import { Competence } from 'src/app/shared/models/competence.model';
import { NgbModal, NgbModalOptions, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { CompetenceDto, LiaisonExperienceUpdateNiveauDto } from 'src/app/shared/services/generated/api/api.client';
import { firstValueFrom, merge, tap } from 'rxjs';

@Component({
  selector: 'app-competences',
  templateUrl: './competences.component.html',
  styleUrls: ['./competences.component.scss']
})

export class CompetencesComponent extends BaseComponent implements OnInit {

  @Input() public tokenDossierTechnique: string = "";

  public compCompetences: Competence[] = [];
  public compMethodologies: Competence[] = [];
  public compOutils: Competence[] = [];
  public compTechnologie: Competence[] = [];
  public arrayNbEtoiles: number[] = [1,2,3,4,5];
  
  constructor(private modalService: NgbModal,
    private service: ApiServiceAgent
  ) {
    super()
  }
  
  public ngOnInit(): void {
    this.populateData();
  }

  public override populateData(): void {
    this.isLoading = true;

    merge(
      this.service.getCompetences(this.tokenDossierTechnique, '1').pipe(
        tap((response: CompetenceDto[]) => {
          this.compCompetences = Competence.fromList(response);
        })
      ),
      this.service.getCompetences(this.tokenDossierTechnique, '2').pipe(
        tap((response: CompetenceDto[]) => {
          this.compMethodologies = Competence.fromList(response);
        })
      ),
      this.service.getCompetences(this.tokenDossierTechnique, '3').pipe(
        tap((response: CompetenceDto[]) => {
          this.compOutils = Competence.fromList(response);
        })
      ),
      this.service.getCompetences(this.tokenDossierTechnique, '4').pipe(
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
    competence.niveau = niveau; // Met à jour le niveau de la compétence
    this.isLoading = true;
    // Appel API pour sauvegarder la note
    this.service.putNote(this.tokenDossierTechnique, this.populateRequestDto(competence, codeTypeLiaison)).subscribe({
      next: () => {
        this.isLoading = false; 
      },
      error: (err) => {
        this.isLoading = false; 
        console.error('Erreur lors de la mise à jour de la note', err);
      }
    });
  }

  // public async onEtoileCOmpetenceClick(competence: Competence, codeTypeLiaison : string, numEToile : number): Promise<void> {
  //   await firstValueFrom(this.service.putNote(this.tokenDossierTechnique,this.populateRequestDto(competence, codeTypeLiaison))).then(() => {
  //     this.isLoading = false;
  //   });
  // }

  private populateRequestDto(competence: Competence, codeTypeLiaison : string): LiaisonExperienceUpdateNiveauDto {

    let dto = new LiaisonExperienceUpdateNiveauDto();

        dto.liaisonId = competence.ldLiaison;
        dto.typeLiaisonCode = codeTypeLiaison;
        dto.note = competence.niveau;

    return dto;
    
  }

  // private loadData(): void {
  //   // TODO : appeler le back pour avoir les infos
  //   this.competences = "";
  // }

}
