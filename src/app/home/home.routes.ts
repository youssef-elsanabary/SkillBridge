import { Routes } from "@angular/router";
import { HomeComponent } from "./home.component";
import { ProfileComponent } from "../profile/profile.component";
import { MassegeComponent } from "../massege/massege.component";
import { ClientHomeComponent } from "./client-home/client-home.component";

export const homeRoutes : Routes = [
    {path :"",component:HomeComponent},
    {path:"HomeClient",component:ClientHomeComponent},
    {path :"finance",loadChildren:()=>import("../Finances/Finance.routes").then(a=>a.financeRoutes)},
    {path:"Massege",component:MassegeComponent},
    {path:"profile",component:ProfileComponent}
]