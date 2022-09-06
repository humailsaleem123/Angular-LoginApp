import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { LoginFormComponent } from './Components/login-form/login-form.component';
import { LoginPageComponent } from './Components/login-page/login-page.component';
import { RegisterFormComponent } from './Components/register-form/register-form.component';

// const routes: Routes = [];

const routes: Routes = [
  {
    path:'',
    component:LoginFormComponent,

    children:[  
      {
        path:'login',
        redirectTo:'',
        pathMatch:'full'
      },
    //   {
    //     path:'register',
    //     component:RegisterFormComponent,
    //   }

    ]
  },
  // {
  //   path:'login',
  //   component:LoginFormComponent,
  // },
  {
    path:'register',
    component:RegisterFormComponent,

  },
  {
    path:'dashboard',
    component:LoginPageComponent,

  },
  {
    path:'**',
    redirectTo:'',
    pathMatch:'full'
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponenets = [  LoginPageComponent , LoginFormComponent , RegisterFormComponent]
