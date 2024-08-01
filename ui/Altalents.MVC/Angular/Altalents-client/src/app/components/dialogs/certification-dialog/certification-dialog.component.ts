import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { CertificationForm } from 'src/app/shared/interfaces/certification-form';
import { Certification } from 'src/app/shared/models/certification.model';

@Component({
  selector: 'app-certification-dialog',
  templateUrl: './certification-dialog.component.html',
  styleUrls: ['../../../app.component.css']
})
export class CertificationDialogComponent implements OnInit {
  public certification?: Certification;
  public formGroup: FormGroup<CertificationForm>;

  constructor(public activeModal: NgbActiveModal) {
    this.formGroup = new FormGroup<CertificationForm>({
      libelle: new FormControl(),
      domaine: new FormControl(),
      niveau: new FormControl(),
      organisme: new FormControl(),
      dateDebut: new FormControl(),
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
        dateDebut: this.certification.dateDebut,
        dateFin: this.certification.dateFin 
      });
    }
  }

  public submit(): void {
    if (this.formGroup.valid) {
      const values = this.formGroup.value;
      let certification: Certification = this.certification ?? new Certification();
      certification.libelle = values.libelle;
      certification.domaine = values.domaine;
      certification.niveau = values.niveau;
      certification.organisme = values.organisme;
      certification.dateDebut = values.dateDebut;
      certification.dateFin = values.dateFin;
      
      this.activeModal.close(certification);
    }
  }

  public closeDialog(): void {
    this.activeModal.close();
  }
}
