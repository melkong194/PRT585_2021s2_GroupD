import { NgModule, ErrorHandler } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginPageComponent } from './login-page/login-page.component';
import { HomePageComponent } from './home-page/home-page.component';
import { MbHomePageComponent } from './mb-home-page/mb-home-page.component';
import * as Elmahio from 'elmah.io.javascript';

import { FlexLayoutModule } from "@angular/flex-layout";
import { AgmCoreModule } from '@agm/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { NavHomeComponent } from './nav-home/nav-home.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { TimeSheetComponent } from './time-sheet/time-sheet.component';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatMenuModule } from '@angular/material/menu';
import { AccountPageComponent } from './account-page/account-page.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatSelectModule } from '@angular/material/select';
import { SchedulerModule } from '@progress/kendo-angular-scheduler';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';


class ElmahIoErrorHandler implements ErrorHandler {
    logger: any;
    constructor() {
        this.logger = new Elmahio({
            apiKey: '87a03e9e26a74d6fa983f9de3a9c8776',
            logId: 'bd8c1453-5792-461b-8021-5bcc8eb338df',
        });
    }
    handleError(error: { message: any; }) {
        if (error && error.message) {
            this.logger.error(error.message, error);
        } else {
            this.logger.error('Error in application', error);
        }
    }
}

@NgModule({
    declarations: [
        AppComponent,
        LoginPageComponent,
        HomePageComponent,
        MbHomePageComponent,
        NavHomeComponent,
        TimeSheetComponent,
        AccountPageComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        HttpClientModule,
        RouterModule.forRoot([
            { path: '', component: LoginPageComponent, pathMatch: 'full' },
            { path: 'home', component: HomePageComponent },
            { path: 'mbhome', component: MbHomePageComponent },
            { path: 'account', component: AccountPageComponent },
            { path: 'timesheet', component: TimeSheetComponent },
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
        MatNativeDateModule
    ],
    providers: [{ provide: ErrorHandler, useClass: ElmahIoErrorHandler }],
    bootstrap: [AppComponent]
})
export class AppModule { }
