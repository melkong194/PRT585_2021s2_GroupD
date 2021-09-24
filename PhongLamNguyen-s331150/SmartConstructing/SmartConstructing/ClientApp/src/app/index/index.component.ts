import { Component } from '@angular/core';

@Component({
  selector: 'app-index-component',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})

export class IndexComponent {
  title = 'My first AGM project';
  locations = [
    { lat: -12.371611433792701, lng: 130.8687731560323 },
    { lat: -12.381611433792701, lng: 130.8687731560323 },
    { lat: -12.371611433792701, lng: 130.8787731560323 },
  ];
  
  icon = {
    url: 'https://toppng.com/uploads/preview/app-icon-set-login-icon-comments-avatar-icon-11553436380yill0nchdm.png',
    scaledSize: {
      width: 30,
      height: 30
    }
  }
}
