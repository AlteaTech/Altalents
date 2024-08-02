import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { DonneesLegalesForm as ParlonsDeVousForm } from 'src/app/shared/interfaces/parlons-de-vous-form';
import { ParlonsDeVous } from 'src/app/shared/models/parlons-de-vous.model';
import { ParlonsDeVousDto } from 'src/app/shared/services/generated/api/api.client';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { ValidateEmailWithApi } from 'src/app/shared/services/services/validators/validate-email-with-api';
import { ValidateIsNumber } from 'src/app/shared/services/services/validators/validate-is-number';
import { ValidateTelephoneWithApi } from 'src/app/shared/services/services/validators/validate-telephone-with-api';

@Component({
  selector: 'app-parlons-de-vous',
  templateUrl: './parlons-de-vous.component.html',
  styleUrls: ['./parlons-de-vous.component.scss', '../../app.component.css']
})
export class ParlonsDeVousComponent extends BaseComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();

  public parlonsDeVous: ParlonsDeVous = new ParlonsDeVous();
  public formGroup: FormGroup<ParlonsDeVousForm>;

  constructor(private readonly service: ApiServiceAgent) {
    super();
    this.formGroup = new FormGroup<ParlonsDeVousForm>({
      prenom: new FormControl('', Validators.required),
      nom: new FormControl('', Validators.required),
      numeroTelephone1: new FormControl('', Validators.required, ValidateTelephoneWithApi(this.service, true)),
      numeroTelephone2: new FormControl(null, undefined, ValidateTelephoneWithApi(this.service, true)),
      adresseMail: new FormControl('', Validators.required, ValidateEmailWithApi(this.service)),
      adresse1: new FormControl('', Validators.required),
      adresse2: new FormControl(null),
      codePostal: new FormControl('', Validators.required, ValidateIsNumber()),
      ville: new FormControl('', Validators.required),
      pays: new FormControl('', Validators.required)
    });
  }

  public ngOnInit(): void {
    this.validationCallback.emit(() => this.submit());
    this.populateData();
  }

  public override populateData(): void {
    this.callRequest(ConstantesRequest.getParlonsDeVous, this.service.getParlonsDeVous(this.tokenDossierTechnique)
        .subscribe((response: ParlonsDeVousDto) => {
          this.parlonsDeVous = ParlonsDeVous.from(response);
        }));
  }

  private submit(): Promise<boolean> {
    let isValid: boolean = false;

    if (this.formGroup.valid) {
      // Appeler la route de save
      isValid = true;
    }else{
      this.formGroup.markAllAsTouched();
    }

    return new Promise<boolean>(resolve => resolve(isValid));
  }
}
