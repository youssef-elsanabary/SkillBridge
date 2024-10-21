import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Base } from '../_modules/base';
import { Service } from '../_modules/service';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(public http:HttpClient) {}
  url : string = "https://localhost:7234/api/Services"
  allServices(){
    return this.http.get<any>(this.url)
  }
  add(service : Service){
    return this.http.post<any>(this.url,service,{observe:"response"})
  }
  serviceById(id :number){
    return this.http.get<any>(this.url+"/"+id)
  }
  serviceByUserId(id:number){
    return this.http.get<any>(this.url+"/users/"+id)
  }
  deleteService(id : number){
    return this.http.delete<any>(this.url+"/"+id)
  }
  editService(id : number,service : Service){
    return this.http.put<any>(this.url+"/"+id,service,{observe:"response"})
  }
}
