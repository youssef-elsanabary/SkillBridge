import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  encapsulation: ViewEncapsulation.None

})
export class HeaderComponent implements OnInit {
  constructor(private router :Router){}
  url : string = "";
  ngOnInit(): void {
    this.url = this.router.url
    console.log(this.url);
    
  }
  
}
