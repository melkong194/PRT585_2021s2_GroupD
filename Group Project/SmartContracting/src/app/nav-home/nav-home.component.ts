import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';

import { ExceptionlessClient } from 'exceptionless';
const defaultClient = ExceptionlessClient.default;
const config = {
  apiKey: "i31ihhJrceMh2z9yYNb9G2OQuSrYfJm77gY5Hu3B"
};
const client = new ExceptionlessClient(config);

@Component({
  selector: 'app-nav-home',
  templateUrl: './nav-home.component.html',
  styleUrls: ['./nav-home.component.css']
})
export class NavHomeComponent implements OnInit {

  user!: string;

  constructor( 
    private route: ActivatedRoute,
    private router: Router) {
    
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.user = params.user;
    });
  }

  navHome(): void {
    let navigationExtras: NavigationExtras = {
      queryParams: {
          "user": this.user
      }
    };

    this.router.navigate(['/home'], navigationExtras);
  }

  navAccount(): void {
    let navigationExtras: NavigationExtras = {
      queryParams: {
          "user": this.user
      }
    };

    this.router.navigate(['/account'], navigationExtras);
  }

  navTimeSheet(): void {
    let navigationExtras: NavigationExtras = {
      queryParams: {
          "user": this.user
      }
    };

    this.router.navigate(['/timesheet'], navigationExtras);
  }

  exceptionless() {
    client.submitException(new Error("Testing!!"));
  }

}
