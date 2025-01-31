import { Component, Input } from '@angular/core';
import { PermissionDT } from '../../models/permissionDT.model';
import { StatutDtFromCodeReferenceEnumInBackend } from '../../constantes/constantes-backend-enums';

@Component({
  selector: 'app-dt-readonly-message',
  templateUrl: './dt-readonly-message.component.html',
  styleUrls: ['./dt-readonly-message.component.css']
})
export class DtReadonlyMessageComponent {
  @Input() public permissionDT: PermissionDT = new PermissionDT();
  public statutDtEnum = StatutDtFromCodeReferenceEnumInBackend; // Exposition de la classe au template
}
