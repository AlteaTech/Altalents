import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { LangueForm } from 'src/app/shared/interfaces/langue-form';
import { CodeLibelle } from 'src/app/shared/models/code-libelle.model';
import { Langue } from 'src/app/shared/models/langue.model';
import { MockService } from 'src/app/shared/services/mock.service';

@Component({
  selector: 'app-langue-dialog',
  templateUrl: './langue-dialog.component.html'
})
export class LangueDialogComponent implements OnInit {
  public formGroup: FormGroup<LangueForm>;
  public niveauxLangues: CodeLibelle[] = [];

  constructor(public activeModal: NgbActiveModal,
    private mockService: MockService
  ) {
    this.formGroup = new FormGroup<LangueForm>({
      libelle: new FormControl(),
      niveau: new FormControl()
    });
  }

  public ngOnInit(): void {
    this.loadNiveauxLangues();  
  }

  public submit(): void {
    if (this.formGroup.valid) {
      const values = this.formGroup.value;
      let langue: Langue = new Langue();
      langue.libelle = values.libelle;
      langue.niveau = values.niveau;
      
      this.activeModal.close(langue);
    }
  }

  public closeDialog(): void {
    this.activeModal.close();
  }

  private loadNiveauxLangues(): void {
    // TODO : appeler le back pour avoir les infos
    this.niveauxLangues = this.mockService.getNiveauxLangues();
  }
}
