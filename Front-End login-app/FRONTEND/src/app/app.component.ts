import { Component } from '@angular/core';
// import { getData } from './getData';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'login-app';

  // constructor(private getData : getData){
  //   this.getData.getuserData();
  // }


//   constructor(private getData: getData){
//    this.getData.getuserData().subscribe({
//     next: (result: any) => {
//    console.log(result);
//    result.find((a:any)=> {
//     console.log(a.username);
//   });
//     },
//     error: (err: any) => {
//         console.log(err);
//         alert("something went wrong!!")
//         },
// })
   
//   }

}


