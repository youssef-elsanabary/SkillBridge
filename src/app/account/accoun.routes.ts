import { Routes } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { LogoutComponent } from "./logout/logout.component";
import { RegisterComponent } from "./register/register.component";
import { ForgetPasswordComponent } from "./forget-password/forget-password.component";
import { RoleComponent } from "./register/role/role.component";

export const accountRoutes : Routes=[
    {path:"login", component:LoginComponent},
    {path:"logout",component:LogoutComponent},
    {path:"role",component:RoleComponent},
    {path:"register/:role",component:RegisterComponent},
    {path:"forgetpassword",component:ForgetPasswordComponent}
]