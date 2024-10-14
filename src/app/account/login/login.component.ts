import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, Validators } from '@angular/forms';
import { AccountService } from '../../_services/account.service';
import { Login } from '../../_modules/login';
import { Router } from '@angular/router';
import { FooterComponent } from "../../core/footer/footer.component";
import { HeaderComponent } from "../../core/header/header.component";
import { Subscription } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule,CommonModule,FooterComponent, HeaderComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  encapsulation : ViewEncapsulation.None
})
export class LoginComponent implements OnInit,OnDestroy {
  constructor(public accountService : AccountService ,public router :Router){}
  sub : Subscription |null = null;
  isAuth : boolean = false;
  status : number|null = null
  ngOnInit(): void {
    
  }
  ngOnDestroy(): void {
    this.sub?.unsubscribe
  }
  user : Login = new Login("","")
  login(){
    this.sub = this.accountService.login(this.user).subscribe(
      //ok
      {next : response=>{
        console.log(response);
        console.log("1"+""+this.isAuth);
        this.isAuth = true;
        console.log("2"+""+this.isAuth);

        this.status = response.status;
        this.router.navigateByUrl("/home");
        localStorage.setItem("token", response.body.token);
      },
      //error
      error : e=>{
      }
  });
  }
  navigateRegister(){
    this.router.navigateByUrl("account/role")
  }
}