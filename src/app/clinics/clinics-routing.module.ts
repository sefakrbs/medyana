import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ClinicsComponent } from './clinics.component';
import { ClinicComponent } from '../clinic/clinic.component';

const routes = [
  { path: '', component: ClinicsComponent },  
  { path: 'clinic/:method', component: ClinicComponent },
  { path: 'clinic/:id/:method', component: ClinicComponent }
];

@NgModule({
  imports: [ RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ClinicsRoutingModule { }
