import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from "../../core/header/header.component";
import { FooterComponent } from "../../core/footer/footer.component";
import { PrposalServiceService } from '../../_services/prposal-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Prposal } from '../../_modules/prposal';
import { jwtDecode } from 'jwt-decode';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-prposal',
  standalone: true,
  imports: [HeaderComponent, FooterComponent,FormsModule],
  templateUrl: './add-prposal.component.html',
  styleUrl: './add-prposal.component.css'
})
export class AddPrposalComponent implements OnInit {
  constructor(private prposalServices : PrposalServiceService , private router : Router ,private activatedRoute : ActivatedRoute){}
  ngOnInit(): void {
    this.newPrposal.userId = this.t.Id
    this.newPrposal.status
    this.activatedRoute.queryParams.subscribe(params => {
      this.serviceId = params['data'];
    });
    this.newPrposal.serviceId = this.serviceId;
  }
  token = localStorage.getItem("token");
  t : {unique_name :string , role : string ,Id :number} =jwtDecode(this.token!)
  newPrposal : Prposal = new Prposal(0,1,new Date,"");
  serviceId : number = 0;
  addPrrposal(){
    console.log(this.newPrposal);
    
    this.prposalServices.addPrposal(this.newPrposal).subscribe({
      next : respnse =>{
        console.log("prposal Added");
        this.router.navigateByUrl("home/service/details/"+this.newPrposal.serviceId)
        console.log(this.newPrposal);
        
      },error : error =>{
        console.log("failed to add prposal");
        
      }
    })
  }
}
