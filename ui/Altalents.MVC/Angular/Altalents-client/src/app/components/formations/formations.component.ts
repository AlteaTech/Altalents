import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormationDialogComponent } from '../dialogs/formation-dialog/formation-dialog.component';
import { StepFormation } from 'src/app/shared/models/step-formation.model';
import { Formation } from 'src/app/shared/models/formation.model';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { CertificationDialogComponent } from '../dialogs/certification-dialog/certification-dialog.component';
import { Certification } from 'src/app/shared/models/certification.model';
import { LangueDialogComponent } from '../dialogs/langue-dialog/langue-dialog.component';
import { Langue } from 'src/app/shared/models/langue.model';

@Component({
  selector: 'app-formations',
  templateUrl: './formations.component.html',
  styleUrls: ['../../app.component.css']
})
export class FormationsComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();
  public stepFormation: StepFormation = new StepFormation();
  
  constructor(private modalService: NgbModal) {
  }

  public ngOnInit(): void {
    this.validationCallback.emit(() => this.submit());
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

  public onAddLangueClick(): void {
    let dialogRef: NgbModalRef = this.modalService.open(LangueDialogComponent);
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
}
