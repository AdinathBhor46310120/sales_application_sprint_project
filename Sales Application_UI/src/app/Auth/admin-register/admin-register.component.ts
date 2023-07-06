import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-admin-register',
  templateUrl: './admin-register.component.html',
  styleUrls: ['./admin-register.component.css']
})
export class AdminRegisterComponent implements OnInit{

  registerForm!:FormGroup;

  constructor(private fb:FormBuilder, private authService:AuthService,private router:Router,private toast:NgToastService) {}

  // "shipperId": 1,
  //   "companyName": "Cognizant",
  //   "phone": "(503) 555-9831",
  //   "email": "SpeedyRecovery@gmail.com",
  //   "password": "GW3CvrxahOVCPNQMGCQ7ESbDff9y/Bfm4UMJ4PyvSATivsj6",
  //   "role": "shipper",
  //   "orders": []

  ngOnInit(): void {
    this.registerForm = this.fb.group({
    
      role:['',Validators.required],
      password:['',Validators.required],
      email:['',Validators.required],
     
    });
  }

  onSubmit(){
    if(this.registerForm.valid){
      var obj = this.registerForm.value;
      let request:any= {
        email:obj.email,
        password:obj.password,
        role:obj.role
      }

      this.authService.signupAdmin(request).subscribe({
        next:(res)=> {
          this.toast.success({detail:'Success',summary:res.message, duration:5000});
          this.registerForm.reset();
          this.router.navigate(["login"])
        },
        error:(err) => {
          this.toast.error({detail:'Error',summary:err.error.message, duration:5000});
        }
      });
    }
    else{
      this.validateFormField(this.registerForm);
    }
  }

  private validateFormField(loginForm:FormGroup){
    Object.keys(loginForm.controls).forEach(field => {
      const control = loginForm.get(field);
      if(control instanceof FormControl){
        control.markAsDirty({onlySelf:true})
      }
      else if(control instanceof FormGroup){
        this.validateFormField(control);
      }
    })
  }
}
