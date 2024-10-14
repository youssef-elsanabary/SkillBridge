import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-header',
  standalone: true,
  imports: [],
  templateUrl: './home-header.component.html',
  styleUrl: './home-header.component.css'
})
export class HomeHeaderComponent {
  constructor(public router : Router){}
  massege(){
    this.router.navigateByUrl("/home/Massege")
  }
}
