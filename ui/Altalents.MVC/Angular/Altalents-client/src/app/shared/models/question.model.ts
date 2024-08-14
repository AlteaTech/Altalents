import { QuestionInsertDto } from "../services/generated/api/api.client";

export class Question {
    ordre!: number;
    isObligatoire!: boolean;
    isShowDt!: boolean;
    question!: string;
    
    public static to(model: Question): QuestionInsertDto {
      let dto = new QuestionInsertDto();
      dto.ordre = model.ordre;
      dto.isObligatoire = model.isObligatoire;
      dto.isShowDt = model.isShowDt;
      dto.question = model.question;
      return dto;
    }

    public static toList(models: Question[]): QuestionInsertDto[] {
      let dto: QuestionInsertDto[] = [];
      models.forEach(model => {
        if(model.question) {
          dto.push(Question.to(model));
        }
      });
      return dto;
    }
}