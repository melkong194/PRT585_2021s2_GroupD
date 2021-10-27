import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';
import { Observable } from 'rxjs';
import {map, startWith} from 'rxjs/operators';
import { ActAPIService } from '../services/act-api.service';
import { UserAPIService } from '../services/user-api.service';

export interface UserData {
  user_id: number,
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

export interface User {
  name: string,
  id: number
}

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements AfterViewInit  {

  displayedColumns: string[] = ['name', 'user_id','role', 'status', 'hour', 'report'];
  dataSource!: MatTableDataSource<UserData>;

  actColumns: string[] = ['time', 'arrow', 'desc']
  actSource!: MatTableDataSource<ActData>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  user!: string;


  mapUsers: any[] = [];

  //Map autocomplete
  myControl = new FormControl();
  options: User[] = [];
  filteredOptions!: Observable<User[]>;

  locations: any[] = [];

  CurLat = -12.371611433792701;

  CurLng = 130.8687731560323;


  constructor(
    private actAPI: ActAPIService,
    private userData: UserAPIService,
    private router: Router,
    private route: ActivatedRoute
  ) {



  }

  ngAfterViewInit() {

    setInterval(() => {

      var tempMapUsers: any[] = [];
      var tempOptions: { name: any; id: any; }[] = [];

      this.userData.GetAllUsers().subscribe((data) => {
        this.dataSource = new MatTableDataSource(Object(data)["result_set"]);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;

        

        for(var _i = 0; _i < Object(data)["result_set"].length; _i++) {
          if(Object(data)["result_set"][_i].status == "working" || Object(data)["result_set"][_i].status == "breaking") {
            var temp = {
              image : "https://material.angular.io/assets/img/examples/shiba1.jpg",
              name : Object(data)["result_set"][_i].name,
              id: Object(data)["result_set"][_i].user_id
            }
            tempMapUsers.push(temp);

            var tempAuto = {
              name: Object(data)["result_set"][_i].name,
              id: Object(data)["result_set"][_i].user_id
            }
            tempOptions.push(tempAuto);
          }
        }

        

        if(JSON.stringify(this.mapUsers) != JSON.stringify(tempMapUsers)) {
          this.mapUsers = tempMapUsers;
        }

        if(JSON.stringify(this.options) != JSON.stringify(tempOptions)) {
          this.options = tempOptions;
        }


        //market data

        this.actAPI.GetAllAct().subscribe((data) => {
          this.actSource = new MatTableDataSource(Object(data)["result_set"].reverse().slice(0,12));
          
          if(this.mapUsers.length != 0) {
            var filterData = Object(data)["result_set"].filter((item: any) => {
              let date = new Date();
              return item['date'] == date.toDateString(), 
                item['desc'] == "Clock In"
            });
    
            var markerData: any[] = [];
  
            for(var _i = 0; _i < this.mapUsers.length; _i++) {
              for(var _j = 0; _j < filterData.length; _j++) {
                if(filterData[_j].user_id == this.mapUsers[_i].id && filterData[_j].user_name == this.mapUsers[_i].name) {
                  markerData.push(filterData[_j]);
                  break;
                }
              }
            }
            
            if(JSON.stringify(this.locations) !== JSON.stringify(markerData)) {
              this.locations = markerData;
            }

          } 
        });

      });

    }, 500);

    //Map autocomplete
    this.filteredOptions = this.myControl.valueChanges
    .pipe(
      startWith(''),
      map(value => typeof value === 'string' ? value : value.name),
      map(name => name ? this._filter(name) : this.options.slice())
    );

    this.route.queryParams.subscribe(params => {
      this.user = params.user;
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  navProfile(user_id: number, name: string) {
    let navigationExtras: NavigationExtras = {
      queryParams: {
          "user": this.user,
          "user_id": user_id,
          "name": name
      }
    };

    this.router.navigate(['/userProfile'], navigationExtras);
  }

  displayFn(user: User): string {
    return user && user.name ? user.name : '';
  }

  private _filter(name: string): User[] {
    const filterValue = name.toLowerCase();

    return this.options.filter(option => option.name.toLowerCase().includes(filterValue));
  }


  mapSearch(id: number, name: string) {
    var temp = this.locations.filter(item => {
      return item.user_id == id,
        item.user_name == name
    });

    this.CurLat = Number(temp[0].lat);
    this.CurLng = Number(temp[0].lng);
  }
}

