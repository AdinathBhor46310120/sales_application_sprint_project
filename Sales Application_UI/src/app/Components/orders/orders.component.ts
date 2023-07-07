import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Orders } from 'src/app/Models/orders';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  orders:Orders[] = [];
  registerForm!: FormGroup;
  constructor(private adminService:AdminService,private fb:FormBuilder) { 

  }
  ngOnInit(): void {
    this.adminService.getAllOrders().subscribe({next:(res)=> {
      this.orders = res;
      console.log(this.orders);
    },error:(err)=>{
      console.log(err);
    }});

  }
}
