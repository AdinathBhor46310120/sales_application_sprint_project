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
import { ShipdetailsComponent } from './Components/shipdetails/shipdetails.component';
import { OrdersComponent } from './Components/orders/orders.component';
import { EmployeeUpdatesComponent } from './Components/employee-updates/employee-updates.component';
import { ShipperUpdatesComponent } from './Components/shipper-updates/shipper-updates.component';
import { TerritoriesUpdatesComponent } from './Components/territories-updates/territories-updates.component';
import { EmployeeOrdersComponent } from './Component/employee-orders/employee-orders.component';
import { EmployeeSalesComponent } from './Component/employee-sales/employee-sales.component';

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
    {path:"shippers",component:ShippersComponent},
    {path:"shipdetail",component:ShipdetailsComponent},
    {path:"orders",component:OrdersComponent},
    {path:"employee-updates",component:EmployeeUpdatesComponent},
    {path:"shipper-updates",component:ShipperUpdatesComponent},
    {path:"territory-updates",component:TerritoriesUpdatesComponent},
    {path:'employee-orders',component:EmployeeOrdersComponent},
    {path:'employee-sales',component:EmployeeSalesComponent}
  ],canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
