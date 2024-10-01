import { QuestionInsertDto, QuestionnaireDto } from "../services/generated/api/api.client";

export class Question {
    id?: string;
    ordre!: number;
    isObligatoire!: boolean;
    isShowDt!: boolean;
    question!: string;
    reponse?: string | null;
    
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
    
    public static from(dto: QuestionnaireDto): Question {
      let model = new Question();
      model.id = dto.id;
      model.isObligatoire = dto.isObligatoire;
      model.question = dto.question ?? "";
      model.reponse = dto.reponse;
      return model;
    }

    public static fromList(dtos: QuestionnaireDto[]): Question[] {
      let models: Question[] = [];
      dtos.forEach(dto => {
        if(dto.question) {
          models.push(Question.from(dto));
        }
      });
      return models;
    }
}