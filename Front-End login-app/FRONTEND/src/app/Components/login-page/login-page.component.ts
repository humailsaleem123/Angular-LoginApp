import { Component, OnInit , ViewEncapsulation ,  ViewChild  } from '@angular/core';
import { IgxNavigationDrawerComponent } from 'igniteui-angular';

// @Component({
//   selector: 'app-login-page',
//   templateUrl: './login-page.component.html',
//   styleUrls: ['./login-page.component.css']
// })

@Component({
  encapsulation: ViewEncapsulation.None,
  selector: 'toolbar-basic-example',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css'],
})
// LoginPageComponent

export class LoginPageComponent implements OnInit {
  
  loggedInUser : string;
  
  constructor() { }

  ngOnInit(): void {
  }


loggedIn(){

this.loggedInUser = localStorage.getItem('token')!;
return this.loggedInUser;

}
loggedOut(){
  
  localStorage.removeItem('token');
 
}

@ViewChild(IgxNavigationDrawerComponent, { static: true })
public drawer: IgxNavigationDrawerComponent;


public navItems = [
  { name: 'account_circle', text: 'Avatar' },
  { name: 'error', text: 'Badge' },
  { name: 'group_work', text: 'Button Group' }
];

public selected = 'Avatar';

public navigate(item: { text: string; }) {
    this.selected = item.text;
    this.drawer.close();
}


}

// export class LoginPageComponent  {
//   @ViewChild(IgxNavigationDrawerComponent, { static: true })
//   public drawer: IgxNavigationDrawerComponent;

//   public navItems = [
//       { name: 'account_circle', text: 'Avatar' },
//       { name: 'error', text: 'Badge' },
//       { name: 'group_work', text: 'Button Group' }
//   ];

//   public selected = 'Avatar';

//   public navigate(item: { text: string; }) {
//       this.selected = item.text;
//       this.drawer.close();
//   }
// }

