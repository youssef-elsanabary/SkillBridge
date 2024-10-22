import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceService } from '../../_services/service.service';

@Component({
  selector: 'app-delete-services',
  standalone: true,
  imports: [],
  templateUrl: './delete-services.component.html',
  styleUrl: './delete-services.component.css'
})
export class DeleteServicesComponent {
  constructor(private activatedRoute : ActivatedRoute, private router : Router, private servic:ServiceService){}
  
  makeContract(){
    console.log("hamadaaaaaaaa");
    
  }

  serviceDeleted(){
    console.log("delete");
    
    this.activatedRoute.params.subscribe(
      p=>{
        this.servic.deleteService(p['id']).subscribe({
          next : success => {
            console.log(success);
            this.router.navigateByUrl("/home/HomeClient")
          },error : failed =>{
            console.log(failed);
             
          }
        })
      }
    )
  }
}
