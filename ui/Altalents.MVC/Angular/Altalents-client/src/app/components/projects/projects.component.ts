import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { ApiServiceAgent } from 'src/app/shared/services/services-agents/api.service-agent';
import { ProjetOrMissionClientDto } from 'src/app/shared/services/generated/api/api.client';
import { ProjectOrMissionClient } from 'src/app/shared/models/project-mission.model';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  // styleUrls: ['./projects.component.scss']
})
export class QuestionsComponent extends BaseComponentCallHttpComponent implements OnInit {
  @Input() public tokenDossierTechnique: string = "";
  @Output() public validationCallback: EventEmitter<() => Promise<boolean>> = new EventEmitter();

  public projetsOrMissions: ProjectOrMissionClient[] = [];
  public showErreurs: boolean = false;

  constructor(private readonly service: ApiServiceAgent) {
    super();
  }
 
  public ngOnInit(): void {
    this.validationCallback.emit(() => this.submit());
    this.populateData();
  }

  public populateData(): void {
    this.isLoading = true;
  }

  private async submit(): Promise<boolean> {
    let isValid: boolean = true;

    this.projetsOrMissions.forEach(x => {
      // if(x.isObligatoire && !x.reponse) {
      //   isValid = false;
      // }
    })
    
    if (isValid) {
      this.isLoading = true;
    } else {
      this.showErreurs = true;
    }

    return new Promise<boolean>(resolve => resolve(isValid));
  }

  private populateRequestDto(): ProjetOrMissionClientDto[] {
    let dtos: ProjetOrMissionClientDto[] = [];
    this.projetsOrMissions.forEach((project: ProjectOrMissionClient) => {
      let dto = new ProjetOrMissionClientDto();

      // dto.budget = question.id ?? "";
      // dto.reponse = question.reponse;

      dtos.push(dto);
    })
    return dtos;
  }
}
