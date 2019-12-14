import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { clinicsList } from '../clinics';
// import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-clinic',
  templateUrl: './clinic.component.html',
  styleUrls: ['./clinic.component.css']
})
export class ClinicComponent implements OnInit {
  clinic;
  method;
  // registerForm: FormGroup;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params=> {
      this.clinic = clinicsList[params.get('id')];
      this.method = params.get('method');
    });
  }
  
  create(name){
    if(!name){
      alert('Name is required');
      return;
    }

  }

  edit(id, name){
    if(!name){
      alert('Name is required');
      return;
    }

  }
  
  delete(){
    
    }
}
