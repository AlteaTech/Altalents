import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DonneesLegalesForm } from 'src/app/shared/interfaces/donnees-legales-form';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { ValidateEmailWithApi } from 'src/app/shared/services/services/validators/validate-email-with-api';
import { ValidateTelephoneWithApi } from 'src/app/shared/services/services/validators/validate-telephone-with-api';

@Component({
  selector: 'app-donnees-legales',
  templateUrl: './donnees-legales.component.html',
  styleUrls: ['./donnees-legales.component.scss', '../../app.component.css']
})
export class DonneesLegalesComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();

  public donneesLegales: string = "";
  public formGroup: FormGroup<DonneesLegalesForm>;

  constructor(private readonly service: ApiServiceAgent) {
    this.formGroup = new FormGroup<DonneesLegalesForm>({
      prenom: new FormControl('', Validators.required),
      nom: new FormControl('', Validators.required),
      numeroTelephone1: new FormControl('', Validators.required, ValidateTelephoneWithApi(this.service, true)),
      numeroTelephone2: new FormControl(null, undefined, ValidateTelephoneWithApi(this.service, true)),
      adresseMail: new FormControl('', Validators.required, ValidateEmailWithApi(this.service)),
      adresse1: new FormControl('', Validators.required),
      adresse2: new FormControl(null),
      codePostal: new FormControl('', Validators.required),
      ville: new FormControl('', Validators.required),
      pays: new FormControl('', Validators.required)
    });
  }

  public ngOnInit(): void {
    this.validationCallback.emit(() => this.submit());
    this.loadData();
  }

  private submit(): Promise<boolean> {
    let isValid: boolean = false;

    if (this.formGroup.valid) {
      // Appeler la route de save
      isValid = true;
    }

    return new Promise<boolean>(resolve => resolve(isValid));
  }

  private loadData(): void {
    // TODO : appeler le back pour avoir les infos
    this.donneesLegales = "";
  }
}
