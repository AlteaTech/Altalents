import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';
import { ConstantesTypesReferences } from 'src/app/shared/constantes/constantes-types-references';
import { CreationDtCommercialForm } from 'src/app/shared/interfaces/creation-dt-commercial-form';
import { Reference } from 'src/app/shared/models/reference.model';
import { CustomUserLoggedDto, DocumentDto, DossierTechniqueInsertRequestDto, GetTrigrammeRequestDto, ReferenceDto, TrigrammeDto } from 'src/app/shared/services/generated/api/api.client';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { ValidateEmailWithApi } from 'src/app/shared/services/services/validators/validate-email-with-api';
import { ValidateIdBoondWithApi } from 'src/app/shared/services/services/validators/validate-idboond-with-api';
import { ValidateTelephoneWithApi } from 'src/app/shared/services/services/validators/validate-telephone-with-api';
import { ValidateTrigramWithApi } from 'src/app/shared/services/services/validators/validate-trigram-with-api';
import { QuestionnaireDialogComponent } from '../dialogs/questionnaire-dialog/questionnaire-dialog.component';
import { PieceJointeDialogComponent } from '../dialogs/piece-jointe-dialog/piece-jointe-dialog.component';
import { PieceJointe } from 'src/app/shared/models/piece-jointe.model';
import { Question } from 'src/app/shared/models/question.model';
import { ConfirmDeleteDialogComponent } from '../dialogs/confirm-delete-dialog/confirm-delete-dialog.component';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { MODAL_OPTIONS_LG } from 'src/app/shared/modal-options';

@Component({
  selector: 'app-commercial-creation-dt-configuration',
  templateUrl: './commercial-creation-dt-configuration.component.html',
  styleUrls: ['./commercial-creation-dt-configuration.component.scss']
})
export class CommercialCreationDtConfigurationComponent  extends BaseComponentCallHttpComponent  implements OnInit, OnDestroy   {
  public formGroup: FormGroup<CreationDtCommercialForm>;
  public userIdLogged: string | undefined;
  public disponibilites: Reference[] = [];
  public questions: Question[] | undefined;
  public piecesJointes: PieceJointe[] = [];



  constructor(private modalService: NgbModal,
    private readonly service: ApiServiceAgent) {
    super();
    this.formGroup = new FormGroup<CreationDtCommercialForm>({
      prenom: new FormControl('', Validators.required),
      nom: new FormControl('', Validators.required),
      trigram: new FormControl('', Validators.required,ValidateTrigramWithApi(this.service)),
      adresseMail: new FormControl('', Validators.required,ValidateEmailWithApi(this.service, undefined)),
      numeroTelephone1: new FormControl(null, undefined,ValidateTelephoneWithApi(this.service,true)),
      poste: new FormControl(null),
      isPrixJourEnable: new FormControl(false),
      prixJour: new FormControl(null),
      disponibilite: new FormControl('8f486cd6-6313-47f9-a4b5-5bd535c199a9', Validators.required),
      idBoond: new FormControl('', Validators.required,ValidateIdBoondWithApi(this.service)),
    });
  }

  public ngOnInit(): void {
    this.populateData();
    this.updateInputPrixJour();
  }
  
  public return(): void {
    window.location.href = `/${ConstantesRoutes.commercialAccueilCreateDt}`;
  }

  public sendCandidat(): void {
    if(this.formGroup.valid){
      this.isLoading = true;
      this.callRequest(ConstantesRequest.addDossierTechnique, this.service.addDossierTechnique(this.generateDossierTechniqueInsertRequestDto())
        .subscribe((response: string) => {
          this.isLoading = false;
          window.location.href = "/Admin/TableauDeBord";
        }));
    }else{
      this.formGroup.markAllAsTouched();
    }
  }
  public downloadPj(i: number): void {
    const pieceJointe = this.piecesJointes[i];
    if (pieceJointe) {
      const a = document.createElement("a"); // Crée un élément <a> pour le téléchargement
      a.href = "data:" + pieceJointe.mimeType + ";base64," + pieceJointe.data;  // Utilisation de base64 pour le téléchargement
      a.download = pieceJointe.nomFichier; // Nom du fichier à télécharger
      a.click();  // Lance le téléchargement
    } else {
      alert("Erreur : la pièce jointe est introuvable.");
    }
  }

