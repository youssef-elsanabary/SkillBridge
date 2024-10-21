import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from "../../core/header/header.component";
import { FooterComponent } from "../../core/footer/footer.component";
import { ServiceService } from '../../_services/service.service';
import { Service } from '../../_modules/service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-add-service',
  standalone: true,
  imports: [HeaderComponent, FooterComponent,FormsModule],
  templateUrl: './add-service.component.html',
  styleUrl: './add-service.component.css'
})
export class AddServiceComponent implements OnInit {
  constructor(public service : ServiceService, public router :Router){}
  userId : number = 0;
  userToken = localStorage.getItem("token");
  t : {unique_name :string , role : string ,Id :number} =jwtDecode(this.userToken!)
  ngOnInit(): void {
    this.userId =this.t.Id;
    this.newService.userId = this.userId;
  }
  newService : Service = new Service(0,"","",0,"","",new Date())
  add(){
    this.service.add(this.newService).subscribe({
      next : response =>{
        alert("Service Added")
        this.router.navigateByUrl("/home/HomeClient")
      },error : e =>{
        alert("Added Failed")
        return e
      }
    })
  }
}
