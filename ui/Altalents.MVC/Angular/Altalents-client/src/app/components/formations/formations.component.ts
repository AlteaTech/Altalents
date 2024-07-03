import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormationDialogComponent } from '../dialogs/formation-dialog/formation-dialog.component';

@Component({
  selector: 'app-formations',
  templateUrl: './formations.component.html'
})
export class FormationsComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @ViewChild('formationDialog') formationDialog!: FormationDialogComponent;
  
  public isFormationDialogOpen: boolean = false;
  public formations: string = "";
  
  public ngOnInit(): void {
    this.loadData();
  }

  public onAddFormationClick(): void {
    this.formationDialog.open();
  }

  private loadData(): void {
    // TODO : appeler le back pour avoir les infos
    this.formations = "";
  }
}
