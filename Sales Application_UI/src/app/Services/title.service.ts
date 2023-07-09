import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TitleService {

  // baseUrl:string = "https://localhost:7022/api/titles";
  // baseUrl:string = "https://salseappapi116.azurewebsites.net/api";
  baseUrl:string = "https://salesbackendapi.azurewebsites.net/api";
  constructor(private http:HttpClient) { }

  getAllTitles()
  {
    return this.http.get(this.baseUrl);
  }
}
