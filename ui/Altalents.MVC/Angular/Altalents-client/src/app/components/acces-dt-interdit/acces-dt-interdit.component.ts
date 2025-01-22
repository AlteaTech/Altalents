import { Component } from '@angular/core';
import { PermissionDT } from 'src/app/shared/models/permissionDT.model';
import { PermissionService } from 'src/app/shared/services/services/security/permission-service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-acces-dt-interdit',
  templateUrl: './acces-dt-interdit.component.html',
  styleUrls: ['./acces-dt-interdit.component.css']
})
export class AccesDtInterditComponent {
    public permissionDT: PermissionDT = new PermissionDT();
    public tokenDossierTechnique: string = "";
    
    constructor(private permissionService: PermissionService, private location: Location) {}

    ngOnInit(): void {
      this.tokenDossierTechnique = this.permissionService.tokenDossierTechnique;
      this.permissionDT = this.permissionService.getLastPermissionDT();

    }

  
    public goBack(): void {
      this.location.back(); // Redirige vers la page précédente
    }


}
