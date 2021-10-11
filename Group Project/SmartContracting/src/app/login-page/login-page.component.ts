import { Component, OnInit } from '@angular/core';

import { Router, ActivatedRoute, NavigationExtras } from '@angular/router';
import { UserAPIService } from '../services/user-api.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  link: string = "";
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private getAllUserData: UserAPIService) { }

  ngOnInit(): void {
  }

  public checkLoginType() {
    var toggle = <HTMLInputElement>document.getElementById("switch");
    var inputUserName = <HTMLInputElement>document.getElementById("inputUserName");
    var inputPassword = <HTMLInputElement>document.getElementById("inputPassword");
    var invalidFeedback = <HTMLInputElement>document.getElementById("invalid-feedback");

    
    this.getAllUserData.GetAllUsers().subscribe((data) => {
      for(var _i = 0; _i < Object(data)["result_set"].length; _i++) {
        if(Object(data)["result_set"][_i].account == inputUserName.value && Object(data)["result_set"][_i].password == inputPassword.value) {
          if (!toggle.checked && Object(data)["result_set"][_i].role == "manager") {

            let navigationExtras: NavigationExtras = {
              queryParams: {
                  "user": Object(data)["result_set"][_i].name
              }
            };

            this.router.navigate(['/home'], navigationExtras);
          } else if (toggle.checked && Object(data)["result_set"][_i].role == "employee") {
            let navigationExtras: NavigationExtras = {
              queryParams: {
                  "user": Object(data)["result_set"][_i].name,
                  "id": Object(data)["result_set"][_i].user_id
              }
            };

            this.router.navigate(['/mbhome'], navigationExtras);
          } else {
            invalidFeedback.style.display = "block";
          }
        } else {
          invalidFeedback.style.display = "block";
        }
      }
    });

      
    

   
  }

}
