import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';
import { ApiClient, CompetenceDto, CustomUserLoggedDto, DocumentDto, DossierTechniqueInsertRequestDto, ExperienceDto, GetTrigrammeRequestDto, IsTelephoneValidRequestDto, NomPrenomPersonneDto, ParlonsDeVousDto, ParlonsDeVousUpdateRequestDto, QuestionnaireDto, QuestionnaireUpdateDto, ReferenceDto, ReferenceRequestDto, TrigrammeDto, LiaisonExperienceUpdateNiveauDto, FormationCertificationRequestDto, LangueParleeRequestDto, AllAboutFormationsDto, RecapitulatifDtDto, ExperienceRequestDto, FormationCertificationEnum } from '../generated/api/api.client';

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

  createReferences(body: ReferenceRequestDto): Observable<string> {
    return this.apiClient.createReferences(body);
  }

  getTrigramme(body: GetTrigrammeRequestDto): Observable<TrigrammeDto> {
    return this.apiClient.getTrigramme(body);
  }

  isEmailValid(email: string, token: string | undefined): Observable<boolean> {
    return this.apiClient.isEmailValid(token, email);
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

  getParlonsDeVous(token: string): Observable<ParlonsDeVousDto> {
    return this.apiClient.getParlonsDeVous(token);
  }

  putParlonsDeVous(token: string, body: ParlonsDeVousUpdateRequestDto): Observable<void> {
    return this.apiClient.putParlonsDeVous(token, body);
  }

  generateDossierCompetenceFile(token: string): Observable<DocumentDto> {
    return this.apiClient.generateDossierCompetenceFile(token);
  }

  getExperiences(token: string): Observable<ExperienceDto[]> {
    return this.apiClient.getExperiences(token);
  }

  updateExperiance(token: string, id: string, dto : ExperienceRequestDto): Observable<string> {
    return this.apiClient.updateExperience(token, id, dto);
  }

  addExperiance(token: string, dto : ExperienceRequestDto): Observable<string> {
    return this.apiClient.addExperience(token, dto);
  }

  deleteExperience(token: string, id: string): Observable<void> {
    return this.apiClient.deleteExperience(token, id);
  }

  getQuestionnaires(token: string): Observable<QuestionnaireDto[]> {
    return this.apiClient.getQuestionnaires(token);
  }

  getDocuments(token: string): Observable<DocumentDto[]> {
    return this.apiClient.getDocuments(token);
  }

  putQuestionnaires(body: QuestionnaireUpdateDto[]): Observable<void> {
    return this.apiClient.setReponseQuestionnaires(body);
  }

  getCompetences(token: string, typeLiaisonCode : string): Observable<CompetenceDto[]> {
    return this.apiClient.getCompetences(token, typeLiaisonCode);
  }

  putNote(body: LiaisonExperienceUpdateNiveauDto): Observable<void> {
    return this.apiClient.putNote(body);
  }

  getAllAboutFormations(token: string): Observable<AllAboutFormationsDto> {
    return this.apiClient.getAllAboutFormations(token);
  }

  addFormationCertification(token: string, body: FormationCertificationRequestDto): Observable<string> {
    return this.apiClient.addFormationCertification(token, body);
  }

  updateFormationCertification(token: string, id: string, body: FormationCertificationRequestDto): Observable<void> {
    return this.apiClient.updateFormationCertification(token, id, body);
  }

  deleteFormationCertification(token: string, id: string,  type : FormationCertificationEnum): Observable<void> {
    return this.apiClient.deleteFormationCertification(token, id, type);
  }

  addLangueParlee(token: string, body: LangueParleeRequestDto): Observable<string> {
    return this.apiClient.addLangueParlee(token, body);
  }

  updateLangueParlee(token: string, id: string, body: LangueParleeRequestDto): Observable<void> {
    return this.apiClient.updateLangueParlee(token, id, body);
  }

  deleteLangueParlee(token: string, id: string): Observable<void> {
    return this.apiClient.deleteLangueParlee(token, id);
  }

  getRecapitulatif(token:string): Observable<RecapitulatifDtDto> {
    return this.apiClient.getRecapitulatif(token);
  }

}
