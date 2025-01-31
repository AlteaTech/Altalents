import { Component, ElementRef, EventEmitter, Input, OnInit, Output, Renderer2 } from '@angular/core';
import { NgbModal, NgbModalOptions, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Experience } from 'src/app/shared/models/experience.model';
import { ExperienceDialogComponent } from '../dialogs/experience-dialog/experience-dialog.component';
import { tap } from 'rxjs';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { ExperienceDto, ExperienceRequestDto, ProjetOrMissionClientRequestDto } from 'src/app/shared/services/generated/api/api.client';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { formatDate } from '@angular/common';
import { Constantes } from 'src/app/shared/constantes/constantes';
import { DureeExperienceService } from 'src/app/shared/services/services/calculators/duree-experience-calculator';
import { ConfirmDeleteDialogComponent } from '../dialogs/confirm-delete-dialog/confirm-delete-dialog.component';
import { ValidateDate } from 'src/app/shared/services/services/validators/validate-date';
import { PermissionDT } from 'src/app/shared/models/permissionDT.model';
import { PermissionService } from 'src/app/shared/services/services/security/permission-service';
import { MODAL_OPTIONS_LG, MODAL_OPTIONS_XL } from 'src/app/shared/modal-options';

@Component({
  selector: 'app-experiences',
  templateUrl: './experiences.component.html',
  styleUrls: ['./experiences.component.scss']
})

export class ExperiencesComponent extends BaseComponentCallHttpComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @Input() public permissionDT: PermissionDT = new PermissionDT();
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();
  
  public experiences: Experience[] = [];

  constructor(private modalService: NgbModal,
    private service: ApiServiceAgent,
            private permissionService: PermissionService, 
            private el: ElementRef,
            private renderer: Renderer2
  ) {
    super()
  }
  
  public ngOnInit(): void {
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
    this.callRequest(ConstantesRequest.getExperiences, this.service.getExperiences(this.tokenDossierTechnique)
        .subscribe((response: ExperienceDto[]) => {
          this.experiences = Experience.fromList(response);
          this.experiences.forEach(x => x.dureeExperience = DureeExperienceService.CalculateDureeExperience(x.dateDebut, x.dateFin, true));
          this.isLoading = false;
    }));
  }

  public onAddExperienceClick(): void {
    let dialogRef: NgbModalRef = this.modalService.open(ExperienceDialogComponent, MODAL_OPTIONS_XL);
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
    let dialogRef: NgbModalRef = this.modalService.open(ExperienceDialogComponent, MODAL_OPTIONS_XL);
    dialogRef.componentInstance.experience = experience;
    dialogRef.componentInstance.tokenAccesRapideDt = this.tokenDossierTechnique;
  
    dialogRef.result
      .then((experience: Experience | undefined) => {
        if (experience) {
          this.service.updateExperiance(this.tokenDossierTechnique, experience.id, this.populateRequestDto(experience))
            .pipe(tap(() => this.ngOnInit()))
            .subscribe();
        }
      })
      .catch(() => {
        // Si l'utilisateur ferme le modal avec "Annuler" ou la croix, on recharge
        this.ngOnInit();
      });
  }
  

  public onDeleteExperienceClick(experience : Experience): void {
    let dialogRef: NgbModalRef = this.modalService.open(ConfirmDeleteDialogComponent, MODAL_OPTIONS_LG);
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
      experienceDto.dateFin = experience.dateFin ? formatDate(experience.dateFin, Constantes.formatDateBack, Constantes.formatDateLocale) : null;
      experienceDto.lieu = experience.lieu;
      experienceDto.domaineMetierId = experience.domaineMetier.id;

      experienceDto.projetsOrMissionsClient = [];
      experience.projetOrMission?.forEach(p => {

        let projectdto = new ProjetOrMissionClientRequestDto();

        projectdto.taches = p.taches;
        projectdto.descriptionProjetOrMission = p.descriptionProjetOrMission;
        projectdto.nomClientOrProjet = p.nomClientOrProjet;

        
        projectdto.dateDebut = p.dateDebut ? formatDate(p.dateDebut!, Constantes.formatDateBack, Constantes.formatDateLocale) : null;
        projectdto.dateFin = p.dateFin ? formatDate(p.dateFin!, Constantes.formatDateBack, Constantes.formatDateLocale) : null;
        projectdto.lieu = p.lieu;
        projectdto.domaineMetierId = p.domaineMetier?.id;
        projectdto.compositionEquipe = p.compositionEquipe;
        projectdto.budget = p.budget;

        projectdto.technologieIds = [];
        p.technologies?.forEach(x => {
          projectdto.technologieIds?.push(x.id);
        })
        projectdto.competenceIds = [];
        p.competences?.forEach(x => {
          projectdto.competenceIds?.push(x.id);
        })
        projectdto.methodologieIds = [];
        p.methodologies?.forEach(x => {
          projectdto.methodologieIds?.push(x.id);
        })
        projectdto.outilIds = [];
        p.outils?.forEach(x => {
          projectdto.outilIds?.push(x.id);
        })

        experienceDto.projetsOrMissionsClient?.push(projectdto);

      })

    return experienceDto;
  }
}
