import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ActAPIService } from '../services/act-api.service';

@Component({
    selector: 'app-mb-home-page',
    templateUrl: './mb-home-page.component.html',
    styleUrls: ['./mb-home-page.component.css']
})
export class MbHomePageComponent implements OnInit {

    // myDate!: string;
    // myTime!: string;
    user!: string;
    id!: string;

    // state!: boolean;
    // break!: boolean;

    child!: string;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private actData: ActAPIService) { }

    ngOnInit(): void {
        // setInterval(() => {
        //     let date = new Date();
        //     this.myTime = date.toTimeString().substring(0, 8);
        //     this.myDate = date.toDateString();
        // }, 1000);

        this.route.queryParams.subscribe(params => {
            this.user = params.user;
            this.id = params.id;
        });

        // this.state = false;
        // this.break = false;
        this.child = '';

    }

    onProfile(){
        this.child = 'profile';
    }
    onHome(){
        this.child = '';
    }
    onTimesheet(){
        this.child = 'timesheet';
    }
 

    // locations = [
    //     { lat: -12.371611433792701, lng: 130.8687731560323 },
    // ];

    // public clocking() {
    //     var clock: string;

    //     if (this.state) {
    //         this.state = !this.state;
    //         clock = "Clock Out";
    //     } else {
    //         this.state = !this.state;
    //         clock = "Clock In";
    //     }

    //     var data = "?desc=" + clock
    //         + "&time=" + this.myTime
    //         + "&date=" + this.myDate
    //         + "&user_id=" + this.id
    //         + "&user_name=" + this.user;

    //     this.actData.CreateAct(data).subscribe((data) => {
    //         // console.log(data);
    //     });

    // }

    // public breaking() {
    //     var clock: string;

    //     if (this.break) {
    //         this.break = false;
    //         clock = "End Break";
    //     } else {
    //         this.break = true;
    //         clock = "Start Break";
    //     }

    //     var data = "?desc=" + clock
    //         + "&time=" + this.myTime
    //         + "&date=" + this.myDate
    //         + "&user_id=" + this.id
    //         + "&user_name=" + this.user;

    //     this.actData.CreateAct(data).subscribe((data) => {
    //         // console.log(data);
    //     });

    // }

}
