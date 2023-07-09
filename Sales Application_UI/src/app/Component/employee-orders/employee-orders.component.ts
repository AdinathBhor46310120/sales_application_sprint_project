import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employee } from 'src/app/Models/employee';
import { Order } from 'src/app/Models/order';
import { AuthService } from 'src/app/Services/auth.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { JwtService } from 'src/app/Services/jwt.service';

@Component({
  selector: 'app-employee-orders',
  templateUrl: './employee-orders.component.html',
  styleUrls: ['./employee-orders.component.css']
})
export class EmployeeOrdersComponent implements OnInit{
   
  orders:Order[] = [];
  employeeId = "4";
  user!:any;

  constructor(private employeeService:EmployeeService,private fb:FormBuilder,private jwtService:JwtService,private authService:AuthService){}
  

  ngOnInit(): void {

    this.employeeService.getAllOrdersHandledByEmployee(this.employeeId).subscribe({next:(res)=>{
      console.log(res);
      this.orders = res;

    },error:(err)=>{
      console.log(err);
    }})
  }

}
