import { formatDate } from '@angular/common';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-employee-register',
  templateUrl: './employee-register.component.html',
  styleUrls: ['./employee-register.component.css']
})
export class EmployeeRegisterComponent implements OnInit{

  registerForm!: FormGroup;
  // selectedFile: any;


  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router, private cd: ChangeDetectorRef,private toast:NgToastService) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      titleofcourtesy: ['', Validators.required],
      title:['',Validators.required],
      firstName:['',Validators.required],
      role: ['', Validators.required],
      password: ['', Validators.required],
      lastName: ['', Validators.required],
      address: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
      email: ['', Validators.required],
      postalCode: ['', Validators.required],
      homePhone: ['', Validators.required],
      birthDate: ['', Validators.required],
      hireDate: ['', Validators.required],
      photoPath:['',Validators.required],
      reportsTo: ['', Validators.required],
      extension: ['',Validators.required],
      region:['',Validators.required],
      photo:[null,Validators.required]
    });
  }

  onSubmit() {
    alert("hello");
    if (this.registerForm.valid) {
      var obj = this.registerForm.value;
      console.log(this.registerForm.value);
      var formData = new FormData();
      formData.append('titleofcourtesy', this.registerForm.value.titleofcourtesy);
      formData.append('title', this.registerForm.value.title);
      formData.append('firstName', this.registerForm.value.firstName);
      formData.append('lastName', this.registerForm.value.lastName);
      formData.append('role', this.registerForm.value.role);
      formData.append('photoPath',this.registerForm.value.photo.path);
      formData.append('photo', obj.photo,obj.photo.name);
      formData.append('region', this.registerForm.value.region);
      formData.append('city',this.registerForm.value.city);
      formData.append('country', this.registerForm.value.country);
      formData.append('address', this.registerForm.value.address);
      formData.append('password',this.registerForm.value.password);
      formData.append('email', this.registerForm.value.email);
      formData.append('birthDate', this.registerForm.value.birthDate);
      formData.append('hireDate', this.registerForm.value.hireDate);
      formData.append('reportsTo', this.registerForm.value.reportsTo);
      formData.append('postalCode',this.registerForm.value.postalCode);
      formData.append('homePhone',this.registerForm.value.homePhone);
      formData.append('notes',this.registerForm.value.notes);
      formData.append('extension',this.registerForm.value.extension);


      this.authService.signupEmployee(formData).subscribe({
        next: (res) => {
          this.toast.success({detail:'Success',summary:res.message, duration:5000});
          this.registerForm.reset();
          this.router.navigate(["login"])
        },
        error: (err) => {
          this.toast.error({detail:'Error',summary:err.error, duration:5000});
        }
      });
    }
    else {
      this.validateFormField(this.registerForm);
    }
  }

  onFileChange(event: any) {

    var reader = new FileReader();
   
    var file = event.target.files[0];

    this.registerForm.patchValue({
      photo: file
    });

    console.log(this.registerForm);

    this.cd.markForCheck();
  };

  private validateFormField(loginForm: FormGroup) {
    Object.keys(loginForm.controls).forEach(field => {
      const control = loginForm.get(field);
      if (control instanceof FormControl) {
        control.markAsDirty({ onlySelf: true })
      }
      else if (control instanceof FormGroup) {
        this.validateFormField(control);
      }
    })
  }

}
