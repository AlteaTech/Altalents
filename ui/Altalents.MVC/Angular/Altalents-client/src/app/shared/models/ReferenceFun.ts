import { ReferenceDto } from "../services/generated/api/api.client"

export class ReferenceFun {
  id!: string
  libelle!: string

  static fromReferenceDto(dto : ReferenceDto):ReferenceFun{
    var model = new ReferenceFun ();
    model.id = dto.id!;
    model.libelle = dto.libelle!;
    if(dto.commentaireFun && dto.commentaireFun.length > 0){
      model.libelle = model.libelle + "("+dto.commentaireFun+")";
    }
    return model;
  }

  static fromListReferenceDto(dtos : ReferenceDto[]):ReferenceFun[]{
    var model :ReferenceFun[] = [];
    dtos.forEach(dto => {
      model.push(this.fromReferenceDto(dto));
    });
    return model;
  }

}
