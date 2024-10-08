import { Component, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { AccountService } from '../../_services/account.service';
import { Login } from '../../_modules/login';
import { Router } from '@angular/router';
import { FooterComponent } from "../../core/footer/footer.component";
import { HeaderComponent } from "../../core/header/header.component";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, FooterComponent, HeaderComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  encapsulation : ViewEncapsulation.None
})
export class LoginComponent {
  constructor(public accountService : AccountService ,public router :Router){}
  user : Login = new Login("","")
  
  login(){
     this.accountService.login(this.user)
     //console.log("success");
  }
  navigateRegister(){
    this.router.navigateByUrl("account/role")
  }
}
