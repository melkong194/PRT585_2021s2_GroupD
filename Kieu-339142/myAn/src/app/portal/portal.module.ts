import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PortalComponent } from './portal.component';
import { Routes, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { FormsModule }   from '@angular/forms';

export const routes: Routes = [
    { path: '', component: PortalComponent },

];

@NgModule({
    declarations: [
        PortalComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        MatButtonModule,
        MatButtonToggleModule,
        FormsModule
    ],
    exports: [
        MatButtonModule,
        MatButtonToggleModule
    ]
})
export class PortalModule { }
