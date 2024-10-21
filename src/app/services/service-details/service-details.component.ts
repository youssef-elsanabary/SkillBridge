import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../../_services/service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Service } from '../../_modules/service';
import { HeaderComponent } from '../../core/header/header.component';
import { FooterComponent } from '../../core/footer/footer.component';
import { jwtDecode } from 'jwt-decode';
import { Prposal } from '../../_modules/prposal';
import { PrposalServiceService } from '../../_services/prposal-service.service';
import { differenceInDays } from 'date-fns';
import { UserService } from '../../_services/user.service';
import { User } from '../../_modules/user';

@Component({
  selector: 'app-service-details',
  standalone: true,
  imports: [HeaderComponent,FooterComponent],
  templateUrl: './service-details.component.html',
  styleUrl: './service-details.component.css'
})
export class ServiceDetailsComponent implements OnInit {
  constructor(
    public service :ServiceService,
    public router :Router,
    public activatedRoute : ActivatedRoute,
    public prposalServices : PrposalServiceService,
    public userServices : UserService
    ){}
  serviceId : number = 0;
  //userId : number = 0;
  userRole : string ="";
  allPrposal :Prposal[] = [];
  prposal : Prposal = new Prposal(0,0,new Date(),"");
  one : Service = new Service(0,"","",0,"","",new Date());
  user : User = new User("","","","","","");
  token = localStorage.getItem('token');
  t : {unique_name :string , role : string ,Id :number} =jwtDecode(this.token!);


  ngOnInit(): void {
    this.userRole = this.t.role
    this.serviceId=this.activatedRoute.snapshot.params['id']
    this.one.serviceId = this.serviceId
    
    this.activatedRoute.params.subscribe(
      p=>{
        this.service.serviceById(p['id']).subscribe({
          next : data =>{
            this.one = data
            this.userServices.getById(this.one.userId).subscribe({
              next : data =>{
                this.user = data                
              },error :err=> {
                return err
              },
            })
            //////////////
            this.showprposal(this.one.serviceId!);
          },error : e =>{
            return e;
          }
        })
      }
    )
   
  }
  addProposel(){
    this.router.navigate(["home/service/prposal"],{queryParams : {data :this.one.serviceId}})
  }
  showprposal(id : number){
    this.prposalServices.getPrposalByServiceId(id).subscribe({
      next : data => {
        this.allPrposal = data;
      },error : e =>{
        return e ;
      }
    }
    );
  }
  deletePrposal(){
    this.prposalServices.deletePrposal(this.prposal.proposalId!) //wrong state because of prposal id
  }
  clacDate(date : Date){
    let currentDate : Date = new Date();
    let differance = differenceInDays(currentDate,date);
    return differance;
  }
  makeContract(){
    
  }
  getUserData(id : number){
    
  }
}
