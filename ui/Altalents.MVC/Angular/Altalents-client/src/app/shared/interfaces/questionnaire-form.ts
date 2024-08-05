import { FormControl } from "@angular/forms";

export interface QuestionnaireForm {
    question1: FormControl<string | null>,
    isObligatoire1: FormControl<boolean | null>,
    isShowDt1: FormControl<boolean | null>,
    isQuestion2Enable: FormControl<boolean | null>,
    question2: FormControl<string | null>,
    isObligatoire2: FormControl<boolean | null>,
    isShowDt2: FormControl<boolean | null>,
    isQuestion3Enable: FormControl<boolean | null>,
    question3: FormControl<string | null>,
    isObligatoire3: FormControl<boolean | null>,
    isShowDt3: FormControl<boolean | null>
}