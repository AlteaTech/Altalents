import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-accueil',
  templateUrl: './accueil.component.html'
})
export class AccueilComponent implements OnInit {
  public nomPrenomCandidat: string = "";

  constructor(private route: ActivatedRoute) {
    
  }
  
  public ngOnInit(): void {
    const idCandidat = this.route.snapshot.paramMap.get("idCandidat");
    // TODO : appeler le back pour avoir le nom prénom du candidat 
    this.nomPrenomCandidat = "Mr. MOCK " + idCandidat;
  }
}
