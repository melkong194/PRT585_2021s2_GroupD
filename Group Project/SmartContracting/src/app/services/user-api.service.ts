import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserAPIService {

  getUrlAPI = "https://localhost:5001/api/User/GetAllUsers";
  createUrlAPI = "https://localhost:5001/api/User/AddUser";
  UpdateUrlAPI = "https://localhost:5001/api/User/UpdateUser";
  DeleteUrlAPI = "https://localhost:5001/api/User/DeleteUser";
  EmailUrl = "https://localhost:5001/api/Email/Send";

  constructor(private http:HttpClient) { }

  GetAllUsers() {
    return this.http.get(this.getUrlAPI);
  }

  AddUser(data: string) {
    return this.http.post(this.createUrlAPI + data, "");
  }

  UpdateUser(data: string) {
    return this.http.post(this.UpdateUrlAPI, data);
  }

  DeleteUser(data: string) {
    return this.http.post(this.DeleteUrlAPI, data);
  }

  SendEmai(data: any) {
    return this.http.post(this.EmailUrl, data);
  }
}
