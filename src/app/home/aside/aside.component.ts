import { Component, OnInit } from '@angular/core';
import { User } from '../../_modules/user';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { UserService } from '../../_services/user.service';

@Component({
  selector: 'app-aside',
  standalone: true,
  imports: [],
  templateUrl: './aside.component.html',
  styleUrl: './aside.component.css'
})
export class AsideComponent implements OnInit {
constructor(public router : Router ,public userServices :UserService){}
  ngOnInit(): void {
    this.user.username = this.t.unique_name;
    this.userId = this.t.Id 
  }
  user:User = new User("","","","","","")
  // userName : string = "";
   userId : number = 0;
  // userBio : string = "";
  token = localStorage.getItem('token');
  t : {unique_name :string , role : string ,Id :number} =jwtDecode(this.token!);
  profileRoute(){
    this.router.navigateByUrl("/home/profile/"+this.userId)
  }
  userData(){
    this.userServices.getById(this.userId).subscribe({
      next:data =>{
        this.user = data;
      }
    })
  }
}
