import { Component, Input, OnInit } from '@angular/core';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { NgbModal, NgbModalOptions, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { tap } from 'rxjs';

@Component({
  selector: 'app-recapitulatif',
  templateUrl: './recapitulatif.component.html',
})

export class RecapitulatifComponent extends BaseComponentCallHttpComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  public recapitulatif: string = "";
  
  constructor(private modalService: NgbModal,
    private service: ApiServiceAgent
  ) {
    super()
  }

  public ngOnInit(): void {
    this.populateData();
  }

  public populateData(): void {
    this.isLoading = true;


      this.service.getCompetences(this.tokenDossierTechnique, '1').pipe(

    ).subscribe({
      next: () => {
        this.isLoading = false; 
      },
      error: () => {
        this.isLoading = false; 
       
      }
    });
  }
}
