import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { clinicsList } from '../clinics';
import {ClinicService } from '../clinic.service';
 // import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-clinic',
  templateUrl: './clinic.component.html',
  styleUrls: ['./clinic.component.css']
})
export class ClinicComponent implements OnInit {
  clinic;
  method;
  clinicName;
  // registerForm: FormGroup;

  constructor(private route: ActivatedRoute,
    private clinicService: ClinicService) { 

  }

  ngOnInit() {
    this.route.paramMap.subscribe(params=> {
      this.clinic = clinicsList[params.get('id')];
      this.method = params.get('method');
    });
  }
  
  create(){
    if(!this.validate(this.clinicName)){
      alert('Name is required');
      return;
    }

    this.clinicService.createClinic(this.clinicName);
  }

  edit(){
    if(!this.validate(this.clinicName)){
      alert('Name is required');
    }

    this.clinicService.updateClinic(this.clinic, this.clinicName);
  }
  
  delete(){
    this.clinicService.deleteClinic(this.clinic.id);
  }

  validate(element):boolean {
        if(element == '' || element == undefined){
          return false;
        }

      return true;
  }
}
