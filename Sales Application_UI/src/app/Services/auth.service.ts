import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { EmployeeRegisterRequest } from '../Models/employee-register-request';
import { LoginRequest } from '../Models/login-request';
import { LoginResponse } from '../Models/login-response';
import { ShipperRegisterRequest } from '../Models/shipper-register-request';
import { RegisterResponse } from '../Models/register-response';
import { JwtHelperService } from '@auth0/angular-jwt';
import { JwtService } from './jwt.service';
import { ToastrService } from 'ngx-toastr';
import { NgToastService } from 'ng-angular-popup';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  // private baseUrl:string = "https://localhost:7127/api/auth";
  baseUrl:string = "https://salseappapi116.azurewebsites.net/api/auth";
  private userPayload:any;

  constructor(private http:HttpClient,private router:Router,private jwtSrvice:JwtService,private toast:NgToastService) { 
    this.userPayload = this.decodedToken();
  }

  login(request : LoginRequest) : Observable<LoginResponse>{
    console.log(request);
    return this.http.post<LoginResponse>(`${this.baseUrl}/login`,request);
  }

  signupShipper(request : ShipperRegisterRequest){
    console.log(request);
    return this.http.post<RegisterResponse>(`${this.baseUrl}/shipper-register`,request)
  }

  signupEmployee(request: FormData){
    console.log(request);
    return this.http.post<RegisterResponse>(`${this.baseUrl}/employee-register`,request);
  }

  signupAdmin(request: any){
    console.log(request);
    return this.http.post<RegisterResponse>(`${this.baseUrl}/admin-register`,request);
  }

  storeToken(token:string)
  {
    localStorage.setItem("token",token);
  }

  logout(){
    localStorage.removeItem("token");
    this.jwtSrvice.removeEmail();
    this.jwtSrvice.removeRole();
    this.jwtSrvice.removeUser();
    this.jwtSrvice.removeUserId();
    this.toast.success({detail:"Success",summary:"Log out successfully!",duration:5000});
    this.router.navigate(["login"]);
  }

  getToken()
  {
    return localStorage.getItem("token");
  }

  isUserLoggedIn():boolean{
    return !!localStorage.getItem("token");
  }

  decodedToken(){
    const jwtHelper = new JwtHelperService();
    const token = this.getToken()!;
    return jwtHelper.decodeToken(token);
  }

  getRoleFromToken(){
    if(this.userPayload)
      return this.userPayload.role;
  }

  getEmailFromToken(){
    if(this.userPayload)
      return this.userPayload.email;
  }

  getUserFromToken(){
    if(this.userPayload){
      console.log(this.userPayload)
      return this.userPayload.JSON
    }
  }

  getUserIdFromToken(){
    this.userPayload = this.decodedToken();
      console.log(JSON.parse(this.userPayload.JSON));
      let user = JSON.parse(this.userPayload.JSON);
      if(this.userPayload.role="admin")
      {
        console.log(user);
        return user.AdminId;
      }
      else if(this.userPayload.role="shipper"){
        console.log(user);
        console.log("shippperr")
        return user.ShipperId;
      }
      else if(this.userPayload.role = "employee"){
        console.log(user);
        return user.EmployeeId;
      }
    
  }
}

