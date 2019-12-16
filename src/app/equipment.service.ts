import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ajax } from 'rxjs/ajax';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {
  
  constructor(private http: HttpClient) { }
  
  getEquipmentList(){
    return ajax({url: 'http://localhost:52814/Equipment/EquipmentList', crossDomain:true});
  }

  createEquipment(name: string){
    const data = ajax({url: 'http://localhost:52814/Equipment/Create', crossDomain:true , body: { Name: name}});
     data.subscribe(res =>{
      if(!res.response || res.response == -1){
        return "operation is not successful";
      }

      return "successfuly created. Id is: " + res.response;    
    });    
  }
    
  updateEquipment(id, name: string){
    const data = ajax({url: 'http://localhost:52814/Equipment/Update', crossDomain:true , body: {Id:id, Name: name}});
    data.subscribe( res => {
      if(!res.response || res.response == -1){
        return "operation is not successful";
      }

      return "successfuly updated. Id is: " + res.response;
    });
  }

    deleteEquipment(id){
      const data = ajax({url: 'http://localhost:52814/Equipment/Delete', body: { id: id}, crossDomain:true });
      data.subscribe( res => {
        if(!res.response || res.response == -1){
          return "operation is not successful";
        }

        return "successfuly deleted.";
      });
    }
}
