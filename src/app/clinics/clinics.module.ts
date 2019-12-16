import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import {DataTablesModule} from 'angular-datatables';

import { ClinicsRoutingModule } from './clinics-routing.module';
import { ClinicsComponent } from './clinics.component';
import { ClinicComponent } from '../clinic/clinic.component';

@NgModule({
  declarations: [ClinicsComponent, ClinicComponent],
  imports: [
    CommonModule,
    ClinicsRoutingModule,
    DataTablesModule
  ]
})
export class ClinicsModule { }
