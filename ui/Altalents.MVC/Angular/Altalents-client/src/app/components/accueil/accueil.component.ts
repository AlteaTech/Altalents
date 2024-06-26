import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';

@Component({
  selector: 'app-accueil',
  templateUrl: './accueil.component.html'
})
export class AccueilComponent implements OnInit {
  public tokenDossierTechnique: string = "";
  public nomPrenomCandidat: string = "";

  constructor(private route: ActivatedRoute) {
    
  }
  
  public ngOnInit(): void {
    this.tokenDossierTechnique = this.route.snapshot.paramMap.get(ConstantesRoutes.accueilParamTokenDossierTechnique) ?? "";
    this.loadNomPrenomCandidat();
  }

  private loadNomPrenomCandidat(): void {
    // TODO : appeler le back pour avoir le nom prénom du candidat 
    this.nomPrenomCandidat = "Mr. MOCK " + this.tokenDossierTechnique;
  }
}
