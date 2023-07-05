import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShipperRegisterComponent } from './Auth/shipper-register/shipper-register.component';
import { LoginComponent } from './Auth/login/login.component';
import { EmployeeRegisterComponent } from './Auth/employee-register/employee-register.component';
import { TitleComponent } from './Components/title/title.component';
import { HomeComponent } from './Layout/home/home.component';
import { AdminRegisterComponent } from './Auth/admin-register/admin-register.component';
import { AuthGuard } from './Services/auth.guard';
import { LogGuard } from './Services/log.guard';

const routes: Routes = [
  {path:"",component:LoginComponent},
  {path:"login",component:LoginComponent,canActivate:[LogGuard]},
  {path:"admin-register",component:AdminRegisterComponent,canActivate:[LogGuard]},
  {path:"author-register",component:ShipperRegisterComponent,canActivate:[LogGuard]},
  {path:"publisher-register",component:EmployeeRegisterComponent},
  {path:"home",component:HomeComponent,children: 
  [
    {path:"title",component:TitleComponent}
  ],canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
