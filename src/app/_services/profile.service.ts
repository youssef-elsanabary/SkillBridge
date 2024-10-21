import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Profile } from '../_modules/profile';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class ProfileService implements OnInit {
  constructor(public httpClient : HttpClient , public router :Router ,public userServices : UserService) { }
  ngOnInit(): void {
    this.url = this.userServices.url
  }
    url :string = ""
  
  profileById(id : number){
    return this.httpClient.get<any>(this.url+"/"+id+"/profiles");
  }
}
