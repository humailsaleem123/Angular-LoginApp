// import { Injectable } from "@angular/core";
// import { HttpClient } from '@angular/common/http';


// @Injectable({
//     providedIn:'root'
// })



// export class getData{

//     constructor(private http:HttpClient){

//     }
//     getuserData(){
//         // let apiUrl = "https://localhost:44330/api/Login";

//         this.http.get<any>("https://localhost:44330/api/Login").subscribe({
//             next: (result: any) => {
//            console.log(result);
//            result.find((a:any)=> {
//             console.log(a.username);
//           });
//             },
//             error: (err: any) => {
//                 console.log(err);
//                 alert("something went wrong!!")
//                 },
//         })
//         // return this.http.get<any>(apiUrl);

//     }

   
// }