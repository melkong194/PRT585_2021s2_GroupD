import { Component } from '@angular/core';

@Component({
  selector: 'app-mbindex',
  templateUrl: './mbindex.component.html',
  styleUrls: ['./mbindex.component.css']
})
export class MbIndexComponent {
  myDate: string;
  myTime: string;

  locations = [
    { lat: -12.371611433792701, lng: 130.8687731560323 },
  ];

  icon = {
    url: 'https://toppng.com/uploads/preview/app-icon-set-login-icon-comments-avatar-icon-11553436380yill0nchdm.png',
    scaledSize: {
      width: 30,
      height: 30
    }
  }

  ngOnInit() {
    setInterval(() => {
      let date = new Date();
      this.myTime = date.toTimeString().substring(0, 8);
      this.myDate = date.toDateString();
    }, 1000);
  }

}
