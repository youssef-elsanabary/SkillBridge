import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../_services/account.service';

@Component({
  selector: 'app-logout',
  standalone: true,
  imports: [],
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.css'
})
export class LogoutComponent implements OnInit {
  constructor(public accountService : AccountService){}
  ngOnInit(): void {
    this.accountService.logout();
  }
}
