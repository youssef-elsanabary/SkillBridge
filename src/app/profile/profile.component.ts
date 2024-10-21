import { CommonModule, DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../_services/profile.service';
import { Profile } from '../_modules/profile';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule ,FormsModule],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css',
  providers:[DatePipe]
})
export class ProfileComponent implements OnInit {
  constructor(public profileService:ProfileService, public datePipe: DatePipe ,public activatedRoute : ActivatedRoute){
    this.updateTime()
  }
  profile : Profile = new Profile(0,"","","","","","",new Date());
  newProfile : Profile = new Profile(1,"youssef","full stack","developer since 2020","mgnon","sdfs","dfsfd",new Date(2024, 9, 14, 21, 50, 0));
  currentContent : string =""
  currentTime: string | null = "50";

  ngOnInit(): void {
    
    console.log(this.currentTime);
    this.activatedRoute.params.subscribe(
      p=>{
        this.profileService.profileById(p['id']).subscribe({
          next : data =>{
            this.profile = data
            console.log("hamada");
            
          },error : e => {
            return e
          }
        })
      }
    )
    
    // this.profileService.getAll().subscribe({
    //   next : data =>{
    //     this.profile = data
    //   },error : e =>{
    //     return e
    //   }
    // })
  }
   save(){}

  //   this.profileService.add(this.newProfile).subscribe({
  //     next : response =>{
  //       console.log(response);
  //       console.log(this.newProfile);
  //     },error : e =>{
  //       console.log(e);
  //       console.log(this.newProfile);
  //     } 
  //   })
  // }
  updateTime() {
    const now = new Date();
    this.currentTime = this.datePipe.transform(now, 'h:mm:ss a');
  }
  showContent(data:string){
    this.currentContent = data
  }
}