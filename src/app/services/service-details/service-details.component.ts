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
import { ContractService } from '../../_services/contract.service';
import { Contract } from '../../_modules/contract';
import { AddContractComponent } from "../../_contract/add-contract/add-contract.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-service-details',
  standalone: true,
  imports: [HeaderComponent, FooterComponent, AddContractComponent, CommonModule],
  templateUrl: './service-details.component.html',
  styleUrl: './service-details.component.css'
})
export class ServiceDetailsComponent implements OnInit {
  constructor(
    public service :ServiceService,
    public router :Router,
    public activatedRoute : ActivatedRoute,
    public prposalServices : PrposalServiceService,
    public userServices : UserService,
    public contracrService: ContractService
    ){}
  serviceId : number = 0;
  //userId : number = 0;
  userRole : string ="";
  allPrposal :Prposal[] = [];
  prposal : Prposal = new Prposal(0,0,new Date(),"");
  contract : Contract = new Contract(0,0,"",0,0,new Date);
  one : Service = new Service(0,"","",0,"","",new Date());
  user : User = new User("","","","","","");
  // prposalUser : User = new User("","","","","","");

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
            this.getServiceContract(this.one.serviceId!);
          },error : e =>{
            return e;
          }
        })
      }
    )
   console.log(this.contract);
   
  }
  addProposel(){
    this.router.navigate(["home/service/prposal"],{queryParams : {data :this.one.serviceId}})
  }
  showprposal(id : number){
    this.prposalServices.getPrposalByServiceId(id).subscribe({
      next : data => {
        this.allPrposal = data;
        this.allPrposal.forEach((item)=>{
          this.userServices.getById(item.userId).subscribe({
            next:data=>{
              //this.prposalUser=data;
              item.user =data
            }
          })
        })
      },error : e =>{
        return e ;
      }
    }
    );
  }
  deletePrposal(prposalNumber : number){
    this.prposalServices.deletePrposal(prposalNumber).subscribe({
      next : deleted =>{
        this.allPrposal = this.allPrposal.filter(item => item.proposalId !== prposalNumber);
        
      },error : err =>{
        return err; 
      }
    }) 
  }
  clacDate(date : Date){
    let currentDate : Date = new Date();
    let differance = differenceInDays(currentDate,date);
    return differance;
  }
  getServiceContract(id : number){
    this.contracrService.getContractByServiceId(id).subscribe({
      next : success =>{
        this.contract = success
        console.log("contract sucess");
        
      },error : err =>{
        console.log("contract error"+err);
        
        return err
      }
    })
  }
  // makeContract(){
  //   this.contracrService.addContract(this.newContract).subscribe({
  //     next : success =>{

  //     },error:err =>{
  //       return err;
  //     }
  //   })
  // }
}
