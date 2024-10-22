import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from '../../core/header/header.component';
import { FooterComponent } from '../../core/footer/footer.component';
import { ProfileService } from '../../_services/profile.service';
import { CommonModule, DatePipe } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { Profile } from '../../_modules/profile';
import { jwtDecode } from 'jwt-decode';
import { User } from '../../_modules/user';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../_services/user.service';
import { AddComponent } from "../../user/add/add.component";
import { ServiceService } from '../../_services/service.service';
import { Service } from '../../_modules/service';
import { DeleteComponent } from '../../user/delete/delete.component';
import { DeleteServicesComponent } from '../../services/delete-services/delete-services.component';
import { differenceInDays, differenceInHours } from 'date-fns';

@Component({
  selector: 'app-profile-details',
  standalone: true,
  imports: [HeaderComponent, FooterComponent, FormsModule, CommonModule, AddComponent,DeleteServicesComponent],
  templateUrl: './profile-details.component.html',
  styleUrl: './profile-details.component.css',
  providers:[DatePipe]
})
export class ProfileDetailsComponent  implements OnInit{
  constructor(
    public userService:UserService,
    public router :Router,
     public datePipe: DatePipe ,
     public activatedRoute : ActivatedRoute ,
     public servicesServices : ServiceService,
     public profileServices : ProfileService
    ){
    this.updateTime()
  }
  isModalVisible: boolean = true;
  currentTime: string | null = "50";
  userId : number = 0;
  token = localStorage.getItem('token');
  t : {unique_name :string , role : string ,Id :number} =jwtDecode(this.token!);
  profile : User = new User("","","","","","","","","",new Date());
  allServices : Service[] = [];
  
  ngOnInit(): void {
    this.userId = this.activatedRoute.snapshot.params['id'];
    this.activatedRoute.params.subscribe(
      p=>{
        this.userService.getById(p['id']).subscribe({          
          next : data =>{
            this.profile = data
            this.displayServices();
          },error : e => {  
            return e
          }
        })
      }
    )
}
serviceDetails(id : number){
  this.router.navigateByUrl("home/service/details/"+id)
}
displayServices(){
  this.servicesServices.serviceByUserId(this.userId).subscribe({
    next : data=>{
        this.allServices = data;        
    },error : e=>{
      return e
    }
  })
}
updateTime() {
  const now = new Date();
  this.currentTime = this.datePipe.transform(now, 'h:mm:ss a');
}
editProfile(){
  this.userService.editById(this.userId,this.profile).subscribe({
    next : success =>{
      this.closeModal();
      console.log("edit bio Done");
      //this.closeModal();
      // this.router.navigateByUrl("/home/profile/"+this.userId)
      console.log(this.profile);    
    },error :err=>{
      return err;
    }
  })
  this.closeModal();
}
closeModal() {
  this.isModalVisible = false;
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
editService(id? : number){
  this.router.navigateByUrl("home/service/edit/"+id)
} 
serviceDeleted(id : number){
      this.servicesServices.deleteService(id).subscribe({
        next : success => {
          console.log("service deleted");
        },error : failed =>{
           console.log("service not deleted");
        }
      })
}
}
