import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Contract } from '../_modules/contract';

@Injectable({
  providedIn: 'root'
})
export class ContractService {

  constructor(public http : HttpClient) { }
  url : string = "https://localhost:7234/api/Contracts";
  addContract(contract : Contract){
    return this.http.post<any>(this.url,contract);
  }
  getContractByServiceId(serviceId : number){
    return this.http.get<any>(this.url+"/services/"+serviceId);
  }
}
