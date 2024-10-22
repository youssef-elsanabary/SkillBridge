import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from '../../core/header/header.component';
import { FooterComponent } from '../../core/footer/footer.component';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../_services/user.service';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { User } from '../../_modules/user';

@Component({
  selector: 'app-edit-profile',
  standalone: true,
  imports: [HeaderComponent,FooterComponent,FormsModule],
  templateUrl: './edit-profile.component.html',
  styleUrl: './edit-profile.component.css'
})
export class EditProfileComponent implements OnInit {
  constructor(public userService :UserService , public router : Router){}
  ngOnInit(): void {
    this.userId = this.t.Id
    this.getUserById();
  }
  userId : number = 0;
  token = localStorage.getItem('token');
  t : {unique_name :string , role : string ,Id :number} =jwtDecode(this.token!);
  profile : User = new User("","","","","","","","","",new Date());
done(){
  this.userService.editById(this.userId,this.profile).subscribe({
    next : success =>{
      console.log("edit bio Done");
      
      this.router.navigateByUrl("/home/profile/"+this.userId)
      console.log(this.profile);
      
    },error :err=>{
      console.log(err);
      
      return err;
    }
  })
}
getUserById(){
  this.userService.getById(this.userId).subscribe({
    next:data =>{
      this.profile = data;
    },error:err=>{
      return err;
    }
  })
}
}
