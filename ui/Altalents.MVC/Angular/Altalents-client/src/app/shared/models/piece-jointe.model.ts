import { DocumentDto, DossierTechniqueInsertRequestDto } from "../services/generated/api/api.client";

export class PieceJointe {

    mimeType!: string;
    nomFichier!: string;
    data!: string;
    commentaire?: string;

    public static from(dto : DocumentDto):PieceJointe{

        var model = new PieceJointe ();

        model.data = dto.data;
        model.mimeType = dto.mimeType;
        model.nomFichier = dto.nomFichier;
        model.commentaire = dto.commentaire!;

        return model;

      }


      public static fromListToDtos(pjs : PieceJointe[]):DocumentDto[]{
        var model: DocumentDto[] = [];
        pjs.forEach(pj => {
          model.push(PieceJointe.populateDocumentDto(pj));
        });
        return model;
      }

      public static populateDocumentDto( pj : PieceJointe) : DocumentDto {

        let documentDto: DocumentDto = new DocumentDto();
        documentDto.mimeType = pj.mimeType;
        documentDto.nomFichier = pj.nomFichier;
        documentDto.commentaire = pj.commentaire;
        documentDto.data = pj.data;
    
        return documentDto;
        
    }
    


      public static toBase64(file: File): Promise<string> {
        return new Promise((resolve) => {
          const reader = new FileReader();
          reader.readAsDataURL(file);
          reader.onload = () => {
            resolve(reader.result?.toString().split(',')[1] ?? "");
          };
        })
      }
}