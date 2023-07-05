import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/Services/auth.service';
import { Router } from '@angular/router';
import { JwtService } from 'src/app/Services/jwt.service';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  loginForm! : FormGroup;

  constructor(private fb:FormBuilder,private authService:AuthService, private router:Router, private jwtService:JwtService,private toast:NgToastService){}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      role:['',Validators.required],
      email:['',Validators.required],
      password:['',Validators.required]
    })
  }

  onSubmit(){
    if(this.loginForm.valid){
      alert("hello");
      this.authService.login(this.loginForm.value).subscribe({
        next:(res)=> {
          // console.log("hello");
          this.authService.storeToken(res.token);
          this.toast.success({detail:'Success',summary:res.message, duration:5000});
          let payload = this.authService.decodedToken();
          this.jwtService.setEmail(payload.email);
          this.jwtService.setRole(payload.role);
          // console.log(res);
          this.loginForm.reset();
          this.router.navigate(["home"])
        },
        error:(err) => {
          this.toast.error({detail:'Error',summary:"Incorrect Password", duration:5000});
        }
      })
    }
    else{
      this.validateFormField(this.loginForm);
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
