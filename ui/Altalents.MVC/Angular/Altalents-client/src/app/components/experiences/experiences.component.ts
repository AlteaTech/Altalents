import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-experiences',
  templateUrl: './experiences.component.html'
})
export class ExperiencesComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  public experiences: string = "";
  
  public ngOnInit(): void {
    this.loadData();
  }

  private loadData(): void {
    // TODO : appeler le back pour avoir les infos
    this.experiences = "";
  }
}
