import { DocumentDto } from "../services/generated/api/api.client";


export class DocumentDt {
    mimeType!: string;
    nomFichier!: string;
    commentaire?: string | null;
    data?: string | null;
    
    public static from(dto: DocumentDto): DocumentDt {
      let model = new DocumentDto();
      model.commentaire = dto.commentaire;
      model.data = dto.data;
      model.mimeType = dto.mimeType;
      model.nomFichier = dto.nomFichier;
      return model;
    }

    public static fromList(dtos: DocumentDto[]): DocumentDt[] {
      let models: DocumentDt[] = [];
      dtos.forEach(dto => {
        if(dto) {
          models.push(this.from(dto));
        }
      });
      return models;
    }
}