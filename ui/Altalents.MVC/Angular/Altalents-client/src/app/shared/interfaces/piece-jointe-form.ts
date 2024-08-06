import { FormControl } from "@angular/forms";

export interface PieceJointeForm {
    pieceJointe: FormControl<File | null>
    commentaire: FormControl<string | null>
}