import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';
import { DocumentDto, NomPrenomPersonneDto } from 'src/app/shared/services/generated/api/api.client';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';

@Component({
  selector: 'app-fin',
  templateUrl: './fin.component.html',
  styleUrls: ['./fin.component.scss']
})

export class FinComponent extends BaseComponentCallHttpComponent implements OnInit {
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

  public populateData(): void {    
    this.callRequest(ConstantesRequest.getNomPrenom, this.service.getNomPrenomFromToken(this.tokenDossierTechnique)
        .subscribe((response: NomPrenomPersonneDto) => {
          this.nomPrenomCandidat = response.prenom + " " + response.nom;
        }));
  }

  public DownloadDt(): void {    
    this.isLoading = true;
    this.callRequest(ConstantesRequest.generateDossierCompetenceFile, this.service.generateDossierCompetenceFile(this.tokenDossierTechnique)
        .subscribe((response: DocumentDto) => {
          var a = document.createElement("a"); 
          a.href = "data:" + response.mimeType + ";base64," + response.data; 
          a.download = response.nomFichier; 
          a.click(); 
          this.isLoading = false;
        }));
  }



}
