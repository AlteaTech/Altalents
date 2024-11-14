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
import { FormationCertificationRequestDto } from 'src/app/shared/services/generated/api/api.client';
import { ConstantesFormationCertification } from 'src/app/shared/constantes/constantes-formation-certification';


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
    this.validationCallback.emit(() => this.submit());
    this.loadData();
  }

  public onAddFormationClick(): void {
    let dialogRef: NgbModalRef = this.modalService.open(FormationDialogComponent, this.customDialog);
    dialogRef.result.then((nouvelElement: Formation | undefined) => {
      if(nouvelElement) {
        //A FINIR 
        // this.service.addFormationCertification (this.tokenDossierTechnique, ConstantesTypesLiaisons.technologie).pipe(
        //   tap((response: CompetenceDto[]) => {
        //     this.compTechnologie = Competence.fromList(response);
        //   })
        // )
      }
    })
  }

  public onModifierFormationClick(formation: Formation): void {
    let dialogRef: NgbModalRef = this.modalService.open(FormationDialogComponent);
    dialogRef.componentInstance.formation = formation;
  }

  public onAddCertificationClick(): void {
    let dialogRef: NgbModalRef = this.modalService.open(CertificationDialogComponent, this.customDialog);
    dialogRef.result.then((nouvelElement: Certification | undefined) => {
      if(nouvelElement) {
        this.stepFormation.certifications.push(nouvelElement)
      }
    })
  }

  public onModifierCertificationClick(certification: Certification): void {
    let dialogRef: NgbModalRef = this.modalService.open(CertificationDialogComponent);
    dialogRef.componentInstance.certification = certification;
  }

  public onAddLangueClick(): void {
    let dialogRef: NgbModalRef = this.modalService.open(LangueDialogComponent, this.customDialog);
    dialogRef.result.then((nouvelElement: Langue | undefined) => {
      if(nouvelElement) {
        this.stepFormation.langues.push(nouvelElement)
      }
    })
  }

  private submit(): Promise<boolean> {
    // Appeler la route de save
    return new Promise<boolean>(resolve => resolve(true));
  }

  private loadData(): void {
    // TODO : appeler le back pour avoir les infos
    this.stepFormation = new StepFormation();
  }

  private populateCertificationRequestDto(certification: Certification): FormationCertificationRequestDto {

    let dto = new FormationCertificationRequestDto();

        dto.dateDebut = certification.dateDebut!;
        dto.dateFin = certification.dateFin;
        dto.domaine = certification.domaine;
        dto.libelle = certification.libelle;
        dto.niveau = certification.niveau;
        dto.organisme = certification.organisme;
        dto.formationOrCertificationEnumCode = ConstantesFormationCertification.certification;

    return dto;
    
  }


  private populateFormationRequestDto(formation: Formation): FormationCertificationRequestDto {

    let dto = new FormationCertificationRequestDto();

        dto.dateDebut = formation.dateDebut!;
        dto.dateFin = formation.dateFin;
        dto.domaine = formation.domaine;
        dto.libelle = formation.libelle;
        dto.niveau = formation.niveau;
        dto.organisme = formation.organisme;
        dto.formationOrCertificationEnumCode = ConstantesFormationCertification.formation;

    return dto;
    
  }


}
