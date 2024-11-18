import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbModal, NgbModalOptions, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Experience } from 'src/app/shared/models/experience.model';
import { ExperienceDialogComponent } from '../dialogs/experience-dialog/experience-dialog.component';
import { firstValueFrom } from 'rxjs';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { ExperienceDto, ExperienceRequestDto, PutExperiencesRequestDto } from 'src/app/shared/services/generated/api/api.client';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { formatDate } from '@angular/common';
import { Constantes } from 'src/app/shared/constantes/constantes';
import { DureeExperienceService } from 'src/app/shared/services/services/calculators/duree-experience-calculator';

@Component({
  selector: 'app-experiences',
  templateUrl: './experiences.component.html',
  styleUrls: ['./experiences.component.scss']
})
export class ExperiencesComponent extends BaseComponentCallHttpComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();
  public experiences: Experience[] = [];
  
  constructor(private modalService: NgbModal,
    private service: ApiServiceAgent
  ) {
    super()
  }
  
  public ngOnInit(): void {
    this.validationCallback.emit(() => this.submit());
    this.populateData();
  }

  public populateData(): void {
    this.isLoading = true;
    this.callRequest(ConstantesRequest.getExperiences, this.service.getExperiences(this.tokenDossierTechnique)
        .subscribe((response: ExperienceDto[]) => {
          this.experiences = Experience.fromList(response);
          this.experiences.forEach(x => x.dureeExperience = DureeExperienceService.CalculateDureeExperience(x.dateDebut, x.dateFin));
          this.isLoading = false;
        }));
  }

  public onAddExperienceClick(): void {
    const ngbModalOptions: NgbModalOptions = {
      backdrop : 'static',
      keyboard : false,
      size: 'lg'
    };
    let dialogRef: NgbModalRef = this.modalService.open(ExperienceDialogComponent, ngbModalOptions);
    dialogRef.result.then((nouvelElement: Experience | undefined) => {
      if(nouvelElement) {
        nouvelElement.dureeExperience = DureeExperienceService.CalculateDureeExperience(nouvelElement.dateDebut, nouvelElement.dateFin);
        this.experiences.push(nouvelElement)
      }
    })
  }

  public onModifierExperienceClick(experience: Experience): void {
    const ngbModalOptions: NgbModalOptions = {
      backdrop : 'static',
      keyboard : false,
      size: 'lg'
    };
    let dialogRef: NgbModalRef = this.modalService.open(ExperienceDialogComponent, ngbModalOptions);
    dialogRef.componentInstance.experience = experience;
    dialogRef.result.then((nouvelElement: Experience | undefined) => {
      if(nouvelElement) {
        nouvelElement.dureeExperience = DureeExperienceService.CalculateDureeExperience(nouvelElement.dateDebut, nouvelElement.dateFin);
      }
    })
  }

  private async submit(): Promise<boolean> {
    this.isLoading = true;
    // On n'utilise pas callRequest ici pour pouvoir await l'appel au back.
    await firstValueFrom(this.service.putExperiences(this.tokenDossierTechnique, this.populateRequestDto()))
      .then(() => {
        this.isLoading = false;
      });     
    return new Promise<boolean>(resolve => resolve(true));
  }

  private populateRequestDto(): PutExperiencesRequestDto {
    let requestDto = new PutExperiencesRequestDto();
    requestDto.experiences = [];

    this.experiences.forEach(experience => {
      let experienceDto = new ExperienceRequestDto();
      experienceDto.typeContratId = experience.typeContrat.id;
      experienceDto.intitulePoste = experience.intitulePoste;
      experienceDto.entreprise = experience.entreprise;
      experienceDto.clientFinal = experience.clientFinal;
      experienceDto.dateDebut = formatDate(experience.dateDebut, Constantes.formatDateBack, Constantes.formatDateLocale);
      experienceDto.dateFin = experience.dateFin ? formatDate(experience.dateFin, Constantes.formatDateBack, Constantes.formatDateLocale) : undefined;
      experienceDto.lieu = experience.lieu;
      experienceDto.description = experience.description;
      experienceDto.domaineMetier = experience.domaineMetier;
      // experienceDto.compositionEquipe = experience.compositionEquipe;
      experienceDto.technologieIds = [];
      experience.technologies?.forEach(x => {
        experienceDto.technologieIds?.push(x.id);
      })
      experienceDto.competenceIds = [];
      experience.competences?.forEach(x => {
        experienceDto.competenceIds?.push(x.id);
      })
      experienceDto.methodologieIds = [];
      experience.methodologies?.forEach(x => {
        experienceDto.methodologieIds?.push(x.id);
      })
      experienceDto.budget = experience.budgetGere;
      requestDto.experiences?.push(experienceDto);
    });

    return requestDto;
  }
}
