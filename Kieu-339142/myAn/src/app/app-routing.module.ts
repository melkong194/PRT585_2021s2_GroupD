import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [
    { path: '', redirectTo: 'login', pathMatch: 'full'},
    { path: 'login', loadChildren: './portal/.module#PortalModule'},
    { path: 'admin', loadChildren: './admin/.module#AdminModule'},
    { path: 'staff', loadChildren: './portal/.module#StaffModule'},
    { path: '**', redirectTo: 'login', pathMatch: 'full'},

];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
