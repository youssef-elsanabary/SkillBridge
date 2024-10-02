import { Routes } from '@angular/router';

export const routes: Routes = [
    {path:"account",loadChildren:()=>import ("./account/accoun.routes").then(a=>a.accountRoutes) }
];
