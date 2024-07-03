import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DonneesLegalesForm } from 'src/app/shared/interfaces/donnees-legales-form';
import { FormationForm } from 'src/app/shared/interfaces/formation-form';
import { Formation } from 'src/app/shared/models/formation.model';

@Component({
  selector: 'app-formation-dialog',
  templateUrl: './formation-dialog.component.html'
})
export class FormationDialogComponent implements OnInit {
  @Input() public formation?: Formation;
  @Output() public validationCallback: EventEmitter<() => Promise<Formation | undefined>> = new EventEmitter();
  @ViewChild('dialog', { static: false }) dialog!: ElementRef<HTMLDialogElement>;
  
  public formGroup: FormGroup<FormationForm>;

  constructor() {
    this.formGroup = new FormGroup<FormationForm>({
      formationLibelle: new FormControl(),
      domaine: new FormControl(),
      niveau: new FormControl(),
      organisme: new FormControl(),
      dateDebut: new FormControl(),
      dateFin: new FormControl(),
    });
  }

  public ngOnInit(): void {
    if(this.formation){
      this.formGroup.patchValue({
        formationLibelle: this.formation.formationLibelle,
        domaine: this.formation.domaine,
        niveau: this.formation.niveau,
        organisme: this.formation.organisme,
        dateDebut: this.formation.dateDebut,
        dateFin: this.formation.dateFin 
      });
    }

    this.validationCallback.emit(() => this.submit());
  }

  public openDialog(): void {
    this.dialog.nativeElement.show();
  }

  public closeDialog(): void {
    this.dialog.nativeElement.close();
  }

  private submit(): Promise<Formation | undefined> {
    let formation: Formation;

    if(this.formGroup.valid){
      const values = this.formGroup.value;
      formation = new Formation();
      formation.formationLibelle = values.formationLibelle;
      formation.domaine = values.domaine;
      formation.niveau = values.niveau;
      formation.organisme = values.organisme;
      formation.dateDebut = values.dateDebut;
      formation.dateFin = values.dateFin;
    }

    return new Promise<Formation | undefined>(resolve => resolve(formation));
  }
}
