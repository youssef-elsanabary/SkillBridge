import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../_services/account.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../../_modules/user';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  constructor(public accountService : AccountService,public router : Router ,public activatRoute : ActivatedRoute){}
  userRole :string = "";
  ngOnInit(): void {
    this.userRole=this.activatRoute.snapshot.params['role']
  }
  
  newuser : User = new User("youssef","youssef@gmail.com","123456",this.userRole);
  register(){
    this.accountService.register(this.newuser)
  }

}
