import { Component } from '@angular/core';
import * as Elmahio from 'elmah.io.javascript';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SmartContracting';


  constructor() {
    const logger = new Elmahio({ apiKey: '87a03e9e26a74d6fa983f9de3a9c8776', logId: 'bd8c1453-5792-461b-8021-5bcc8eb338df' });
    logger.information('App started!');
  }
}
