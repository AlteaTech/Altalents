import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Constantes } from 'src/app/shared/constantes/constantes';
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
      libelle: new FormControl(null, Validators.required),
      domaine: new FormControl(),
      niveau: new FormControl(),
      organisme: new FormControl(),
      dateDebut: new FormControl(null, Validators.required),
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
        dateDebut:  formatDate(this.formation.dateDebut, Constantes.formatDateFront, Constantes.formatDateLocale), 
        dateFin: this.formation.dateFin ? formatDate(this.formation.dateFin, Constantes.formatDateFront, Constantes.formatDateLocale) : undefined,
      });
    }
  }

  public submit(): void {
    if (this.formGroup.valid) {
      const values = this.formGroup.value;
      let formation: Formation = this.formation ?? new Formation();
      formation.libelle = values.libelle!;
      formation.domaine = values.domaine;
      formation.niveau = values.niveau;
      formation.organisme = values.organisme;
      formation.dateDebut = values.dateDebut ? new Date(values.dateDebut) : new Date();
      formation.dateFin = values.dateFin ? new Date(values.dateFin) : undefined;

      this.activeModal.close(formation);
    } else {
      this.formGroup.markAllAsTouched();
    }
  }

  public closeDialog(): void {
    this.activeModal.close();
  }
}
