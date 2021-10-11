import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { adminRoutes } from './admin.routes';
import { RouterModule } from '@angular/router';
import { HomeModule } from './home/home.module';
import { ProfileModule } from './profile/profile.module';
import { TeamModule } from './team/team.module';
import { AdminNavbarComponent } from '../shared/admin-navbar/admin-navbar.component';


@NgModule({
  declarations: [
    AdminComponent, 
    AdminNavbarComponent
  ],
  imports: [
    CommonModule,
    HomeModule,
    ProfileModule,
    TeamModule,
    RouterModule.forChild(adminRoutes),
    
  ],
})
export class AdminModule { }
