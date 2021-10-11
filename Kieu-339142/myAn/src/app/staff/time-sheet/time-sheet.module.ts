import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { TimeSheetComponent } from './time-sheet.component';

import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { SchedulerModule } from "@progress/kendo-angular-scheduler";


const routes: Routes = [
    { path: '', component: TimeSheetComponent },
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BrowserModule, 
    BrowserAnimationsModule, 
    SchedulerModule,
    RouterModule.forChild(routes),
  ]
})
export class TimeSheetModule { }
