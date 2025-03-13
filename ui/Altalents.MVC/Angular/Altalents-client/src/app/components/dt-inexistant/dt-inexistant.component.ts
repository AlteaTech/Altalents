import { Component } from '@angular/core';
import { PermissionDT } from 'src/app/shared/models/permissionDT.model';
import { PermissionService } from 'src/app/shared/services/services/security/permission-service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-dt-inexistant',
  templateUrl: './dt-inexistant.component.html',
  styleUrls: ['./dt-inexistant.component.css']
})
export class DtInexistantComponent {
    public permissionDT: PermissionDT = new PermissionDT();
    
    constructor(private permissionService: PermissionService, private location: Location) {}

    ngOnInit(): void {
      this.permissionDT = this.permissionService.getLastPermissionDT();
    }

    public goMoon(): void {
      window.open('https://www.nasa.gov', '_blank'); // Ouvre dans un nouvel onglet
    }
}
