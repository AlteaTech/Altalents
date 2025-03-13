import { PermissionConsultationDtDto } from "../services/generated/api/api.client";

export class PermissionDT {
   
    tokenAccesRapide!: string;
    isDtExist!: boolean;
    isDtAccessible!: boolean;
    isDtReadOnly!: boolean;
    isUserLoggedInBackOffice!: boolean;
    message!: string;
    codeStatutDT!: string;
    libelleStatutDT!: string;
    numLastEtapeValidated! :number;

    public static from(dto : PermissionConsultationDtDto):PermissionDT{

        var model = new PermissionDT ();

        model.tokenAccesRapide = dto.tokenAccesRapide!;
        model.isDtExist = dto.isDtExiste ?? false;
        model.isDtAccessible = dto.isDtAccessible ?? false;
        model.isDtReadOnly =  dto.isDtReadOnly ?? true;
        model.message = dto.message! ;
        model.codeStatutDT = dto.codeStatutDT!;
        model.libelleStatutDT = dto.libelleStatutDT!;
        model.isUserLoggedInBackOffice = dto.isUserLoggedInBackOffice!;
        model.numLastEtapeValidated = dto.numLastEtapeValidated! ;

        return model;

      }

}