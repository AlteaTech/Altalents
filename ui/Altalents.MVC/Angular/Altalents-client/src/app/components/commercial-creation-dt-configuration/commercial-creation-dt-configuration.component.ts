import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';
import { ConstantesTypesReferences } from 'src/app/shared/constantes/constantes-types-references';
import { CreationDtCommercialForm } from 'src/app/shared/interfaces/creation-dt-commercial-form';
import { Reference } from 'src/app/shared/models/reference.model';
import { CustomUserLoggedDto, DossierTechniqueInsertRequestDto, GetTrigrammeRequestDto, ReferenceDto, TrigrammeDto } from 'src/app/shared/services/generated/api/api.client';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { ValidateEmailWithApi } from 'src/app/shared/services/services/validators/validate-email-with-api';
import { ValidateIdBoondWithApi } from 'src/app/shared/services/services/validators/validate-idboond-with-api';
import { ValidateTelephoneWithApi } from 'src/app/shared/services/services/validators/validate-telephone-with-api';
import { ValidateTrigramWithApi } from 'src/app/shared/services/services/validators/validate-trigram-with-api';

@Component({
  selector: 'app-commercial-creation-dt-configuration',
  templateUrl: './commercial-creation-dt-configuration.component.html',
  styleUrls: ['./commercial-creation-dt-configuration.component.scss','../../app.component.css']
})

export class CommercialCreationDtConfigurationComponent  extends BaseComponent  implements OnInit, OnDestroy   {
  public formGroup: FormGroup<CreationDtCommercialForm>;
  public userIdLogged: string | undefined;
  public isReady = false;
  public disponibilites: Reference[] = [];

  constructor(
    private readonly service: ApiServiceAgent) {
    super();
    this.formGroup = new FormGroup<CreationDtCommercialForm>({
      prenom: new FormControl('', Validators.required),
      nom: new FormControl('', Validators.required),
      trigram: new FormControl('', Validators.required,ValidateTrigramWithApi(this.service)),
      adresseMail: new FormControl('', Validators.required,ValidateEmailWithApi(this.service, undefined)),
      numeroTelephone1: new FormControl(null, undefined,ValidateTelephoneWithApi(this.service,true)),
      poste: new FormControl(null),
      prixJour: new FormControl(null),
      disponibilite: new FormControl('8f486cd6-6313-47f9-a4b5-5bd535c199a9', Validators.required),
      idBoond: new FormControl('', Validators.required,ValidateIdBoondWithApi(this.service)),
    });
  }

  public ngOnInit(): void {
    this.populateData();
  }
  
  public return(): void {
    window.location.href = `/${ConstantesRoutes.commercialAccueilCreateDt}`;
  }

  public sendCandidat(): void {
    if(this.formGroup.valid){
      this.callRequest(ConstantesRequest.addDossierTechnique, this.service.addDossierTechnique(this.generateDossierTechniqueInsertRequestDto())
        .subscribe((response: string) => {
          window.location.href = "/Admin/TableauDeBord";
        }));
    }else{
      this.formGroup.markAllAsTouched();
    }
  }

  public nomPrenomChange(): void {
    const formValues = this.formGroup.value;
    let body = new GetTrigrammeRequestDto();
    body.nom =  formValues.nom ?? "";
    body.prenom = formValues.prenom ?? "";

    if(body.nom.length > 0 && body.prenom.length > 0){
      this.callRequest(ConstantesRequest.getTrigramme, this.service.getTrigramme(body)
      .subscribe((response: TrigrammeDto) => {
        this.formGroup.controls.trigram.setValue(response.valeur);
    }));
    }
  }

  public generateDossierTechniqueInsertRequestDto(): DossierTechniqueInsertRequestDto {
    const formValues = this.formGroup.value;
    const retour = new DossierTechniqueInsertRequestDto();
    retour.adresseMail = formValues.adresseMail ?? "";
    retour.disponibiliteId = formValues.disponibilite ?? "";
    retour.idBoond = formValues.idBoond ?? "";
    retour.nom = formValues.nom ?? "";
    retour.poste = formValues.poste;
    retour.prenom = formValues.prenom ?? "";
    retour.tarifJournalier = formValues.prixJour;
    retour.telephone = formValues.numeroTelephone1;
    retour.trigramme = formValues.trigram ?? "";
    retour.utilisateurId = this.userIdLogged;
    return retour;
  }

  public override populateData(): void {
    this.callRequest(ConstantesRequest.getUserLoggedDto, this.service.getUserLoggedDto()
        .subscribe((response: CustomUserLoggedDto) => {
          this.userIdLogged = response.userId;
        },() => {
          window.location.href = "/Admin";
        }));
    this.callRequest(ConstantesRequest.getReferences, this.service.getReferences(ConstantesTypesReferences.disponibilite)
        .subscribe((response: ReferenceDto[]) => {
          this.disponibilites = Reference.fromListReferenceDto(response);
          this.isReady = true;
        }));
  }
}

