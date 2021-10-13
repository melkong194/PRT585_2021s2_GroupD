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
    work!: string;
    rest!: string;


    constructor(private route: ActivatedRoute,
        private router: Router,
        private actData: ActAPIService) { }

    ngOnInit(): void {
        setInterval(() => {
            let date = new Date();
            this.myTime = date.toTimeString().substring(0, 8);
            this.myDate = date.toDateString();
        }, 1000);

        this.state = false;
        this.break = false;
    }

    locations = [
        { lat: -12.371611433792701, lng: 130.8687731560323 },
    ];

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
            + "&time=" + this.myTime
            + "&date=" + this.myDate
            + "&user_id=" + this.id
            + "&user_name=" + this.user;

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
        }

        var data = "?desc=" + clock
            + "&time=" + this.myTime
            + "&date=" + this.myDate
            + "&user_id=" + this.id
            + "&user_name=" + this.user;

        this.actData.CreateAct(data).subscribe((data) => {
            // console.log(data);
        });
    }

    calculateTime(time1: any, time2: any){
        // return min
        
        var a1 = time1.split(":").map(Number);
        var a2 = time2.split(":").map(Number);
        console.log(a1);
        console.log(a2);
        return ((a2[0]-a1[0])*60) - (a2[1]-a1[1]);
    }

}
