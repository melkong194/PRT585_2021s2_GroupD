import { Component, OnInit } from '@angular/core';
import { StaffAuthenService } from '../core/services/staff-authen.service';
import { AdminAuthenService } from '../core/services/admin-authen.service';
import { UrlConstants } from '../core/common/url-constants.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-portal',
    templateUrl: './portal.component.html',
    styleUrls: ['./portal.component.css']
})
export class PortalComponent implements OnInit {

    role: string = "";
    link: string = "";
    constructor(
        private staffService: StaffAuthenService, 
        private adminService: AdminAuthenService,
        private router: Router) {

    }

    ngOnInit(): void {
        this.role = 'staff';
    }

    public roleChoose(val: string) {
        this.role = val;
    }

    public login() {
        var username = <HTMLInputElement>document.getElementById("inputUserName");
        var password = <HTMLInputElement>document.getElementById("inputPassword");

        console.log("role", this.role);
        console.log("username", username.value);
        console.log("pass", password.value);

        if(this.role=="staff"){
            var result = this.staffService.staffAuthen(username.value, password.value);
            result.subscribe(data => {
                if (Object(data)['success']) {
                    this.router.navigate(['/staff/home']);
                }

            }, error => {
                console.log(JSON.stringify(error));
            });
        }else if(this.role=="admin"){
            var result = this.adminService.adminAuthen(username.value, password.value);
            result.subscribe(data => {
                if (Object(data)['success']) {
                    this.router.navigate(['/admin/home']);
                }

            }, error => {
                console.log(JSON.stringify(error));
            });

        }else{
            this.router.navigate(['/login']);
        }

        

        

        // .then(data => { this.router.navigate([UrlConstants.STAFF]); });

    }

}
