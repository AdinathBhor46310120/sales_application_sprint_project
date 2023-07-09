import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { JwtService } from 'src/app/Services/jwt.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  role!:string;
  user!:any;
  userId!:string;

  constructor(private authService:AuthService,private jwtService:JwtService){}
  ngOnInit(): void {
    this.jwtService.getRole().subscribe(res => {
      var r = this.authService.getRoleFromToken();
      this.role = res || r;
    })

    this.jwtService.getUser().subscribe(res => {
      console.log(res);
      var user = this.authService.getUserFromToken();
      this.user = res || JSON.parse(user.JSON);
      // this.user = JSON.parse(this.user);
      console.log(this.user);
      if(this.user.Role == "shipper"){
        this.userId = this.user.ShipperId;
      }

      console.log(this.userId);
    })
  }
  
  logout(){
    this.authService.logout();
  }
}
