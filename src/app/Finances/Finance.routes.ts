import { Router, Routes } from "@angular/router";
import { FinancesOverviewComponent } from "./finances-overview/finances-overview.component";
import { ReportsComponent } from "./reports/reports.component";

export const financeRoutes : Routes = [
    {path:"",component:FinancesOverviewComponent},
    {path:"overview",component:FinancesOverviewComponent},
    {path:"reports",component:ReportsComponent}
]