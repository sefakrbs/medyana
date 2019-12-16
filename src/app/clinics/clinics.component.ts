import { Component, OnInit } from '@angular/core';
import { ClinicService } from '../clinic.service';
import { clinicsList } from '../clinics';
import { Router } from '@angular/router';

@Component({
  selector: 'app-clinics',
  templateUrl: './clinics.component.html',
  styleUrls: ['./clinics.component.css']
})
export class ClinicsComponent implements OnInit {

  list = clinicsList;
  constructor(
    private service: ClinicService,
    private router: Router) {
   }

  ngOnInit() {
    // this.clinics = this.service.getClinicList();
  }

  edit(url, id, method){
    this.router.navigate([url, id, 'edit']);
  }

  delete(url, id, method){
    this.router.navigate([url, id, 'delete']);
  }

  createNew(url, method) {
    this.router.navigate([url, 'create']);
  }

  deneme (){
    this.service.deleteClinic(6);
  }

}
