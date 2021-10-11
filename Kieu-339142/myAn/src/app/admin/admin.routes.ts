import { Routes } from '@angular/router';
import { AdminComponent } from './admin.component';


export const adminRoutes: Routes = [
    {
        path: '', component: AdminComponent, children: [
            // { path: '', redirectTo: 'home'},
            { path: 'home', loadChildren: () => import('./home/home.module').then(mod => mod.HomeModule) },
            { path: 'profile', loadChildren: () => import('./profile/profile.module').then(mod => mod.ProfileModule) },
            { path: 'team', loadChildren: () => import('./team/team.module').then(mod => mod.TeamModule) },
            { path: '**', redirectTo: 'home', pathMatch: 'full'},
        ]
    }

]