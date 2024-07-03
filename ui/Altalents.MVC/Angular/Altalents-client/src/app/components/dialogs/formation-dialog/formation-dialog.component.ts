import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DonneesLegalesForm } from 'src/app/shared/interfaces/donnees-legales-form';
import { FormationForm } from 'src/app/shared/interfaces/formation-form';

@Component({
  selector: 'app-formation-dialog',
  templateUrl: './formation-dialog.component.html'
})
export class FormationDialogComponent implements OnInit {
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();
  @ViewChild('dialog', { static: false }) dialog!: ElementRef<HTMLDialogElement>;
  
  public formGroup: FormGroup<FormationForm>;

  constructor() {
    this.formGroup = new FormGroup<FormationForm>({
      formation: new FormControl(null),
      domaine: new FormControl(null),
      niveau: new FormControl(null),
      organisme: new FormControl(null),
      dateDebut: new FormControl(null),
      dateFin: new FormControl(null),
    });
  }

  public ngOnInit(): void {
    this.validationCallback.emit(() => this.submit());
  }

  public openDialog(): void {
    this.dialog.nativeElement.show();
  }

  public closeDialog(): void {
    this.dialog.nativeElement.close();
  }

  private submit(): Promise<boolean> {
    let isValid: boolean = false;

    if(this.formGroup.valid){
// Appeler la route de save
      isValid = true;
    }

    return new Promise<boolean>(resolve => resolve(isValid));
  }
}
