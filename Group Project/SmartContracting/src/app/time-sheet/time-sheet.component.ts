import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { SchedulerEvent } from "@progress/kendo-angular-scheduler";
import { EventAPIService } from '../services/event-api.service';
import { UserAPIService } from '../services/user-api.service';
import * as XLSX from 'xlsx';
import { MatSnackBar } from '@angular/material/snack-bar';

interface User {
  value: string;
  viewValue: string;
}

interface Event {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-time-sheet',
  templateUrl: './time-sheet.component.html',
  styleUrls: ['./time-sheet.component.css']
})
export class TimeSheetComponent implements OnInit {

  private dataUser: any;
  private dataEvent: any;

  selectedUser!: string;
  selectedEvent!: string;

  private eventSelectedUserID!: any;

  users: User[] = [];
  events: Event[] = [];

  roleControl = new FormControl('', Validators.required);

  public selectedDate!: Date;
  public eventList!: SchedulerEvent[];

  constructor(
    private userData: UserAPIService,
    private eventData : EventAPIService,
    private _snackBar: MatSnackBar
    ) { }

  ngOnInit(): void {
    this.users = [];
    this.userData.GetAllUsers().subscribe((data) => {
      this.dataUser =  Object(data)["result_set"];
      for(var _i = 0; _i < Object(data)["result_set"].length; _i++) {
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

    this.selectedDate = new Date(currentYear, 5, 24);

    this.eventData.GetAllEvents().subscribe((data) => {
      
      this.eventList = Object(data)["result_set"].map((dataItem: { user_name: string, start: string; end: string; title: string; recurrence_rule: any; RoomID: any; user_id: any; }) => (
        <SchedulerEvent> {
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

    for(var _i = 0; _i < this.dataUser.length; _i++) {
      if(this.dataUser[_i].user_id == this.selectedUser) {
        inputName.value = this.dataUser[_i].name;
        
        return;
      }
    }
  }

  selectEvent() {
    var inputName = <HTMLInputElement>document.getElementById("nameUpdate");
    var inputTitle = <HTMLInputElement>document.getElementById("titleUpdate");
    var inputStart = <HTMLInputElement>document.getElementById("startUpdate");
    var inputEnd = <HTMLInputElement>document.getElementById("endUpdate");
    var inputDate = <HTMLInputElement>document.getElementById("datePickUpdate");

    for(var _i = 0; _i < this.dataEvent.length; _i++) {
      if(this.dataEvent[_i].event_id == this.selectedEvent) {
        inputName.value = this.dataEvent[_i].user_name;
        inputTitle.value = this.dataEvent[_i].title;
        inputStart.value = this.dataEvent[_i].start.split(" ")[1];
        inputEnd.value = this.dataEvent[_i].end.split(" ")[1];
        inputDate.value = this.dataEvent[_i].start.split(" ")[0];

        this.eventSelectedUserID = this.dataEvent[_i].user_id;
        
        return;
      }
    }

  }

  
  createEvent() {
    var inputName = <HTMLInputElement>document.getElementById("name");
    var inputTitle = <HTMLInputElement>document.getElementById("title");
    var inputStart = <HTMLInputElement>document.getElementById("start");
    var inputEnd = <HTMLInputElement>document.getElementById("end");
    var inputDate = <HTMLInputElement>document.getElementById("datePickCreate");
    var invalidFeedback = <HTMLInputElement>document.getElementById("invalid-feedback");
    var validFeedback = <HTMLInputElement>document.getElementById("valid-feedback");
    var data: string;

    if(this.selectedUser != undefined && inputName.value != "" && inputTitle.value != "" && inputStart.value != "" && inputEnd.value != "") {
      data = "?user_id=" + this.selectedUser 
      + "&user_name=" + inputName.value
      + "&title=" + inputTitle.value
      + "&start=" + inputDate.value + " " + inputStart.value
      + "&end=" + inputDate.value + " " + inputEnd.value

      this.eventData.CreateEvent(data).subscribe((data) => {
        if(Object(data)["success"]){
          validFeedback.style.display = "block";
          invalidFeedback.style.display = "none";

          this.ngOnInit();
          this.noneRefresh();
          this.refreshFields(inputName, inputTitle, inputStart, inputEnd, inputDate);
        }
      });
    } else {
      invalidFeedback.style.display = "block";
    }
  }

  updateEvent() {
    var inputName = <HTMLInputElement>document.getElementById("nameUpdate");
    var inputTitle = <HTMLInputElement>document.getElementById("titleUpdate");
    var inputStart = <HTMLInputElement>document.getElementById("startUpdate");
    var inputEnd = <HTMLInputElement>document.getElementById("endUpdate");
    var inputDate = <HTMLInputElement>document.getElementById("datePickUpdate");
    var invalidFeedback = <HTMLInputElement>document.getElementById("invalid-feedback");
    var validFeedback = <HTMLInputElement>document.getElementById("valid-feedback");
    var data: any;

    if(this.selectedEvent != undefined && inputName.value != "" && inputTitle.value != "" && inputStart.value != "" && inputEnd.value != "") {
      data = {
        "id": this.selectedEvent,
        "user_id": this.eventSelectedUserID,
        "user_name": inputName.value,
        "title": inputTitle.value,
        "start": inputDate.value + " " + inputStart.value,
        "end": inputDate.value + " " + inputEnd.value
      };

      this.eventData.UpdateEvent(data).subscribe((data) => {
        if(Object(data)["success"]){
          validFeedback.style.display = "block";
          invalidFeedback.style.display = "none";

          this.ngOnInit();
          this.noneRefreshEvent();
          this.refreshFields(inputName, inputTitle, inputStart, inputEnd, inputDate);
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

  noneRefreshEvent() {
    var inputName = <HTMLInputElement>document.getElementById("nameUpdate");
    var inputTitle = <HTMLInputElement>document.getElementById("titleUpdate");
    var inputStart = <HTMLInputElement>document.getElementById("startUpdate");
    var inputEnd = <HTMLInputElement>document.getElementById("endUpdate");
    var inputDate = <HTMLInputElement>document.getElementById("datePickUpdate");

    inputName.value = "";
    inputTitle.value = "";
    inputStart.value = "";
    inputEnd.value = "";
    inputDate.value = "";
  }

  refreshFields(inputName: HTMLInputElement, inputTitle: HTMLInputElement, inputStart: HTMLInputElement, inputEnd: HTMLInputElement, inputDate: HTMLInputElement) {
    inputName.value = "";
    inputTitle.value = "";
    inputStart.value = "";
    inputEnd.value = "";
    inputDate.value = "";
  }

  

  importPDF(event: any) {
    var importData: any[][];
    var target: DataTransfer = <DataTransfer>(event.target);

    if(target.files.length !== 1) {
      console.log("More than 1 file!!!");
    }

    var reader: FileReader = new FileReader();

    reader.onload = (e: any) => {
      var bstr: string = e.target.result;
      var wb: XLSX.WorkBook = XLSX.read(bstr, {type: 'binary'});
      var wsname: string = wb.SheetNames[0];
      var ws: XLSX.WorkSheet = wb.Sheets[wsname];

      importData = (XLSX.utils.sheet_to_json(ws, {header: 1}));

      for(var _i = 1; _i < importData.length; _i++) {
        var data = "?user_id=" + importData[_i][0]
        + "&user_name=" + importData[_i][1]
        + "&title=" + importData[_i][2]
        + "&start=" + importData[_i][5] + " " + importData[_i][3]
        + "&end=" + importData[_i][5] + " " + importData[_i][4];

        this.eventData.CreateEvent(data).subscribe((data) => {
          

          if(Object(data)["success"]){

            this._snackBar.openFromComponent(SuccessSnack, {
              duration: 5000,
            });

            this.ngOnInit();
          } else {
            this._snackBar.openFromComponent(FailSnack, {
              duration: 5000,
            });
          }
          
        });
      }
    };

    reader.readAsBinaryString(target.files[0]);
  }

  rangePicker = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });

  pickRange() {
    this.events = [];
    this.eventData.GetAllEvents().subscribe((data) => {
      this.dataEvent =  Object(data)["result_set"];
      for(var _i = 0; _i < Object(data)["result_set"].length; _i++) {
        if(this.rangePicker.controls.start.value <= new Date(Object(data)["result_set"][_i].start.split(" ")[0]) && 
              new Date(Object(data)["result_set"][_i].start.split(" ")[0]) <= this.rangePicker.controls.end.value) {
          var temp = {
            value: Object(data)["result_set"][_i].event_id,
            viewValue: Object(data)["result_set"][_i].event_id + ": " + Object(data)["result_set"][_i].title
              + " - " + Object(data)["result_set"][_i].user_name
          }
          this.events.push(temp);
        }
      }
    });
  }

}

@Component({
  selector: 'success-snack',
  template: `
    <span class="text">
      Request succeeded!!!
    </span>`,
  styles: [`
    .text {
      color: green;
    }  
  `]

})
export class SuccessSnack {}

@Component({
  selector: 'success-snack',
  template: `
    <span class="text">
      Request Failed!!!
    </span>`,
  styles: [`
    .text {
      color: red;
    }  
  `]

})
export class FailSnack {}
