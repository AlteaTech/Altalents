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

@Component({
  selector: 'app-experience-dialog',
  templateUrl: './experience-dialog.component.html',
  styleUrls: ['./experience-dialog.component.scss']
})

export class ExperienceDialogComponent extends BaseComponentCallHttpComponent implements OnInit {
  public experience?: Experience;
  public formGroup: FormGroup<ExperienceForm>;
  public typesContrats: Reference[] = [];
  public domaines: Reference[] = [];
  public constantesRequest = ConstantesRequest;
  public constantesTypesReferences = ConstantesTypesReferences;

  public IsEsn: boolean = false;
  
  public ngbModalDeleteOptions: NgbModalOptions = {
    backdrop : 'static',
    keyboard : false,
    size: 'lg'
  };

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
      description: new FormControl(null, Validators.required),
      domaineMetier: new FormControl(null, Validators.required),
      compositionEquipe: new FormControl(),
      technologies: new FormControl(),
      competences: new FormControl(),
      methodologies: new FormControl(),
      outils : new FormControl(),
      isBudgetGere: new FormControl(),
      budgetGere: new FormControl(),
      projects: new FormArray<FormGroup<ProjectForm>>([], [Validators.required, Validators.minLength(1)]),
    });

    this.formGroup.setValidators(dateRangeValidator('dateDebut', 'dateFin'));
  }

  public ngOnInit(): void {
    this.populateData();

    if (this.experience) {

      this.IsEsn = this.experience.IsEntrepriseEsnOrInterim;

      this.formGroup.patchValue({
        typeContrat : this.experience.typeContrat,
        intitulePoste: this.experience.intitulePoste,
        entreprise: this.experience.nomEntreprise,
        isEntrepriseEsnOrInterim: this.experience.IsEntrepriseEsnOrInterim,
        dateDebut: formatDate(this.experience.dateDebut, Constantes.formatDateFront, Constantes.formatDateLocale),
        dateFin: this.experience.dateFin ? formatDate(this.experience.dateFin, Constantes.formatDateFront, Constantes.formatDateLocale) : undefined,
        isPosteActuel: !this.experience.dateFin,
        lieu: this.experience.lieu,
        description: this.experience.description,
        domaineMetier: this.experience.domaineMetier,
        compositionEquipe: this.experience.compositionEquipe,
        technologies: this.experience.technologies,
        competences: this.experience.competences,
        methodologies: this.experience.methodologies,
        outils : this.experience.outils,
        budgetGere: this.experience.budgetGere,
        isBudgetGere: this.experience.budgetGere ? true : false,
        projects: this.experience.projetOrMission,
      });

      if (this.experience.projetOrMission) {
        this.experience.projetOrMission.forEach((project) => {
          this.addProject(project);  // Populate the form with the projects if any exist
        });
      }

      // this.formGroup.valueChanges.subscribe(value => {
      //   console.log("Form value changed:", value);
      //   // Ajoutez ici des logiques supplémentaires si nécessaire
      // });

    }

    this.updateInputPosteActuel();
  }

  public getProjets(): FormArray {
    return this.formGroup.get('projects') as FormArray;
  }

  public addProject(project?: ProjectOrMissionClient): void {

    const projectsArray = this.formGroup.get('projects') as FormArray;



    const projectGroup = new FormGroup({
      nomClientOrProjet: new FormControl(project?.NomClientOrProjet ?? null),
      descriptionProjetOrMission: new FormControl(project?.descriptionProjetOrMission ?? null, Validators.required),
      domaineMetier: new FormControl(project?.domaineMetier ?? null),
      dateDebut: new FormControl(project?.dateDebut ? formatDate(project?.dateDebut!, Constantes.formatDateFront, Constantes.formatDateLocale) : null, [maxDateTodayValidator()]),
      dateFin: new FormControl(project?.dateFin ? formatDate(project?.dateFin!, Constantes.formatDateFront, Constantes.formatDateLocale): null, [maxDateTodayValidator()]),
      taches: new FormControl(project?.taches ?? null, Validators.required),
      compositionEquipe: new FormControl(project?.compositionEquipe ?? null),
      budget: new FormControl(project?.budget ?? null),
      lieu: new FormControl(project?.lieu ?? null),
    });

    projectGroup.setValidators(dateRangeValidator('dateDebut', 'dateFin'));

    projectsArray.push(projectGroup);

  }

  public toggleIsEsn() {
    this.IsEsn = !this.IsEsn;
  }

  openTab(event: any, tabName: string) {
    const tabcontents = document.querySelectorAll('.tabcontent');
    tabcontents.forEach((tab: any) => tab.classList.remove('active'));

    const tablinks = document.querySelectorAll('.tablinks');
    tablinks.forEach((tab: any) => tab.classList.remove('active'));

    // Afficher l'onglet cliqué
    document.getElementById(tabName)?.classList.add('active');
    event.currentTarget.classList.add('active');
}

  public removeProjet(index: number): void {
      let dialogRef: NgbModalRef = this.modalService.open(ConfirmDeleteDialogComponent, this.ngbModalDeleteOptions);
      dialogRef.componentInstance.itemName = this.IsEsn  ? 'cette mission' : 'ce projet ';
      dialogRef.result.then((validated: boolean | undefined) => {
        if(validated) {
          const projectsArray = this.formGroup.get('projects') as FormArray;
          projectsArray.removeAt(index);
        }
      })
    }

    public hasAtLeastOneProject(): boolean {
      const projetsControls = this.getProjets().controls;
      return projetsControls && projetsControls.length > 0;
    }

  public updateInputPosteActuel(): void {
    const controls = this.formGroup.controls;

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

        // Déplacer l'élément avec l'ID spécifique en bas
        const index = this.domaines.findIndex(x => x.id === Constantes.idDomaineMetierAutre);
        if (index !== -1) {
          const [item] = this.domaines.splice(index, 1);
          this.domaines.push(item);
        }

          if(this.experience) {
            let type: Reference  | null = this.domaines.find(x => x.id == this.experience!.domaineMetier.id) ?? null
            this.formGroup.controls.domaineMetier.setValue(type);

              // Pré-sélectionner les missions
              if (this.experience.projetOrMission) {
                this.experience.projetOrMission.forEach((project, index) => {
                  const selectedDomaineMetier = this.domaines.find(d => d.id === project.domaineMetier?.id) ?? null;
                  // Assigner le domaineMetier de la mission dans le formulaire
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

          if(this.experience) {
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

    if (this.formGroup.valid) {

        const projects: ProjectOrMissionClient[] = projectsArray.controls.map((group) => {
          const valuesProj = group.value;
          return {
            NomClientOrProjet: valuesProj.nomClientOrProjet ?? "",
            descriptionProjetOrMission: valuesProj.descriptionProjetOrMission ?? "",
            taches: valuesProj.taches ?? "",
            lieu: valuesProj.lieu ?? "",
            budget: valuesProj.budget ? Number(valuesProj.budget) : undefined,
            compositionEquipe: valuesProj.compositionEquipe ?? "",
            dateDebut: valuesProj.dateDebut!,
            dateFin: valuesProj.dateFin!,
            domaineMetier: valuesProj.domaineMetier ?? undefined
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
        experience.description = values.description ?? "";
        experience.domaineMetier = values.domaineMetier ?? new Reference();
        experience.compositionEquipe = values.compositionEquipe ?? undefined;
        experience.budgetGere = values.budgetGere ?? undefined;

        experience.technologies = values.technologies ?? [];
        experience.competences = values.competences ?? [];
        experience.methodologies = values.methodologies ?? [];
        experience.outils = values.outils ?? [];
        experience.projetOrMission = projects ?? [];

        this.activeModal.close(experience);

    } else {
      this.formGroup.markAllAsTouched();
    }
  }

  public cancel(): void {
    this.activeModal.close();
  }

  public onSelectedTechnologiesChange(technologies: Reference[]): void {
    this.formGroup.controls.technologies.setValue(technologies);
  }

  public onSelectedCompetencesChange(competences: Reference[]): void {
    this.formGroup.controls.competences.setValue(competences);
  }

  public onSelectedMethodologiesChange(methodologies: Reference[]): void {
    this.formGroup.controls.methodologies.setValue(methodologies);
  }

  public onSelectedOutilsChange(outils: Reference[]): void {
    this.formGroup.controls.outils.setValue(outils);
  }
}