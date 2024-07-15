import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiClient, DossierTechniqueInsertRequestDto } from '../generated/api/api.client';

@Injectable({ providedIn: 'root' })
export class ApiServiceAgent {
  private readonly apiClient: ApiClient;

  constructor(private readonly httpClient: HttpClient) {
    //@ts-ignore
    const baseUrl = window.baseUrlApi ?? "https://altalent-dev.azurewebsites.net";
    this.apiClient = new ApiClient(httpClient, baseUrl);
  }

  addDossierTechnique(body: DossierTechniqueInsertRequestDto): Observable<string> {
    return this.apiClient.addDossierTechnique(body);
  }
}
