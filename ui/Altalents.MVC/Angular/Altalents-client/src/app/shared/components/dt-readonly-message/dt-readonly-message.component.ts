import { Component, Input } from '@angular/core';
import { PermissionDT } from '../../models/permissionDT.model';

@Component({
  selector: 'app-dt-readonly-message',
  templateUrl: './dt-readonly-message.component.html',
  styleUrls: ['./dt-readonly-message.component.css']
})
export class DtReadonlyMessageComponent {
  @Input() permissionDT: PermissionDT = new PermissionDT();
}
