import { Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { canLoginGuard } from './_guards/can-login.guard';
import { FinancesOverviewComponent } from './Finances/finances-overview/finances-overview.component';
import { ReportsComponent } from './Finances/reports/reports.component';
import { ProfileComponent } from './profile/profile.component';
import { EditProfileComponent } from './profile/edit-profile/edit-profile.component';
import { ClientHomeComponent } from './home/client-home/client-home.component';
import { AllServicesComponent } from './services/all-services/all-services.component';

export const routes: Routes = [
    // {path:"",component:ClientHomeComponent},
    {path:"",component:LoginComponent},
    {path:"account",loadChildren:()=>import ("./account/accoun.routes").then(a=>a.accountRoutes) },
    {path:"service",component:AllServicesComponent,canActivate:[canLoginGuard]},
    {path:"home",loadChildren:()=>import ("./home/home.routes").then(a=>a.homeRoutes),canActivate:[canLoginGuard]}
];
 