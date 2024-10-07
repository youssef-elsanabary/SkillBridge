import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Base } from '../_modules/base';
import { User } from '../_modules/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  constructor(public http:HttpClient) { }
  isAuth : boolean = false;
  loginUrl : string =`https://localhost:7234/api/auth/login`
  registerUrl : string =`https://localhost:7234/api/auth/register`

  register(user : User){
    this.http.post<string>(this.registerUrl,
      {
        body:{
          'username' : user.userName,
          'email' : user.email,
          'password' : user.password,
          'role' : user.role
        }}).subscribe(
          //ok 
          {
            next : t => {
              console.log("registration done");
            },//error
            error : r =>{
              console.log("registration failed")
            }
          }
        )
  }

  login(username : string ,pass :string){
    this.http.post<string>(this.loginUrl,
      {
        body:{'Username':username,'Password':pass}})
      // {responseType:'text',params:{'':email,'':pass}})
      .subscribe(
        //ok
        {next : t=>{
          console.log("login done");
          
      localStorage.setItem("token", t);
      this.isAuth = true;
        },
        //error
        error : e=>{
          console.log("login failed");
        }
    });
  }
  
  logout(){
    localStorage.removeItem("token");
    this.isAuth=false;
  }
}
