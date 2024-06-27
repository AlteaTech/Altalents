import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';

@Component({
  selector: 'app-recapitulatif',
  templateUrl: './recapitulatif.component.html'
})
export class RecapitulatifComponent implements OnInit {
  public tokenDossierTechnique: string = "";
  public recapitulatif: string = "";

  constructor(private route: ActivatedRoute) {
    
  }
  
  public ngOnInit(): void {
    this.tokenDossierTechnique = this.route.snapshot.paramMap.get(ConstantesRoutes.paramTokenDossierTechnique) ?? "";
    this.loadData();
  }

  private loadData(): void {
    // TODO : appeler le back pour avoir les infos
    this.recapitulatif = "";
  }
}
