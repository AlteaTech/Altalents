import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-donnees-legales',
  templateUrl: './donnees-legales.component.html'
})
export class DonneesLegalesComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  public donneesLegales: string = "";

  public ngOnInit(): void {
    this.loadData();
  }

  private loadData(): void {
    // TODO : appeler le back pour avoir les infos
    this.donneesLegales = "";
  }
}
