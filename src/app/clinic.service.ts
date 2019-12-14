import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClinicService {

  constructor(private http: HttpClient) { 

  }

  getClinicList(){
    // return this.clinics;
    // return this.http.get('http://localhost:63600/Clinic/ClinicList');
  }

}
