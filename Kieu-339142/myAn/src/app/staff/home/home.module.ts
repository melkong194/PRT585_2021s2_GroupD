import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { Routes, RouterModule } from '@angular/router';
import { AgmCoreModule } from '@agm/core';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';

const routes: Routes = [
    // { path: '', redirectTo: 'home', pathMatch: 'full'},
    { path: '', component: HomeComponent },
]

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    AgmCoreModule,
    MatButtonModule,
    MatButtonToggleModule
  ],
  exports: [
      MatButtonModule,
      MatButtonToggleModule
  ]
})
export class HomeModule { }
