import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from '../../core/header/header.component';
import { FooterComponent } from '../../core/footer/footer.component';
import { FormsModule } from '@angular/forms';
import { Service } from '../../_modules/service';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceService } from '../../_services/service.service';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-edit-services',
  standalone: true,
  imports: [HeaderComponent,FooterComponent,FormsModule],
  templateUrl: './edit-services.component.html',
  styleUrl: './edit-services.component.css'
})
export class EditServicesComponent implements OnInit {
  constructor(public activatedRoute:ActivatedRoute, public service:ServiceService,public router :Router,private activateRoute : ActivatedRoute){}
  serviceId : number = 0
  token = localStorage.getItem('token')
  t : {unique_name :string , role : string ,Id :number} =jwtDecode(this.token!)
  oldService : Service = new Service(0,"","",0,"","",new Date(),0)

  ngOnInit(): void {
    this.serviceId=this.activateRoute.snapshot.params['id']
    this.oldService.serviceId = this.serviceId
    this.oldService.userId = this.t.Id;
    this.getServiceDetails();
  }
  done(){
    console.log(this.oldService.serviceId);
    
    this.activatedRoute.params.subscribe(
      p=>{
        this.service.editService(p['id'],this.oldService).subscribe({
          next : response => {
            alert("Edit Service Complate successfully");
            this.router.navigateByUrl("/home/HomeClient")
          },error : e =>{
            return e
          }
        })
      }
    )
  }
  getServiceDetails(){
    this.service.serviceById(this.serviceId).subscribe({
      next:data=>{
        this.oldService = data;
      },error:err =>{
        return err;
      }
    })
  }
}
