import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Base } from '../_modules/base';
import { User } from '../_modules/user';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  constructor(public http:HttpClient , public router : Router) { }
  isAuth : boolean = false;
  loginUrl : string =`https://localhost:7234/api/auth/login`
  registerUrl : string =`https://localhost:7234/api/auth/register`

  register(user : User){
    this.http.post<string>(this.registerUrl,user).subscribe(
          //ok 
          {
            next : t => {
              this.router.navigateByUrl("home");
              alert("registration done")
              console.log("registration done");
            },//error
            error : r =>{
              alert("registration failed")
              console.log("registration failed")
            }
          }
        )
  }

  login(userObj : any){
    this.http.post<string>(this.loginUrl,userObj)
      // {responseType:'text',params:{'':email,'':pass}})
      .subscribe(
        //ok
        {next : t=>{
          alert("login done");
          this.router.navigateByUrl("home");
          localStorage.setItem("token", t);
          this.isAuth = true;
        },
        //error
        error : e=>{
          alert("login failed");
          console.log(e);
          
        }
    });
  }
  
  logout(){
    localStorage.removeItem("token");
    this.isAuth=false;
  }
}
