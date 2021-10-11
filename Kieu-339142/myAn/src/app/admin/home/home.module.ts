import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { Routes, RouterModule } from '@angular/router';
import { AgmCoreModule } from '@agm/core';


const routes: Routes = [
    { path: '', component: HomeComponent },
]


@NgModule({
  declarations: [
    HomeComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    AgmCoreModule,
  ]
})
export class HomeModule { }
