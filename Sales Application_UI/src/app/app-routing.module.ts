import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShipperRegisterComponent } from './Auth/shipper-register/shipper-register.component';
import { LoginComponent } from './Auth/login/login.component';
import { EmployeeRegisterComponent } from './Auth/employee-register/employee-register.component';
import { HomeComponent } from './Layout/home/home.component';
import { AdminRegisterComponent } from './Auth/admin-register/admin-register.component';
import { AuthGuard } from './Services/auth.guard';
import { LogGuard } from './Services/log.guard';
import { EmployeesComponent } from './Components/employees/employees.component';
import { TerritoriesComponent } from './Components/territories/territories.component';
import { ShippersComponent } from './Components/shippers/shippers.component';

const routes: Routes = [
  {path:"",component:LoginComponent,canActivate:[LogGuard]},
  {path:"login",component:LoginComponent,canActivate:[LogGuard]},
  {path:"admin-register",component:AdminRegisterComponent,canActivate:[LogGuard]},
  {path:"shipper-register",component:ShipperRegisterComponent,canActivate:[LogGuard]},
  {path:"employee-register",component:EmployeeRegisterComponent},
  {path:"home",component:HomeComponent,children: 
  [
    {path:"employees",component:EmployeesComponent},
    {path:"territories",component:TerritoriesComponent},
    {path:"shippers",component:ShippersComponent}
  ],canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
