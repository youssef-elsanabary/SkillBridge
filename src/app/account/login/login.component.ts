import { Component, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { AccountService } from '../../_services/account.service';
import { Login } from '../../_modules/login';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  encapsulation : ViewEncapsulation.None
})
export class LoginComponent {
  constructor(public accountService : AccountService ,public router :Router){}
  user : Login = new Login("","")
  
  login(){
     this.accountService.login(this.user.Email,this.user.Password)
     this.router.navigateByUrl("")
     console.log("success");
     
  }
}
