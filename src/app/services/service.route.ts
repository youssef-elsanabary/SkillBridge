import { Routes } from "@angular/router";
import { AllServicesComponent } from "./all-services/all-services.component";
import { AddServiceComponent } from "./add-service/add-service.component";
import { DeleteServicesComponent } from "./delete-services/delete-services.component";
import { EditServicesComponent } from "./edit-services/edit-services.component";
import { ServiceDetailsComponent } from "./service-details/service-details.component";
import { AddPrposalComponent } from "../Prposal/add-prposal/add-prposal.component";

export const ServiceRoutes : Routes = [
    {path:"",component:AllServicesComponent},
    {path:"all",component:AllServicesComponent},
    {path:"add",component:AddServiceComponent},
    {path:"delete/:id",component:DeleteServicesComponent},
    {path:"edit/:id",component:EditServicesComponent},
    {path:"details/:id",component:ServiceDetailsComponent},
    {path:"prposal",component:AddPrposalComponent}
]