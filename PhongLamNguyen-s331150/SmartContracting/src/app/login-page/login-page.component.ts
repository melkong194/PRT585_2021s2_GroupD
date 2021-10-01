import { Component, OnInit } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  link: string = "";
  constructor(
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
  }

  public checkLoginType() {
    var toggle = <HTMLInputElement>document.getElementById("switch");
    var inputUserName = <HTMLInputElement>document.getElementById("inputUserName");
    var invalidFeedback = <HTMLInputElement>document.getElementById("invalid-feedback");

    if (inputUserName.value == "") {
      invalidFeedback.style.display = "block";
    } else {
      if (!toggle.checked) {
        this.router.navigate(['/home']);
        console.log("haha");
      } else if (toggle.checked) {
        this.router.navigate(['/mbhome']);
      }
    }

   
  }

}
