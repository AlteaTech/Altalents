import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';
import { NomPrenomPersonneDto, PermissionConsultationDtDto } from 'src/app/shared/services/generated/api/api.client';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { PermissionDT } from 'src/app/shared/models/permissionDT.model';
import { PermissionService } from 'src/app/shared/services/services/security/permission-service';

@Component({
  selector: 'app-accueil',
  templateUrl: './accueil.component.html',
  styleUrls: ['./accueil.component.scss']

})

export class AccueilComponent extends BaseComponentCallHttpComponent implements OnInit {
  public tokenDossierTechnique: string = "";
  public nomPrenomCandidat: string = "";
  public permissionDT: PermissionDT = new PermissionDT();
  
  constructor(private route: ActivatedRoute,
    private readonly service: ApiServiceAgent,private permissionService: PermissionService) {
    super();
  }
  
  public async ngOnInit(): Promise<void> {
    
    this.isLoading = true;

    // Récupérer le token
    this.tokenDossierTechnique = this.route.snapshot.paramMap.get(ConstantesRoutes.paramTokenDossierTechnique) ?? "";
    
    // Attendre que la permission soit rafraîchie
    this.permissionDT = await this.permissionService.getRefreshedDTPermissionAndRedirectIfNecessary(this.tokenDossierTechnique);
    
    // Vérifier si le dossier technique est accessible
    if (this.permissionDT.isDtAccessible) {
      this.populateData();
    }
  }

  public onDemarrerClick(): void {
    document.location.href = `${ConstantesRoutes.dossierTechniqueBaseUrl}${this.tokenDossierTechnique}`
  }

  public populateData(): void {    

    this.callRequest(ConstantesRequest.getNomPrenom, this.service.getNomPrenomFromToken(this.tokenDossierTechnique)
        .subscribe((response: NomPrenomPersonneDto) => {
          this.nomPrenomCandidat = response.prenom + " " + response.nom;
          this.isLoading = false;
        }));
  }

}
