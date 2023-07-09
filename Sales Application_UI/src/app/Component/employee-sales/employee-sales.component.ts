import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employee } from 'src/app/Models/employee';
import { Sale } from 'src/app/Models/sale';
import { AuthService } from 'src/app/Services/auth.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { JwtService } from 'src/app/Services/jwt.service';

@Component({
  selector: 'app-employee-sales',
  templateUrl: './employee-sales.component.html',
  styleUrls: ['./employee-sales.component.css']
})
export class EmployeeSalesComponent implements OnInit{
   
  searchForm!:FormGroup;
  sales:Sale[]=[];
  employeeId = "4";
  isThereDate!:boolean;
  isThereToDate!:boolean;
  employees:Employee[] = [];
  user!:any;

  constructor(private employeeService:EmployeeService,private fb:FormBuilder,private jwtService:JwtService,private authService:AuthService){
    this.searchForm = this.fb.group({
      option:['',Validators.required],
      search:['',Validators.required],
      date:['',Validators.required],
      todate:['',Validators.required]
    });
  }
  ngOnInit(): void {

    this.employeeService.getAllHighestByEmployee(this.employeeId).subscribe({next:(res)=>{
      console.log(res);
      this.sales = res;

    },error:(err)=>{
      console.log(err);
    }})

    
  }

  OnSelectChange(event:any){
    console.log("hello");
    if(this.searchForm.value.option == "date")
    {
      this.isThereDate = true;
      this.isThereToDate = false;
    }
    else if(this.searchForm.value.option == "btwDates")
    {
      this.isThereDate = true;
      this.isThereToDate = true;
    }
    else{
      this.isThereDate = false;
      this.isThereToDate = false;
    }
    
  }

  Search(){
    alert("clicked");
    console.log(this.searchForm.value);
      var opt = this.searchForm.value.option;
      var val = this.searchForm.value.search;
      var date = this.searchForm.value.date;
      var toDate = this.searchForm.value.todate;
      if(opt == "date")
      {
        this.getSalesByDate(date);
      }
      else if(opt == "year")
      {
        this.getSalesByYear(val)
      }
      else if(opt == "month")
      {
        this.getSaleByMonth(val);
      }
      else if(opt == "btwDates")
      {
        this.getSaleBetweenDate(date,toDate);
      }
   
  }
  getSaleBetweenDate(date: any, toDate: any) {
    this.employeeService.getSalesBetweenDate(this.employeeId,date,toDate).subscribe({next:(res)=>{
      console.log(res);
      this.sales = res;

    },error:(err)=>{
      console.log(err);
    }})
  }
  getSaleByMonth(val: any) {
    this.employeeService.getSalesOnMonth(this.employeeId,val).subscribe({next:(res)=>{
      console.log(res);
      this.sales = res;

    },error:(err)=>{
      console.log(err);
    }})
  }
  getSalesByYear(val: any) {
    this.employeeService.getSalesInYear(this.employeeId,val).subscribe({next:(res)=>{
      console.log(res);
      this.sales = res;

    },error:(err)=>{
      console.log(err);
    }})
  }
  getSalesByDate(date: any) {
    this.employeeService.getSalesOnDate(this.employeeId,date).subscribe({next:(res)=>{
      console.log(res);
      this.sales = res;

    },error:(err)=>{
      console.log(err);
    }})
  }

}
