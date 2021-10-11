import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StaffComponent } from './staff.component';
import { staffRoutes } from './staff.routes';
import { RouterModule } from '@angular/router';
import { HomeModule } from './home/home.module';
import { ProfileModule } from './profile/profile.module';
import { RecordModule } from './record/record.module';
import { StaffNavbarComponent } from '../shared/staff-navbar/staff-navbar.component';
import { TimeSheetComponent } from './time-sheet/time-sheet.component';


@NgModule({
  declarations: [
    StaffComponent, StaffNavbarComponent, TimeSheetComponent
  ],
  imports: [
    CommonModule,
    HomeModule,
    ProfileModule,
    RecordModule,
    RouterModule.forChild(staffRoutes)
  ]
})
export class StaffModule { }
