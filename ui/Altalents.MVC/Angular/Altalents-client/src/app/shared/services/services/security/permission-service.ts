import { BaseComponentCallHttpComponent } from '@altea-si-tech/altea-base';
import { ElementRef, Injectable, OnInit, Renderer2 } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConstantesRequest } from 'src/app/shared/constantes/constantes-request';
import { ConstantesRoutes } from 'src/app/shared/constantes/constantes-routes';
import { PermissionDT } from 'src/app/shared/models/permissionDT.model';
import { PermissionConsultationDtDto } from '../../generated/api/api.client';
import { ApiServiceAgent } from '../../services-agents/api.service-agent';
import { from, lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class PermissionService extends BaseComponentCallHttpComponent implements OnInit {
  public tokenDossierTechnique: string = "";
  private  permissionDT: PermissionDT = new PermissionDT();

  constructor(
    private readonly service: ApiServiceAgent,
    private router: Router) {
    super();
  }

  public ngOnInit(): void 
  {

  }
  
  public getLastPermissionDT(): PermissionDT {
    return this.permissionDT;
  }

  public async getRefreshedDTPermissionAndRedirectIfNecessary(tokenRapide: string): Promise<PermissionDT> {
    try {

      // Convertir l'Observable en Promise avec lastValueFrom
      const response = await lastValueFrom(this.service.getPermissionsDT(tokenRapide));
  
      this.tokenDossierTechnique = tokenRapide;
      this.permissionDT = PermissionDT.from(response);
  
      if (!this.permissionDT.isDtExist) {
        this.router.navigateByUrl(ConstantesRoutes.dtInexistant);
      }
      else if (!this.permissionDT.isDtAccessible) {
        this.router.navigateByUrl(ConstantesRoutes.dtForbidenAccess);
      }
  
      return this.permissionDT;

    } catch (error) {
      console.error("Erreur lors de la récupération des permissions DT:", error);
      throw error;
    }
  }
  
  disableAllFields(elementRef: ElementRef, renderer: Renderer2): void {
    // Désactive tous les champs de saisie, boutons et liens, zones de dépôt,  

    const fields = elementRef.nativeElement.querySelectorAll('input, textarea, select, button, .drop-zone, .edit-link, .fa-star, .toggle-slider');
    
    fields.forEach((field: HTMLElement) => {
      if (field instanceof HTMLButtonElement) {
        renderer.setStyle(field, 'display', 'none');
      } 
      else if (field.classList.contains('drop-zone')) {
        renderer.setStyle(field, 'display', 'none');
      } 
      else if (field.classList.contains('edit-link')) {
        renderer.setStyle(field, 'display', 'none');
      } 
      else if (field.classList.contains('fa-star')) {
        const parentElement = field.parentElement;
        if (parentElement) {
          renderer.addClass(parentElement, 'clickable-item-disabled');
        }
      } 
      else if (field.classList.contains('toggle-slider')) {
        renderer.addClass(field, 'clickable-item-disabled');
      } 
      else {
        renderer.setAttribute(field, 'disabled', 'true');
      }
    });
  }
}
