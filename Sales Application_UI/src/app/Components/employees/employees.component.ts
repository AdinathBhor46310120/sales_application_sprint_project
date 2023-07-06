import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employee } from 'src/app/Models/employee';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {

  searchForm!:FormGroup;
  employees:Employee[] = [];
  isThereDate!:boolean;

  constructor(private adminService:AdminService,private fb:FormBuilder){
    this.searchForm = this.fb.group({
      option:['',Validators.required],
      search:['',Validators.required],
      date:['',Validators.required]
    });
  }


  OnSelectChange(event:any){
    if(this.searchForm.value.option == "hireDate")
    {
      this.isThereDate = true;
    }
    else{
      this.isThereDate = false;
    }
  }
  
  ngOnInit(): void {
    this.adminService.getAllEmployees().subscribe({next:(res)=> {
      this.employees = res;
      console.log(this.employees);
    },error:(err)=>{
      console.log(err);
    }});
  }

  Search(){
    alert("clicked");
    console.log(this.searchForm.value);
      var opt = this.searchForm.value.option;
      var val = this.searchForm.value.search;
      var date = this.searchForm.value.date;
      if(opt == "title")
      {
        this.getAllEmployeesByTitle(val);
      }
      else if(opt == "city")
      {
        this.getAllEmployeesByCity(val);
      }
      else if(opt == "region")
      {
        this.getAllEmployeesByRegion(val);
      }
      else if(opt == "hireDate")
      {
        this.getAllEmployeesByHireDate(date);
      }
      else if(opt == 'highestSale')
      {
        // this.get
      }
      else if(opt == 'lowestSale')
      {

      }
    
   
  }

  getAllEmployeesByTitle(title:string)
  {
    console.log("In title");
    this.adminService.getAllEmployeesByTitle(title).subscribe({next:(res)=> {
      this.employees = res;
      console.log(this.employees);
    },error:(err)=>{
      console.log(err);
    }});
  }

  getAllEmployeesByCity(city:string)
  {
    console.log("In title");
    this.adminService.getAllEmployeesByCity(city).subscribe({next:(res)=> {
      this.employees = res;
      console.log(this.employees);
    },error:(err)=>{
      console.log(err);
    }});
  }

  getAllEmployeesByRegion(region:string)
  {
    console.log("In title");
    this.adminService.getAllEmployeesByRegion(region).subscribe({next:(res)=> {
      this.employees = res;
      console.log(this.employees);
    },error:(err)=>{
      console.log(err);
    }});
  }

  getAllEmployeesByHireDate(date:string)
  {
    console.log("In title");
    this.adminService.getAllEmployeesByHireDate(date).subscribe({next:(res)=> {
      this.employees = res;
      console.log(this.employees);
    },error:(err)=>{
      console.log(err);
    }});
  }
}
