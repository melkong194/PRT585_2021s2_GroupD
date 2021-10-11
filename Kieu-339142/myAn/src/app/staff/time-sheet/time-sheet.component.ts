import { Component, OnInit } from '@angular/core';
import { SchedulerEvent } from "@progress/kendo-angular-scheduler";
import { sampleData, displayDate } from "./events-utc";

@Component({
    selector: 'app-time-sheet',
    templateUrl: './time-sheet.component.html',
    styleUrls: ['./time-sheet.component.css']
})
export class TimeSheetComponent implements OnInit {
    public selectedDate: Date = displayDate;
    public events: SchedulerEvent[] = sampleData;
    constructor() { }

    ngOnInit(): void {
    }

}
