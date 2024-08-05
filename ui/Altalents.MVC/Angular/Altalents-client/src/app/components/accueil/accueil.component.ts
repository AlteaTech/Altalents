import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';
import { NomPrenomPersonneDto } from 'src/app/shared/services/generated/api/api.client';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';

@Component({
  selector: 'app-accueil',
  templateUrl: './accueil.component.html',
  styleUrls: ['./accueil.component.scss','../../app.component.css']

})
export class AccueilComponent extends BaseComponent implements OnInit {
  public tokenDossierTechnique: string = "";
  public nomPrenomCandidat: string = "";

  constructor(private route: ActivatedRoute,
    private readonly service: ApiServiceAgent) {
    super();
  }
  
  public ngOnInit(): void {
    this.tokenDossierTechnique = this.route.snapshot.paramMap.get(ConstantesRoutes.paramTokenDossierTechnique) ?? "";
    this.populateData();
  }

  public onDemarrerClick(): void {
    document.location.href = `${ConstantesRoutes.dossierTechniqueBaseUrl}${this.tokenDossierTechnique}`
  }

  public override populateData(): void {    
    this.callRequest(ConstantesRequest.getNomPrenom, this.service.getNomPrenomFromToken(this.tokenDossierTechnique)
        .subscribe((response: NomPrenomPersonneDto) => {
          this.nomPrenomCandidat = response.prenom + " " + response.nom;
        }));
  }
}
