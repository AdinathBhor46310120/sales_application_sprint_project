import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-employee-updates',
  templateUrl: './employee-updates.component.html',
  styleUrls: ['./employee-updates.component.css']
})
export class EmployeeUpdatesComponent implements OnInit{
  ngOnInit(): void {
  //   registerForm!: FormGroup;
  // // selectedFile: any;


  // constructor(private fb: FormBuilder, private authService: AuthService, private router: Router, private cd: ChangeDetectorRef,private toast:NgToastService) { }
  }

}
