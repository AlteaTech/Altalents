import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Constantes } from 'src/app/shared/constantes/constantes';
import { CertificationForm } from 'src/app/shared/interfaces/certification-form';
import { Certification } from 'src/app/shared/models/certification.model';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { dateRangeValidator, maxDateThisMonthValidator, maxDateTodayValidator } from 'src/app/shared/services/services/validators/validate-date';

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
      dateObtention: new FormControl(null, [Validators.required, maxDateThisMonthValidator()]),
      
    });


  }

  public ngOnInit(): void {
    if (this.certification) {
      this.formGroup.patchValue({
        libelle: this.certification.libelle,
        niveau: this.certification.niveau,
        organisme: this.certification.organisme,
        dateObtention:  this.certification.dateObtention, 
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
      certification.dateObtention = values.dateObtention ? new Date(values.dateObtention) : new Date();
      this.activeModal.close(certification);
    }else {
      this.formGroup.markAllAsTouched();
    }
  }

  public closeDialog(): void {
    this.activeModal.close();
  }
}
