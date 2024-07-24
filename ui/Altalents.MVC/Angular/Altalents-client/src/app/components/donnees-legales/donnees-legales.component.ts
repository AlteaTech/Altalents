import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DonneesLegalesForm } from 'src/app/shared/interfaces/donnees-legales-form';

@Component({
  selector: 'app-donnees-legales',
  templateUrl: './donnees-legales.component.html',
  styleUrls: ['./donnees-legales.component.scss','../../app.component.css']
})
export class DonneesLegalesComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();

  public donneesLegales: string = "";
  public formGroup: FormGroup<DonneesLegalesForm>;

  constructor() {
    this.formGroup = new FormGroup<DonneesLegalesForm>({
      prenom: new FormControl('', Validators.required),
      nom: new FormControl('', Validators.required),
      numeroTelephone1: new FormControl('', Validators.required),
      numeroTelephone2: new FormControl(null),
      adresseMail: new FormControl('', Validators.required),
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

    if(this.formGroup.valid){
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
