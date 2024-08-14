import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from 'src/app/shared/components/base.component';
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
  styleUrls: ['./experience-dialog.component.scss','../../../app.component.css']
})
export class ExperienceDialogComponent extends BaseComponent implements OnInit {
  public experience?: Experience;
  public formGroup: FormGroup<ExperienceForm>;
  public typesContrats: Reference[] = [];
  public constantesRequest = ConstantesRequest;
  public constantesTypesReferences = ConstantesTypesReferences;

  constructor(public activeModal: NgbActiveModal,
    private readonly service: ApiServiceAgent) {
    super();
    this.formGroup = new FormGroup<ExperienceForm>({
      typeContrat: new FormControl(),
      intitulePoste: new FormControl(),
      entreprise: new FormControl(),
      isClientFinal: new FormControl(),
      clientFinal: new FormControl(),
      dateDebut: new FormControl(),
      dateFin: new FormControl(),
      isPosteActuel: new FormControl(),
      lieu: new FormControl(),
      description: new FormControl(),
      domaineMetier: new FormControl(),
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
        typeContrat: this.experience.typeContrat,
        intitulePoste: this.experience.intitulePoste,
        entreprise: this.experience.entreprise,
        clientFinal: this.experience.clientFinal,
        isClientFinal: this.experience.clientFinal ? true : false,
        dateDebut: this.experience.dateDebut,
        dateFin: this.experience.dateFin,
        isPosteActuel: this.experience.isPosteActuel,
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
    controls.isPosteActuel.value ? controls.dateFin.disable() : controls.dateFin.enable();
  }

  public updateInputClientFinal(): void {
    let controls = this.formGroup.controls;
    controls.isClientFinal.value ? controls.clientFinal.enable() : controls.clientFinal.disable();
  }

  public updateInputBudgetGere(): void {
    let controls = this.formGroup.controls;
    controls.isBudgetGere.value ? controls.budgetGere.enable() : controls.budgetGere.disable();
  }

  public override populateData(): void {
    this.callRequest(ConstantesRequest.getReferencesTypesContrats, this.service.getReferences(ConstantesTypesReferences.typeContrat)
        .subscribe((response: ReferenceDto[]) => {
          this.typesContrats = Reference.fromListReferenceDto(response);
        }));
  }

  public submit(): void {
    if (this.formGroup.valid) {
      const values = this.formGroup.value;
      let experience: Experience = this.experience ?? new Experience();
      experience.typeContrat = values.typeContrat;
      experience.intitulePoste = values.intitulePoste;
      experience.entreprise = values.entreprise;
      experience.clientFinal = values.clientFinal;
      experience.dateDebut = values.dateDebut;
      experience.dateFin = values.dateFin;
      experience.isPosteActuel = values.isPosteActuel ?? false;
      experience.lieu = values.lieu;
      experience.description = values.description;
      experience.domaineMetier = values.domaineMetier;
      experience.compositionEquipe = values.compositionEquipe;
      experience.technologies = values.technologies ?? [];
      experience.competences = values.competences ?? [];
      experience.methodologies = values.methodologies ?? [];
      experience.budgetGere = values.budgetGere;
      
      this.activeModal.close(experience);
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
