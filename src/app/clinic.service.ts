import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ajax } from 'rxjs/ajax';

@Injectable({
  providedIn: 'root'
})
export class ClinicService {

  constructor(private http: HttpClient) { 

  }

  getClinicList(){
    // return this.clinics;
    return ajax({url: 'http://localhost:52814/Clinic/ClinicList', crossDomain:true});
  }

  createClinic(name: string){
    const data = ajax({ url:'http://localhost:52814/Clinic/Create', method:'POST',  body: { Name: name}, crossDomain:true });
    data.subscribe( res => {
      if(!res.response || res.response == -1){
        return "operation is not successful";
      }

      return "successfuly created. Id is: " + res.response;
    });
  }
    
  updateClinic(id, name: string){
    const data = ajax({ url:'http://localhost:52814/Clinic/Update', method:'POST',  body: { Id: id, Name: name}, crossDomain:true });
    data.subscribe( res => {
      if(!res.response || res.response == -1){
        return "operation is not successful";
      }

      return "successfuly updated. Id is: " + res.response;
    });
  }

    deleteClinic(id){
      const data = ajax({ url:'http://localhost:52814/Clinic/Delete', method:'POST',  body: { id: id}, crossDomain:true })
      data.subscribe( res => {
        if(!res.response || res.response == -1){
          return "operation is not successful";
        }

        return "successfuly deleted.";
      });
    }
}

