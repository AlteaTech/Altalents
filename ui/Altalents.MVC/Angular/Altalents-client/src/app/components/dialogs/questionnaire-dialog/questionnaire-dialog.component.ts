import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { QuestionnaireForm } from 'src/app/shared/interfaces/questionnaire-form';
import { Question } from 'src/app/shared/models/question.model';
import { Questionnaire } from 'src/app/shared/models/questionnaire.model';

@Component({
  selector: 'app-questionnaire-dialog',
  templateUrl: './questionnaire-dialog.component.html',
  styleUrls: ['../../../app.component.css']
})
export class QuestionnaireDialogComponent implements OnInit {
  public questionnaire?: Questionnaire;
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
    if (this.questionnaire) {
      this.formGroup.patchValue({
        question1: this.questionnaire.questions[0].question,
        isShowDt1: this.questionnaire.questions[0].isShowDt,
        isObligatoire1: this.questionnaire.questions[0].isObligatoire,
        isQuestion2Enable: this.questionnaire.questions[1].question ? true : false,
        question2: this.questionnaire.questions[1].question,
        isShowDt2: this.questionnaire.questions[1].isShowDt,
        isObligatoire2: this.questionnaire.questions[1].isObligatoire,
        isQuestion3Enable: this.questionnaire.questions[2].question ? true : false,
        question3: this.questionnaire.questions[2].question,
        isShowDt3: this.questionnaire.questions[2].isShowDt,
        isObligatoire3: this.questionnaire.questions[2].isObligatoire
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
      let questionnaire: Questionnaire = this.questionnaire ?? new Questionnaire();
      questionnaire.questions[0] = new Question();
      questionnaire.questions[0].ordre = 1;
      questionnaire.questions[0].isObligatoire = values.isObligatoire1 ?? false;
      questionnaire.questions[0].isShowDt = values.isShowDt1 ?? false;
      questionnaire.questions[0].question = values.question1 ?? "";
      questionnaire.questions[1] = new Question();
      questionnaire.questions[1].ordre = 2;
      questionnaire.questions[1].isObligatoire = values.isObligatoire2 ?? false;
      questionnaire.questions[1].isShowDt = values.isShowDt2 ?? false;
      questionnaire.questions[1].question = values.question2 ?? "";
      questionnaire.questions[2] = new Question();
      questionnaire.questions[2].ordre = 3;
      questionnaire.questions[2].isObligatoire = values.isObligatoire3 ?? false;
      questionnaire.questions[2].isShowDt = values.isShowDt3 ?? false;
      questionnaire.questions[2].question = values.question3 ?? "";

      this.activeModal.close(questionnaire);
    }
  }

  public closeDialog(): void {
    this.activeModal.close();
  }
}
