import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';

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

}
