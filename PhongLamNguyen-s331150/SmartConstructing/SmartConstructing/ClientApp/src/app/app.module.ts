import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { IndexComponent } from './index/index.component';
import { TimeSheetComponent } from './timesheet/timesheet.component';
import { MbIndexComponent } from './mbindex/mbindex.component';

import { AgmCoreModule } from '@agm/core';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    IndexComponent,
    TimeSheetComponent,
    MbIndexComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'index', component: IndexComponent },
      { path: 'timesheet', component: TimeSheetComponent },
      { path: 'mbindex', component: MbIndexComponent },
    ]),
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyAkNi7U2_6ZqRDlun0DcHcXI6yiJg8oVrg'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
