import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { PieceJointeForm } from 'src/app/shared/interfaces/piece-jointe-form';
import { PieceJointe } from 'src/app/shared/models/piece-jointe.model';

@Component({
  selector: 'app-piece-jointe-dialog',
  templateUrl: './piece-jointe-dialog.component.html',
  styleUrls: ['../../../app.component.css']
})
export class PieceJointeDialogComponent implements OnInit {
  public pieceJointe?: PieceJointe;
  public formGroup: FormGroup<PieceJointeForm>;

  constructor(public activeModal: NgbActiveModal) {
    this.formGroup = new FormGroup<PieceJointeForm>({
      pieceJointe: new FormControl(null, Validators.required),
      commentaire: new FormControl()
    });
  }

  public ngOnInit(): void {
    if (this.pieceJointe) {
      this.formGroup.patchValue({
        pieceJointe: this.pieceJointe.pieceJointe,
        commentaire: this.pieceJointe.commentaire
      });
    }
  }

  public submit(): void {
    if (this.formGroup.valid) {
      const values = this.formGroup.value;
      let pieceJointe: PieceJointe = this.pieceJointe ?? new PieceJointe();
      pieceJointe.pieceJointe = values.pieceJointe!;
      pieceJointe.commentaire = values.commentaire ?? undefined;

      this.activeModal.close(pieceJointe);
    }
  }

  public closeDialog(): void {
    this.activeModal.close();
  }
}
