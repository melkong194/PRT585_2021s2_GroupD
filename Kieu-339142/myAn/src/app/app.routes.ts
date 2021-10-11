import { RouterModule, Routes } from '@angular/router';


export const appRoutes: Routes = [
    { path: '', redirectTo: 'login', pathMatch: 'full'},
    { path: 'login', loadChildren: () => import('./portal/portal.module').then(mod => mod.PortalModule) },
    { path: 'staff', loadChildren: () => import('./staff/staff.module').then(mod => mod.StaffModule) },
    { path: 'admin', loadChildren: () => import('./admin/admin.module').then(mod => mod.AdminModule) },
    { path: '**', redirectTo: 'login', pathMatch: 'full'},

];

// @NgModule({
//     imports: [RouterModule.forRoot(routes)],
//     exports: [RouterModule]
// })

