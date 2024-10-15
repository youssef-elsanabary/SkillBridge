import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Base } from '../_modules/base';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(public http:HttpClient) {}
  url : string = "https://localhost:7234/api/Services"
  allServices(){
    return this.http.get<any>(this.url)
  }
}
