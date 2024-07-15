import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommercialCreationDtAccueilComponent } from './commercial-creation-dt-accueil.component';

describe('CommercialCreationDtAccueilComponent', () => {
  let component: CommercialCreationDtAccueilComponent;
  let fixture: ComponentFixture<CommercialCreationDtAccueilComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CommercialCreationDtAccueilComponent]
    });
    fixture = TestBed.createComponent(CommercialCreationDtAccueilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
