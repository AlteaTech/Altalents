import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-confirm-delete-dialog',
  templateUrl: './confirm-delete-dialog.component.html',
  styleUrls: ['./confirm-delete-dialog.component.scss']
})

export class ConfirmDeleteDialogComponent extends BaseComponentCallHttpComponent implements OnInit {

    public itemName: string | undefined;



    constructor(public activeModal: NgbActiveModal) {
        super();
    }

    ngOnInit(): void {
    }

    onCancel(): void {
        this.activeModal.close(false);
    }

    onConfirm(): void {
        this.activeModal.close(true);
    }
}
