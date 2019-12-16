import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: 'clinics', loadChildren: () => import('./clinics/clinics.module').then(m => m.ClinicsModule) }, 
  { path: 'equipments', loadChildren: () => import('./equipments/equipments.module').then(m => m.EquipmentsModule) 
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
