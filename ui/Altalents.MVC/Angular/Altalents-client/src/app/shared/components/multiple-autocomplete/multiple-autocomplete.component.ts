import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Reference } from 'src/app/shared/models/reference.model';
import { AutocompleteForm } from '../../interfaces/autocomplete-form';
import { BaseComponent } from '../base.component';
import { ReferenceDto } from '../../services/generated/api/api.client';
import { ApiServiceAgent } from '../../services/services-agents/api.service-agent';

@Component({
  selector: 'app-multiple-autocomplete',
  templateUrl: './multiple-autocomplete.component.html',
  styleUrls: ['multiple-autocomplete.component.scss']
})
export class MultipleAutocompleteComponent extends BaseComponent implements OnInit {
  @Input() public placeholder: string = "";
  @Input() public constanteRequest: string = "";
  @Input() public constanteTypeReference: string = "";
  @Input() public selectedReferences: Reference[] = [];
  @Output() public selectedReferencesCallback: EventEmitter<Reference[]> = new EventEmitter();

  public formGroup: FormGroup<AutocompleteForm>;
  public sourceReferences: Reference[] = [];
  public filtredReferences: Reference[] = [];
  public isDropdownVisible: boolean = false;
  
  constructor(private readonly service: ApiServiceAgent) {
    super()
    this.formGroup = new FormGroup<AutocompleteForm>({
      input: new FormControl()
    });
  }

  public ngOnInit(): void {   
    this.populateData();
  }

  public override populateData(): void {
    this.callRequest(this.constanteRequest, this.service.getReferences(this.constanteTypeReference)
        .subscribe((response: ReferenceDto[]) => {
          this.sourceReferences = Reference.fromListReferenceDto(response);
          this.filterReferences();
        }));
  }
  
  public onInputReferences(): void {
    const input: string = this.formGroup.value.input ?? "";

    // APPELER LE BACK POUR LE FILTRE
    this.filtredReferences = this.sourceReferences.filter(x => 
      x.libelle.toLowerCase()
       .startsWith(input.toLowerCase())
    ).filter(x => !this.selectedReferences.includes(x));

    const referenceInput: Reference | undefined = this.filtredReferences.find(x => x.libelle.toLowerCase() === input.toLowerCase());
    if(!referenceInput) {
      let referenceAAjouter = new Reference();
      referenceAAjouter.libelle = input;
      this.filtredReferences.unshift(referenceAAjouter);
    }
  }

  public onFocus(): void {
    this.isDropdownVisible = true;
  }

  public onFocusOut(): void {
    this.isDropdownVisible = false;
    this.formGroup.reset();
    this.filterReferences();
    this.selectedReferencesCallback.emit(this.selectedReferences);
  }

  public onReferenceClick(reference: Reference): void {
    this.formGroup.reset();

    if(!reference.id) {
      // APPEL BACK POUR ADD LA REF (+ GET)
    }

    this.selectedReferences.push(reference);
    this.filterReferences();
  }

  public onRemoveReferenceClick(reference: Reference): void {
    this.formGroup.reset();
    const index = this.selectedReferences.indexOf(reference);
    this.selectedReferences.splice(index, 1);
    this.filterReferences();
  }

  private filterReferences(): void {
    this.filtredReferences = this.sourceReferences.filter(x => !this.selectedReferences.includes(x));
  }
}
