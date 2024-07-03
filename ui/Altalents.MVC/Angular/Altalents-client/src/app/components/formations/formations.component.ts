import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormationDialogComponent } from '../dialogs/formation-dialog/formation-dialog.component';
import { StepFormation } from 'src/app/shared/models/step-formation.model';

@Component({
  selector: 'app-formations',
  templateUrl: './formations.component.html'
})
export class FormationsComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @ViewChild('formationDialog') formationDialog!: FormationDialogComponent;
  
  public stepFormation: StepFormation = new StepFormation();
  
  public ngOnInit(): void {
    this.loadData();
  }

  public onAddFormationClick(): void {
    this.formationDialog.openDialog();
  }

  private loadData(): void {
    // TODO : appeler le back pour avoir les infos
    this.stepFormation = new StepFormation();
  }
}
