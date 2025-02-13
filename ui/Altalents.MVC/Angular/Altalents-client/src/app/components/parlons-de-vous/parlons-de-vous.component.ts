import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnInit, Output, Renderer2 } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { firstValueFrom } from 'rxjs';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { ParlonsDeVousForm } from 'src/app/shared/interfaces/parlons-de-vous-form';
import { AdresseUpdateRequestDto, DocumentDto, ParlonsDeVousDto, ParlonsDeVousUpdateRequestDto } from 'src/app/shared/services/generated/api/api.client';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { ValidateTelephoneWithApi } from 'src/app/shared/services/services/validators/validate-telephone-with-api';
import { ParlonsDeVous } from 'src/app/shared/models/parlons-de-vous.model';
import { PieceJointe } from 'src/app/shared/models/piece-jointe.model';
import { PermissionDT } from 'src/app/shared/models/permissionDT.model';
import { PermissionService } from 'src/app/shared/services/services/security/permission-service';

@Component({
  selector: 'app-parlons-de-vous',
  templateUrl: './parlons-de-vous.component.html',
  styleUrls: ['./parlons-de-vous.component.scss']
})
export class ParlonsDeVousComponent extends BaseComponentCallHttpComponent implements OnInit  {
  @Input() public tokenDossierTechnique: string = "";
  @Input() public permissionDT: PermissionDT = new PermissionDT();
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();
  @Output() public stepperUpdate: EventEmitter<void> = new EventEmitter<void>();
  
  public formGroup!: FormGroup<ParlonsDeVousForm>;
  public parlonsDeVous: ParlonsDeVous = new ParlonsDeVous();
  public errorMessageFile: string | null = null;
  public isDragging: boolean = false;
  
  constructor(
    private readonly service: ApiServiceAgent,
    private permissionService: PermissionService, 
    private el: ElementRef,
    private renderer: Renderer2
  ) 
  {
    super();

    this.formGroup = new FormGroup<ParlonsDeVousForm>({
      prenom: new FormControl(this.parlonsDeVous.prenom!, Validators.required),
      nom: new FormControl('', Validators.required),
      numeroTelephone1: new FormControl('', Validators.required, ValidateTelephoneWithApi(this.service, true)),
      adresseMail: new FormControl('', [Validators.required, Validators.email]),
      zoneGeo: new FormControl('', Validators.required),
      adresse1: new FormControl(null),
      adresse2: new FormControl(null),
      codePostal: new FormControl(null),
      ville: new FormControl(null),
      pays: new FormControl(null),
      synthese : new FormControl('', Validators.required),
      fileInput : new FormControl('', Validators.required),
      softSkills : new FormControl(null),
    });
  }

  public async ngOnInit(): Promise<void> {
    // Appeler la méthode pour obtenir la permission et attendre sa résolution
    this.stepperUpdate.emit(); 

    // Vérifier si le dossier technique est accessible
    if (this.permissionDT.isDtAccessible) {
      this.validationCallback.emit(() => this.submit());

      this.populateData();
      this.formGroup.get('adresseMail')?.disable();
    }
  }

  public ngAfterViewInit(): void {
    // Déplacer la logique ici pour désactiver les champs si nécessaire
    if (this.permissionDT.isDtReadOnly) {
      this.permissionService.disableAllFields(this.el, this.renderer);
    }
  }


  public populateData(): void {
    this.isLoading = true;
    this.callRequest(ConstantesRequest.getParlonsDeVous, this.service.getParlonsDeVous(this.tokenDossierTechnique)
        .subscribe((response: ParlonsDeVousDto) => {
          this.parlonsDeVous = ParlonsDeVous.from(response);

          if (this.parlonsDeVous) {

            this.formGroup.patchValue({
              prenom : this.parlonsDeVous.prenom,
              nom: this.parlonsDeVous.nom,
              numeroTelephone1: this.parlonsDeVous.telephone1,
              adresseMail:  this.parlonsDeVous.email,
              adresse1:  this.parlonsDeVous.adresse?.adresse1,
              adresse2: this.parlonsDeVous.adresse?.adresse2,
              ville: this.parlonsDeVous.adresse?.ville,
              codePostal: this.parlonsDeVous.adresse?.codePostal,
              pays: this.parlonsDeVous.adresse?.pays,
              synthese: this.parlonsDeVous.synthese,
              // fileInput: this.parlonsDeVous.pieceJointe?.data,
              zoneGeo: this.parlonsDeVous.zoneGeo,
              softSkills: this.parlonsDeVous.softSKills,
            }, { emitEvent: false });
          }


          // Vérification si pieceJointe est définie pour ajuster la validation
          if (this.parlonsDeVous.pieceJointe) {
            this.formGroup.get('fileInput')?.clearValidators();
          } else {
            this.formGroup.get('fileInput')?.setValidators(Validators.required);
          }
          this.formGroup.get('fileInput')?.updateValueAndValidity();

          this.isLoading = false;
        }));
  }



