import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';

@Component({
  selector: 'app-accueil',
  templateUrl: './accueil.component.html'
})
export class AccueilComponent implements OnInit {
  public nomPrenomCandidat: string = "";

  constructor(private route: ActivatedRoute) {
    
  }
  
  public ngOnInit(): void {
    const tokenDossierTechnique = this.route.snapshot.paramMap.get(ConstantesRoutes.accueilParamTokenDossierTechnique);
    // TODO : appeler le back pour avoir le nom prénom du candidat 
    this.nomPrenomCandidat = "Mr. MOCK " + tokenDossierTechnique;
  }
}
