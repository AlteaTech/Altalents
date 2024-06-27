import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';

@Component({
  selector: 'app-competences',
  templateUrl: './competences.component.html'
})
export class CompetencesComponent implements OnInit {
  public tokenDossierTechnique: string = "";
  public competences: string = "";

  constructor(private route: ActivatedRoute) {
    
  }
  
  public ngOnInit(): void {
    this.tokenDossierTechnique = this.route.snapshot.paramMap.get(ConstantesRoutes.paramTokenDossierTechnique) ?? "";
    this.loadData();
  }

  private loadData(): void {
    // TODO : appeler le back pour avoir les infos
    this.competences = "";
  }
}
