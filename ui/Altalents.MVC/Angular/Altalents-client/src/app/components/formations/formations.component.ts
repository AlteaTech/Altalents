import { Component, Input, OnInit } from '@angular/core';
import { FormationDialogComponent } from '../dialogs/formation-dialog/formation-dialog.component';
import { StepFormation } from 'src/app/shared/models/step-formation.model';
import { Formation } from 'src/app/shared/models/formation.model';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-formations',
  templateUrl: './formations.component.html'
})
export class FormationsComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  
  public stepFormation: StepFormation = new StepFormation();
  public validationFormationCallBack: (() => Promise<Formation | undefined>) | undefined;
  
  constructor(private modalService: NgbModal){
    
  }

  public ngOnInit(): void {
    this.loadData();
  }

  public onAddFormationClick(): void {
    let dialogRef: NgbModalRef = this.modalService.open(FormationDialogComponent);
    dialogRef.result.then(result => {
      debugger;
    })
  }

  private loadData(): void {
    // TODO : appeler le back pour avoir les infos
    this.stepFormation = new StepFormation();
  }
}
