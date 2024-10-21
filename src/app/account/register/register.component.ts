import { Component, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { AccountService } from '../../_services/account.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../../_modules/user';
import { Subscription } from 'rxjs';
import { HeaderComponent } from "../../core/header/header.component";
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Profile } from '../../_modules/profile';
import { ProfileService } from '../../_services/profile.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [HeaderComponent,FormsModule,CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit,OnDestroy {
  constructor(public accountService : AccountService,public router : Router ,public activatRoute : ActivatedRoute){}
  
  newuser : User = new User("","","","");
  userRole :string = "";
  sub : Subscription|null = null;
  fName : string = "";
  LName : string = "";
 
  ngOnDestroy(): void {
    this.sub?.unsubscribe
  }  
  ngOnInit(): void {
    this.userRole=this.activatRoute.snapshot.params['role']
    this.newuser.role = this.userRole
    }

  register(){
    this.sub = this.accountService.register(this.newuser).subscribe(
      //ok 
      {
        next : (t) => {
          this.accountService.isAuth = true;
          alert("Registration Done")
          this.router.navigateByUrl("account/login")
          // if(this.newuser.role=="Client"){
          //   this.router.navigateByUrl("HomeClient")
          // }else{
          // this.router.navigateByUrl("home");
          // }
        },//error
        error : r =>{
          alert("Registration Failed")
        }
      }
    )
  }

}
