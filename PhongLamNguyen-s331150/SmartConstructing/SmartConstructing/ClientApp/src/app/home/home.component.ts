import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent {
  link: string = "";
  constructor(
    private route: ActivatedRoute,
    private router: Router) { }

  public checkLoginType() {
    var toggle = <HTMLInputElement>document.getElementById("switch");
    var inputUserName = <HTMLInputElement>document.getElementById("inputUserName");

    if (inputUserName.value == "") {
      inputUserName.classList.add("is-invalid"); //remove after jquery
    } else {
      if (!toggle.checked) {
        this.router.navigate(['/index']);
      } else if (toggle.checked) {
        this.router.navigate(['/mbindex']);
      }
    }

   
  }

}
