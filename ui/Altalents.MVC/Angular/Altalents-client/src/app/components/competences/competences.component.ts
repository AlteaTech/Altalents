import { Component, Input, OnInit } from '@angular/core';
import { Competence } from 'src/app/shared/models/competence.model';
import { NgbModal, NgbModalOptions, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { CompetenceDto, LiaisonExperienceUpdateNiveauDto } from 'src/app/shared/services/generated/api/api.client';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-competences',
  templateUrl: './competences.component.html'
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

    this.callRequest(ConstantesRequest.getCompetences, this.service.getCompetences(this.tokenDossierTechnique,'1')
        .subscribe((response: CompetenceDto[]) => {
          this.compCompetences = Competence.fromList(response);
          this.isLoading = false;
        }));

        this.callRequest(ConstantesRequest.getCompetences, this.service.getCompetences(this.tokenDossierTechnique,'2')
        .subscribe((response: CompetenceDto[]) => {
          this.compMethodologies = Competence.fromList(response);
          this.isLoading = false;
        }));

        this.callRequest(ConstantesRequest.getCompetences, this.service.getCompetences(this.tokenDossierTechnique,'3')
        .subscribe((response: CompetenceDto[]) => {
          this.compOutils = Competence.fromList(response);
          this.isLoading = false;
        }));

        this.callRequest(ConstantesRequest.getCompetences, this.service.getCompetences(this.tokenDossierTechnique,'4')
        .subscribe((response: CompetenceDto[]) => {
          this.compTechnologie = Competence.fromList(response);
          this.isLoading = false;
        }));

  }

  private async onEtoileCOmpetenceClick(competence: Competence, codeTypeLiaison : string, numEToile : number): Promise<void> {
    await firstValueFrom(this.service.putNote(this.tokenDossierTechnique,this.populateRequestDto(competence, codeTypeLiaison))).then(() => {
      this.isLoading = false;
    });
  }

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
