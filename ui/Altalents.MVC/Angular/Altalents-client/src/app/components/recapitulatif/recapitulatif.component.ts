import { Component, Input, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { NgbModal, NgbModalOptions, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { tap } from 'rxjs';

@Component({
  selector: 'app-recapitulatif',
  templateUrl: './recapitulatif.component.html',
})

export class RecapitulatifComponent extends BaseComponent implements OnInit {
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

  public override populateData(): void {
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
