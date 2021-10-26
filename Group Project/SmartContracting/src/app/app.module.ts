import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginPageComponent } from './login-page/login-page.component';
import { HomePageComponent } from './home-page/home-page.component';
import { MbHomePageComponent } from './mb-home-page/mb-home-page.component';

import {FlexLayoutModule} from "@angular/flex-layout";
import { AgmCoreModule } from '@agm/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {MatSidenavModule} from '@angular/material/sidenav';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatListModule} from '@angular/material/list';
import { NavHomeComponent } from './nav-home/nav-home.component';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { TimeSheetComponent } from './time-sheet/time-sheet.component';
import {MatCardModule} from '@angular/material/card';
import {MatChipsModule} from '@angular/material/chips';
import {MatMenuModule} from '@angular/material/menu';
import { AccountPageComponent } from './account-page/account-page.component';
import {MatTabsModule} from '@angular/material/tabs';
import {MatSelectModule} from '@angular/material/select';
import { SchedulerModule } from '@progress/kendo-angular-scheduler';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MbProfileComponent } from './mb-profile/mb-profile.component';
import { MbTimesheetComponent } from './mb-timesheet/mb-timesheet.component';
import { MbClockComponent } from './mb-clock/mb-clock.component';
import { ActPageComponent } from './act-page/act-page.component';
import { PDFExportModule } from '@progress/kendo-angular-pdf-export';
import { PDFModule } from "@progress/kendo-angular-scheduler";
import { UserProfileComponent } from './user-profile/user-profile.component';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatSortModule} from '@angular/material/sort';


@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    HomePageComponent,
    MbHomePageComponent,
    NavHomeComponent,
    TimeSheetComponent,
    AccountPageComponent,
    MbProfileComponent,
    MbTimesheetComponent,
    MbClockComponent,
    ActPageComponent,
    UserProfileComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: LoginPageComponent, pathMatch: 'full' },
      { path: 'home', component: HomePageComponent},
      { path: 'account', component: AccountPageComponent},
      { path: 'timesheet', component: TimeSheetComponent},
      { path: 'mbhome', component: MbHomePageComponent},
      { path: 'mbprofile', component: MbProfileComponent},
      { path: 'act', component: ActPageComponent},
      { path: 'userProfile', component: UserProfileComponent},
    ]),
    
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyAkNi7U2_6ZqRDlun0DcHcXI6yiJg8oVrg'
    }),
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatListModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatChipsModule,
    MatMenuModule,
    MatTabsModule,
    MatSelectModule,
    SchedulerModule,
    MatDatepickerModule,
    MatNativeDateModule,
    PDFExportModule,
    PDFModule,
    MatAutocompleteModule,
    MatSortModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
