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
    icon = {
        url: 'https://upload.wikimedia.org/wikipedia/en/b/bd/Doraemon_character.png',
        Size: {height: 10, width: 10}
    };

    locations = [
        { lat: -12.371611433792701, lng: 130.0687731560323 },
        { lat: -13.371611433792701, lng: 132.1687731560323 },
        { lat: -12.571611433792701, lng: 130.3687731560323 },
        { lat: -13.916114337927011, lng: 132.4687731560323 },
        { lat: -12.071611433792701, lng: 130.5687731560323 },
    ];

    constructor(private map: MapsService) { }

    ngOnInit(): void {
        this.map.getLocation().subscribe(data => {
            console.log(data);
            this.lat = Number(data.latitude);
            this.lng = Number(data.longitude);
        })
    }

}
