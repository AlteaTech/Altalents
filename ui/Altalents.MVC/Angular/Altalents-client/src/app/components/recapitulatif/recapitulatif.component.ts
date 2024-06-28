import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-recapitulatif',
  templateUrl: './recapitulatif.component.html'
})
export class RecapitulatifComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  public recapitulatif: string = "";
  
  public ngOnInit(): void {
    this.loadData();
  }

  private loadData(): void {
    // TODO : appeler le back pour avoir les infos
    this.recapitulatif = "";
  }
}
