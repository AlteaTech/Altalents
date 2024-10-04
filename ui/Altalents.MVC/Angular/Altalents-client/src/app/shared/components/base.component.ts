import { Component } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-base',
  templateUrl: './base.component.html'
})
export abstract class BaseComponent {
  public subscription: Subscription | undefined;
  public requests = new Map<string, Subscription>();
  public isLoading = false;
  public cptAppelsAsyncTermines = 0;

  ngOnDestroy(): void {
    this.requests.forEach((value: Subscription, key: string, map: Map<string, Subscription>) => {
      value?.unsubscribe();
    });
  }

  public abstract populateData(): void;

  protected callRequest(key: string, subscription: Subscription): void {
    this.requests.get(key)?.unsubscribe();
    this.requests.set(key, subscription);
  }

  protected checkLoadingTermine(nbAppelsAsync: number): void {
    this.cptAppelsAsyncTermines++;
    if (this.cptAppelsAsyncTermines === nbAppelsAsync) {
      this.isLoading = false;
      this.cptAppelsAsyncTermines = 0;
    }
  }
}
