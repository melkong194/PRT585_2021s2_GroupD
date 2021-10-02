import { AfterViewInit, Component, ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';

export interface UserData {
  name: string,
  role: string,
  status: string,
  totalHour: string,
  report: string
}

const FRUITS: string[] = [
  'blueberry', 'lychee', 'kiwi', 'mango', 'peach', 'lime', 'pomegranate', 'pineapple'
];
const NAMES: string[] = [
  'Maia', 'Asher', 'Olivia', 'Atticus', 'Amelia', 'Jack', 'Charlotte', 'Theodore', 'Isla', 'Oliver',
  'Isabella', 'Jasper', 'Cora', 'Levi', 'Violet', 'Arthur', 'Mia', 'Thomas', 'Elizabeth'
];

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements AfterViewInit  {

  displayedColumns: string[] = ['name', 'role', 'status', 'hours', 'report'];
  dataSource: MatTableDataSource<UserData>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor() {
    // Create 100 users
    const users = [
      {
        name: "employee 1",
        role: "12",
        status: "aa",
        totalHour: "10",
        report: ""
      },
      {
        name: "a",
        role: "12",
        status: "aa",
        totalHour: "10",
        report: ""
      },
      {
        name: "a",
        role: "12",
        status: "aa",
        totalHour: "10",
        report: ""
      }
    ];

    // Assign the data to the data source for the table to render
    this.dataSource = new MatTableDataSource(users);
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


  locations = [
    { lat: -12.371611433792701, lng: 130.8687731560323 },
    { lat: -12.381611433792701, lng: 130.8687731560323 },
    { lat: -12.371611433792701, lng: 130.8787731560323 },
  ];
  
  icon = {
    url: 'https://toppng.com/uploads/preview/app-icon-set-login-icon-comments-avatar-icon-11553436380yill0nchdm.png',
    scaledSize: {
      width: 30,
      height: 30
    }
  }

  
}

