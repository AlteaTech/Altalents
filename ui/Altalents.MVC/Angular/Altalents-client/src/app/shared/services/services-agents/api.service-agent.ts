import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';
import { ApiClient, CustomUserLoggedDto, DossierTechniqueInsertRequestDto, GetTrigrammeRequestDto, IsTelephoneValidRequestDto, NomPrenomPersonneDto, ReferenceDto, TrigrammeDto } from '../generated/api/api.client';

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

  getReferences(typeReferenceCode: string, startsWith?: string | undefined): Observable<ReferenceDto[]> {
    return this.apiClient.getReferences(typeReferenceCode, startsWith);
  }

  getTrigramme(body: GetTrigrammeRequestDto): Observable<TrigrammeDto> {
    return this.apiClient.getTrigramme(body);
  }
  isEmailValid(email: string): Observable<boolean> {
    return this.apiClient.isEmailValid(email);
  }
  isIdBoondValid(idboond: string): Observable<boolean> {
    return this.apiClient.isIdBoondValid(idboond);
  }
  isTrigramValid(trigram: string): Observable<boolean> {
    return this.apiClient.isTrigrammeValid(trigram);
  }
  isTelephoneValid(telephone: string, isOptionnal: boolean): Observable<boolean> {
    let request = new IsTelephoneValidRequestDto();
    request.isOptionnal = isOptionnal;
    request.telephone = telephone;
    return this.apiClient.isTelephoneValid(request);
  }

  getNomPrenomFromToken(token: string): Observable<NomPrenomPersonneDto> {
    return this.apiClient.getNomPrenomFromToken(token);
  }  
}
