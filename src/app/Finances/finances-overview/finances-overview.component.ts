import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-finances-overview',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './finances-overview.component.html',
  styleUrl: './finances-overview.component.css'
})
export class FinancesOverviewComponent {
  currentContent :string = "";
  showContent(content : string){
    this.currentContent = content
  }
}
