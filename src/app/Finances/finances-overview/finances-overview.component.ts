import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HeaderComponent } from "../../core/header/header.component";
import { FooterComponent } from '../../core/footer/footer.component';

@Component({
  selector: 'app-finances-overview',
  standalone: true,
  imports: [CommonModule, HeaderComponent,FooterComponent],
  templateUrl: './finances-overview.component.html',
  styleUrl: './finances-overview.component.css'
})
export class FinancesOverviewComponent {
  currentContent :string = "";
  showContent(content : string){
    this.currentContent = content
  }
}
