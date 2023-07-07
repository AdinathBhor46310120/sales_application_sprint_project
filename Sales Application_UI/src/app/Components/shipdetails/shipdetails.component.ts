import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ShipDetails } from 'src/app/Models/shipDetails';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-shipdetails',
  templateUrl: './shipdetails.component.html',
  styleUrls: ['./shipdetails.component.css']
})
export class ShipdetailsComponent implements OnInit {
  shipdetails:ShipDetails[] = [];
  registerForm!: FormGroup;
  constructor(private adminService:AdminService,private fb:FormBuilder) { 

  }
  ngOnInit(): void {
    this.adminService.getAllShipDetails().subscribe({next:(res)=> {
      this.shipdetails = res;
      console.log(this.shipdetails);
    },error:(err)=>{
      console.log(err);
    }});
    

  }
}
