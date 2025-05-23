import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Constantes } from 'src/app/shared/constantes/constantes';
import { FormationForm } from 'src/app/shared/interfaces/formation-form';
import { Formation } from 'src/app/shared/models/formation.model';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { dateRangeValidator, maxDateThisMonthValidator, maxDateTodayValidator } from 'src/app/shared/services/services/validators/validate-date';

@Component({
  selector: 'app-formation-dialog',
  templateUrl: './formation-dialog.component.html'
})
export class FormationDialogComponent extends BaseComponentCallHttpComponent  implements OnInit {
  public formation?: Formation;
  public formGroup: FormGroup<FormationForm>;

  constructor(public activeModal: NgbActiveModal,
    private readonly service: ApiServiceAgent) {
    super();
    this.formGroup = new FormGroup<FormationForm>({
      libelle: new FormControl(null, Validators.required),
      niveau: new FormControl(),
      organisme: new FormControl(null, Validators.required),
      dateObtention: new FormControl(null, [Validators.required, maxDateThisMonthValidator()]),

    });
  }

  public ngOnInit(): void {
    if (this.formation) {
      this.formGroup.patchValue({
        libelle: this.formation.libelle,
        niveau: this.formation.niveau,
        organisme: this.formation.organisme,
        dateObtention:  this.formation.dateObtention, 
      });
    }
  }

  public submit(): void {
    if (this.formGroup.valid) {
      this.isLoading = true;
      const values = this.formGroup.value;
      let formation: Formation = this.formation ?? new Formation();
      formation.libelle = values.libelle!;
      formation.niveau = values.niveau;
      formation.organisme = values.organisme!;
      formation.dateObtention = values.dateObtention ? new Date(values.dateObtention) : new Date();

      this.activeModal.close(formation);
    } else {
      this.formGroup.markAllAsTouched();
    }
  }

  public closeDialog(): void {
    this.activeModal.close();
  }
}
