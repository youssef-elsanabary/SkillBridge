import { Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { AddComponent } from './services/add/add.component';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
    {path:"",component:LoginComponent},
    {path:"account",loadChildren:()=>import ("./account/accoun.routes").then(a=>a.accountRoutes) },
    {path:"service",component:AddComponent},
    {path:"home",component:HomeComponent}

];
