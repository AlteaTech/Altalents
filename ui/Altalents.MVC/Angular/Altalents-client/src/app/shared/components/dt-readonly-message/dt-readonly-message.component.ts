import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-dt-readonly-message',
  templateUrl: './dt-readonly-message.component.html',
  styleUrls: ['./dt-readonly-message.component.css']
})
export class DtReadonlyMessageComponent {
  @Input() isReadOnly: boolean = false;
}
