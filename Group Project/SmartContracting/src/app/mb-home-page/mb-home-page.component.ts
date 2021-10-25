import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ActAPIService } from '../services/act-api.service';
import { UserAPIService } from '../services/user-api.service';

@Component({
    selector: 'app-mb-home-page',
    templateUrl: './mb-home-page.component.html',
    styleUrls: ['./mb-home-page.component.css']
})
export class MbHomePageComponent implements OnInit {

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
    rest!: any;

    child!: string;
    temp!: any;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private actData: ActAPIService,
        private userData: UserAPIService) { }

    ngOnInit(): void {
        setInterval(() => {
            let date = new Date();
            this.myTime = date.toTimeString().substring(0, 8);
            this.myDate = date.toDateString();
        }, 1000);

        this.route.queryParams.subscribe(params => {
            this.user = params.user;
            this.id = params.id;
        });

        this.state = false;
        this.break = false;
        this.rest = [0, 0];
        this.child = '';

    }

    locations = [
        { lat: -12.371611433792701, lng: 130.8687731560323 },
    ];

    onProfile() {
        this.child = 'profile';
    }
    onHome() {
        this.child = '';
    }
    onTimesheet() {
        this.child = 'timesheet';
    }


    public breaking() {
        var clock: string;
        var flag = false;
        if (!this.break) {
            if (this.state) {
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

            let x = this.addTime(this.durationCal(this.startBreak, this.endBreak), this.rest);
            this.rest = [x[0], x[1]];

        }

        if (flag) {
            var data = "?desc=" + clock
                + "&time=" + this.myTime
                + "&date=" + this.myDate
                + "&user_id=" + this.id
                + "&user_name=" + this.user;

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
                let x = this.addTime(this.durationCal(this.startBreak, this.endBreak), this.rest);
                this.rest = [x[0], x[1]];
            }

            this.state = !this.state;
            clock = "Clock Out";
            this.endTime = this.myTime;

            let work = this.subTime(this.rest, this.durationCal(this.startTime, this.endTime));
            this.rest = [0, 0];

            this.userData.GetAllUsers().subscribe((data) => {
                for (var _i = 0; _i < Object(data)["result_set"].length; _i++) {
                    if (Object(data)["result_set"][_i].user_id == this.id) {
                        this.temp = Object(data)["result_set"][_i];
                    }
                }
            });
            setTimeout(() => {

                    let t = this.temp['hour'].split(":", 2);
                    let h = this.addTime([ t[0], t[1] ] , work );
                    let data = {
                        "id": this.id,
                        "name": this.temp['name'],
                        "account": this.user,
                        "password": this.temp['password'],
                        "role": this.temp['role'],
                        "hour": h[0] +":"+h[1],
                    };
                    this.temp = data;
    
                    this.userData.UpdateUser(this.temp).subscribe((data) => {
        
                    });
                
            }, 5000)

        }

        var data = "?desc=" + clock
            + "&time=" + this.myTime
            + "&date=" + this.myDate
            + "&user_id=" + this.id
            + "&user_name=" + this.user;

        this.actData.CreateAct(data).subscribe((data) => {
        });

    }

    durationCal(before: any, after: any) {
        var a1 = before.split(":", 3);
        var a2 = after.split(":", 3);
        var dur = (Number(a2[0]) * 60 + Number(a2[1])) - (Number(a1[0]) * 60 + Number(a1[1]));

        return [Math.floor(dur / 60), dur % 60];
    }

    addTime(x: any, y: any) {
        let t = Number(x[1]) + Number(y[1]);
        return [Number(x[0]) + Number(y[0]) + Number(Math.floor(t / 60)), t % 60];
    }

    subTime(x: any, y: any) {
        let t = (Number(y[0]) * 60 + Number(y[1])) - ( Number(x[0]) * 60 + Number(x[1]));
        return [Math.floor(t / 60), t % 60];
    }

}
