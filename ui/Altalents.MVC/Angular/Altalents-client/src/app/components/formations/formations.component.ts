import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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
import { AllAboutFormationsDto, FormationCertificationRequestDto, LangueParleeRequestDto } from 'src/app/shared/services/generated/api/api.client';
import { ConstantesFormationCertification } from 'src/app/shared/constantes/constantes-formation-certification';
import { catchError, tap } from 'rxjs';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { Constantes } from 'src/app/shared/constantes/constantes';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-formations',
  templateUrl: './formations.component.html',
  styleUrls: ['./formations.component.scss']
})
export class FormationsComponent  extends BaseComponentCallHttpComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();
  public stepFormation: StepFormation = new StepFormation();
  public customDialog: NgbModalOptions = {
    centered: true,
    backdrop : 'static',
    keyboard : false,
  };

  constructor(private modalService: NgbModal,
    private service: ApiServiceAgent
  ) {
    super()
  }

  public ngOnInit(): void {
    //On retire la validation et le submit sachant que dosromais on save a la validation des modals
    // this.validationCallback.emit(() => this.submit());
    this.populateData();
  }

  public onAddFormationClick(): void {
    let dialogRef: NgbModalRef = this.modalService.open(FormationDialogComponent, this.customDialog);
    dialogRef.result.then((nouvelFormation: Formation | undefined) => {
      if(nouvelFormation) {
        this.service.addFormationCertification(this.tokenDossierTechnique, this.populateFormationRequestDto(nouvelFormation))
          .pipe(
            tap((response: string) => {
              this.ngOnInit(); // Recharge les données
            })
          )
          .subscribe({
            error: (err) => console.error('Erreur lors de l’appel au service:', err),
          });
      }
    })
  }

  public onModifierFormationClick(formation: Formation): void {
    let dialogRef: NgbModalRef = this.modalService.open(FormationDialogComponent);
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
    let dialogRef: NgbModalRef = this.modalService.open(CertificationDialogComponent, this.customDialog);
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
    let dialogRef: NgbModalRef = this.modalService.open(CertificationDialogComponent);
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
    let dialogRef: NgbModalRef = this.modalService.open(LangueDialogComponent, this.customDialog);
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

  public onUpdateLangueClick(): void {
    let dialogRef: NgbModalRef = this.modalService.open(LangueDialogComponent);
    dialogRef.result.then((selectedLangue: Langue | undefined) => {
      if(selectedLangue) {
        this.service.updateLangueParlee(this.tokenDossierTechnique, selectedLangue.id, this.populateLangueParleeRequestDto(selectedLangue)).pipe(
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
    }));
  }

  private populateCertificationRequestDto(certification: Certification): FormationCertificationRequestDto {

    let dto = new FormationCertificationRequestDto();

        dto.dateDebut = formatDate(certification.dateDebut!, Constantes.formatDateBack, Constantes.formatDateLocale);
        dto.dateFin = certification.dateFin ? formatDate(certification.dateFin, Constantes.formatDateBack, Constantes.formatDateLocale) : undefined;
        dto.domaine = certification.domaine;
        dto.libelle = certification.libelle;
        dto.niveau = certification.niveau;
        dto.organisme = certification.organisme;
        dto.formationOrCertificationEnumCode = ConstantesFormationCertification.certification;

    return dto;
    
  }

  private populateFormationRequestDto(formation: Formation): FormationCertificationRequestDto {

    let dto = new FormationCertificationRequestDto();

    dto.dateDebut = formatDate(formation.dateDebut!, Constantes.formatDateBack, Constantes.formatDateLocale);
    dto.dateFin = formation.dateFin ? formatDate(formation.dateFin, Constantes.formatDateBack, Constantes.formatDateLocale) : undefined;
        dto.domaine = formation.domaine;
        dto.libelle = formation.libelle;
        dto.niveau = formation.niveau;
        dto.organisme = formation.organisme;
        dto.formationOrCertificationEnumCode = ConstantesFormationCertification.formation;

    return dto;
  }

  private populateLangueParleeRequestDto(langue: Langue): LangueParleeRequestDto {

    let dto = new LangueParleeRequestDto();

        dto.langueId = langue.langue?.id!;
        dto.niveau = langue.niveau?.id;

    return dto;
  }


}
