import { Component } from '@angular/core';
import { HeaderComponent } from "../../../core/header/header.component";
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-role',
  standalone: true,
  imports: [HeaderComponent,FormsModule,RouterLink],
  templateUrl: './role.component.html',
  styleUrl: './role.component.css'
})
export class RoleComponent {

  selectedUserType :  'freelancer' |'client' |null = null
}
