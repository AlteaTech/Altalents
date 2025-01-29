import { Component, ElementRef, EventEmitter, Input, OnInit, Output, Renderer2 } from '@angular/core';
import { FormationDialogComponent } from '../dialogs/formation-dialog/formation-dialog.component';
import { StepFormation } from 'src/app/shared/models/step-formation.model';
import { Formation } from 'src/app/shared/models/formation.model';
import { NgbModal, NgbModalOptions, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { CertificationDialogComponent } from '../dialogs/certification-dialog/certification-dialog.component';
import { Certification } from 'src/app/shared/models/certification.model';
import { LangueDialogComponent } from '../dialogs/langue-dialog/langue-dialog.component';
import { Langue } from 'src/app/shared/models/langue.model';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { AllAboutFormationsDto, FormationCertificationEnum, FormationCertificationRequestDto, LangueParleeRequestDto } from 'src/app/shared/services/generated/api/api.client';

import { tap } from 'rxjs';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { Constantes } from 'src/app/shared/constantes/constantes';
import { formatDate } from '@angular/common';
import { ConfirmDeleteDialogComponent } from '../dialogs/confirm-delete-dialog/confirm-delete-dialog.component';
import { PermissionDT } from 'src/app/shared/models/permissionDT.model';
import { PermissionService } from 'src/app/shared/services/services/security/permission-service';
import { MODAL_OPTIONS_LG } from 'src/app/shared/modal-options';
import { FormationCertificationEnumCodeInBackend } from 'src/app/shared/constantes/constantes-formation-certification-backend-enum';
@Component({
  selector: 'app-formations',
  templateUrl: './formations.component.html',
  styleUrls: ['./formations.component.scss']
})
export class FormationsComponent extends BaseComponentCallHttpComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @Input() public permissionDT: PermissionDT = new PermissionDT();
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();

  public stepFormation: StepFormation = new StepFormation();

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

  public onAddFormationClick(): void {
    let dialogRef: NgbModalRef = this.modalService.open(FormationDialogComponent, MODAL_OPTIONS_LG);
    dialogRef.result.then((nouvelFormation: Formation | undefined) => {
      if(nouvelFormation) {
        this.service.addFormationCertification(this.tokenDossierTechnique, this.populateFormationRequestDto(nouvelFormation))
          .pipe(
            tap((response: string) => {
              this.ngOnInit();
            })
          )
          .subscribe();
      }
    })
  }

  public onModifierFormationClick(formation: Formation): void {
    let dialogRef: NgbModalRef = this.modalService.open(FormationDialogComponent, MODAL_OPTIONS_LG);
    dialogRef.componentInstance.formation = formation;
    dialogRef.result.then((formationToUpdate: Formation | undefined) => {
      if(formationToUpdate) {
        this.service.updateFormationCertification (this.tokenDossierTechnique, formationToUpdate.id, this.populateFormationRequestDto(formationToUpdate)).pipe(
          tap((response: void) => {
            this.ngOnInit();
          })
        ).subscribe();
      }
    })
  }

  public onAddCertificationClick(): void {
    let dialogRef: NgbModalRef = this.modalService.open(CertificationDialogComponent, MODAL_OPTIONS_LG);
    dialogRef.result.then((nouvelCertification: Certification | undefined) => {
      if(nouvelCertification) {
        this.service.addFormationCertification (this.tokenDossierTechnique, this.populateCertificationRequestDto(nouvelCertification)).pipe(
          tap((response: string) => {
            this.ngOnInit();
          })
        ).subscribe();
      }
    })
  }

  public onModifierCertificationClick(certification: Certification): void {
    let dialogRef: NgbModalRef = this.modalService.open(CertificationDialogComponent, MODAL_OPTIONS_LG);
    dialogRef.componentInstance.certification = certification;
    dialogRef.result.then((CertificationToUpdate: Certification | undefined) => {
      if(CertificationToUpdate) {
        this.service.updateFormationCertification (this.tokenDossierTechnique, CertificationToUpdate.id, this.populateCertificationRequestDto(CertificationToUpdate)).pipe(
          tap((response: void) => {
            this.ngOnInit();
          })
        ).subscribe();
      }
    })
  }

  public onAddLangueClick(): void {
    let dialogRef: NgbModalRef = this.modalService.open(LangueDialogComponent, MODAL_OPTIONS_LG);
    dialogRef.result.then((selectedLangue: Langue | undefined) => {
      if(selectedLangue) {
        this.service.addLangueParlee(this.tokenDossierTechnique, this.populateLangueParleeRequestDto(selectedLangue)).pipe(
          tap((response: string) => {
            this.ngOnInit();
          })
        ).subscribe();
      }
    })
  }

  public onUpdateLangueClick(langue : Langue): void {
    let dialogRef: NgbModalRef = this.modalService.open(LangueDialogComponent, MODAL_OPTIONS_LG);
    dialogRef.componentInstance.langueInput = langue;
    dialogRef.result.then((LangueToUpdate: Langue | undefined) => {
      if(LangueToUpdate) {
        this.service.updateLangueParlee(this.tokenDossierTechnique, LangueToUpdate.id, this.populateLangueParleeRequestDto(LangueToUpdate)).pipe(
          tap((response: void) => {
            this.ngOnInit();
          })
        ).subscribe();
      }
    })
  }

  public onDeleteLangueClick(langue : Langue): void {
    let dialogRef: NgbModalRef = this.modalService.open(ConfirmDeleteDialogComponent, MODAL_OPTIONS_LG);
    dialogRef.componentInstance.itemName = langue.libelleLangue;
    dialogRef.result.then((validated: boolean | undefined) => {
      if(validated) {
        this.service.deleteLangueParlee(this.tokenDossierTechnique, langue.id).pipe(
          tap((response: void) => {
            this.ngOnInit();
          })
        ).subscribe();
      }
    })
  }

  public onDeleteCertificationClick(certification : Certification): void {
    let dialogRef: NgbModalRef = this.modalService.open(ConfirmDeleteDialogComponent, MODAL_OPTIONS_LG);
    dialogRef.componentInstance.itemName = certification.libelle;
    dialogRef.result.then((validated: boolean | undefined) => {
      if(validated) {
        this.service.deleteFormationCertification(this.tokenDossierTechnique, certification.id, FormationCertificationEnum.Certification).pipe(
          tap((response: void) => {
            this.ngOnInit();
          })
        ).subscribe();
      }
    })
  }

  public onDeleteFormationClick(formation : Formation): void {
    let dialogRef: NgbModalRef = this.modalService.open(ConfirmDeleteDialogComponent, MODAL_OPTIONS_LG);
    dialogRef.componentInstance.itemName = formation.libelle;
    dialogRef.result.then((validated: boolean | undefined) => {
      if(validated) {
        this.service.deleteFormationCertification(this.tokenDossierTechnique, formation.id, FormationCertificationEnum.Formation).pipe(
          tap((response: void) => {
            this.ngOnInit();
          })
        ).subscribe();
      }
    })
  }

  private populateData(): void {
    this.isLoading = true;
    this.callRequest(ConstantesRequest.GetAllAboutFormations, this.service.getAllAboutFormations(this.tokenDossierTechnique)
    .subscribe((response: AllAboutFormationsDto) => {
      this.stepFormation.certifications = Certification.fromList(response.certifications!);
      this.stepFormation.formations = Formation.fromList(response.formations!);
      this.stepFormation.langues = Langue.fromList(response.languesParlees!);
      this.isLoading = false;
    }));
  }

  private populateCertificationRequestDto(certification: Certification): FormationCertificationRequestDto {
    let dto = new FormationCertificationRequestDto();
        dto.dateDebut = formatDate(certification.dateDebut!, Constantes.formatDateBack, Constantes.formatDateLocale);
        dto.dateFin = certification.dateFin ? formatDate(certification.dateFin, Constantes.formatDateBack, Constantes.formatDateLocale) : undefined;
        dto.libelle = certification.libelle;
        dto.niveau = certification.niveau;
        dto.organisme = certification.organisme;
        dto.formationOrCertificationEnumCode = FormationCertificationEnumCodeInBackend.certification;
    return dto;
  }

  private populateFormationRequestDto(formation: Formation): FormationCertificationRequestDto {
    let dto = new FormationCertificationRequestDto();
        dto.dateDebut = formatDate(formation.dateDebut!, Constantes.formatDateBack, Constantes.formatDateLocale);
        dto.dateFin = formation.dateFin ? formatDate(formation.dateFin, Constantes.formatDateBack, Constantes.formatDateLocale) : undefined;
        dto.libelle = formation.libelle;
        dto.niveau = formation.niveau;
        dto.organisme = formation.organisme;
        dto.formationOrCertificationEnumCode = FormationCertificationEnumCodeInBackend.formation;
    return dto;
  }

  private populateLangueParleeRequestDto(langue: Langue): LangueParleeRequestDto {
    let dto = new LangueParleeRequestDto();
        dto.langueId = langue.idLangue!;
        dto.niveauId = langue.idReferenceNiveau!;
    return dto;
  }


}
