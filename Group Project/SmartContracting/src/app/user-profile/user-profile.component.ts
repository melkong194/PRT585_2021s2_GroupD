import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserAPIService } from '../services/user-api.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  hide = true;

  constructor(
    private userData: UserAPIService,
    private route: ActivatedRoute,) { }

  ngOnInit(): void {
    var id = <HTMLInputElement>document.getElementById("id");
    var name = <HTMLInputElement>document.getElementById("name");
    var account = <HTMLInputElement>document.getElementById("account");
    var password = <HTMLInputElement>document.getElementById("password");
    var role = <HTMLInputElement>document.getElementById("role");
    var status = <HTMLInputElement>document.getElementById("status");
    var hours = <HTMLInputElement>document.getElementById("hours");

    this.route.queryParams.subscribe(params => {
      this.userData.GetAllUsers().subscribe((data) => {
        for(var _i = 0; _i < Object(data)["result_set"].length; _i++) {
          if(Object(data)["result_set"][_i].user_id == params.user_id && Object(data)["result_set"][_i].name == params.name) {
            id.value = Object(data)["result_set"][_i].user_id;
            name.value = Object(data)["result_set"][_i].name;
            account.value = Object(data)["result_set"][_i].account;
            password.value = Object(data)["result_set"][_i].password;
            role.value = Object(data)["result_set"][_i].role;
            status.value = Object(data)["result_set"][_i].status;
            hours.value = Object(data)["result_set"][_i].hour;
          }
        }
      });
    });
  }

}
