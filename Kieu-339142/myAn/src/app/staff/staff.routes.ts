import { Routes } from '@angular/router';
import { StaffComponent } from './staff.component';

export const staffRoutes: Routes = [
    {
        path: '', component: StaffComponent, children: [
            // { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', loadChildren: () => import('./home/home.module').then(mod => mod.HomeModule) },
            { path: 'profile', loadChildren: () => import('./profile/profile.module').then(mod => mod.ProfileModule) },
            { path: 'record', loadChildren: () => import('./record/record.module').then(mod => mod.RecordModule) },
            { path: 'schedule', loadChildren: () => import('./time-sheet/time-sheet.module').then(mod => mod.TimeSheetModule) },
            { path: '**', redirectTo: 'home', pathMatch: 'full'},
        ]
    }

]