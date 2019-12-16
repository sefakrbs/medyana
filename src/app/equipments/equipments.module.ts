import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EquipmentsRoutingModule } from './equipments-routing.module';
import { EquipmentsComponent } from './equipments.component';
import { EquipmentComponent } from '../equipment/equipment.component';
import {DataTablesModule} from 'angular-datatables';


@NgModule({
  declarations: [EquipmentsComponent, EquipmentComponent],
  imports: [
    CommonModule,
    EquipmentsRoutingModule,
    DataTablesModule
  ]
})
export class EquipmentsModule { }
