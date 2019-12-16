import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EquipmentComponent } from '../equipment/equipment.component';
import { EquipmentsComponent } from './equipments.component';

const routes: Routes = [
  { path: '', component: EquipmentsComponent },  
  { path: 'equipment/:id/:method', component: EquipmentComponent },
  { path: 'equipment/:method', component: EquipmentComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EquipmentsRoutingModule { }
