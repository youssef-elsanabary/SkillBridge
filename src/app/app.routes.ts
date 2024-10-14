import { Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { AddComponent } from './services/add/add.component';
import { canLoginGuard } from './_guards/can-login.guard';
import { FinancesOverviewComponent } from './Finances/finances-overview/finances-overview.component';
import { ReportsComponent } from './Finances/reports/reports.component';
import { ProfileComponent } from './profile/profile.component';

export const routes: Routes = [
    {path:"",component:ProfileComponent},
    // {path:"",component:LoginComponent},
    {path:"account",loadChildren:()=>import ("./account/accoun.routes").then(a=>a.accountRoutes) },
    {path:"service",component:AddComponent},
    {path:"home",loadChildren:()=>import ("./home/home.routes").then(a=>a.homeRoutes)}
];
 