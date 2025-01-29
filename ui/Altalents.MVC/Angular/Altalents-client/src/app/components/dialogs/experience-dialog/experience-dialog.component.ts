import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal, NgbModalOptions, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { Constantes } from 'src/app/shared/constantes/constantes';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { ConstantesTypesReferences } from 'src/app/shared/constantes/constantes-types-references';
import { ExperienceForm } from 'src/app/shared/interfaces/experience-form';
import { Experience } from 'src/app/shared/models/experience.model';
import { Reference } from 'src/app/shared/models/reference.model';
import { ReferenceDto } from 'src/app/shared/services/generated/api/api.client';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { ProjectOrMissionClient } from 'src/app/shared/models/project-mission.model';
import { ProjectForm } from 'src/app/shared/interfaces/project-mission-form';
import { dateRangeValidator, maxDateTodayValidator } from 'src/app/shared/services/services/validators/validate-date';
import { ConfirmDeleteDialogComponent } from '../confirm-delete-dialog/confirm-delete-dialog.component';
import { DataFormatService } from 'src/app/shared/services/services/formators/currency-formator';
import { MODAL_OPTIONS_LG } from 'src/app/shared/modal-options';
import { tap } from 'rxjs';

@Component({
  selector: 'app-experience-dialog',
  templateUrl: './experience-dialog.component.html',
  styleUrls: ['./experience-dialog.component.scss']
})

export class ExperienceDialogComponent extends BaseComponentCallHttpComponent implements OnInit {
  
  public tokenAccesRapideDt: string | undefined;
  public experience?: Experience;
  public formGroup: FormGroup<ExperienceForm>;
  public typesContrats: Reference[] = [];
  public domaines: Reference[] = [];
  public constantesRequest = ConstantesRequest;
  public constantesTypesReferences = ConstantesTypesReferences;
  public IsEsn: boolean = false;
  public submitted = false;
  public isLieuVisible: boolean = true;  // Nouvelle variable pour gérer la visibilité du champ "lieu"


  constructor(public activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private readonly service: ApiServiceAgent) {

    super();
    const today = new Date();

    this.formGroup = new FormGroup<ExperienceForm>({
      
      typeContrat: new FormControl(null, Validators.required),
      intitulePoste: new FormControl(null, Validators.required),
      entreprise: new FormControl(null, Validators.required),
      isEntrepriseEsnOrInterim: new FormControl(),
      dateDebut: new FormControl(null, [Validators.required, maxDateTodayValidator()]),
      dateFin: new FormControl(null, [maxDateTodayValidator()]),
      isPosteActuel: new FormControl(),
      lieu: new FormControl(null, Validators.required),
      domaineMetier: new FormControl(null, Validators.required),
      projects: new FormArray<FormGroup<ProjectForm>>([], [Validators.required, Validators.minLength(1)]),
    });

    this.formGroup.setValidators(dateRangeValidator('dateDebut', 'dateFin'));
  }

  public ngOnInit(): void {
    this.populateData();

    if (this.experience) {
      this.IsEsn = this.experience.IsEntrepriseEsnOrInterim;

      this.formGroup.patchValue({

        typeContrat: this.experience.typeContrat,
        intitulePoste: this.experience.intitulePoste,
        entreprise: this.experience.nomEntreprise,
        isEntrepriseEsnOrInterim: this.experience.IsEntrepriseEsnOrInterim,
        dateDebut: formatDate(this.experience.dateDebut, Constantes.formatDateFront, Constantes.formatDateLocale),
        dateFin: this.experience.dateFin ? formatDate(this.experience.dateFin, Constantes.formatDateFront, Constantes.formatDateLocale) : undefined,
        isPosteActuel: !this.experience.dateFin,
        lieu: this.experience.lieu,
        domaineMetier: this.experience.domaineMetier,
        projects: this.experience.projetOrMission,
      });

      if (this.experience.projetOrMission) {
        this.experience.projetOrMission.forEach((project, i) => {
          this.addProject(project);
        });
      }
    }
    this.updateInputPosteActuel();
    this.updateInputIsEsn();
  }

  ngAfterViewChecked(): void {
    this.formatBudgetFields();
  }

  public formatBudgetFields(): void {
    const activeTab = document.querySelector('.tab-pane.active');

    if (activeTab) {
      const budgetFields = activeTab.querySelectorAll('.budget-field');
      budgetFields.forEach((field: Element) => {
        const inputField = field as HTMLInputElement | HTMLTextAreaElement;
        const value = inputField.value || inputField.textContent || inputField.innerText;
        inputField.value = DataFormatService.FormatCurrencyEuro(value);
      });
    }
  }

  public onTabChange(event: any): void {
    this.formatBudgetFields();
  }

  public getProjets(): FormArray {
    return this.formGroup.get('projects') as FormArray;
  }

