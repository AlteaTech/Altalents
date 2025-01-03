import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Constantes } from 'src/app/shared/constantes/constantes';
import { FormationForm } from 'src/app/shared/interfaces/formation-form';
import { Formation } from 'src/app/shared/models/formation.model';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { dateRangeValidator, maxDateTodayValidator } from 'src/app/shared/services/services/validators/validate-date';

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
      organisme: new FormControl(),
      dateDebut: new FormControl(null, [Validators.required, maxDateTodayValidator()]),
      dateFin: new FormControl(null, [maxDateTodayValidator()]),
    });

    this.formGroup.setValidators(dateRangeValidator('dateDebut', 'dateFin'));

  }

  public ngOnInit(): void {
    if (this.formation) {
      this.formGroup.patchValue({
        libelle: this.formation.libelle,
        niveau: this.formation.niveau,
        organisme: this.formation.organisme,
        dateDebut:  formatDate(this.formation.dateDebut, Constantes.formatDateFront, Constantes.formatDateLocale), 
        dateFin: this.formation.dateFin ? formatDate(this.formation.dateFin, Constantes.formatDateFront, Constantes.formatDateLocale) : undefined,
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
