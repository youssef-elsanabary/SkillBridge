import { Component, OnDestroy, OnInit } from '@angular/core';
import { AccountService } from '../../_services/account.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../../_modules/user';
import { Subscription } from 'rxjs';
import { HeaderComponent } from "../../core/header/header.component";
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [HeaderComponent,FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit,OnDestroy {
  constructor(public accountService : AccountService,public router : Router ,public activatRoute : ActivatedRoute){}
  ngOnDestroy(): void {
    this.sub?.unsubscribe
  }
  userRole :string = "";
  sub : Subscription|null = null;
  fName : string = "";
  LName : string = "";
  usrName : string = this.fName + this.LName
  
  ngOnInit(): void {
    this.userRole=this.activatRoute.snapshot.params['role']
   
  }

  newuser : User = new User(this.usrName,"","",this.userRole);
  register(){
    this.sub = this.accountService.register(this.newuser).subscribe(
      //ok 
      {
        next : (t) => {
          
          this.router.navigateByUrl("home");
          alert("registration done")
          console.log("registration done");
        },//error
        error : r =>{
          r
          alert("registration failed")
          console.log("registration failed")
        }
      }
    )
  }

}
