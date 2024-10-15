import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Profile } from '../_modules/profile';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  constructor(public httpClient : HttpClient , public router :Router) { }
  url : string = "https://localhost:7234/api/Profiles"
  
  add(profile : Profile){
    return this.httpClient.post<any>(this.url,profile,{observe:"response"});
  }
  getAll(){
    return this.httpClient.get<any>(this.url)
  }
}
