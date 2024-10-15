import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../../_services/service.service';

@Component({
  selector: 'app-all-services',
  standalone: true,
  imports: [],
  templateUrl: './all-services.component.html',
  styleUrl: './all-services.component.css'
})
export class AllServicesComponent implements OnInit {
  constructor(public services : ServiceService){}
  allService : string[] =[]
  ngOnInit(): void {
    this.services.allServices().subscribe({
      next : data=>{
          this.allService = data;
      },error : e=>{
        return e
      }
    })
  }
   
}
