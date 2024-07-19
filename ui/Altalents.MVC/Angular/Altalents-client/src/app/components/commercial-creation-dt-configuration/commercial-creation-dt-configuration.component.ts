import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';
import { ConstantesTypesReferences } from 'src/app/shared/constantes/constantes-types-references';
import { CreationDtCommercialForm } from 'src/app/shared/interfaces/creation-dt-commercial-form';
import { ReferenceFun } from 'src/app/shared/models/ReferenceFun';
import { CustomUserLoggedDto, DossierTechniqueInsertRequestDto, GetTrigrammeRequestDto, ReferenceDto, TrigrammeDto } from 'src/app/shared/services/generated/api/api.client';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';

@Component({
  selector: 'app-commercial-creation-dt-configuration',
  templateUrl: './commercial-creation-dt-configuration.component.html',
  styleUrls: ['./commercial-creation-dt-configuration.component.css','../../app.component.css']
})

export class CommercialCreationDtConfigurationComponent  extends BaseComponent  implements OnInit, OnDestroy   {

  public formGroup: FormGroup<CreationDtCommercialForm>;
  pathConfigDt: string = `${ConstantesRoutes.commercialAccueilCreateDt}`;
  userIdLogged: string | undefined;
  isReady = false;
  disponibilites: ReferenceFun[] = [];

  constructor(
    private readonly service: ApiServiceAgent) {
    super();
    this.formGroup = new FormGroup<CreationDtCommercialForm>({
      prenom: new FormControl('', Validators.required),
      nom: new FormControl('', Validators.required),
      trigram: new FormControl('', Validators.required),
      adresseMail: new FormControl('', Validators.required),
      numeroTelephone1: new FormControl(null),
      poste: new FormControl(null),
      prixJour: new FormControl(null),
      disponibilite: new FormControl('8f486cd6-6313-47f9-a4b5-5bd535c199a9', Validators.required),
      idBoond: new FormControl('', Validators.required),
    });
  }

  ngOnInit(): void {
    this.populateData();
  }

  sendCancidat() {
    if(this.formGroup.valid){
      this.callRequest(ConstantesRequest.addDossierTechnique, this.service.addDossierTechnique(this.generateDossierTechniqueInsertRequestDto())
        .subscribe((response: string) => {
          window.location.href = "/Admin/TableauDeBord";
        }));
    }
  }

  nomPrenomChange() {
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

  generateDossierTechniqueInsertRequestDto(): DossierTechniqueInsertRequestDto {

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
          this.disponibilites = ReferenceFun.fromListReferenceDto(response);
          this.isReady = true;
        }));
  }
}


