import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Constantes } from 'src/app/shared/constantes/constantes';
import { CertificationForm } from 'src/app/shared/interfaces/certification-form';
import { Certification } from 'src/app/shared/models/certification.model';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { dateRangeValidator, maxDateTodayValidator } from 'src/app/shared/services/services/validators/validate-date';

@Component({
  selector: 'app-certification-dialog',
  templateUrl: './certification-dialog.component.html'
})

export class CertificationDialogComponent extends BaseComponentCallHttpComponent implements OnInit {
  public certification?: Certification;
  public formGroup: FormGroup<CertificationForm>;

  constructor(public activeModal: NgbActiveModal,
    private readonly service: ApiServiceAgent) {
      super();
      this.formGroup = new FormGroup<CertificationForm>({
      libelle: new FormControl(null, Validators.required),
      niveau: new FormControl(),
      organisme: new FormControl(null, Validators.required),
      dateDebut: new FormControl(null, [Validators.required, maxDateTodayValidator()]),
      dateFin: new FormControl(null, [maxDateTodayValidator()]),
    });

    this.formGroup.setValidators(dateRangeValidator('dateDebut', 'dateFin'));
  }

  public ngOnInit(): void {
    if (this.certification) {
      this.formGroup.patchValue({
        libelle: this.certification.libelle,
        niveau: this.certification.niveau,
        organisme: this.certification.organisme,
        dateDebut:  formatDate(this.certification.dateDebut, Constantes.formatDateFront, Constantes.formatDateLocale), 
        dateFin: this.certification.dateFin ? formatDate(this.certification.dateFin, Constantes.formatDateFront, Constantes.formatDateLocale) : undefined,
      });
    }
  }

  public submit(): void {
    if (this.formGroup.valid) {
      this.isLoading = true;
      const values = this.formGroup.value;
      let certification: Certification = this.certification ?? new Certification();
      certification.libelle = values.libelle!;
      certification.niveau = values.niveau;
      certification.organisme = values.organisme!;
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
