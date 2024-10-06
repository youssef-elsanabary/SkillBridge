import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Base } from '../_modules/base';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  constructor(public http:HttpClient) { }
  isAuth : boolean = false;
  url : string =""
  login(email : string ,pass :string){
    this.http.get<string>(this.url,
      {params:{'':email,'':pass}})
      // {responseType:'text',params:{'':email,'':pass}})
      .subscribe(
        //ok
        {next : t=>{
      localStorage.setItem("token", t);
      this.isAuth = true;
        },
        //error
        error : e=>{

        }
    });
  }
  logout(){
    localStorage.removeItem("token");
    this.isAuth=false;
  }
}
