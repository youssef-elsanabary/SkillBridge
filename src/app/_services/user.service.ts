import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Base } from '../_modules/base';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(public http:HttpClient) { }
  url : string = 'https://localhost:7234/api/Users'
  getById(id : number){
    return this.http.get<any>(this.url+"/"+id)
  }
}
 