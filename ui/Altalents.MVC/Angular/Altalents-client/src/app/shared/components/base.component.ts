import { Component } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-base',
  templateUrl: './base.component.html'
})
export abstract class BaseComponent {
  public subscription: Subscription | undefined;
  public requests = new Map<string, Subscription>();

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
}
