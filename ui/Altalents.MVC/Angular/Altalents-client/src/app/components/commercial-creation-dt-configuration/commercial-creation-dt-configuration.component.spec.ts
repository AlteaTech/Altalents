import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommercialCreationDtConfigurationComponent } from './commercial-creation-dt-configuration.component';

describe('CommercialCreationDtConfigurationComponent', () => {
  let component: CommercialCreationDtConfigurationComponent;
  let fixture: ComponentFixture<CommercialCreationDtConfigurationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CommercialCreationDtConfigurationComponent]
    });
    fixture = TestBed.createComponent(CommercialCreationDtConfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
