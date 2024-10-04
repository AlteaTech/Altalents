import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';
import { DocumentDto } from 'src/app/shared/services/generated/api/api.client';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';

@Component({
  selector: 'app-telechargement-dt',
  templateUrl: './telechargement-dt.component.html'
})
export class TelechargementDtComponent extends BaseComponent implements OnInit {
  public tokenDossierTechnique: string = "";

  constructor(private route: ActivatedRoute,
    private readonly service: ApiServiceAgent) {
    super();
  }
  
  public ngOnInit(): void {
    this.tokenDossierTechnique = this.route.snapshot.paramMap.get(ConstantesRoutes.paramTokenDossierTechnique) ?? "";
    this.populateData();
  }

  public override populateData(): void {    
    this.isLoading = true;
    this.callRequest(ConstantesRequest.generateDossierCompetenceFile, this.service.generateDossierCompetenceFile(this.tokenDossierTechnique)
        .subscribe((response: DocumentDto) => {
          var a = document.createElement("a"); //Create <a>
          a.href = "data:" + response.mimeType + ";base64," + response.data; //Image Base64 Goes here
          a.download = response.nomFichier; //File name Here
          a.click(); //Downloaded file
          this.isLoading = false;
        }));
  }
}
