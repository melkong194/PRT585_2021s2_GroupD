import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ActAPIService } from '../services/act-api.service';

@Component({
    selector: 'app-mb-clock',
    templateUrl: './mb-clock.component.html',
    styleUrls: ['./mb-clock.component.css']
})
export class MbClockComponent implements OnInit {

    myDate!: string;
    myTime!: string;
    user!: string;
    id!: string;

    state!: boolean;
    break!: boolean;

    startTime!: string;
    endTime!: string;
    startBreak!: string;
    endBreak!: string;
<<<<<<< HEAD
    work!: string;
    rest!: string;
=======
    rest!: any;
>>>>>>> development/client_app


    constructor(private route: ActivatedRoute,
        private router: Router,
        private actData: ActAPIService) { }

    ngOnInit(): void {
        setInterval(() => {
            let date = new Date();
            this.myTime = date.toTimeString().substring(0, 8);
            this.myDate = date.toDateString();
        }, 1000);

<<<<<<< HEAD
        this.state = false;
        this.break = false;
=======
        this.route.queryParams.subscribe(params => {
            this.user = params.user;
            this.id = params.id;
        });

        this.state = false;
        this.break = false;
        this.rest =[0,0];
>>>>>>> development/client_app
    }

    locations = [
        { lat: -12.371611433792701, lng: 130.8687731560323 },
    ];

<<<<<<< HEAD
    public clocking() {
        var clock: string;

        if (this.state) {
            this.state = !this.state;
            clock = "Clock Out";
            this.startTime = this.myTime;
        } else {
            this.state = !this.state;
            clock = "Clock In";
            this.endTime = this.myTime;
            console.log("end",this.endTime);
            console.log(this.startTime);
            console.log(this.calculateTime(this.startTime, this.endTime));
        }

        var data = "?desc=" + clock
=======
    public breaking() {
        var clock: string;
        var flag = false;
        if (!this.break) {
            if(this.state){
                this.break = !this.break;
                clock = "Start Break";
                this.startBreak = this.myTime;
                flag = true;
            }
            clock = "End Break";
        } else {
            this.break = !this.break;
            clock = "End Break";
            this.endBreak = this.myTime;
            flag = true;

            let x = this.addTime(this.durationCal(this.startBreak, this.endBreak) , this.rest);
            this.rest = [x[0], x[1]];

        }

        if(flag){
            var data = "?desc=" + clock
>>>>>>> development/client_app
            + "&time=" + this.myTime
            + "&date=" + this.myDate
            + "&user_id=" + this.id
            + "&user_name=" + this.user;

<<<<<<< HEAD
        this.actData.CreateAct(data).subscribe((data) => {
            // console.log(data);
        });

    }

    public breaking() {
        var clock: string;

        if (this.break) {
            this.break = false;
            clock = "End Break";
            this.startBreak = this.myTime;
        } else {
            this.break = true;
            clock = "Start Break";
            this.endBreak = this.myTime;
=======
            this.actData.CreateAct(data).subscribe((data) => {
                // console.log(data);
            });
            flag = false;
        }

    }

    public clocking() {
        var clock: string;

        if (!this.state) {
            this.state = !this.state;
            clock = "Clock In";
            this.startTime = this.myTime;

        } else {
            if (this.break) {
                this.break = !this.break;
                clock = "End Break";
                this.endBreak = this.myTime;
                let x = this.addTime(this.durationCal(this.startBreak, this.endBreak) , this.rest);
                this.rest = [x[0], x[1]];
            }
            
            this.state = !this.state;
            clock = "Clock Out";
            this.endTime = this.myTime;

            let work = this.subTime(this.rest, this.durationCal(this.startTime,this.endTime));
            

            this.rest =[0,0];
>>>>>>> development/client_app
        }

        var data = "?desc=" + clock
            + "&time=" + this.myTime
            + "&date=" + this.myDate
            + "&user_id=" + this.id
            + "&user_name=" + this.user;

        this.actData.CreateAct(data).subscribe((data) => {
            // console.log(data);
        });
<<<<<<< HEAD
    }

    calculateTime(time1: any, time2: any){
        // return min
        
        var a1 = time1.split(":").map(Number);
        var a2 = time2.split(":").map(Number);
        console.log(a1);
        console.log(a2);
        return ((a2[0]-a1[0])*60) - (a2[1]-a1[1]);
=======

    }

    durationCal(before: any, after: any){
        var a1 = before.split(":",3);
        var a2 = after.split(":",3);
        var dur = ( Number(a2[0])*60 + Number(a2[1]) ) - ( Number(a1[0])*60 + Number(a1[1]));
        
        return [ Math.floor(dur/60) , dur%60 ];
    }

    addTime(x:any, y:any){
        let t = x[1] + y[1];
        return [  x[0] + y[0] + Math.floor(t/60) , t%60];
    }

    subTime(x:any, y:any){
        let t = ( y[0]*60 + y[1] ) - ( x[0]*60 + x[1] );
        return [ Math.floor(t/60) , t%60 ];
>>>>>>> development/client_app
    }

}
