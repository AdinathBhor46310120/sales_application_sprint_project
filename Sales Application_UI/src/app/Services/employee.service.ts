import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Order } from '../Models/order';
import { Sale } from '../Models/sale';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  // baseUrl:string = "https://localhost:7127/api";
  // baseUrl:string = "https://saleswebapiapplication.azurewebsites.net/api";
  baseUrl:string = "https://salesbackendapi.azurewebsites.net/api";
  constructor(private http:HttpClient) { }

  getAllOrdersHandledByEmployee(employeeID:string){
    return this.http.get<Order[]>(`${this.baseUrl}/employees/orders/${employeeID}`);
  }

  getAllHighestByEmployee(employeeID:string){
    return this.http.get<Sale[]>(`${this.baseUrl}/employees/highestsalebyemployee/${employeeID}`);
  }

  getSalesOnDate(employeeID:string,date:string){
    return this.http.get<Sale[]>(`${this.baseUrl}/employees/salebyemploye/date/${employeeID}/${date}`);
  }
  getSalesOnMonth(employeeID:string,month:string){
    return this.http.get<Sale[]>(`${this.baseUrl}/employees/salebyemploye/month/${employeeID}/${month}`);
  }
  getSalesInYear(employeeID:string,year:string){
    return this.http.get<Sale[]>(`${this.baseUrl}/employees/salebyemploye/year/${employeeID}/${year}`);
  }

  getSalesBetweenDate(employeeID:string,date:string,toDate:string){
    return this.http.get<Sale[]>(`${this.baseUrl}/employees/salebyemploye/betweendate/${employeeID}/${date}/${toDate}`);
  }
}
