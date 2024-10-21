import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Prposal } from '../_modules/prposal';

@Injectable({
  providedIn: 'root'
})
export class PrposalServiceService {

  constructor(private httpClient : HttpClient) { } 
  url : string ="https://localhost:7234/api/Proposals"

  addPrposal(prposal : Prposal){
    return this.httpClient.post<any>(this.url,prposal);
  }
  getAllPrposal(){
    return this.httpClient.get<any>(this.url);
  }
  getPrposalById(id:number){
    return this.httpClient.get<any>(this.url+"/"+id);
  }
  getPrposalByServiceId(id : number){
    return this.httpClient.get<any>(this.url+"/service/"+id)
  }
  deletePrposal(id : number){
    return this.httpClient.delete<any>(this.url+"/"+id)
  }
}
