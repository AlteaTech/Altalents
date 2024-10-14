import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { firstValueFrom } from 'rxjs';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { ParlonsDeVousForm } from 'src/app/shared/interfaces/parlons-de-vous-form';
import { AdresseUpdateRequestDto, ParlonsDeVousDto, ParlonsDeVousUpdateRequestDto } from 'src/app/shared/services/generated/api/api.client';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { ValidateEmailWithApi } from 'src/app/shared/services/services/validators/validate-email-with-api';
import { ValidateIsNumber } from 'src/app/shared/services/services/validators/validate-is-number';
import { ValidateTelephoneWithApi } from 'src/app/shared/services/services/validators/validate-telephone-with-api';

@Component({
  selector: 'app-parlons-de-vous',
  templateUrl: './parlons-de-vous.component.html',
  styleUrls: ['./parlons-de-vous.component.scss']
})
export class ParlonsDeVousComponent extends BaseComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();

  public formGroup!: FormGroup<ParlonsDeVousForm>;

  constructor(private readonly service: ApiServiceAgent) {
    super();
  }

  public ngOnInit(): void {
    this.validationCallback.emit(() => this.submit());
    this.formGroup = new FormGroup<ParlonsDeVousForm>({
      prenom: new FormControl('', Validators.required),
      nom: new FormControl('', Validators.required),
      numeroTelephone1: new FormControl('', Validators.required, ValidateTelephoneWithApi(this.service, true)),
      numeroTelephone2: new FormControl(null, undefined, ValidateTelephoneWithApi(this.service, true)),
      adresseMail: new FormControl('', Validators.required, ValidateEmailWithApi(this.service, this.tokenDossierTechnique)),
      adresse1: new FormControl('', Validators.required),
      adresse2: new FormControl(null),
      codePostal: new FormControl('', Validators.required, ValidateIsNumber()),
      ville: new FormControl('', Validators.required),
      pays: new FormControl('', Validators.required)
    });
    this.populateData();
  }

  public override populateData(): void {
    this.isLoading = true;
    this.callRequest(ConstantesRequest.getParlonsDeVous, this.service.getParlonsDeVous(this.tokenDossierTechnique)
        .subscribe((response: ParlonsDeVousDto) => {
          this.formGroup.patchValue({
            prenom: response.prenom,
            nom: response.nom,
            numeroTelephone1: response.telephone1,
            numeroTelephone2: response.telephone2,
            adresseMail: response.email,
            adresse1: response.adresse?.adresse1,
            adresse2: response.adresse?.adresse2,
            codePostal: response.adresse?.codePostal,
            ville: response.adresse?.ville,
            pays: response.adresse?.pays
          });
          this.isLoading = false;
        }));
  }

  private async submit(): Promise<boolean> {
    let isValid: boolean = false;
    if (this.formGroup.valid) {
      this.isLoading = true;
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
    requestDto.telephone2 = values.numeroTelephone2;
    requestDto.email = values.adresseMail ?? "";
    requestDto.adresse = adresseRequestDto;
    return requestDto;
  }
}
