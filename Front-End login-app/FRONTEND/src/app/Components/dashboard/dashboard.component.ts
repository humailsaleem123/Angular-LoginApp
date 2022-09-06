import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {


  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    
  }

  userData:any = [];

  getData(){

    this.http.post<any>("https://localhost:44330/api/File?filepath=C%3A%5CUsers%5CAdeen%5CDownloads%5CinvoicecreditnoteupdateResults483.csv",  { title: 'Angular POST Request Example' })
    .subscribe({
      next: (result: any) => {
        console.log(result);
        this.userData = result;

      },
      error: (err: any) => {
        console.log(err);
        alert("something went wrong!!")
        },     
        
      complete: () => {
          console.log('complete');
          console.log("aaaaa", this.userData);
          }  


    })

  }

}
