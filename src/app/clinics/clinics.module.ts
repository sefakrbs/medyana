import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ClinicsRoutingModule } from './clinics-routing.module';
import { ClinicsComponent } from './clinics.component';
import { ClinicComponent } from '../clinic/clinic.component';


const routes = [
  { path: '', component: ClinicsComponent },  
  { path: 'clinic/:method', component: ClinicComponent },
  { path: 'clinic/:id/:method', component: ClinicComponent }
];

@NgModule({
  declarations: [ClinicsComponent, ClinicComponent],
  imports: [
    CommonModule,
    ClinicsRoutingModule,
    RouterModule.forChild(routes)
  ]
})
export class ClinicsModule { }
