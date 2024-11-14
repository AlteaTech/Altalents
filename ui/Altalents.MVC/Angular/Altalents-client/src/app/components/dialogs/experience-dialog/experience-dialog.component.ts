import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { Constantes } from 'src/app/shared/constantes/constantes';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { ConstantesTypesReferences } from 'src/app/shared/constantes/constantes-types-references';
import { ExperienceForm } from 'src/app/shared/interfaces/experience-form';
import { Experience } from 'src/app/shared/models/experience.model';
import { Reference } from 'src/app/shared/models/reference.model';
import { ReferenceDto } from 'src/app/shared/services/generated/api/api.client';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';

@Component({
  selector: 'app-experience-dialog',
  templateUrl: './experience-dialog.component.html',
  styleUrls: ['./experience-dialog.component.scss']
})
export class ExperienceDialogComponent extends BaseComponentCallHttpComponent implements OnInit {
  public experience?: Experience;
  public formGroup: FormGroup<ExperienceForm>;
  public typesContrats: Reference[] = [];
  public constantesRequest = ConstantesRequest;
  public constantesTypesReferences = ConstantesTypesReferences;

  constructor(public activeModal: NgbActiveModal,
    private readonly service: ApiServiceAgent) {
    super();
    this.formGroup = new FormGroup<ExperienceForm>({
      typeContrat: new FormControl(null, Validators.required),
      intitulePoste: new FormControl(null, Validators.required),
      entreprise: new FormControl(null, Validators.required),
      isClientFinal: new FormControl(),
      clientFinal: new FormControl(),
      dateDebut: new FormControl(null, Validators.required),
      dateFin: new FormControl(),
      isPosteActuel: new FormControl(),
      lieu: new FormControl(null, Validators.required),
      description: new FormControl(null, Validators.required),
      domaineMetier: new FormControl(null, Validators.required),
      compositionEquipe: new FormControl(),
      technologies: new FormControl(),
      competences: new FormControl(),
      methodologies: new FormControl(),
      isBudgetGere: new FormControl(),
      budgetGere: new FormControl()
    });
  }

  public ngOnInit(): void {
    this.populateData();

    if (this.experience) {
      this.formGroup.patchValue({
        intitulePoste: this.experience.intitulePoste,
        entreprise: this.experience.entreprise,
        clientFinal: this.experience.clientFinal,
        isClientFinal: this.experience.clientFinal ? true : false,
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
        budgetGere: this.experience.budgetGere,
        isBudgetGere: this.experience.budgetGere ? true : false
      });
    }

    this.updateInputPosteActuel();
    this.updateInputClientFinal();
    this.updateInputBudgetGere();
  }

  public updateInputPosteActuel(): void {
    let controls = this.formGroup.controls;
    if(controls.isPosteActuel.value) {
      controls.dateFin.disable();
      controls.dateFin.reset();
    } else {
      controls.dateFin.enable();
    }
  }

  public updateInputClientFinal(): void {
    let controls = this.formGroup.controls;
    if(controls.isClientFinal.value) {
      controls.clientFinal.enable();
    } else {
      controls.clientFinal.disable();
      controls.clientFinal.reset();
    }
  }

  public updateInputBudgetGere(): void {
    let controls = this.formGroup.controls;
    if(controls.isBudgetGere.value) {
      controls.budgetGere.enable();
    } else {
      controls.budgetGere.disable();
      controls.budgetGere.reset();
    }
  }

  public populateData(): void {
    this.isLoading = true;
    this.callRequest(ConstantesRequest.getReferencesTypesContrats, this.service.getReferences(ConstantesTypesReferences.typeContrat)
        .subscribe((response: ReferenceDto[]) => {
          this.typesContrats = Reference.fromListReferenceDto(response);

          if(this.experience) {
            const type: Reference = this.typesContrats.find(x => x.id == this.experience!.typeContrat.id) ?? this.typesContrats[0];
            this.formGroup.controls.typeContrat.setValue(type);
          } else {
            this.formGroup.controls.typeContrat.setValue(this.typesContrats[0]);
          }
          
          this.isLoading = false;
        }));
  }

  public submit(): void {
    if (this.formGroup.valid) {
      const values = this.formGroup.value;
      let experience: Experience = this.experience ?? new Experience();
      experience.typeContrat = values.typeContrat ?? new Reference();
      experience.intitulePoste = values.intitulePoste ?? "";
      experience.entreprise = values.entreprise ?? "";
      experience.clientFinal = values.clientFinal ?? undefined;
      experience.dateDebut = values.dateDebut ? new Date(values.dateDebut) : new Date();
      experience.dateFin = values.dateFin ? new Date(values.dateFin) : undefined;
      experience.lieu = values.lieu ?? "";
      experience.description = values.description ?? "";
      experience.domaineMetier = values.domaineMetier ?? "";
      experience.compositionEquipe = values.compositionEquipe ?? undefined;
      experience.technologies = values.technologies ?? [];
      experience.competences = values.competences ?? [];
      experience.methodologies = values.methodologies ?? [];
      experience.budgetGere = values.budgetGere ?? undefined;
      
      this.activeModal.close(experience);
    } else {
      this.formGroup.markAllAsTouched();
    }
  }

  public closeDialog(): void {
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
}
