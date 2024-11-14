import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { ConstantesTypesReferences } from 'src/app/shared/constantes/constantes-types-references';
import { LangueForm } from 'src/app/shared/interfaces/langue-form';
import { Langue } from 'src/app/shared/models/langue.model';
import { Reference } from 'src/app/shared/models/reference.model';
import { ReferenceDto } from 'src/app/shared/services/generated/api/api.client';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';

@Component({
  selector: 'app-langue-dialog',
  templateUrl: './langue-dialog.component.html'
})
export class LangueDialogComponent extends BaseComponentCallHttpComponent implements OnInit {
  public formGroup: FormGroup<LangueForm>;
  public langues: Reference[] = [];
  public niveauxLangues: Reference[] = [];

  constructor(public activeModal: NgbActiveModal,
    private readonly service: ApiServiceAgent) {
    super();
    this.formGroup = new FormGroup<LangueForm>({
      langue: new FormControl(),
      niveau: new FormControl()
    });
  }

  public ngOnInit(): void {
    this.populateData();
  }

  public submit(): void {
    if (this.formGroup.valid) {
      const values = this.formGroup.value;
      let langue: Langue = new Langue();
      langue.langue = values.langue;
      langue.niveau = values.niveau;
      
      this.activeModal.close(langue);
    }
  }

  public closeDialog(): void {
    this.activeModal.close();
  }

  public populateData(): void {
    this.isLoading = true;
    const nbAppelsAsync = 2;

    this.callRequest(ConstantesRequest.getReferencesLangues, this.service.getReferences(ConstantesTypesReferences.langue)
        .subscribe((response: ReferenceDto[]) => {
          this.langues = Reference.fromListReferenceDto(response);
          this.checkLoadingTermine(nbAppelsAsync);
        }));
    this.callRequest(ConstantesRequest.getReferencesNiveauxLangues, this.service.getReferences(ConstantesTypesReferences.niveauLangue)
        .subscribe((response: ReferenceDto[]) => {
          this.niveauxLangues = Reference.fromListReferenceDto(response);
          this.formGroup.controls.niveau.setValue(this.niveauxLangues[0]);
          this.checkLoadingTermine(nbAppelsAsync);
        }));
  }
}
