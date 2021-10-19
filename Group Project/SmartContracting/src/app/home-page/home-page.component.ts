import { AfterViewInit, Component, ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { ActAPIService } from '../services/act-api.service';
import { UserAPIService } from '../services/user-api.service';

export interface UserData {
  name: string,
  role: string,
  status: string,
  hour: string,
  report: string
}

export interface ActData {
  act_id: number,
  date: string,
  desc: string,
  time: string,
  user_id: number,
  user_name: string
}

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements AfterViewInit  {

  displayedColumns: string[] = ['name', 'role', 'status', 'hours', 'report'];
  dataSource!: MatTableDataSource<UserData>;

  actColumns: string[] = ['time', 'arrow', 'desc']
  actSource!: MatTableDataSource<ActData>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private actAPI: ActAPIService,
    private userData: UserAPIService
  ) {

    this.actAPI.GetAllAct().subscribe((data) => {
      this.actSource = new MatTableDataSource(Object(data)["result_set"].reverse().slice(0,10));
    });

  }

  ngAfterViewInit() {

    this.userData.GetAllUsers().subscribe((data) => {
      this.dataSource = new MatTableDataSource(Object(data)["result_set"]);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
    
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

