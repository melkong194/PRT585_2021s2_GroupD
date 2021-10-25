import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { UserAPIService } from '../services/user-api.service';

interface Role {
  value: string;
  viewValue: string;
}

interface User {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-account-page',
  templateUrl: './account-page.component.html',
  styleUrls: ['./account-page.component.css']
})
export class AccountPageComponent implements OnInit {

  private dataUser: any;

  hide = true;

  selectedRole!: string;

  selectedUser!: string;

  roles: Role[] = [
    {value: 'manager', viewValue: 'Manager'},
    {value: 'employee', viewValue: 'Employee'},
  ];

  users: User[] = [];

  roleControl = new FormControl('', Validators.required);

  constructor(private userData: UserAPIService) { }

  ngOnInit(): void {
    this.users = [];
    this.userData.GetAllUsers().subscribe((data) => {
      this.dataUser =  Object(data)["result_set"];
      for(var _i = 0; _i < Object(data)["result_set"].length; _i++) {
        var temp = {
          value: Object(data)["result_set"][_i].user_id,
          viewValue: Object(data)["result_set"][_i].user_id + ": " + Object(data)["result_set"][_i].name
        }
        this.users.push(temp);
      }
    });

  }

  selectUser() {
    var inputName = <HTMLInputElement>document.getElementById("nameUpdate");
    var inputAccount = <HTMLInputElement>document.getElementById("accountUpdate");
    var inputPassword = <HTMLInputElement>document.getElementById("passwordUpdate");
    var inputRole = <HTMLInputElement>document.getElementById("roleDelete");

    for(var _i = 0; _i < this.dataUser.length; _i++) {
      if(this.dataUser[_i].user_id == this.selectedUser) {
        inputName.value = this.dataUser[_i].name;
        inputAccount.value = this.dataUser[_i].account;
        inputPassword.value = this.dataUser[_i].password;
        this.selectedRole = this.dataUser[_i].role;

        if(inputRole) {
          inputRole.value = this.dataUser[_i].role;
        }
        
        return;
      }
    }
  }

  createUser() {
    var inputName = <HTMLInputElement>document.getElementById("name");
    var inputAccount = <HTMLInputElement>document.getElementById("account");
    var inputPassword = <HTMLInputElement>document.getElementById("password");
    var invalidFeedback = <HTMLInputElement>document.getElementById("invalid-feedback");
    var validFeedback = <HTMLInputElement>document.getElementById("valid-feedback");
    var data: string;

    if(this.selectedRole != undefined && inputName.value != "" && inputAccount.value != "" && inputPassword.value != "") {
      data = "?name=" + inputName.value 
      + "&account=" + inputAccount.value 
      + "&password=" + inputPassword.value 
      + "&role=" + this.selectedRole
      + "&hour=0.0";

      this.userData.AddUser(data).subscribe((data) => {
        if(Object(data)["success"]){
          validFeedback.style.display = "block";
          invalidFeedback.style.display = "none";

          this.refreshFields(inputName, inputAccount, inputPassword);

          this.ngOnInit();
        }
      });
    } else {
      invalidFeedback.style.display = "block";
    }

  }

  updateUser() {
    var inputName = <HTMLInputElement>document.getElementById("nameUpdate");
    var inputAccount = <HTMLInputElement>document.getElementById("accountUpdate");
    var inputPassword = <HTMLInputElement>document.getElementById("passwordUpdate");
    var invalidFeedback = <HTMLInputElement>document.getElementById("invalid-feedback");
    var validFeedback = <HTMLInputElement>document.getElementById("valid-feedback");
    var data: any;

    if(this.selectedRole != undefined && inputName.value != "" && inputAccount.value != "" && inputPassword.value != "") {
      data = {
        "id": this.selectedUser,
        "name": inputName.value,
        "account": inputAccount.value,
        "password": inputPassword.value,
        "role": this.selectedRole
      }

      // console.log(data);

      this.userData.UpdateUser(data).subscribe((data) => {
        if(Object(data)["success"]){
          validFeedback.style.display = "block";
          invalidFeedback.style.display = "none";

          this.refreshFields(inputName, inputAccount, inputPassword);

          this.ngOnInit();
        }
      });
    } else {
      invalidFeedback.style.display = "block";
    }
  }

  deleteUser() {
    var inputName = <HTMLInputElement>document.getElementById("nameUpdate");
    var inputAccount = <HTMLInputElement>document.getElementById("accountUpdate");
    var inputPassword = <HTMLInputElement>document.getElementById("passwordUpdate");
    var inputRole = <HTMLInputElement>document.getElementById("roleDelete");
    var invalidFeedback = <HTMLInputElement>document.getElementById("invalid-feedback");
    var validFeedback = <HTMLInputElement>document.getElementById("valid-feedback");
    var data: any;

    if(inputRole.value != "" && inputName.value != "" && inputAccount.value != "" && inputPassword.value != "") {
      data = {
        "id": this.selectedUser,
        "name": inputName.value,
        "account": inputAccount.value,
        "password": inputPassword.value,
        "role": inputRole.value
      }

      // console.log(data);

      this.userData.DeleteUser(data).subscribe((data) => {
        if(Object(data)["success"]){
          validFeedback.style.display = "block";
          invalidFeedback.style.display = "none";

          this.refreshFields(inputName, inputAccount, inputPassword);
          inputRole.value = "";

          this.ngOnInit();
        }
      });
    } else {
      invalidFeedback.style.display = "block";
    }
  }

  refreshFields(inputName: HTMLInputElement, inputAccount: HTMLInputElement, inputPassword: HTMLInputElement) {
    inputName.value = "";
    inputAccount.value = "";
    inputPassword.value = "";
  }

  noneRefresh() {
    var inputName = <HTMLInputElement>document.getElementById("nameUpdate");
    var inputAccount = <HTMLInputElement>document.getElementById("accountUpdate");
    var inputPassword = <HTMLInputElement>document.getElementById("passwordUpdate");
    var inputRole = <HTMLInputElement>document.getElementById("roleDelete");

    this.refreshFields(inputName, inputAccount, inputPassword);
    inputRole.value = "";
  }

}
