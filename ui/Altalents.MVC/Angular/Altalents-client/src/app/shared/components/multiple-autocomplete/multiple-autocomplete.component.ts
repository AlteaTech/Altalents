import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Reference } from 'src/app/shared/models/reference.model';
import { AutocompleteForm } from '../../interfaces/autocomplete-form';
import { BaseComponent } from '../base.component';
import { ReferenceDto, ReferenceRequestDto } from '../../services/generated/api/api.client';
import { ApiServiceAgent } from '../../services/services-agents/api.service-agent';
import { ConstantesRequest } from '../../constantes/constantes-request';

@Component({
  selector: 'app-multiple-autocomplete',
  templateUrl: './multiple-autocomplete.component.html',
  styleUrls: ['multiple-autocomplete.component.scss','../../../app.component.css']
})
export class MultipleAutocompleteComponent extends BaseComponent implements OnInit {
  @Input() public placeholder: string = "";
  @Input() public constanteRequest: string = "";
  @Input() public constanteTypeReference: string = "";
  @Input() public selectedReferences: Reference[] = [];
  @Output() public selectedReferencesCallback: EventEmitter<Reference[]> = new EventEmitter();

  public formGroup: FormGroup<AutocompleteForm>;
  public references: Reference[] = [];
  
  constructor(private readonly service: ApiServiceAgent) {
    super()
    this.formGroup = new FormGroup<AutocompleteForm>({
      input: new FormControl()
    });
  }

  public ngOnInit(): void {   
    this.populateData();
  }

  public override populateData(): void {}
  
  public onInputReferences(): void {
    const input: string | undefined = this.formGroup.value.input;
    this.callRequest(this.constanteRequest, this.service.getReferences(this.constanteTypeReference, input)
        .subscribe((response: ReferenceDto[]) => {
          this.references = Reference.fromListReferenceDto(response);
          this.filterReferences();

          if(input) {
            const referenceInput: Reference | undefined = this.references.find(x => x.libelle.toLowerCase() === input.toLowerCase());
            if(!referenceInput) {
              let referenceAAjouter = new Reference();
              referenceAAjouter.libelle = input;
              this.references.unshift(referenceAAjouter);
            }
          }
        }));
  }

  public onFocusOut(): void {
    this.formGroup.reset();
    this.references = [];
    this.selectedReferencesCallback.emit(this.selectedReferences);
  }

  public onReferenceClick(reference: Reference): void {
    this.formGroup.reset();
    this.references = [];

    if(!reference.id) {
      let requestDto = new ReferenceRequestDto();
      requestDto.typeReference = this.constanteTypeReference;
      requestDto.libelle = reference.libelle;

      this.callRequest(ConstantesRequest.createReferences, this.service.createReferences(requestDto)
        .subscribe((response: string) => {
          reference.id = response;
          this.selectedReferences.push(reference);
        }));
    } else {
      this.selectedReferences.push(reference);
    }
  }

  public onRemoveReferenceClick(reference: Reference): void {
    this.formGroup.reset();
    this.references = [];
    const index = this.selectedReferences.indexOf(reference);
    this.selectedReferences.splice(index, 1);
  }

  private filterReferences(): void {
    this.references = this.references.filter(x => !this.selectedReferences.find(y => y.id == x.id));
  }
}
