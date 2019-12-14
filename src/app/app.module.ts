import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClinicListComponent } from './clinic-list/clinic-list.component';
import { AppMenuComponent } from './app-menu/app-menu.component';
import { EquipmentListComponent } from './equipment-list/equipment-list.component';
import { ClinicComponent } from './clinic/clinic.component';

const routes = [
  { path: '', component: AppMenuComponent },
  { path:'clinic', component:ClinicListComponent},
  { path:'equipment', component:EquipmentListComponent},
  { path: 'clinic/:id/:method', component: ClinicComponent },
  { path: 'clinic/:method', component: ClinicComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    ClinicListComponent,
    AppMenuComponent,
    EquipmentListComponent,
    ClinicComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
