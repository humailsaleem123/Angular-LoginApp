import { NgModule } from '@angular/core';
import { BrowserModule, HammerModule,
 HammerGestureConfig, HAMMER_GESTURE_CONFIG } from '@angular/platform-browser';
 import * as Hammer from 'hammerjs';
import { AppRoutingModule , routingComponenets} from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { LoginPageComponent } from './Components/login-page/login-page.component';
import { IgxNavbarModule } from 'igniteui-angular';
import { IgxInputGroupModule } from "igniteui-angular";
import { 
	IgxButtonModule,
	IgxIconModule,
	IgxNavigationDrawerModule,
	IgxRippleModule,
  IgxCardModule,
	IgxToggleModule
 } from "igniteui-angular";
import { CardComponent } from './Components/card/card.component';
import { TableComponent } from './Components/table/table.component';


 export class HammerConfig extends HammerGestureConfig {
  override = {
    swipe: { direction: Hammer.DIRECTION_ALL },
  };
}

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    routingComponenets,
    CardComponent,
    TableComponent,
  ],
  imports: [
    BrowserModule,
    HammerModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    IgxButtonModule,
    IgxIconModule,
    IgxNavigationDrawerModule,
    IgxRippleModule,
    IgxNavbarModule,
    IgxToggleModule,
    IgxCardModule,
    IgxInputGroupModule
  ],
  providers: [{
    provide: HAMMER_GESTURE_CONFIG,
    useClass: HammerConfig
  }],
  entryComponents: [],
  schemas: [],
  bootstrap: [AppComponent]
})



export class AppModule { }
