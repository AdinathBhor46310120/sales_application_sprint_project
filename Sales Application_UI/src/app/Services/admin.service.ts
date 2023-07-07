import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../Models/employee';
import { ShipDetails } from '../Models/shipDetails';
import { Shippers } from '../Models/shipper';
import { Territorie } from '../Models/territorie';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  

  baseUrl:string = "https://localhost:7127/api";

  constructor(private http:HttpClient) { }


  getAllEmployees(){
    return this.http.get<Employee[]>(`${this.baseUrl}/employees`);
  }

  getAllEmployeesByTitle(title:string){
    console.log(title);
    return this.http.get<Employee[]>(`${this.baseUrl}/employees/title/${title}`);
  }
  getAllEmployeesByCity(city:string){
    console.log(city);
    return this.http.get<Employee[]>(`${this.baseUrl}/employees/City/${city}`);
  }
  getAllEmployeesByRegion(region:string){
    console.log(region);
    return this.http.get<Employee[]>(`${this.baseUrl}/employees/Region/${region}`);
  }
  getAllEmployeesByHireDate(date:string){
    console.log(date);
    return this.http.get<Employee[]>(`${this.baseUrl}/employees/HireDate/${date}`);
  }

  getAllTerritories(){
    return this.http.get<Territorie[]>(`${this.baseUrl}/Territories`);
  }

  getAllTerriteroriesByRegion(region:string){
    console.log(region);
    return this.http.get<Territorie[]>(`${this.baseUrl}/Territories/region/${region}`);
  }

  getAllShippers(){
    return this.http.get<Shippers[]>(`${this.baseUrl}/shippers`);

  }

  getAllShipDetails(){
    return this.http.get<ShipDetails[]>(`${this.baseUrl}/orders`);

  }
}



