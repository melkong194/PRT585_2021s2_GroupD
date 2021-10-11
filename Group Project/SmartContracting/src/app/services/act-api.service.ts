import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ActAPIService {

  getUrlAPI = "https://localhost:5001/api/Act/GetAllActs";
  createUrlAPI = "https://localhost:5001/api/Act/AddAct";

  constructor(private http:HttpClient) { }

  GetAllAct() {
    return this.http.get(this.getUrlAPI);
  }

  CreateAct(data: any) {
    return this.http.post(this.createUrlAPI + data, "");
  }

}