  triggerFileInput(): void {
    document.querySelector<HTMLInputElement>('#fileInput')?.click();
  }

// Gérer le survol de la zone
public onDragOver(event: DragEvent): void {
  event.preventDefault();
  this.isDragging = true;
}

// Gérer la sortie de la zone
public onDragLeave(event: DragEvent): void {
  event.preventDefault();
  this.isDragging = false;
}

// Gérer le dépôt d'un fichier
public async onDrop(event: DragEvent): Promise<void> {
  event.preventDefault();
  this.isDragging = false;
  const fichiers = event.dataTransfer?.files;
  await this.ProcessFileList(fichiers!);
}


  public async onFileUploadChange(event: Event): Promise<void> {
    const fichiers: FileList | null = (event.target as HTMLInputElement).files;
    await this.ProcessFileList(fichiers!);
  }


  private async ProcessFileList(fichiers:FileList) {
    this.errorMessageFile = null;
    if (fichiers && fichiers.length > 0) {

        const file: File = fichiers[0];

        // Vérification de la taille : 5 Mo = 5 * 1024 * 1024 octets
        const MAX_SIZE_MB = 5 * 1024 * 1024; 
        if (file.size > MAX_SIZE_MB) {
          this.errorMessageFile = "Le fichier sélectionné dépasse la taille maximale de 5 Mo.";
          return;
        }

          // Validation du type de fichier : PDF ou Word (DOCX)
        const validMimeTypes = ['application/pdf', 'application/vnd.openxmlformats-officedocument.wordprocessingml.document'];
        if (!validMimeTypes.includes(file.type)) {
          this.errorMessageFile = "Le fichier doit être un PDF ou un document Word (.docx).";
          return;
        }
    


        this.parlonsDeVous.pieceJointe = this.parlonsDeVous.pieceJointe ?? new PieceJointe();

        this.parlonsDeVous.pieceJointe.id = undefined;
        this.parlonsDeVous.pieceJointe.mimeType = file.type;

        this.parlonsDeVous.pieceJointe.nomFichier = file.name;

        this.isLoading = true;

        this.parlonsDeVous.pieceJointe.data = await PieceJointe.toBase64(file)
      
        .then((data: string) => {

          this.formGroup.get('fileInput')?.setValue(data);
          return data;
        });

      this.isLoading = false;
    }
  }

  public downloadPj()
  {
    
    if (!this.parlonsDeVous.pieceJointe || !this.parlonsDeVous.pieceJointe.id) {
      // Cas où pieceJointe ou Id est null : téléchargement à partir de la donnée base64
      const link = document.createElement("a");
      link.href = "data:" + this.parlonsDeVous.pieceJointe?.mimeType + ";base64," + this.parlonsDeVous.pieceJointe?.data;
      link.download = this.parlonsDeVous.pieceJointe?.nomFichier!;
      link.click();
     
    } else {
        this.isLoading = true;
        this.callRequest(ConstantesRequest.getCvFile, this.service.getCvFile(this.tokenDossierTechnique)
        .subscribe((response: DocumentDto) => {
          var a = document.createElement("a"); 
          a.href = "data:" + response.mimeType + ";base64," + response.data;
          a.download = response.nomFichier; 
          a.click(); 
          this.isLoading = false;
        }));
    }
  }

  private async submit(): Promise<boolean> {
    let isValid: boolean = false;
    if (this.formGroup.valid) {
      this.isLoading = true;
      this.formGroup.get('adresseMail')?.enable();
      // On n'utilise pas callRequest ici pour pouvoir await l'appel au back.
      await firstValueFrom(this.service.putParlonsDeVous(this.tokenDossierTechnique, this.populateRequestDto())).then(() => {
        isValid = true;
        this.isLoading = false;
      });
    } else {
      this.formGroup.markAllAsTouched();
    }

    return new Promise<boolean>(resolve => resolve(isValid));
  }

  private populateRequestDto(): ParlonsDeVousUpdateRequestDto {
    const values = this.formGroup.value;
    let adresseRequestDto: AdresseUpdateRequestDto = new AdresseUpdateRequestDto();
    adresseRequestDto.adresse1 = values.adresse1 ?? "";
    adresseRequestDto.adresse2 = values.adresse2;
    adresseRequestDto.codePostal = values.codePostal ?? "";
    adresseRequestDto.ville = values.ville ?? "";
    adresseRequestDto.pays = values.pays ?? "";

    let requestDto: ParlonsDeVousUpdateRequestDto = new ParlonsDeVousUpdateRequestDto();

    requestDto.nom = values.nom ?? "";
    requestDto.prenom = values.prenom ?? "";
    requestDto.telephone1 = values.numeroTelephone1 ?? "";
    requestDto.email = values.adresseMail ?? "";
    requestDto.adresse = adresseRequestDto;
    requestDto.synthese = values.synthese;
    requestDto.zoneGeo = values.zoneGeo ?? "";
    requestDto.softSKills = values.softSkills;
    requestDto.cv = this.parlonsDeVous.pieceJointe ? PieceJointe.populateDocumentDto(this.parlonsDeVous.pieceJointe) : undefined;

    return requestDto;
  }
}
