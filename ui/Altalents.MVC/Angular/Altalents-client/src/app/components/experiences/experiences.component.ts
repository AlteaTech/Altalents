import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';

@Component({
  selector: 'app-experiences',
  templateUrl: './experiences.component.html'
})
export class ExperiencesComponent implements OnInit {
  public tokenDossierTechnique: string = "";
  public experiences: string = "";

  constructor(private route: ActivatedRoute) {
    
  }
  
  public ngOnInit(): void {
    this.tokenDossierTechnique = this.route.snapshot.paramMap.get(ConstantesRoutes.paramTokenDossierTechnique) ?? "";
    this.loadData();
  }

  private loadData(): void {
    // TODO : appeler le back pour avoir les infos
    this.experiences = "";
  }
}
