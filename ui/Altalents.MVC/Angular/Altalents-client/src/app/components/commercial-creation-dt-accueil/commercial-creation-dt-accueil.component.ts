import { Component } from '@angular/core';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';

@Component({
  selector: 'app-commercial-creation-dt-accueil',
  templateUrl: './commercial-creation-dt-accueil.component.html',
  styleUrls: ['./commercial-creation-dt-accueil.component.css','../../app.component.css']
})
export class CommercialCreationDtAccueilComponent {
pathConfigDt: string = `${ConstantesRoutes.commercialAccueilCreateDt}/${ConstantesRoutes.commercialAccueilConfigurationDt}`;

}
