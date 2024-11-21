import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Constantes } from 'src/app/shared/constantes/constantes';
import { CertificationForm } from 'src/app/shared/interfaces/certification-form';
import { Certification } from 'src/app/shared/models/certification.model';

@Component({
  selector: 'app-certification-dialog',
  templateUrl: './certification-dialog.component.html'
})

export class CertificationDialogComponent implements OnInit {
  public certification?: Certification;
  public formGroup: FormGroup<CertificationForm>;

  constructor(public activeModal: NgbActiveModal) {
    this.formGroup = new FormGroup<CertificationForm>({
      libelle: new FormControl(null, Validators.required),
      domaine: new FormControl(),
      niveau: new FormControl(),
      organisme: new FormControl(),
      dateDebut: new FormControl(null, Validators.required),
      dateFin: new FormControl(),
    });
  }

  public ngOnInit(): void {
    if (this.certification) {
      this.formGroup.patchValue({
        libelle: this.certification.libelle,
        domaine: this.certification.domaine,
        niveau: this.certification.niveau,
        organisme: this.certification.organisme,
        dateDebut:  formatDate(this.certification.dateDebut, Constantes.formatDateFront, Constantes.formatDateLocale), 
        dateFin: this.certification.dateFin ? formatDate(this.certification.dateFin, Constantes.formatDateFront, Constantes.formatDateLocale) : undefined,
      });
    }
  }

  public submit(): void {
    if (this.formGroup.valid) {
      const values = this.formGroup.value;
      let certification: Certification = this.certification ?? new Certification();
      certification.libelle = values.libelle!;
      certification.domaine = values.domaine;
      certification.niveau = values.niveau;
      certification.organisme = values.organisme;
      certification.dateDebut = values.dateDebut ? new Date(values.dateDebut) : new Date();
      certification.dateFin = values.dateFin ? new Date(values.dateFin) : undefined;
      
      this.activeModal.close(certification);
    }else {
      this.formGroup.markAllAsTouched();
    }
  }

  public closeDialog(): void {
    this.activeModal.close();
  }
}
