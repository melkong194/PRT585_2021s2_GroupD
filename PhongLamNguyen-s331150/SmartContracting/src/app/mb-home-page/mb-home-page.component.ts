import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-mb-home-page',
  templateUrl: './mb-home-page.component.html',
  styleUrls: ['./mb-home-page.component.css']
})
export class MbHomePageComponent implements OnInit {

  myDate!: string;
  myTime!: string;
  
  constructor() { }

  ngOnInit(): void {
    setInterval(() => {
      let date = new Date();
      this.myTime = date.toTimeString().substring(0, 8);
      this.myDate = date.toDateString();
    }, 1000);
  }

  locations = [
    { lat: -12.371611433792701, lng: 130.8687731560323 },
  ];

  public clocking() {
    console.log("haha");
  }

}
