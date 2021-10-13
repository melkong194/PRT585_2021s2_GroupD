import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { UserAPIService } from '../services/user-api.service';


@Component({
    selector: 'app-mb-profile',
    templateUrl: './mb-profile.component.html',
    styleUrls: ['./mb-profile.component.css']
})
export class MbProfileComponent implements OnInit {
    private dataUser: any;
    users: any;

    constructor(private userData: UserAPIService) { }

    ngOnInit(): void {
        this.users = [];
        this.userData.GetAllUsers().subscribe((data) => {
            this.dataUser = Object(data)["result_set"];
            for (var _i = 0; _i < Object(data)["result_set"].length; _i++) {
                var temp = {
                    value: Object(data)["result_set"][_i].user_id,
                    viewValue: Object(data)["result_set"][_i].user_id + ": " + Object(data)["result_set"][_i].name
                }
                this.users.push(temp);
            }
        });

    }

}
