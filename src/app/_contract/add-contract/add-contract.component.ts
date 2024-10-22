import { Component, Input, OnInit } from '@angular/core';
import { HeaderComponent } from '../../core/header/header.component';
import { FooterComponent } from '../../core/footer/footer.component';
import { ContractService } from '../../_services/contract.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Contract } from '../../_modules/contract';
import { FormsModule } from '@angular/forms';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-add-contract',
  standalone: true,
  imports: [HeaderComponent,FooterComponent,FormsModule],
  templateUrl: './add-contract.component.html',
  styleUrl: './add-contract.component.css'
})
export class AddContractComponent implements OnInit {
  constructor(public contractService :ContractService,public router:Router,public activatedRoute : ActivatedRoute){}
  
  newContract : Contract = new Contract(0,0,"",0,0,new Date);
  token = localStorage.getItem("token");
  t : {unique_name :string , role : string ,Id :number} =jwtDecode(this.token!)
  @Input()
  sId : number = 0;

  ngOnInit(): void {
    this.newContract.userId = this.t.Id;
    this.newContract.serviceId = this.sId;
    this.newContract.createdDate = new Date;
  }
  
  makeContract(){
    this.contractService.addContract(this.newContract).subscribe({
      next : success=>{
        console.log(this.newContract);
        
        console.log("contractAdded");
        
      },error : err=>{
        console.log(this.newContract);
        console.log(err);
        console.log("errorr");
        
      }
    })
  }
}
