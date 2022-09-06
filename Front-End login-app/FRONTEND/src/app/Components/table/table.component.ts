import { Component, OnInit , Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {DashboardComponent} from '../dashboard/dashboard.component';

@Injectable({
  providedIn:'root'
})


@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  constructor(private dashboardComponent:DashboardComponent) { 
  }

  ngOnInit(): void {
  }




}
