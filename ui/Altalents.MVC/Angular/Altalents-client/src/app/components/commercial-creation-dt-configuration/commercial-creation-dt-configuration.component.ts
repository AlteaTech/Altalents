import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';
import { CreationDtCommercialForm } from 'src/app/shared/interfaces/creation-dt-commercial-form';

@Component({
  selector: 'app-commercial-creation-dt-configuration',
  templateUrl: './commercial-creation-dt-configuration.component.html',
  styleUrls: ['./commercial-creation-dt-configuration.component.css','../../app.component.css']
})
export class CommercialCreationDtConfigurationComponent {

  public formGroup: FormGroup<CreationDtCommercialForm>;
  pathConfigDt: string = `${ConstantesRoutes.commercialAccueilCreateDt}`;

  constructor() {
    this.formGroup = new FormGroup<CreationDtCommercialForm>({
      prenom: new FormControl('', Validators.required),
      nom: new FormControl('', Validators.required),
      trigram: new FormControl('', Validators.required),
      adresseMail: new FormControl('', Validators.required),
      numeroTelephone1: new FormControl(null),
      poste: new FormControl(null),
      prixJour: new FormControl(null),
      disponibilite: new FormControl('', Validators.required),
      idboond: new FormControl('', Validators.required),
    });
  }
}
