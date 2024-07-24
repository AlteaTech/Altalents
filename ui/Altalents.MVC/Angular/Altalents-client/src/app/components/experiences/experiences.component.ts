import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Experience } from 'src/app/shared/models/experience.model';
import { ExperienceDialogComponent } from '../dialogs/experience-dialog/experience-dialog.component';

@Component({
  selector: 'app-experiences',
  templateUrl: './experiences.component.html'
})
export class ExperiencesComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();
  public experiences: Experience[] = [];
  
  constructor(private modalService: NgbModal) {
  }
  
  public ngOnInit(): void {
    this.validationCallback.emit(() => this.submit());
    this.loadData();
  }

  public onAddExperienceClick(): void {
    let dialogRef: NgbModalRef = this.modalService.open(ExperienceDialogComponent);
    dialogRef.result.then((nouvelElement: Experience | undefined) => {
      if(nouvelElement) {
        this.experiences.push(nouvelElement)
      }
    })
  }

  private submit(): Promise<boolean> {
    // Appeler la route de save
    return new Promise<boolean>(resolve => resolve(true));
  }

  private loadData(): void {
    // TODO : appeler le back pour avoir les infos
    this.experiences = [];
  }
}
