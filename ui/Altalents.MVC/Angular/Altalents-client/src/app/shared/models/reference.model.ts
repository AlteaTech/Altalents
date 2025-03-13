import { ReferenceDto } from "../services/generated/api/api.client"

export class Reference {
  id!: string
  libelle!: string
  code!: string
  commentaireFun!: string

  static fromReferenceDto(dto : ReferenceDto):Reference{
    var model = new Reference ();
    model.id = dto.id!;
    model.libelle = dto.libelle!;
    model.code = dto.code!;

    if(dto.commentaireFun && dto.commentaireFun.length > 0){
      model.commentaireFun = dto.commentaireFun;
    }
    
    return model;
  }

  static fromListReferenceDto(dtos : ReferenceDto[]):Reference[]{
    var model :Reference[] = [];
    dtos.forEach(dto => {
      model.push(this.fromReferenceDto(dto));
    });
    return model;
  }

}
