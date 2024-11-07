import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { Component } from '@angular/core';

@Component({
  selector: 'app-base',
  templateUrl: './base.component.html'
})
export abstract class BaseComponent extends BaseComponentCallHttpComponent {

  public abstract populateData(): void;
}