  public nomPrenomChange(): void {
    const formValues = this.formGroup.value;
    let body = new GetTrigrammeRequestDto();
    body.nom =  formValues.nom ?? "";
    body.prenom = formValues.prenom ?? "";

    if(body.nom.length > 0 && body.prenom.length > 0){
      this.isLoading = true;
      this.callRequest(ConstantesRequest.getTrigramme, this.service.getTrigramme(body)
        .subscribe((response: TrigrammeDto) => {
          this.formGroup.controls.trigram.setValue(response.valeur);
          this.isLoading = false;
      }));
    }
  }

  public onAjouterQuestionnaireClick(): void {

    let dialogRef: NgbModalRef = this.modalService.open(QuestionnaireDialogComponent, MODAL_OPTIONS_LG);
    dialogRef.componentInstance.questions = this.questions;
    dialogRef.result.then((nouvelElement: Question[] | undefined) => {
      if(nouvelElement) {
        this.questions = nouvelElement;
      }
    })
  }

  public onAjouterDocumentClick(): void {

    let dialogRef: NgbModalRef = this.modalService.open(PieceJointeDialogComponent, MODAL_OPTIONS_LG);
    dialogRef.componentInstance.modalTitle = "Document pour le candidat";
    dialogRef.result.then((nouvelElement: PieceJointe | undefined) => {
      if (nouvelElement) {
        this.piecesJointes.push(nouvelElement); // Ajout à la liste des pièces jointes
      }
    }).catch(() => {
      // Modal fermée sans action
    });
  }

  public onModifierDocumentClick(i: number): void {

  
    let dialogRef: NgbModalRef = this.modalService.open(PieceJointeDialogComponent, MODAL_OPTIONS_LG);
    dialogRef.componentInstance.modalTitle = "Document pour le candidat";
    dialogRef.componentInstance.pieceJointe = this.piecesJointes[i];  // Passage du document à modifier
    dialogRef.result.then((nouvelElement: PieceJointe | undefined) => {
      if (nouvelElement) {
        // Remplacer l'élément modifié par celui retourné
        this.piecesJointes[i] = nouvelElement;
      }
    }).catch(() => {
      // Modal fermée sans action
    });
  }

  public removePieceJointe(i: number, nomFichier : string): void {


    let dialogRef: NgbModalRef = this.modalService.open(ConfirmDeleteDialogComponent, MODAL_OPTIONS_LG);
    dialogRef.componentInstance.itemName = nomFichier;
    dialogRef.result.then((validated: boolean | undefined) => {
      if(validated) {
        this.piecesJointes.splice(i, 1); 
      }
    })
  }

  private generateDossierTechniqueInsertRequestDto(): DossierTechniqueInsertRequestDto {
    
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
    retour.questionnaires = this.questions ? Question.toList(this.questions) : undefined;
    retour.documents = PieceJointe.fromListToDtos(this.piecesJointes);

    return retour;
  }


  public populateData(): void {
    this.isLoading = true;
    const nbAppelsAsync = 2;

    this.callRequest(ConstantesRequest.getUserLoggedDto, this.service.getUserLoggedDto()
        .subscribe((response: CustomUserLoggedDto) => {
          this.userIdLogged = response.userId;
          this.checkLoadingTermine(nbAppelsAsync);
        },() => {
          window.location.href = "/Admin";
        }));
    this.callRequest(ConstantesRequest.getReferences, this.service.getReferences(ConstantesTypesReferences.disponibilite)
        .subscribe((response: ReferenceDto[]) => {
          this.disponibilites = Reference.fromListReferenceDto(response);
          this.checkLoadingTermine(nbAppelsAsync);
        }));
  }

  public updateInputPrixJour(): void {
    let controls = this.formGroup.controls;
    controls.isPrixJourEnable.value ? controls.prixJour.enable() : controls.prixJour.disable();
  }
  
}

