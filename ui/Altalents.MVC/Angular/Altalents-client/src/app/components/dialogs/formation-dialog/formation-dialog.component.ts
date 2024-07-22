import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormationForm } from 'src/app/shared/interfaces/formation-form';
import { Formation } from 'src/app/shared/models/formation.model';

@Component({
  selector: 'app-formation-dialog',
  templateUrl: './formation-dialog.component.html'
})
export class FormationDialogComponent implements OnInit {
  public formation?: Formation;
  public formGroup: FormGroup<FormationForm>;

  constructor(public activeModal: NgbActiveModal) {
    this.formGroup = new FormGroup<FormationForm>({
      libelle: new FormControl(),
      domaine: new FormControl(),
      niveau: new FormControl(),
      organisme: new FormControl(),
      dateDebut: new FormControl(),
      dateFin: new FormControl(),
    });
  }

  public ngOnInit(): void {
    if (this.formation) {
      this.formGroup.patchValue({
        libelle: this.formation.libelle,
        domaine: this.formation.domaine,
        niveau: this.formation.niveau,
        organisme: this.formation.organisme,
        dateDebut: this.formation.dateDebut,
        dateFin: this.formation.dateFin 
      });
    }
  }

  public submit(): void {
    if (this.formGroup.valid) {
      const values = this.formGroup.value;
      let formation: Formation = this.formation ?? new Formation();
      formation.libelle = values.libelle;
      formation.domaine = values.domaine;
      formation.niveau = values.niveau;
      formation.organisme = values.organisme;
      formation.dateDebut = values.dateDebut;
      formation.dateFin = values.dateFin;
      
      this.activeModal.close(formation);
    }
  }

  public closeDialog(): void {
    this.activeModal.close();
  }
}
