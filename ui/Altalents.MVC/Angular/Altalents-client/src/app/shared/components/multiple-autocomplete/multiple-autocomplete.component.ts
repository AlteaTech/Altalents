import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Reference } from 'src/app/shared/models/reference.model';
import { AutocompleteForm } from '../../interfaces/autocomplete-form';

@Component({
  selector: 'app-multiple-autocomplete',
  templateUrl: './multiple-autocomplete.component.html',
  styleUrls: ['multiple-autocomplete.component.scss']
})
export class MultipleAutocompleteComponent implements OnInit {
  @Input() public placeholder: string = "";
  @Input() public sourceReferences: Reference[] = [];
  @Input() public selectedReferences: Reference[] = [];
  @Output() public selectedReferencesCallback: EventEmitter<Reference[]> = new EventEmitter();

  public formGroup: FormGroup<AutocompleteForm>;
  public filtredReferences: Reference[] = [];
  public isDropdownVisible: boolean = false;
  
  constructor() {
    this.formGroup = new FormGroup<AutocompleteForm>({
      input: new FormControl()
    });
  }

  public ngOnInit(): void {
    this.filterReferences();
  }
  
  public onInputReferences(): void {
    this.filtredReferences = this.sourceReferences.filter(x => 
      x.libelle.toLowerCase()
               .startsWith(this.formGroup.value.input?.toLowerCase() ?? "")
    ).filter(x => !this.selectedReferences.includes(x));
  }

  public onInputFocus(): void {
    this.isDropdownVisible = true;
  }

  public onAutocompleteBlur(): void {
    this.isDropdownVisible = false;
    this.selectedReferencesCallback.emit(this.selectedReferences);
  }

  public onReferenceClick(reference: Reference): void {
    this.formGroup.reset();
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
