import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbModal, NgbModalOptions, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Experience } from 'src/app/shared/models/experience.model';
import { ExperienceDialogComponent } from '../dialogs/experience-dialog/experience-dialog.component';
import { firstValueFrom } from 'rxjs';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { ExperienceDto, ExperienceRequestDto, PutExperiencesRequestDto } from 'src/app/shared/services/generated/api/api.client';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-experiences',
  templateUrl: './experiences.component.html',
  styleUrls: ['./experiences.component.scss','../../app.component.css']
})
export class ExperiencesComponent extends BaseComponent implements OnInit {
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

  public override populateData(): void {
    this.callRequest(ConstantesRequest.getExperiences, this.service.getExperiences(this.tokenDossierTechnique)
        .subscribe((response: ExperienceDto[]) => {
          this.experiences = Experience.fromList(response);
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
        this.populateDureeExperience(nouvelElement);
        this.experiences.push(nouvelElement)
      }
    })
  }

  private populateDureeExperience(experience: Experience) {
    if (experience.dateDebut && experience.dateFin) {
      const dateFin = new Date(experience.dateFin);
      const dateDebut = new Date(experience.dateDebut);
      const jours: number = Math.round((Date.UTC(dateFin.getFullYear(), dateFin.getMonth(), dateFin.getDate())
                                          - Date.UTC(dateDebut.getFullYear(), dateDebut.getMonth(), dateDebut.getDate()))
                                        / (1000 * 60 * 60 * 24));

      if(jours <= 30) {
        experience.dureeExperience = jours + " jours";
      }
      else if(jours < 365) {
        experience.dureeExperience = Math.round(jours/30) + " mois";
      }
      else {
        experience.dureeExperience = Math.round(jours/365) + " ans";
      }
    }
  }

  public onModifierExperienceClick(experience: Experience): void {
    const ngbModalOptions: NgbModalOptions = {
      backdrop : 'static',
      keyboard : false,
      size: 'lg'
    };
    let dialogRef: NgbModalRef = this.modalService.open(ExperienceDialogComponent, ngbModalOptions);
    dialogRef.componentInstance.experience = experience;
  }

  private async submit(): Promise<boolean> {
    // On n'utilise pas callRequest ici pour pouvoir await l'appel au back.
    await firstValueFrom(this.service.putExperiences(this.tokenDossierTechnique, this.populateRequestDto())).then(() => {});     
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
      experienceDto.dateDebut = formatDate(experience.dateDebut, 'yyyy-MM-ddT00:00:00', 'fr-FR');
      experienceDto.dateFin = experience.dateFin ? formatDate(experience.dateFin, 'yyyy-MM-ddT00:00:00', 'fr-FR') : undefined;
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