  public addProject(project?: ProjectOrMissionClient): void {
    this.submitted = false;
    const projectsArray = this.formGroup.get('projects') as FormArray;

    const projectGroup = new FormGroup({
      
      id: new FormControl(project?.id ?? null),
      nomClientOrProjet: new FormControl(project?.nomClientOrProjet ?? null),
      descriptionProjetOrMission: new FormControl(project?.descriptionProjetOrMission ?? null, Validators.required),
      domaineMetier: new FormControl(project?.domaineMetier ?? null),
      dateDebut: new FormControl(project?.dateDebut ? formatDate(project?.dateDebut!, Constantes.formatDateFront, Constantes.formatDateLocale) : null, [maxDateTodayValidator()]),
      dateFin: new FormControl(project?.dateFin ? formatDate(project?.dateFin!, Constantes.formatDateFront, Constantes.formatDateLocale): null, [maxDateTodayValidator()]),
      taches: new FormControl(project?.taches ?? null, Validators.required),
      compositionEquipe: new FormControl(project?.compositionEquipe ?? null),
      budget: new FormControl(project?.budget ?? null),
      lieu: new FormControl(project?.lieu ?? null),

      technologies: new FormControl(project?.technologies ?? null),
      competences: new FormControl(project?.competences ?? null),
      outils: new FormControl(project?.outils ?? null),
      methodologies: new FormControl(project?.methodologies ?? null),

    });

    projectGroup.setValidators(dateRangeValidator('dateDebut', 'dateFin'));
    projectsArray.push(projectGroup);
  }

  public toggleIsEsn() {
    this.submitted = false;
    this.IsEsn = !this.IsEsn;

    this.updateInputIsEsn();
  }

  private updateInputIsEsn() {
    
    if (this.IsEsn) {
      // this.isLieuVisible = false;
      this.formGroup.controls.lieu.clearValidators();
    } else {
      // this.isLieuVisible = true;
      this.formGroup.controls.lieu.setValidators(Validators.required);
    }

    this.formGroup.controls.lieu.updateValueAndValidity();

    // Met à jour les validateurs pour les champs des projets
    const projectsArray = this.formGroup.get('projects') as FormArray<FormGroup>;

    projectsArray.controls.forEach((projectGroup) => {

      // Maintenant, projectGroup est automatiquement reconnu comme un FormGroup
      if (this.IsEsn) {
        projectGroup.controls['nomClientOrProjet'].setValidators(Validators.required);
        projectGroup.controls['lieu'].setValidators(Validators.required);
        projectGroup.controls['dateDebut'].setValidators(Validators.required);
      } else {
        projectGroup.controls['nomClientOrProjet'].clearValidators();
        projectGroup.controls['lieu'].clearValidators();
        projectGroup.controls['dateDebut'].clearValidators();
      }

      projectGroup.controls['nomClientOrProjet'].updateValueAndValidity();
      projectGroup.controls['lieu'].updateValueAndValidity();
      projectGroup.controls['dateDebut'].updateValueAndValidity();

    });

  }

  public removeProjet(index: number): void {
    this.submitted = false;
    let dialogRef: NgbModalRef = this.modalService.open(ConfirmDeleteDialogComponent, MODAL_OPTIONS_LG);
    dialogRef.componentInstance.itemName = this.IsEsn  ? 'cette mission' : 'ce projet ';
    
    dialogRef.result.then((validated: boolean | undefined) => {
      if (validated) {
        
       

        let idProjectOrMission : string | undefined;
        
        if (this.experience && this.experience.projetOrMission && this.experience.projetOrMission.length > index) {
          idProjectOrMission = this.experience.projetOrMission[index]?.id;
        }
        
        if(idProjectOrMission) {
          this.isLoading = true;
          this.service.deleteProjectOrMission(this.tokenAccesRapideDt!, idProjectOrMission).pipe(
            tap(() => {
              this.isLoading = false;
           
            })
          ).subscribe();
        }

        const projectsArray = this.formGroup.get('projects') as FormArray;
        projectsArray.removeAt(index);

      }
    });
  }

  public hasAtLeastOneProject(): boolean {
    const projetsControls = this.getProjets().controls;
    return projetsControls && projetsControls.length > 0;
  }

  public updateInputPosteActuel(): void {
    const controls = this.formGroup.controls;

    this.submitted = false;

    if (controls.isPosteActuel.value) {
      controls.dateFin.disable();
      controls.dateFin.clearValidators();
      controls.dateFin.reset();
    } else {
      controls.dateFin.enable();
      controls.dateFin.setValidators(Validators.required);
    }
    controls.dateFin.updateValueAndValidity();
  }

