import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';

interface Location {
    latitude: string;
    longitude: string;
}

@Injectable({
    providedIn: 'root'
})

export class MapsService {

    constructor(private http: HttpClient) { }

    getLocation() {
        return this.http.get<Location>('http://api.ipapi.com/138.80.112.206?access_key=8449ed9fd31fdce74a30d776f10c73cc');
    }
}