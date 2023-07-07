import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { Shippers } from 'src/app/Models/shipper';
import { AdminService } from 'src/app/Services/admin.service';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.css']
})
export class ShippersComponent implements OnInit{
  shippers:Shippers[] = [];
  registerForm!: FormGroup;
  constructor(private adminService:AdminService,private fb:FormBuilder) { 

  }
  ngOnInit(): void {
    this.adminService.getAllShippers().subscribe({next:(res)=> {
      this.shippers = res;
      console.log(this.shippers);
    },error:(err)=>{
      console.log(err);
    }});
    
  }
  
  // ngOnInit(): void {
  //   this.registerForm = this.fb.group({
  //     titleofcourtesy: ['', Validators.required],
  //     companyName: ['', Validators.required],
  //     phone: ['', Validators.required],
  //     email: ['', Validators.required],
  //     password: ['', Validators.required],
  //     role: ['', Validators.required],
  //     orders: ['', Validators.required],
  //   });
    
  }

  //https://localhost:7127/api/shippers



