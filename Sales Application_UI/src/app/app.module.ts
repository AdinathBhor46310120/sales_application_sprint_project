import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Auth/login/login.component';
import { HomeComponent } from './Layout/home/home.component';
import { ShipperRegisterComponent } from './Auth/shipper-register/shipper-register.component';
import { EmployeeRegisterComponent } from './Auth/employee-register/employee-register.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgToastModule } from 'ng-angular-popup';
import { AdminRegisterComponent } from './Auth/admin-register/admin-register.component';
import { TokenInterceptor } from './Services/token.interceptor';
import { EmployeesComponent } from './Components/employees/employees.component';
import { OrdersComponent } from './Components/orders/orders.component';
import { ShippersComponent } from './Components/shippers/shippers.component';
import { TerritoriesComponent } from './Components/territories/territories.component';
import { ShipdetailsComponent } from './Components/shipdetails/shipdetails.component';
import { SalesComponent } from './Components/sales/sales.component';
import { EmployeeUpdatesComponent } from './Components/employee-updates/employee-updates.component';
import { ShipperUpdatesComponent } from './Components/shipper-updates/shipper-updates.component';
import { TerritoriesUpdatesComponent } from './Components/territories-updates/territories-updates.component';
import { EmployeeOrdersComponent } from './Component/employee-orders/employee-orders.component';
import { EmployeeSalesComponent } from './Component/employee-sales/employee-sales.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    ShipperRegisterComponent,
    EmployeeRegisterComponent,
    AdminRegisterComponent,
    EmployeesComponent,
    OrdersComponent,
    ShippersComponent,
    TerritoriesComponent,
    ShipdetailsComponent,
    SalesComponent,
    EmployeeUpdatesComponent,
    ShipperUpdatesComponent,
    TerritoriesUpdatesComponent,
    EmployeeOrdersComponent,
    EmployeeSalesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgToastModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
