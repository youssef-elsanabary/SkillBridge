import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AllServicesComponent } from "../../services/all-services/all-services.component";
import { HeaderComponent } from "../../core/header/header.component";
import { FooterComponent } from "../../core/footer/footer.component";

@Component({
  selector: 'app-client-home',
  standalone: true,
  imports: [AllServicesComponent, HeaderComponent, FooterComponent],
  templateUrl: './client-home.component.html',
  styleUrl: './client-home.component.css'
})
export class ClientHomeComponent {
constructor(public router : Router , public httpClient : HttpClient){}
addService(){
  this.router.navigateByUrl("")
}
}
