import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  email: any;
  password: any;
  //role: any;

  constructor( private http: HttpClient){}


  login() {
    const url = 'https://localhost:7127/api/auth/login';
    const payload = {
      email: this.email,
      password: this.password,
      //role: this.role
    };
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    this.http.post(url, payload, { headers }).subscribe(
      (response) => {
        // Handle successful login
        console.log('Login successful!');
      },
      (error) => {
        // Handle login error
        console.error('Login failed:', error);
      }
    );
  }


}
// home