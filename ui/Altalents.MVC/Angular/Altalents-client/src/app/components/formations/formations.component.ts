import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-formations',
  templateUrl: './formations.component.html'
})
export class FormationsComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  public formations: string = "";
  
  public ngOnInit(): void {
    this.loadData();
  }

  private loadData(): void {
    // TODO : appeler le back pour avoir les infos
    this.formations = "";
  }
}
