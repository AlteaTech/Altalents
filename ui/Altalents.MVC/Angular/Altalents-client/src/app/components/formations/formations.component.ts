import { Component, Input, OnInit } from '@angular/core';
import { FormationDialogComponent } from '../dialogs/formation-dialog/formation-dialog.component';
import { StepFormation } from 'src/app/shared/models/step-formation.model';
import { Formation } from 'src/app/shared/models/formation.model';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { CertificationDialogComponent } from '../dialogs/certification-dialog/certification-dialog.component';
import { Certification } from 'src/app/shared/models/certification.model';

@Component({
  selector: 'app-formations',
  templateUrl: './formations.component.html'
})
export class FormationsComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";  
  public stepFormation: StepFormation = new StepFormation();
  
  constructor(private modalService: NgbModal) {
  }

  public ngOnInit(): void {
    this.loadData();
  }

  public onAddFormationClick(): void {
    let dialogRef: NgbModalRef = this.modalService.open(FormationDialogComponent);
    dialogRef.result.then((nouvelElement: Formation | undefined) => {
      if(nouvelElement) {
        this.stepFormation.formations.push(nouvelElement)
      }
    })
  }

  public onModifierFormationClick(formation: Formation): void {
    let dialogRef: NgbModalRef = this.modalService.open(FormationDialogComponent);
    dialogRef.componentInstance.formation = formation;
  }

  public onAddCertificationClick(): void {
    let dialogRef: NgbModalRef = this.modalService.open(CertificationDialogComponent);
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

  private loadData(): void {
    // TODO : appeler le back pour avoir les infos
    this.stepFormation = new StepFormation();
  }
}
