import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { PieceJointeForm } from 'src/app/shared/interfaces/piece-jointe-form';
import { PieceJointe } from 'src/app/shared/models/piece-jointe.model';

@Component({
  selector: 'app-piece-jointe-dialog',
  templateUrl: './piece-jointe-dialog.component.html'
})
export class PieceJointeDialogComponent implements OnInit {
  public pieceJointe?: PieceJointe;
  public formGroup: FormGroup<PieceJointeForm>;
  public isLoading: boolean = true;
  public isDragging: boolean = false;
  public modalTitle: string = "";

  constructor(public activeModal: NgbActiveModal) {
    this.formGroup = new FormGroup<PieceJointeForm>({
      commentaire: new FormControl()
    });

    if (this.modalTitle = "")
    {

      this.modalTitle  = "Upload de document";
    }

  }

  public ngOnInit(): void {
    if (this.pieceJointe) {
      this.formGroup.patchValue({
        commentaire: this.pieceJointe.commentaire
      });
    }

    this.isLoading = false;
  }

  triggerFileInput(): void {
    // this.fileInput.nativeElement.click();
    document.querySelector<HTMLInputElement>('#fileInput')?.click();
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


// Gérer le survol de la zone
public onDragOver(event: DragEvent): void {
  event.preventDefault();
  this.isDragging = true;
}

// Gérer la sortie de la zone
public onDragLeave(event: DragEvent): void {
  event.preventDefault();
  this.isDragging = false;
}

// Gérer le dépôt d'un fichier
public async onDrop(event: DragEvent): Promise<void> {
  event.preventDefault();
  this.isDragging = false;
  const fichiers = event.dataTransfer?.files;
  await this.ProcessFileList(fichiers!);
}


private async ProcessFileList(fichiers:FileList) {
  if (fichiers && fichiers.length > 0) {
    this.isLoading = true;
    const file: File = fichiers[0];
    this.pieceJointe = this.pieceJointe ?? new PieceJointe();
    this.pieceJointe.mimeType = file.type;
    this.pieceJointe.nomFichier = file.name;
    this.pieceJointe.data = await PieceJointe.toBase64(file)
    .then((data: string) => {
      return data;
    });
    this.isLoading = false;
  }
}

  public async onFileUploadChange(event: Event): Promise<void> {
    const fichiers: FileList | null = (event.target as HTMLInputElement).files;
    await this.ProcessFileList(fichiers!);
    }

  
}
