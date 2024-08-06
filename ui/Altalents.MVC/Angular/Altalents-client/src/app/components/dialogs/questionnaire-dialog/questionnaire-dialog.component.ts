import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { QuestionnaireForm } from 'src/app/shared/interfaces/questionnaire-form';
import { Question } from 'src/app/shared/models/question.model';

@Component({
  selector: 'app-questionnaire-dialog',
  templateUrl: './questionnaire-dialog.component.html',
  styleUrls: ['../../../app.component.css']
})
export class QuestionnaireDialogComponent implements OnInit {
  public questions?: Question[];
  public formGroup: FormGroup<QuestionnaireForm>;

  constructor(public activeModal: NgbActiveModal) {
    this.formGroup = new FormGroup<QuestionnaireForm>({
      question1: new FormControl('', Validators.required),
      isObligatoire1: new FormControl(),
      isShowDt1: new FormControl(),
      isQuestion2Enable: new FormControl(),
      question2: new FormControl(),
      isObligatoire2: new FormControl(),
      isShowDt2: new FormControl(),
      isQuestion3Enable: new FormControl(),
      question3: new FormControl(),
      isObligatoire3: new FormControl(),
      isShowDt3: new FormControl()
    });
  }

  public ngOnInit(): void {
    if (this.questions) {
      this.formGroup.patchValue({
        question1: this.questions[0].question,
        isShowDt1: this.questions[0].isShowDt,
        isObligatoire1: this.questions[0].isObligatoire,
        isQuestion2Enable: this.questions[1].question ? true : false,
        question2: this.questions[1].question,
        isShowDt2: this.questions[1].isShowDt,
        isObligatoire2: this.questions[1].isObligatoire,
        isQuestion3Enable: this.questions[2].question ? true : false,
        question3: this.questions[2].question,
        isShowDt3: this.questions[2].isShowDt,
        isObligatoire3: this.questions[2].isObligatoire
      });
    }

    this.updateInputIsQuestion2Enable();
    this.updateInputIsQuestion3Enable();
  }

  public updateInputIsQuestion2Enable(): void {
    let controls = this.formGroup.controls;
    if(controls.isQuestion2Enable.value) {
      controls.question2.enable();
      controls.isObligatoire2.enable();
      controls.isShowDt2.enable();
    } else {
      controls.question2.disable();
      controls.question2.reset();
      controls.isObligatoire2.disable();
      controls.isObligatoire2.reset();
      controls.isShowDt2.disable();
      controls.isShowDt2.reset();
    }
  }

  public updateInputIsQuestion3Enable(): void {
    let controls = this.formGroup.controls;
    if(controls.isQuestion3Enable.value) {
      controls.question3.enable();
      controls.isObligatoire3.enable();
      controls.isShowDt3.enable();
    } else {
      controls.question3.disable();
      controls.question3.reset();
      controls.isObligatoire3.disable();
      controls.isObligatoire3.reset();
      controls.isShowDt3.disable();
      controls.isShowDt3.reset();
    }
  }

  public submit(): void {
    if (this.formGroup.valid) {
      const values = this.formGroup.value;
      let questions: Question[] = this.questions ?? [];
      questions[0] = new Question();
      questions[0].ordre = 1;
      questions[0].isObligatoire = values.isObligatoire1 ?? false;
      questions[0].isShowDt = values.isShowDt1 ?? false;
      questions[0].question = values.question1 ?? "";
      questions[1] = new Question();
      questions[1].ordre = 2;
      questions[1].isObligatoire = values.isObligatoire2 ?? false;
      questions[1].isShowDt = values.isShowDt2 ?? false;
      questions[1].question = values.question2 ?? "";
      questions[2] = new Question();
      questions[2].ordre = 3;
      questions[2].isObligatoire = values.isObligatoire3 ?? false;
      questions[2].isShowDt = values.isShowDt3 ?? false;
      questions[2].question = values.question3 ?? "";

      this.activeModal.close(questions);
    }
  }

  public closeDialog(): void {
    this.activeModal.close();
  }
}
