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
  constructor(private router: Router) {
    
   }

  ngOnInit() {
    
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
