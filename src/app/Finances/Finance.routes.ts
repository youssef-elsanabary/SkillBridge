import { Router, Routes } from "@angular/router";
import { FinancesOverviewComponent } from "./finances-overview/finances-overview.component";

export const financeRoutes : Routes = [
    {path:"",component:FinancesOverviewComponent},
    {path:"overview",component:FinancesOverviewComponent}
]