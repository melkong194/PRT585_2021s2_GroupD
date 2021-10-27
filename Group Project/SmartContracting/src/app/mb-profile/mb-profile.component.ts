import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { UserAPIService } from '../services/user-api.service';
import { ActivatedRoute, Router } from '@angular/router';



@Component({
    selector: 'app-mb-profile',
    templateUrl: './mb-profile.component.html',
    styleUrls: ['./mb-profile.component.css']
})
export class MbProfileComponent implements OnInit {
    hide = true;
    user!: string;
    id!: string;
    temp!: any;

    constructor(
        private userData: UserAPIService,
        private route: ActivatedRoute,
        private router: Router,
        ) { }

    ngOnInit(): void {
        this.route.queryParams.subscribe(params => {
            this.user = params.user;
            this.id = params.id;
        });

        this.userData.GetAllUsers().subscribe((data) => {
            for (var _i = 0; _i < Object(data)["result_set"].length; _i++) {
                if (Object(data)["result_set"][_i].user_id == this.id) {
                    this.temp = Object(data)["result_set"][_i];
                }
            }
        });

    }

    updateAccount() {
        var name = <HTMLInputElement>document.getElementById("name");
        var acc = <HTMLInputElement>document.getElementById("account");
        var pass = <HTMLInputElement>document.getElementById("password");
        var invalidFeedback = <HTMLInputElement>document.getElementById("invalid-feedback");
        var validFeedback = <HTMLInputElement>document.getElementById("valid-feedback");


        if(name.value !==null && acc.value !==null && pass.value !==null){
            let data = {
                "id": this.id,
                "status" : this.temp['status'],
                "name": name.value,
                "account": acc.value,
                "password": pass.value,
                "role": this.temp['role'],
                "hour": this.temp['hour'],
            };

            let email : any;  

            email = {
                ToEMail: 'melkong194@gmail.com',
                Subject: 'testing',
                Body: 'ur account ifo has been updated!',
            };

            this.userData.SendEmai(email).subscribe((data) => {
            });
    
            this.temp = data;
            this.userData.UpdateUser(this.temp).subscribe((data) => {
                if(Object(data)["success"]){
                    validFeedback.style.display = "block";
                    invalidFeedback.style.display = "none";  
                    this.refreshFields(name, acc, pass);
                    // this.router.navigate(['/']);           
                    this.ngOnInit();
                  }
            });

            

        }else{
            invalidFeedback.style.display = "block";
        }       
    }

    refreshFields(inputName: HTMLInputElement, inputAccount: HTMLInputElement, inputPassword: HTMLInputElement) {
        inputName.value = "";
        inputAccount.value = "";
        inputPassword.value = "";
    }

   

}
