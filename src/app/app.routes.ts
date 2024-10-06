import { Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';

export const routes: Routes = [
    {path:"",component:LoginComponent},
    {path:"account",loadChildren:()=>import ("./account/accoun.routes").then(a=>a.accountRoutes) }
];
