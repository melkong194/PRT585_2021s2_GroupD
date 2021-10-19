import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActAPIService } from '../services/act-api.service';

export interface ActData {
  act_id: number;
  user_name: string;
  user_id: number;
  desc: string;
  time: string;
  date: string;
}

@Component({
  selector: 'app-act-page',
  templateUrl: './act-page.component.html',
  styleUrls: ['./act-page.component.css']
})
export class ActPageComponent implements OnInit {

  displayedColumns: string[] = ['id', 'user', 'userID', 'desc', 'time', 'date'];
  dataSource!: MatTableDataSource<ActData>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private actData: ActAPIService) { }

  ngOnInit(): void {
    this.actData.GetAllAct().subscribe((data) => {
      this.dataSource = new MatTableDataSource(Object(data)["result_set"].reverse());
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

}
