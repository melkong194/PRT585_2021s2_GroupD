<<<<<<< HEAD
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { UserAPIService } from '../services/user-api.service';

import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';

=======
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { UserAPIService } from '../services/user-api.service';

>>>>>>> development/client_app

@Component({
    selector: 'app-mb-profile',
    templateUrl: './mb-profile.component.html',
    styleUrls: ['./mb-profile.component.css']
})
<<<<<<< HEAD
export class MbProfileComponent implements AfterViewInit  {
=======
export class MbProfileComponent implements OnInit {
>>>>>>> development/client_app
    private dataUser: any;
    users: any;

    constructor(private userData: UserAPIService) { }

    ngOnInit(): void {
        this.users = [];
        this.userData.GetAllUsers().subscribe((data) => {
            this.dataUser = Object(data)["result_set"];
            for (var _i = 0; _i < Object(data)["result_set"].length; _i++) {
                var temp = {
                    value: Object(data)["result_set"][_i].user_id,
                    viewValue: Object(data)["result_set"][_i].user_id + ": " + Object(data)["result_set"][_i].name
                }
                this.users.push(temp);
            }
        });

    }

<<<<<<< HEAD
    displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
    dataSource = new MatTableDataSource<PeriodicElement>(ELEMENT_DATA);
  
    @ViewChild(MatPaginator) paginator!: MatPaginator;
  
    ngAfterViewInit() {
        // console.log(this.paginator);
      this.dataSource.paginator = this.paginator;
    }

}



export interface PeriodicElement {
    name: string;
    position: number;
    weight: number;
    symbol: string;
  }
  
  const ELEMENT_DATA: PeriodicElement[] = [
    {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
    {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
    {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
    {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
    {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
    {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
    {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
    {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
    {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
    {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
    {position: 11, name: 'Sodium', weight: 22.9897, symbol: 'Na'},
    {position: 12, name: 'Magnesium', weight: 24.305, symbol: 'Mg'},
    {position: 13, name: 'Aluminum', weight: 26.9815, symbol: 'Al'},
    {position: 14, name: 'Silicon', weight: 28.0855, symbol: 'Si'},
    {position: 15, name: 'Phosphorus', weight: 30.9738, symbol: 'P'},
    {position: 16, name: 'Sulfur', weight: 32.065, symbol: 'S'},
    {position: 17, name: 'Chlorine', weight: 35.453, symbol: 'Cl'},
    {position: 18, name: 'Argon', weight: 39.948, symbol: 'Ar'},
    {position: 19, name: 'Potassium', weight: 39.0983, symbol: 'K'},
    {position: 20, name: 'Calcium', weight: 40.078, symbol: 'Ca'},
  ];
=======
}
>>>>>>> development/client_app
