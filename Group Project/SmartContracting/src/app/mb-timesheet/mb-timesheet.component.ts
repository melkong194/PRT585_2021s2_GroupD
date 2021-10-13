import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { SchedulerEvent } from "@progress/kendo-angular-scheduler";
import { EventAPIService } from '../services/event-api.service';
import { UserAPIService } from '../services/user-api.service';
import { ActivatedRoute, Router } from '@angular/router';

interface User {
    value: string;
    viewValue: string;
}

@Component({
    selector: 'app-mb-timesheet',
    templateUrl: './mb-timesheet.component.html',
    styleUrls: ['./mb-timesheet.component.css']
})
export class MbTimesheetComponent implements OnInit {

    user!: string;
    id!: string;

    private dataUser: any;
    selectedUser!: string;
    users: User[] = [];

    roleControl = new FormControl('', Validators.required);

    range = new FormGroup({
        start: new FormControl(),
        end: new FormControl()
    });

    public selectedDate!: Date;
    public events!: SchedulerEvent[];

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private userData: UserAPIService,
        private eventData: EventAPIService,
    ) { }

    ngOnInit(): void {
        this.route.queryParams.subscribe(params => {
            this.user = params.user;
            this.id = params.id;
        });

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

        const currentYear = new Date().getFullYear();

        const parseAdjust = (eventDate: string): Date => {
            const date = new Date(eventDate);
            date.setFullYear(currentYear);
            return date;
        };

        this.selectedDate = new Date(currentYear, 9, 13);

        this.eventData.GetAllEvents().subscribe((data) => {

            this.events = Object(data)["result_set"].map((dataItem: { user_name: string, start: string; end: string; title: string; recurrence_rule: any; RoomID: any; user_id: any; }) => (
                <SchedulerEvent>{
                    start: parseAdjust(dataItem.start),
                    end: parseAdjust(dataItem.end),
                    title: dataItem.user_name + " : " + dataItem.title,
                    recurrenceRule: dataItem.recurrence_rule,

                    ownerID: dataItem.user_id
                }
            ));
        });

    }

    selectUser() {
        var inputName = <HTMLInputElement>document.getElementById("name");

        for (var _i = 0; _i < this.dataUser.length; _i++) {
            if (this.dataUser[_i].user_id == this.selectedUser) {
                inputName.value = this.dataUser[_i].name;

                return;
            }
        }
    }


    createEvent() {
        var inputName = <HTMLInputElement>document.getElementById("name");
        var inputTitle = <HTMLInputElement>document.getElementById("title");
        var inputStart = <HTMLInputElement>document.getElementById("start");
        var inputEnd = <HTMLInputElement>document.getElementById("end");
        var invalidFeedback = <HTMLInputElement>document.getElementById("invalid-feedback");
        var validFeedback = <HTMLInputElement>document.getElementById("valid-feedback");
        var data: string;

        if (this.selectedUser != undefined && inputName.value != "" && inputTitle.value != "" && inputStart.value != "" && inputEnd.value != "") {
            data = "?user_id=" + this.selectedUser
                + "&user_name=" + inputName.value
                + "&title=" + inputTitle.value
                + "&start=" + this.range.value.start.toDateString() + " " + inputStart.value
                + "&end=" + this.range.value.end.toDateString() + " " + inputEnd.value

            this.eventData.CreateEvent(data).subscribe((data) => {
                if (Object(data)["success"]) {
                    validFeedback.style.display = "block";
                    invalidFeedback.style.display = "none";


                    this.ngOnInit();
                    this.noneRefresh();
                }
            });
        } else {
            invalidFeedback.style.display = "block";
        }
    }

    noneRefresh() {
        var inputName = <HTMLInputElement>document.getElementById("name");
        var inputTitle = <HTMLInputElement>document.getElementById("title");
        var inputStart = <HTMLInputElement>document.getElementById("start");
        var inputEnd = <HTMLInputElement>document.getElementById("end");

        inputName.value = "";
        inputTitle.value = "";
        inputStart.value = "";
        inputEnd.value = "";
    }

    refreshFields(inputName: HTMLInputElement, inputTitle: HTMLInputElement, inputStart: HTMLInputElement, inputEnd: HTMLInputElement) {
        inputName.value = "";
        inputTitle.value = "";
        inputStart.value = "";
        inputEnd.value = "";
    }

}
