import { HttpClient } from '@angular/common/http';
import { Component, OnInit , Injectable } from '@angular/core';
import {FormBuilder , FormGroup} from "@angular/forms";
import { Router } from '@angular/router';
import { Observable , Subscription   } from 'rxjs';


@Injectable({
  providedIn:'root'
})


@Component({
  selector: 'form-field-appearance-example',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})

export class LoginFormComponent implements OnInit {

  hide = true;  
  

  public loginForm!: FormGroup

  constructor( private formBuilder: FormBuilder , private http: HttpClient, private router : Router) { 

  }
  
  ngOnInit(): void {

    this.loginForm = this.formBuilder.group({

      username:[''],
      password:['']
    })

  }


  login(){


    this.http.get<any>("https://localhost:44330/api/Login?username="+this.loginForm.value.username+"&password="+this.loginForm.value.password).subscribe({
      next: (result: any) => {
      console.log(result);
      // const user = result.find((a:any)=> {
      //   console.log("valuesss", a.username);
      //   console.log("dadadadad",a.username === this.loginForm.value.username);
      //         return a.username.trim() === this.loginForm.value.username &&
      //          a.password.trim() === this.loginForm.value.password

      //       });
            console.log("user'values", result);
            if(result.length>0){
                    localStorage.setItem("token",this.loginForm.value.username );
                    alert("login successful");
                    this.loginForm.reset();
                    this.router.navigate(['dashboard'])
                  }
                  else{
                    // localStorage.clear();
                    alert("incorrect username or password");
                  }
      },
      error: (err: any) => {
      console.log(err);
      alert("something went wrong!!")
      },
      complete: () => {
      console.log('complete');
      }
      
      });


  }


}
