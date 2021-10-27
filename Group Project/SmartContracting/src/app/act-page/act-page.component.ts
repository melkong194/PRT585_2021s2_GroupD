import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
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
  lat: string;
  lng: string;
}

@Component({
  selector: 'app-act-page',
  templateUrl: './act-page.component.html',
  styleUrls: ['./act-page.component.css']
})
export class ActPageComponent implements OnInit {

  displayedColumns: string[] = ['act_id', 'user_name', 'user_id', 'desc', 'time', 'date', 'location'];
  dataSource!: MatTableDataSource<ActData>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private actData: ActAPIService,
    public dialog: MatDialog) { }

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

  openLoc(lat: string, lng: string) {
    const dialogRef = this.dialog.open(DialogMap, {
      width: '50%',
      height: '70%',
      data: {
        lat: Number(lat),
        lng: Number(lng)
      }
    })
  }

}

export interface DialogData {
  lat: number;
  lng: number;
}

@Component({
  selector: 'dialog-map',
  template: `
  <agm-map [latitude]="data.lat" [longitude]="data.lng" [zoom]="17" [disableDefaultUI]="true">
    <agm-marker [latitude]="data.lat" [longitude]="data.lng"></agm-marker>
  </agm-map>
  `,
  styles: [`
    agm-map {
      height: 100%;
    }
  `]
})
export class DialogMap {
  constructor(
    public dialogRef: MatDialogRef<DialogMap>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}
  onNoClick(): void {
    this.dialogRef.close();
  }
}