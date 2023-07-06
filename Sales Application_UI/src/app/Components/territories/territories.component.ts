import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Territorie } from 'src/app/Models/territorie';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-territories',
  templateUrl: './territories.component.html',
  styleUrls: ['./territories.component.css']
})
export class TerritoriesComponent implements OnInit{
  searchForm!:FormGroup;
  territories:Territorie[] = [];
  isAllSelected!:boolean;

  constructor(private adminService:AdminService,private fb:FormBuilder){
    this.searchForm = this.fb.group({
      option:['',Validators.required],
      search:['',Validators.required]
    });
  }


  OnSelectChange(event:any){
    if(this.searchForm.value.option == "all")
    {
      this.isAllSelected = true;
    }
    else{
      this.isAllSelected= false;
    }
  }
  
  ngOnInit(): void {
    this.adminService.getAllTerritories().subscribe({next:(res)=> {
      this.territories = res;
      console.log(this.territories);
    },error:(err)=>{
      console.log(err);
    }});
  }

  Search(){
    alert("clicked");
    console.log(this.searchForm.value);
      var opt = this.searchForm.value.option;
      var val = this.searchForm.value.search;
      if(opt == "all")
      {
        this.adminService.getAllTerritories().subscribe({next:(res)=> {
          this.territories = res
          console.log(this.territories);
        },error:(err)=>{
          console.log(err);
        }});
      }
      else if(opt == "region")
      {
        this.getAllTerritoriesByRegion(val)
      }
  }
  
  getAllTerritoriesByRegion(region:string)
  {
    console.log("In title");
    this.adminService.getAllTerriteroriesByRegion(region).subscribe({next:(res)=> {
      this.territories = res;
      console.log(this.territories);
      return 
    },error:(err)=>{
      console.log(err);
    }});
  }
}
