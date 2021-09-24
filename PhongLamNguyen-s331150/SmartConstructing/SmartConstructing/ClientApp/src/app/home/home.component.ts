import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  link: string = "";

  public checkLoginType() {
    var toggle = <HTMLInputElement>document.getElementById("switch");
    var inputUserName = <HTMLInputElement>document.getElementById("inputUserName");

    if (inputUserName.value == "") {
      inputUserName.classList.add("is-invalid");
    } else {
      if (!toggle.checked) {
        this.link = "index";
      } else if (toggle.checked) {
        this.link = "mbindex";
      }
    }

   
  }

}
