import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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
  public isLoading: boolean = true;

  constructor(public activeModal: NgbActiveModal) {
    this.formGroup = new FormGroup<PieceJointeForm>({
      commentaire: new FormControl()
    });
  }

  public ngOnInit(): void {
    if (this.pieceJointe) {
      this.formGroup.patchValue({
        commentaire: this.pieceJointe.commentaire
      });
    }

    this.isLoading = false;
  }

  public submit(): void {
    if (this.formGroup.valid && this.pieceJointe) {
      const values = this.formGroup.value;
      this.pieceJointe.commentaire = values.commentaire ?? undefined;
      this.activeModal.close(this.pieceJointe);
    } else {
      this.formGroup.markAllAsTouched();
    }
  }

  public closeDialog(): void {
    this.activeModal.close();
  }

  public async onFileUploadChange(event: Event): Promise<void> {
    const fichiers: FileList | null = (event.target as HTMLInputElement).files;

    if(fichiers) {
      this.isLoading = true;
      const file: File = fichiers[0];
      this.pieceJointe = this.pieceJointe ?? new PieceJointe();
      this.pieceJointe.mimeType = file.type;
      this.pieceJointe.nomFichier = file.name;
      this.pieceJointe.data = await this.toBase64(file)
      .then((data: string) => {
        return data;
      });
      this.isLoading = false;
    }
  }

  private toBase64(file: File): Promise<string> {
    return new Promise((resolve) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => {
        resolve(reader.result?.toString().split(',')[1] ?? "");
      };
    })
  }
}
