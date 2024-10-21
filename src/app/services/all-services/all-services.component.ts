import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../../_services/service.service';
import { Service } from '../../_modules/service';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { DeleteServicesComponent } from "../delete-services/delete-services.component";
import { User } from '../../_modules/user';
import { ProfileService } from '../../_services/profile.service';
import { differenceInDays, differenceInHours } from 'date-fns';
import { UserService } from '../../_services/user.service';

@Component({
  selector: 'app-all-services',
  standalone: true,
  imports: [FormsModule, RouterLink, DeleteServicesComponent],
  templateUrl: './all-services.component.html',
  styleUrl: './all-services.component.css'
})
export class AllServicesComponent implements OnInit {
  constructor(
    public services : ServiceService ,
     public router : Router ,
     public activatedRoute : ActivatedRoute,
     public profileService : ProfileService,
     public userServices : UserService,
    ){} 
  
  allService : Service[] =[];
  serviceUser : User = new User("","","","","")
  userRole:string = "";
  token = localStorage.getItem('token');
  t : {unique_name :string , role : string ,Id :number} =jwtDecode(this.token!);
  
  ngOnInit(): void {
    this.userRole = this.t.role;
    this.services.allServices().subscribe({
      next : data=>{
          this.allService = data;
          this.allService.forEach((item)=>{
            this.userServices.getById(item.userId).subscribe({
              next : data =>{
                this.serviceUser = data;
              },error : err =>{
                return err;
              }
            })
          })
      },error : e=>{        
        return e
      }
    })
  }
  editService(id? : number){
    this.router.navigateByUrl("home/service/edit/"+id)
  }  
  serviceDetails(id? : number){
    this.router.navigateByUrl("home/service/details/"+id)
  }
  serviceDeleted(){
    this.activatedRoute.params.subscribe(
      p=>{
        this.services.deleteService(p['id']).subscribe({
          next : success => {
            this.router.navigateByUrl("/home/HomeClient")
          },error : failed =>{
            console.log(failed);
          }
        })
      }
    )
  }
  openProfile(id : number){
    this.router.navigateByUrl("/home/profile/"+id)
  }
  clacDate(date : Date){
    let currentDate : Date = new Date();
    let differance = differenceInDays(currentDate,date);
    if(differance >= 1){
      return differance
    }else{
      return differenceInHours(currentDate,date);
    }
  }
  getUserById(id : number){
    this.profileService.profileById(id).subscribe({
      next : data => {
        this.serviceUser = data;
      },error : e =>{
        return e ;
      }
    })
  }
}
