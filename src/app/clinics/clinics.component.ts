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
  dtOptions: DataTables.Settings = {};
  list = clinicsList;
  constructor(
    private service: ClinicService,
    private router: Router) {
   }

  ngOnInit() {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 2,
      processing: true
    };
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

}
