import { Injectable } from '@angular/core';
import {BehaviorSubject} from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class JwtService {
  private role$ = new BehaviorSubject<string>("");
  private email$ = new BehaviorSubject<string>("");
  private user$ = new BehaviorSubject<any>({});
  private userId$ = new BehaviorSubject<string>("");

  constructor() { }

  public getRole(){
    return this.role$.asObservable();
  }

  public setRole(role:string){
    this.role$.next(role);
  }

  public getEmail(){
    return this.email$.asObservable();
  }

  public setEmail(email:string){
    this.email$.next(email);
  }

  public getUser(){
    return this.user$.asObservable();
  }

  public removeRole(){
    this.role$ = new BehaviorSubject<string>("");
  }

  public setUserId(user:string)
  {
    let u= JSON.parse(user);
    console.log(user);
    console.log(u);
    if(u.Role="admin")
    {
      this.userId$ = u.AdminId;
    }
    else if(u.Role="shipper"){
      this.userId$ = u.ShipperId;
    }
    else if(u.Role = "employee"){
      this.userId$ = u.EmployeeId;
    }
    console.log(u);
    // this.userId$.next(u);
  }

  public getUserId()
  {
    console.log(this.userId$.value)
    return this.userId$.asObservable();
  }

  public removeUserId(){
    this.userId$ = new BehaviorSubject<string>("");
  }

  public removeEmail(){
    this.email$ = new BehaviorSubject<string>("");
  }

  public setUser(user:string){
    this.user$.next(JSON.parse(user));
  }

  public removeUser(){
    this.user$ = new BehaviorSubject<any>({});
  }
}
