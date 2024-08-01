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
  styleUrls: ['experience-dialog.component.scss']
})
export class ExperienceDialogComponent extends BaseComponent implements OnInit {
  public experience?: Experience;
  public formGroup: FormGroup<ExperienceForm>;
  public typesContrats: Reference[] = [];
  public sourceTechnologies: Reference[] = [];
  public filtredTechnologies: Reference[] = [];
  public selectedTechnologies: Reference[] = [];
  public competences: Reference[] = [];
  public methodologies: Reference[] = [];
  public isDropdownTechnologieVisible: boolean = false;

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
      technologie: new FormControl(),
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
        dateDebut: this.experience.dateDebut,
        dateFin: this.experience.dateFin,
        isPosteActuel: this.experience.isPosteActuel,
        lieu: this.experience.lieu,
        description: this.experience.description,
        domaineMetier: this.experience.domaineMetier,
        compositionEquipe: this.experience.compositionEquipe,
        competences: this.experience.competences,
        methodologies: this.experience.methodologies,
        budgetGere: this.experience.budgetGere
      });

      this.selectedTechnologies = this.experience.technologies;
    }

    this.updateInputClientFinal();
    this.updateInputBudgetGere();
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
    
    // ------ CONSTANTES TYPES REFERENCES A CHANGER ------ 
    this.callRequest(ConstantesRequest.getReferencesTechnologies, this.service.getReferences(ConstantesTypesReferences.langue)
        .subscribe((response: ReferenceDto[]) => {
          this.filtredTechnologies = this.sourceTechnologies = Reference.fromListReferenceDto(response);
          this.filterTechnologies();
        }));
    this.callRequest(ConstantesRequest.getReferencesCompetences, this.service.getReferences(ConstantesTypesReferences.langue)
        .subscribe((response: ReferenceDto[]) => {
          this.competences = Reference.fromListReferenceDto(response);
        }));
    this.callRequest(ConstantesRequest.getReferencesMethodologies, this.service.getReferences(ConstantesTypesReferences.langue)
        .subscribe((response: ReferenceDto[]) => {
          this.methodologies = Reference.fromListReferenceDto(response);
        }));
    // ------ END CONSTANTES TYPES REFERENCES A CHANGER ------ 
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
      experience.technologies = this.selectedTechnologies;
      experience.competences = values.competences ?? [];
      experience.methodologies = values.methodologies ?? [];
      experience.budgetGere = values.budgetGere;
      
      this.activeModal.close(experience);
    }
  }

  public closeDialog(): void {
    this.activeModal.close();
  }
  
  public inputTechnologies(): void {
    this.filtredTechnologies = this.sourceTechnologies.filter(x => 
      x.libelle.toLowerCase()
               .startsWith(this.formGroup.value.technologie?.toLowerCase() ?? "")
    ).filter(x => !this.selectedTechnologies.includes(x));
  }

  public onInputTechnologiesFocus(): void {
    this.isDropdownTechnologieVisible = true;
  }

  public onAutocompleteTechnologieBlur(): void {
    this.isDropdownTechnologieVisible = false;
  }

  public onTechnologieClick(technologie: Reference): void {
    this.formGroup.controls.technologie.reset();
    this.selectedTechnologies.push(technologie);
    this.filterTechnologies();
  }

  public onTechnologieRemoveClick(technologie: Reference): void {
    this.formGroup.controls.technologie.reset();
    const index = this.selectedTechnologies.indexOf(technologie);
    this.selectedTechnologies.splice(index, 1);
    this.filterTechnologies();
  }

  private filterTechnologies(): void {
    this.filtredTechnologies = this.sourceTechnologies.filter(x => !this.selectedTechnologies.includes(x));
  }
}
