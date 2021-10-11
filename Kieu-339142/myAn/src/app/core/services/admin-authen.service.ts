import { Injectable } from '@angular/core';
import { SystemConstants } from '../common/system-constants.service';
import { LoggedInUser } from '../domain/loggedin-user.service';
// import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})

export class AdminAuthenService {

    base = "https://localhost:5000/api/Admin/";
    Authen = this.base + "Authenticate";
    Create = this.base + "Create";
    Update = this.base + "Update";
    ReadByAdmin = this.base + "GetStaffsByAdmin";
    ReadAll = this.base + "GetAll";

    httpHeader = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(private http: HttpClient) { }

    adminAuthen(username: string, password: string) {            
        
        let body = '?username=' + username +
                    '&password=' + password;
        console.log("https://localhost:5000/api/Admin/"+body,"");
        // var result = {};
        return this.http.post(this.Authen+body,"");
            
        
        // let promise = new Promise((resolve, reject) => {
        //     this._http.post(this.Authen,body,{headers: headers})
        //         .subscribe((response: any) => {
        //             const user: LoggedInUser = response.json();
        //             console.log(user);
        //             if (user) {
        //                 localStorage.removeItem(SystemConstants.CURRENT_USER);
        //                 localStorage.setItem(SystemConstants.CURRENT_USER, JSON.stringify(user));
        //                 resolve(true);
        //             }
        //             else {
        //                 reject(false);
        //             }
        //         }, error => {
        //             reject(error);
        //         });
        // });
        // return promise;
    };
    adminCreate() {

    };
    adminUpdate() {

    };
    adminByAdmin() {

    };
    adminReadAll() {

    };




}