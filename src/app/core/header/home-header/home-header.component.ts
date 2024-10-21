import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-home-header',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './home-header.component.html',
  styleUrl: './home-header.component.css'
})
export class HomeHeaderComponent implements OnInit {
  constructor(public router : Router){}
  ngOnInit(): void {
    this.userId=this.t.Id
  }
  navigateProfile(){
    this.router.navigateByUrl("/home/profile/"+this.userId)
  }
  token = localStorage.getItem('token');
  t : {unique_name :string , role : string ,Id :number} =jwtDecode(this.token!);
  userId : number = 0;
  massege(){
    this.router.navigateByUrl("/home/Massege")
  }
}
