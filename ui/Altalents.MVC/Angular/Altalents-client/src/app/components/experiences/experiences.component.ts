import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbModal, NgbModalOptions, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
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
    const ngbModalOptions: NgbModalOptions = {
      backdrop : 'static',
      keyboard : false,
      size: 'lg'
    };
    let dialogRef: NgbModalRef = this.modalService.open(ExperienceDialogComponent, ngbModalOptions);
    dialogRef.result.then((nouvelElement: Experience | undefined) => {
      if(nouvelElement) {
        this.populateDureeExperience(nouvelElement);
        this.experiences.push(nouvelElement)
      }
    })
  }

  private populateDureeExperience(experience: Experience) {
    if (experience.dateDebut && experience.dateFin) {
      const dateFin = new Date(experience.dateFin);
      const dateDebut = new Date(experience.dateDebut);
      const jours: number = Math.round((Date.UTC(dateFin.getFullYear(), dateFin.getMonth(), dateFin.getDate())
                                          - Date.UTC(dateDebut.getFullYear(), dateDebut.getMonth(), dateDebut.getDate()))
                                        / (1000 * 60 * 60 * 24));

      if(jours <= 30) {
        experience.dureeExperience = jours + " jours";
      }
      else if(jours < 365) {
        experience.dureeExperience = Math.round(jours/30) + " mois";
      }
      else {
        experience.dureeExperience = Math.round(jours/365) + " ans";
      }
    }
  }

  public onModifierExperienceClick(experience: Experience): void {
    const ngbModalOptions: NgbModalOptions = {
      backdrop : 'static',
      keyboard : false,
      size: 'lg'
    };
    let dialogRef: NgbModalRef = this.modalService.open(ExperienceDialogComponent, ngbModalOptions);
    dialogRef.componentInstance.experience = experience;
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