  public populateData(): void {
    this.isLoading = true;
    const nbAppelsAsync = 2;

    this.callRequest(ConstantesRequest.getReferencesDomaines, this.service.getReferences(ConstantesTypesReferences.domaine)
      .subscribe((response: ReferenceDto[]) => {
        this.domaines = Reference.fromListReferenceDto(response);

        const index = this.domaines.findIndex(x => x.id === Constantes.idDomaineMetierAutre);
        if (index !== -1) {
          const [item] = this.domaines.splice(index, 1);
          this.domaines.push(item);
        }

        if (this.experience) {
          let type: Reference | null = this.domaines.find(x => x.id == this.experience!.domaineMetier.id) ?? null
          this.formGroup.controls.domaineMetier.setValue(type);

          if (this.experience.projetOrMission) {
            this.experience.projetOrMission.forEach((project, index) => {

              const selectedDomaineMetier = this.domaines.find(d => d.id === project.domaineMetier?.id) ?? null;
              const projectGroup = (this.formGroup.get('projects') as FormArray).at(index) as FormGroup;
              projectGroup.controls['domaineMetier'].setValue(selectedDomaineMetier);

            });
          }
        } else {
          this.formGroup.controls.domaineMetier.setValue(null);
        }
        this.checkLoadingTermine(nbAppelsAsync);
      }));

    this.callRequest(ConstantesRequest.getReferencesTypesContrats, this.service.getReferences(ConstantesTypesReferences.typeContrat)
      .subscribe((response: ReferenceDto[]) => {
        this.typesContrats = Reference.fromListReferenceDto(response);

        if (this.experience) {
          const type: Reference = this.typesContrats.find(x => x.id == this.experience!.typeContrat.id) ?? this.typesContrats[0];
          this.formGroup.controls.typeContrat.setValue(type);
        } else {
          this.formGroup.controls.typeContrat.setValue(this.typesContrats[0]);
        }
        this.checkLoadingTermine(nbAppelsAsync);
      }));
  }

  public submit(): void {
    const projectsArray = this.formGroup.get('projects') as FormArray<FormGroup<ProjectForm>>;

    this.submitted = true;

    if (this.formGroup.valid) {
      const projects: ProjectOrMissionClient[] = projectsArray.controls.map((group) => {
        const valuesProj = group.value;

        return {
          
          id: valuesProj.id ?? "",
          nomClientOrProjet: valuesProj.nomClientOrProjet ?? "",
          descriptionProjetOrMission: valuesProj.descriptionProjetOrMission ?? "",

          taches: valuesProj.taches ?? "",
          lieu: valuesProj.lieu ?? "",
          budget: valuesProj.budget ? parseFloat(valuesProj.budget.toString().replace(/[€,\s]/g, '').trim()) : undefined,
          compositionEquipe: valuesProj.compositionEquipe ?? "",
          dateDebut: valuesProj.dateDebut!,
          dateFin: valuesProj.dateFin!,
          domaineMetier: valuesProj.domaineMetier ?? undefined,

          technologies: valuesProj.technologies ?? [],
          competences: valuesProj.competences ?? [],
          methodologies: valuesProj.methodologies ?? [],
          outils: valuesProj.outils ?? []
        };
      });

      const values = this.formGroup.value;
      let experience: Experience = this.experience ?? new Experience();

      experience.typeContrat = values.typeContrat ?? new Reference();
      experience.intitulePoste = values.intitulePoste ?? "";
      experience.nomEntreprise = values.entreprise ?? "";
      experience.IsEntrepriseEsnOrInterim = values.isEntrepriseEsnOrInterim ?? false ;
      experience.dateDebut = values.dateDebut ? new Date(values.dateDebut) : new Date();
      experience.dateFin = values.dateFin ? new Date(values.dateFin) : undefined;
      experience.lieu = values.lieu ?? "";
      experience.domaineMetier = values.domaineMetier ?? new Reference();

      experience.projetOrMission = projects ?? [];

      this.activeModal.close(experience);

    } else {

      this.formGroup.markAllAsTouched();

    }
  }

  public cancel(): void {
    this.activeModal.dismiss(); 
  }

  public onSelectedTechnologiesChange(technologies: Reference[], index: number): void {
    const projectsArray = this.formGroup.get('projects') as FormArray;
    const projectFormGroup = projectsArray.at(index) as FormGroup<ProjectForm>;
    projectFormGroup.controls.technologies.setValue(technologies);
  }

  public onSelectedCompetencesChange(competences: Reference[], index: number): void {
    const projectsArray = this.formGroup.get('projects') as FormArray;
    const projectFormGroup = projectsArray.at(index) as FormGroup<ProjectForm>;
    projectFormGroup.controls.competences.setValue(competences);
  }

  public onSelectedMethodologiesChange(methodologies: Reference[], index: number): void {
    const projectsArray = this.formGroup.get('projects') as FormArray;
    const projectFormGroup = projectsArray.at(index) as FormGroup<ProjectForm>;
    projectFormGroup.controls.methodologies.setValue(methodologies);
  }

  public onSelectedOutilsChange(outils: Reference[], index: number): void {
    const projectsArray = this.formGroup.get('projects') as FormArray;
    const projectFormGroup = projectsArray.at(index) as FormGroup<ProjectForm>;
    projectFormGroup.controls.outils.setValue(outils);
  }

}
