import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Base } from '../_modules/base';
import { User } from '../_modules/user';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  constructor(public http:HttpClient , public router : Router) { }
  isAuth : boolean = false;
  loginUrl : string =`https://localhost:7234/api/auth/login`
  registerUrl : string =`https://localhost:7234/api/auth/register`

  register(user : User){
    return this.http.post<User>(this.registerUrl,user,{ observe :'response'});
  }

  login(userObj : any): Observable<HttpResponse<any>>{
    return this.http.post<any>(this.loginUrl,userObj, { observe: 'response' });
  }
  
  logout(){
    localStorage.removeItem("token");
    this.isAuth=false;
  }
}
