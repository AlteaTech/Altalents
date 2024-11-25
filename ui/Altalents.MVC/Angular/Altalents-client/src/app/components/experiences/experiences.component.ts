import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbModal, NgbModalOptions, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Experience } from 'src/app/shared/models/experience.model';
import { ExperienceDialogComponent } from '../dialogs/experience-dialog/experience-dialog.component';
import { tap } from 'rxjs';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { ExperienceDto, ExperienceRequestDto } from 'src/app/shared/services/generated/api/api.client';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { formatDate } from '@angular/common';
import { Constantes } from 'src/app/shared/constantes/constantes';
import { DureeExperienceService } from 'src/app/shared/services/services/calculators/duree-experience-calculator';
import { ConfirmDeleteDialogComponent } from '../dialogs/confirm-delete-dialog/confirm-delete-dialog.component';

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

 private async submit(): Promise<boolean> {
   return new Promise<boolean>(resolve => resolve(true))
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
    dialogRef.result.then((experience: Experience | undefined) => {
      if(experience) {
        this.service.addExperiance(this.tokenDossierTechnique, this.populateRequestDto(experience)).pipe(
          tap(() => {
            this.ngOnInit();
          })
        ).subscribe();
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
    dialogRef.result.then((experience: Experience | undefined) => {
      if(experience) {
        this.service.updateExperiance(this.tokenDossierTechnique, experience.id, this.populateRequestDto(experience)).pipe(
          tap(() => {
            this.ngOnInit();
          })
        ).subscribe();
      }
    })
  }

  public onDeleteExperienceClick(experience : Experience): void {
    const ngbModalOptions: NgbModalOptions = {
      backdrop : 'static',
      keyboard : false,
      size: 'lg'
    };
    let dialogRef: NgbModalRef = this.modalService.open(ConfirmDeleteDialogComponent, ngbModalOptions);
    dialogRef.componentInstance.itemName = experience.intitulePoste;
    dialogRef.result.then((validated: boolean | undefined) => {
      if(validated) {
        this.service.deleteExperience(this.tokenDossierTechnique, experience.id).pipe(
          tap(() => {
            this.ngOnInit();
          })
        ).subscribe();
      }
    })
  }

  private populateRequestDto(experience : Experience): ExperienceRequestDto {

      let experienceDto = new ExperienceRequestDto();
      experienceDto.typeContratId = experience.typeContrat.id;
      experienceDto.intitulePoste = experience.intitulePoste;
      experienceDto.entreprise = experience.nomEntreprise;
      experienceDto.isEntrepriseEsnOrInterim = experience.IsEntrepriseEsnOrInterim;
      experienceDto.dateDebut = formatDate(experience.dateDebut, Constantes.formatDateBack, Constantes.formatDateLocale);
      experienceDto.dateFin = experience.dateFin ? formatDate(experience.dateFin, Constantes.formatDateBack, Constantes.formatDateLocale) : undefined;
      experienceDto.lieu = experience.lieu;
      experienceDto.description = experience.description;
      experienceDto.domaineMetierId = experience.domaineMetier.id;
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
      experienceDto.outilIds = [];
      experience.outils?.forEach(x => {
        experienceDto.outilIds?.push(x.id);
      })
      experienceDto.budget = experience.budgetGere;
    
    return experienceDto;

  }
}
