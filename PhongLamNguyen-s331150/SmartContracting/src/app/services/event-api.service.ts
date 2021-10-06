import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EventAPIService {

  createUrlAPI = "https://localhost:5001/api/Event/AddEvent";
  getAllUrlAPI = "https://localhost:5001/api/Event/GetAllEvents"

  constructor(private http:HttpClient) { }


  CreateEvent(data: string) {
    return this.http.post(this.createUrlAPI + data, "");
  }

  GetAllEvents() {
    return this.http.get(this.getAllUrlAPI);
  }

}
