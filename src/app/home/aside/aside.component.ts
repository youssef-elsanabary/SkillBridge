import { Component, OnInit } from '@angular/core';
import { User } from '../../_modules/user';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-aside',
  standalone: true,
  imports: [],
  templateUrl: './aside.component.html',
  styleUrl: './aside.component.css'
})
export class AsideComponent implements OnInit {
constructor(public router : Router){}
  ngOnInit(): void {
    this.userName = this.t.unique_name;
    this.userId = this.t.Id
  }
  userName : string = "";
  userId : number = 0;
  token = localStorage.getItem('token');
  t : {unique_name :string , role : string ,Id :number} =jwtDecode(this.token!);
  profileRoute(){
    this.router.navigateByUrl("/home/profile/"+this.userId)
  }
}
