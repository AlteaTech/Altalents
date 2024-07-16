import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';
import { ApiClient, CustomUserLoggedDto, DossierTechniqueInsertRequestDto } from '../generated/api/api.client';

@Injectable({ providedIn: 'root' })
export class ApiServiceAgent {
  private readonly apiClient: ApiClient;

  constructor(private readonly httpClient: HttpClient) {
    //@ts-ignore
    const baseUrl = window.baseUrlApi ?? "https://localhost:7195";
    this.apiClient = new ApiClient(httpClient, baseUrl);
  }

  addDossierTechnique(body: DossierTechniqueInsertRequestDto): Observable<string> {
    return this.apiClient.addDossierTechnique(body);
  }

  getUserLoggedDto(): Observable<CustomUserLoggedDto> {
    //@ts-ignore
    if(window.baseUrlApi != null && window.baseUrlApi != undefined){
      return this.apiClient.getUserLoggedDto();
    } const mock = new CustomUserLoggedDto();
    mock.nom = "a";
    mock.login = "a";
    mock.userId = "870eab28-378d-48e3-84bd-08dc96b4bf1b";
    return new Observable<CustomUserLoggedDto>((subscriber: Subscriber<CustomUserLoggedDto>) => subscriber.next(mock));
  }
}
