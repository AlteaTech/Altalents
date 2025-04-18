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
    public langueInput?: Langue;
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
      
      this.isLoading = true;
      const values = this.formGroup.value;
      let langue: Langue = this.langueInput ?? new Langue();
      langue.idLangue = values.langue?.id;
      langue.libelleLangue = values.langue?.libelle;
      langue.idReferenceNiveau = values.niveau?.id;
      langue.libelleReferenceNiveau = values.niveau?.libelle;

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

          // Trier la liste pour mettre "Français" et "Anglais" en haut
          this.langues = this.langues.sort((a, b) => {
            if (a.libelle === "Français" || a.libelle === "Anglais") {
              return -1; // Priorise "Français" et "Anglais"
            }
            if (b.libelle === "Français" || b.libelle === "Anglais") {
              return 1;
            }
            return 0; // Maintient l'ordre pour les autres
          });
          

          if (this.langueInput) {
            const selectedRefLang: Reference = this.langues.find(x => x.id == this.langueInput!.idLangue) ?? this.langues[0];
            this.formGroup.controls.langue.setValue(selectedRefLang);
          } else {
            this.formGroup.controls.langue.setValue(this.langues[0]);
          }

          this.checkLoadingTermine(nbAppelsAsync);
        }));


    this.callRequest(ConstantesRequest.getReferencesNiveauxLangues, this.service.getReferences(ConstantesTypesReferences.niveauLangue)
        .subscribe((response: ReferenceDto[]) => {
          this.niveauxLangues = Reference.fromListReferenceDto(response);

          if (this.langueInput) {
            const selectedNivLang: Reference = this.niveauxLangues.find(x => x.id == this.langueInput!.idReferenceNiveau) ?? this.niveauxLangues[0];
            this.formGroup.controls.niveau.setValue(selectedNivLang);
          } else {
            this.formGroup.controls.niveau.setValue(this.niveauxLangues[0]);
          }

          this.checkLoadingTermine(nbAppelsAsync);
        }));
        
 

  }
}
