import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { HomeHeaderComponent } from './home-header/home-header.component';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [HomeHeaderComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  encapsulation: ViewEncapsulation.None

})
export class HeaderComponent implements OnInit {
  constructor(private router :Router){}
  url : string = "";
  ngOnInit(): void {
    this.url = this.router.url
  }
  
}
