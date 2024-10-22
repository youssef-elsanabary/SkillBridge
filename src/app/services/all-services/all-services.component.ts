import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../../_services/service.service';
import { Service } from '../../_modules/service';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { DeleteServicesComponent } from "../delete-services/delete-services.component";
import { User } from '../../_modules/user';
import { ProfileService } from '../../_services/profile.service';
import { differenceInDays, differenceInHours } from 'date-fns';
import { UserService } from '../../_services/user.service';
import { toArray } from 'rxjs';
import { CommonModule } from '@angular/common';
import { Contract } from '../../_modules/contract';
import { ContractService } from '../../_services/contract.service';

@Component({
  selector: 'app-all-services',
  standalone: true,
  imports: [FormsModule, RouterLink, DeleteServicesComponent,CommonModule],
  templateUrl: './all-services.component.html',
  styleUrl: './all-services.component.css'
})
export class AllServicesComponent implements OnInit {
  constructor(
    public services : ServiceService ,
     public router : Router ,
     public activatedRoute : ActivatedRoute,
     public profileService : ProfileService,
     public userServices : UserService,
    public contracrService: ContractService

    ){} 
  paginatedServices: Service[] = [];
  currentPage: number = 1;
  itemsPerPage: number = 3;
  filteredServices: Service[] = [];
  searchQuery: string = ''

  totalItems: number = 0;
  contract : Contract = new Contract(0,0,"",0,0,new Date);
  allService : Service[] =[];
  userRole:string = "";
  token = localStorage.getItem('token');
  t : {unique_name :string , role : string ,Id :number} =jwtDecode(this.token!);
  
  ngOnInit(): void {
    this.userRole = this.t.role;
    this.getAllServices();
  } 
  getAllServices(){
    this.services.allServices(this.currentPage,this.itemsPerPage,this.searchQuery).subscribe({
      next : data=>{
          this.allService = data.services;
          this.filterServices()
          this.allService.forEach((item)=>{
            
            //get service contract data
            //get service user data
            this.userServices.getById(item.userId).subscribe({
              next : data =>{
                item.user =data
              },error : err =>{
                return err;
              }
            })
          })
      },error : e=>{        
        return e
      }
    })
  }
  serviceDetails(id? : number){
    this.router.navigateByUrl("home/service/details/"+id)
  }
  openProfile(id : number){
    this.router.navigateByUrl("/home/profile/"+id)
  }
  clacDate(date : Date){
    let currentDate : Date = new Date();
    let differance = differenceInDays(currentDate,date);
    if(differance >= 1){
      return differance
    }else{
      return differenceInHours(currentDate,date);
    }
  }
  filterServices() {
    if (this.searchQuery.trim() === '') {
      this.filteredServices = [...this.allService];
    } else {
      this.filteredServices = this.allService.filter(service => 
        service.title.toLowerCase().includes(this.searchQuery.toLowerCase())
      );
    }
    console.log('Filtered Services:', this.filteredServices);
    this.paginateServices();
  }

  paginateServices() {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    this.paginatedServices = this.allService.slice(startIndex, endIndex);
    console.log('Paginated Services:', this.paginatedServices);
  }

  changePage(page: number) {
    this.currentPage = page;
    this.paginateServices();
  }
  nextPage() {
    if (this.currentPage * this.itemsPerPage < this.allService.length) {
      this.changePage(this.currentPage + 1);
    }
  }

  previousPage() {
    if (this.currentPage > 1) {
      this.changePage(this.currentPage - 1);
    }
  }
  onSearch(query: string) {
    this.searchQuery = query;
    this.currentPage = 1;
    this.filterServices();
  }
}
