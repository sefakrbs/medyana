import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { equipmentList} from '../equipments';

@Component({
  selector: 'app-equipment',
  templateUrl: './equipment.component.html',
  styleUrls: ['./equipment.component.css']
})
export class EquipmentComponent implements OnInit {
  equipment;
  method;
  constructor(private route: ActivatedRoute) {

   }

  
  ngOnInit() {
    this.route.paramMap.subscribe(params=> {
      this.equipment = equipmentList[params.get('id')];
      this.method = params.get('method');
    });
  }
  
  create(name){
    if(!this.validate(name)){
      alert('Name is required');
      return;
    }

  }

  edit(id, name){
    if(!this.validate(name)){
      alert('Name is required');
      return;
    }

  }
  
  delete(){
    
    }

    validate(params: []):boolean {
      params.forEach(element => {
        if(element == ''){
          return false;
        }
      });

      return true;
    }
}
