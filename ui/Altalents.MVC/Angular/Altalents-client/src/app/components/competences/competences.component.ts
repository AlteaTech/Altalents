import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-competences',
  templateUrl: './competences.component.html'
})
export class CompetencesComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  public competences: string = "";
  
  public ngOnInit(): void {
    this.loadData();
  }

  private loadData(): void {
    // TODO : appeler le back pour avoir les infos
    this.competences = "";
  }
}
