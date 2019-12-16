import { Component, OnInit } from '@angular/core';
import { equipmentList } from '../equipments';
import { Router } from '@angular/router';

@Component({
  selector: 'app-equipments',
  templateUrl: './equipments.component.html',
  styleUrls: ['./equipments.component.css']
})
export class EquipmentsComponent implements OnInit {
  list=equipmentList;
  dtOptions: DataTables.Settings = {};
  constructor(private router: Router) {
    
   }

  ngOnInit() {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 2,
      processing: true
    };
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
