import { Component } from '@angular/core';
import { AccountService } from '../../_services/account.service';
import { Router } from '@angular/router';
import { User } from '../../_modules/user';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  constructor(public accountService : AccountService,public router : Router){}
  user : User = new User("","","","");
  register(){
    this.accountService.register(this.user)
  }

}
