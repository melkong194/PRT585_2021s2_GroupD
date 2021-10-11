import { Component, OnInit } from '@angular/core';
import { MapsService } from '../../maps.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    lat: number = 0;
    lng: number = 0;
    location: Object = {};

    constructor(private map: MapsService) { }

    ngOnInit(): void {
        this.map.getLocation().subscribe(data => {
            console.log(data);
            this.lat = Number(data.latitude);
            this.lng = Number(data.longitude);
        })
    }

}
