import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Base } from '../_modules/base';
import { Service } from '../_modules/service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(public http:HttpClient) {}
  url : string = "https://localhost:7234/api/Services"
  allServices(page: number, size: number, query: string){
    let params = new HttpParams()
      .set('page', page.toString())
      .set('size', size.toString())
      .set('query', query);
    return this.http.get<any>(this.url,{params})
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
